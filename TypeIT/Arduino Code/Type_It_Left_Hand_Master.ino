#include <SoftwareSerial.h>

// Define pins for buttons
const int buttonPins[5] = {3, 4, 5, 6, 7};

// Variables to store button states
int buttonStates[5];
int prevButtonStates[5];

// SoftwareSerial for communication with the right-hand device
SoftwareSerial BTSerialRight(8, 9); // RX, TX

// SoftwareSerial for communication with PC/laptop
SoftwareSerial BTSerialPC(10, 11); // RX, TX

// Variables to store right-hand data
char rightHandData[5] = {'0', '0', '0', '0', '0'};

void setup() {
  // Initialize Serial Monitor for debugging (optional)
  Serial.begin(9600);

  // Initialize SoftwareSerial ports
  BTSerialRight.begin(9600); // Ensure this matches the HC-05's baud rate
  BTSerialPC.begin(9600);    // Baud rate for communication with PC

  // Set BTSerialRight as the active listener
  BTSerialRight.listen();

  // Initialize button pins with INPUT_PULLUP
  for (int i = 0; i < 5; i++) {
    pinMode(buttonPins[i], INPUT_PULLUP);
    buttonStates[i] = digitalRead(buttonPins[i]);
    prevButtonStates[i] = buttonStates[i];
  }

  Serial.println("Left-hand device initialized.");
}

void loop() {
  // Read current button states
  for (int i = 0; i < 5; i++) {
    buttonStates[i] = digitalRead(buttonPins[i]);
  }

  // Check if own button states have changed
  bool stateChanged = false;
  for (int i = 0; i < 5; i++) {
    if (buttonStates[i] != prevButtonStates[i]) {
      stateChanged = true;
      break;
    }
  }

  // Read data from right-hand device
  bool rightHandDataReceived = false;
  BTSerialRight.listen(); // Ensure BTSerialRight is the active listener

  // Check if there are at least 7 bytes available
  while (BTSerialRight.available() >= 7) {
    // Read data packet from right-hand device
    char dataFromRight[7]; // Expected data packet size is 7
    int index = 0;
    while (index < 7) {
      dataFromRight[index] = BTSerialRight.read();
      index++;
    }

    if (dataFromRight[0] == 'S' && dataFromRight[6] == 'E') {
      // Valid data packet received
      // Update rightHandData
      for (int i = 0; i < 5; i++) {
        rightHandData[i] = dataFromRight[i + 1]; // Positions 1 to 5
      }
      rightHandDataReceived = true;

      // Optional: For debugging, print received data
      Serial.print("Received data from right-hand: ");
      for (int i = 0; i < 7; i++) {
        Serial.print(dataFromRight[i]);
      }
      Serial.println();
    } else {
      // Invalid data packet received
      Serial.println("Invalid data packet from right-hand device.");
    }
  }

  // If state changed or right-hand data received, send combined data
  if (stateChanged || rightHandDataReceived) {
    sendCombinedData();
  }

  // Update previous button states
  for (int i = 0; i < 5; i++) {
    prevButtonStates[i] = buttonStates[i];
  }

  // Small delay to debounce buttons
  delay(50);
}

void sendCombinedData() {
  // Create an array to hold the combined data
  char combinedData[12];

  // Start bit
  combinedData[0] = 'S'; // ASCII code 83

  // Left-hand button states
  for (int i = 0; i < 5; i++) {
    if (buttonStates[i] == LOW) {
      // Button is pressed (since using INPUT_PULLUP, LOW means pressed)
      combinedData[i + 1] = '1'; // ASCII code 49
    } else {
      combinedData[i + 1] = '0'; // ASCII code 48
    }
  }

  // Right-hand button states
  for (int i = 0; i < 5; i++) {
    combinedData[i + 6] = rightHandData[i];
  }

  // Stop bit
  combinedData[11] = 'E'; // ASCII code 69

  // Send the combined data via Bluetooth to PC
  for (int i = 0; i < 12; i++) {
    BTSerialPC.write(combinedData[i]);
    Serial.print(combinedData[i]); // Optional debugging
  }
  Serial.println(); // New line for readability
}