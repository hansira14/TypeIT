#include <SoftwareSerial.h>

// Define pins for buttons
const int buttonPins[5] = {3, 4, 5, 6, 7};

// Variables to store button states
int buttonStates[5];
int prevButtonStates[5];

// SoftwareSerial pins for HC-05 Bluetooth module
SoftwareSerial BTSerial(10, 11); // TX, RX

void setup() {
  // Initialize Serial Monitor (optional for debugging)
  Serial.begin(9600);

  // Initialize SoftwareSerial for HC-05 communication
  BTSerial.begin(9600); // Ensure this matches the HC-05's baud rate

  // Initialize button pins with INPUT_PULLUP
  for (int i = 0; i < 5; i++) {
    pinMode(buttonPins[i], INPUT_PULLUP);
    buttonStates[i] = digitalRead(buttonPins[i]);
    prevButtonStates[i] = buttonStates[i];
  }

  Serial.println("Right-hand device initialized.");
}

void loop() {
  // Read current button states
  for (int i = 0; i < 5; i++) {
    buttonStates[i] = digitalRead(buttonPins[i]);
  }

  // Check if any button state has changed
  bool stateChanged = false;
  for (int i = 0; i < 5; i++) {
    if (buttonStates[i] != prevButtonStates[i]) {
      stateChanged = true;
      break;
    }
  }

  // If state has changed, send data
  if (stateChanged) {
    sendButtonStates();
    // Update previous states
    for (int i = 0; i < 5; i++) {
      prevButtonStates[i] = buttonStates[i];
    }
  }

  // Small delay to debounce buttons
  delay(50);
}

void sendButtonStates() {
  // Create an array to hold the ASCII codes
  char dataToSend[7];

  // Start bit
  dataToSend[0] = 'S'; // ASCII code 83

  // Button states
  for (int i = 0; i < 5; i++) {
    if (buttonStates[i] == LOW) {
      // Button is pressed (since using INPUT_PULLUP, LOW means pressed)
      dataToSend[i + 1] = '1'; // ASCII code 49
    } else {
      // Button is not pressed
      dataToSend[i + 1] = '0'; // ASCII code 48
    }
  }

  // Stop bit
  dataToSend[6] = 'E'; // ASCII code 69

  // Send the data via Bluetooth
  for (int i = 0; i < 7; i++) {
    BTSerial.write(dataToSend[i]);
    // Optional: For debugging, print to Serial Monitor
    Serial.print(dataToSend[i]);
  }
  Serial.println(); // New line for readability
}
