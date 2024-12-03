// Debug Macro Setup
#define DEBUG 1  // Set to 0 to disable debugging

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

// Add after BUTTON_MASK definition
const unsigned long SEND_INTERVAL = 5;  // 5ms interval between sends
const unsigned long DEBOUNCE_DELAY = 10; // 10ms debounce time

// Bluetooth communication
SoftwareSerial BTSerial(10, 11);  // RX, TX for HC-05

// Variables to store button states
uint8_t currentState = 0;
uint8_t prevState = 0;

void setup() {
  #if DEBUG
    Serial.begin(9600);
  #endif

  // Initialize SoftwareSerial for HC-05 communication
  BTSerial.begin(9600);

  // Configure pins 3-7 as inputs with pullup
  BUTTON_DDR &= ~BUTTON_MASK;  // Set as inputs
  BUTTON_PORT |= BUTTON_MASK;  // Enable pullup resistors

  DEBUG_PRINTLN(F("Right-hand device initialized."));
}

void loop() {
  // Read all button states at once using direct port reading
  uint8_t rawRead = BUTTON_PIN;
  uint8_t maskedState = (rawRead & BUTTON_MASK) >> 3;  // Shift to get clean 5-bit value

  static unsigned long lastDebounceTime = 0;
  static unsigned long lastSendTime = 0;
  unsigned long currentTime = millis();

  // Debounce logic
  if (maskedState != prevState) {
    lastDebounceTime = currentTime;
  }

  // If debounced state has changed or it's time to send periodic update
  if (((currentTime - lastDebounceTime) > DEBOUNCE_DELAY && maskedState != currentState) ||
      (currentTime - lastSendTime >= SEND_INTERVAL)) {
    
    currentState = maskedState;
    lastSendTime = currentTime;
    
    DEBUG_PRINT(F("Raw State: "));
    DEBUG_PRINTLN(maskedState, BIN);
    
    sendButtonStates();
  }

  prevState = maskedState;
}

void sendButtonStates() {
  char dataToSend[7];
  dataToSend[0] = 'S';  // Start bit

  // Convert port reading to individual button states
  // Since we're using pullup resistors, a 0 in the raw reading means button pressed
  for (uint8_t i = 0; i < 5; i++) {
    // Check if bit is 0 (pressed) in the currentState
    dataToSend[i + 1] = ((currentState & (1 << i)) == 0) ? '1' : '0';
  }

  dataToSend[6] = 'E';  // End bit

  // Send all bytes at once
  BTSerial.write(dataToSend, 7);
  
  // Debugging output
  #if DEBUG
    DEBUG_PRINT(F("Sent: "));
    for (uint8_t i = 0; i < 7; i++) {
      DEBUG_PRINT(dataToSend[i]);
    }
    DEBUG_PRINTLN();
  #endif
}
