// Debug Macro Setup
#define DEBUG 1 // Set to 0 to disable debugging

#if DEBUG
  #define DEBUG_PRINT(...) Serial.print(__VA_ARGS__)
  #define DEBUG_PRINTLN(...) Serial.println(__VA_ARGS__)
#else
  #define DEBUG_PRINT(...)   // No operation
  #define DEBUG_PRINTLN(...) // No operation
#endif

#include <SoftwareSerial.h>

// Define register addresses for faster digital reads
#define BUTTON_PORT PORTD
#define BUTTON_DDR  DDRD
#define BUTTON_PIN  PIND
#define BUTTON_MASK 0b11111000  // Pins 3-7 mask

// Configuration constants
// const uint8_t SYNC_DELAY = 80;     // Synchronization delay in ms
// const uint8_t DEBOUNCE_DELAY = 5; // Debounce time in ms
const uint8_t SYNC_DELAY = 0;     // Synchronization delay in ms
const uint8_t DEBOUNCE_DELAY = 10; // Debounce time in ms
const uint8_t COMBINATION_WINDOW = 20;  // Window to combine keypresses in ms

// SoftwareSerial for communication
SoftwareSerial BTSerialRight(8, 9);   // RX, TX for right-hand device
SoftwareSerial BTSerialPC(10, 11);    // RX, TX for PC

// Variables for state tracking
uint8_t currentState = 0;  // Current left-hand button state
uint8_t prevState = 0;     // Previous left-hand button state
unsigned long lastDebounceTime = 0;  // Last debounce time
unsigned long lastSyncTime = 0;      // Last synchronization time
bool stateChanged = false;           // Flag for button state changes

char rightHandData[5] = {'0', '0', '0', '0', '0'}; // Data from the right-hand device
char lastSentData[12] = {0};         // Last sent data to avoid redundant sends
unsigned long lastDebugPrint = 0;    // Timer for periodic debug printing

// Packet processing variables
char incomingBuffer[7];
uint8_t bufferIndex = 0;
bool receivingPacket = false;
bool rightHandDataReceived = false;

void setup() {
  #if DEBUG
    Serial.begin(9600);
    while (!Serial) {
      ; // Wait for serial port to connect
    }
  #endif

  // Initialize SoftwareSerial ports
  BTSerialRight.begin(9600);
  BTSerialPC.begin(9600);
  
  // Set BTSerialRight to listen
  BTSerialRight.listen();

  // Configure pins 3-7 as inputs with pull-up
  BUTTON_DDR &= ~BUTTON_MASK;  // Set as inputs
  BUTTON_PORT |= BUTTON_MASK;  // Enable pull-up resistors

  DEBUG_PRINTLN(F("Left-hand device initialized."));
  DEBUG_PRINTLN(F("Bluetooth communication starting..."));
  DEBUG_PRINT(F("Button mask: "));
  DEBUG_PRINTLN(BUTTON_MASK, BIN);
}

void loop() {
  // Read raw button state
  uint8_t rawRead = BUTTON_PIN;

  // Mask pins 3-7 and shift to get 5-bit value
  uint8_t maskedState = (rawRead & BUTTON_MASK) >> 3;

  // Debounce logic
  unsigned long currentTime = millis();
  if (maskedState != prevState) {
    if (currentTime - lastDebounceTime > DEBOUNCE_DELAY) {
      lastDebounceTime = currentTime;
      currentState = maskedState;
      stateChanged = true;
    }
  }

  prevState = maskedState;

  // Process right-hand device data with a larger window
  while (BTSerialRight.available() > 0) {
    char inByte = BTSerialRight.read();
    processRightHandData(inByte);
  }

  // Send combined data if either state changed or received right hand data
  // Use a combination window to catch near-simultaneous presses
  static unsigned long lastStateChangeTime = 0;
  if (stateChanged) {
    lastStateChangeTime = currentTime;
  }

  if ((stateChanged || rightHandDataReceived) && 
      (currentTime - lastStateChangeTime <= COMBINATION_WINDOW)) {
    sendCombinedData();
    rightHandDataReceived = false;
    stateChanged = false;
  }
}

void processRightHandData(char incomingByte) {
  if (!receivingPacket && incomingByte == 'S') {
    bufferIndex = 0;
    incomingBuffer[bufferIndex++] = incomingByte;
    receivingPacket = true;
    return;
  }

  if (!receivingPacket) return;

  incomingBuffer[bufferIndex++] = incomingByte;

  if (bufferIndex == 7) {
    if (incomingBuffer[0] == 'S' && incomingBuffer[6] == 'E') {
      memcpy(rightHandData, &incomingBuffer[1], 5);
      rightHandDataReceived = true;
    }
    receivingPacket = false;
    bufferIndex = 0;
  }
}

void sendCombinedData() {
  char combinedData[12];
  combinedData[0] = 'S';

  // Convert port reading to individual button states for left hand
  for (uint8_t i = 0; i < 5; i++) {
    combinedData[i + 1] = ((currentState & (1 << i)) == 0) ? '1' : '0';
  }

  // Add right-hand data
  memcpy(&combinedData[6], rightHandData, 5);
  combinedData[11] = 'E';

  // Send only if data has changed
  if (memcmp(combinedData, lastSentData, 12) != 0) {
    BTSerialPC.write(combinedData, 12);
    memcpy(lastSentData, combinedData, 12);

    DEBUG_PRINT(F("Sent to PC: "));
    for (uint8_t i = 0; i < 12; i++) {
      DEBUG_PRINT(combinedData[i]);
    }
    DEBUG_PRINTLN();
  }
}
