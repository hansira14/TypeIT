using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeIT.Models
{
    public class SerialCommunicationModel
    {
        private SerialPort _serialPort;
        private StringBuilder _dataBuffer = new StringBuilder(); // Buffer to store incomplete data

        public event Action<string> CombinationReceived;

        public bool Connect(string portName, string bluetoothName)
        {
            try
            {
                _serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                _serialPort.DataReceived += SerialPort_DataReceived;
                _serialPort.Open();

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Access to COM Port {portName} is denied. It might be in use by another application or you might not have the required permissions.",
                                "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"I/O error while connecting to {bluetoothName} on COM Port {portName}: {ioEx.Message}.Please check if the device is connected and try again.\n\nPlease go to your bluetooth devices settings then pair and connect with the device.",
                                "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TimeoutException)
            {
                MessageBox.Show($"Timeout while connecting to {bluetoothName} on COM Port {portName}. The device may not be responding. Please ensure the device is connected and try again.",
                                "Connection Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show($"The COM Port {portName} is already open or not valid. Ensure that no other application is using it and that the port name is correct.",
                                "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error while connecting to {bluetoothName} on COM Port {portName}: {ex.Message}.",
                                "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        byte[] buffer = new byte[_serialPort.BytesToRead];
                        _serialPort.Read(buffer, 0, buffer.Length);
                        string receivedData = Encoding.ASCII.GetString(buffer);

                        // Append the received data to the buffer
                        _dataBuffer.Append(receivedData);

                        ProcessBufferedData();
                    }
                }
                else
                {
                    // Handle the case when the serial port is closed
                    MessageBox.Show(
                        "The serial port is closed. Data cannot be received.",
                        "Serial Port Closed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (InvalidOperationException ex)
            {
                // Handle if the port is unexpectedly closed
                MessageBox.Show(
                    $"An error occurred while receiving data: {ex.Message}",
                    "Serial Port Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // General exception handling
                MessageBox.Show(
                    $"An unexpected error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void ProcessBufferedData()
        {
            string buffer = _dataBuffer.ToString();

            while (true)
            {
                // Find the start bit ('S')
                int startIndex = buffer.IndexOf('S');

                if (startIndex == -1)
                {
                    // No start bit found, clear the buffer and exit
                    _dataBuffer.Clear();
                    break;
                }

                // Find the end bit ('E') after the start bit
                int endIndex = buffer.IndexOf('E', startIndex + 1);

                if (endIndex != -1)
                {
                    // Extract the complete message
                    string completeMessage = buffer.Substring(startIndex, endIndex - startIndex + 1);

                    // Log or process the complete message
                    //Debug.WriteLine($"Complete Message: {completeMessage}");

                    // Remove the processed message from the buffer
                    buffer = buffer.Substring(endIndex + 1);

                    // The command code needed for handling the keystroke or macros to execute on the PC
                    HandleKeyStrokeOrMacro(completeMessage);
                }
                else
                {
                    // Check if another start bit appears before an end bit
                    int nextStartIndex = buffer.IndexOf('S', startIndex + 1);

                    if (nextStartIndex != -1)
                    {
                        // Discard the corrupted data up to the new start bit
                        Debug.WriteLine($"Corrupted data detected. Discarding: {buffer.Substring(0, nextStartIndex)}");
                        buffer = buffer.Substring(nextStartIndex);
                    }
                    else
                    {
                        // No end bit or new start bit found, keep the remaining buffer
                        break;
                    }
                }
            }

            // Update the buffer with remaining unprocessed data
            _dataBuffer.Clear();
            _dataBuffer.Append(buffer);
        }

        private void HandleKeyStrokeOrMacro(string keyCommand)
        {
            // Raise the combination received event
            CombinationReceived?.Invoke(keyCommand);

            // Rest of your existing code...
            Debug.WriteLine($"Key Command Code: {keyCommand}");
            if (Program.CurrentSelectedMappingProfile != null)
            {
                var currentProfile = Program.CurrentSelectedMappingProfile;
                if (currentProfile.CurrentMappingsSelected != null)
                {
                    // Ensure the keyCommand is not the unpressed command (e.g., "S0000000000E")
                    if (keyCommand != "S0000000000E")
                    {
                        // Check if the keyCommand matches any activation key in the profile's sets
                        if (currentProfile.Sets.TryGetValue(keyCommand, out var newMappingSet))
                        {
                            // Switch to the new mapping set
                            currentProfile.CurrentMappingsSelected = newMappingSet;
                            Debug.WriteLine($"Switched to new mapping set: {newMappingSet.ActivationKey}");
                        }
                        else
                        {
                            // Handle as a regular keystroke if it exists in the current mapping set
                            if (currentProfile.CurrentMappingsSelected.KeyMappings.TryGetValue(keyCommand, out var mappedValues))
                            {
                                var keysToSend = string.Join("", mappedValues); //Much faster for simple keystrokes let's say [
                                Debug.WriteLine($"Processing keystroke(s): {keysToSend}");
                                SendKeys.SendWait(keysToSend);

                                //If you need more customization, granularity, or special key checking/handling on some keys.
                                //foreach (var key in mappedValues)
                                //{
                                //    Debug.WriteLine($"Processing keystroke: {key}");
                                //    SendKeys.SendWait(key);
                                //}
                            }
                            else
                            {
                                Debug.WriteLine($"Key Command '{keyCommand}' not found in current mapping set.");
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.WriteLine("No Mapping Profile is currently selected.");
                MessageBox.Show(
                    $"A key command was captured from your Type It Keyboard, but no keystroke will be processed since no KeyMappingProfile was selected yet.",
                    "No Key Mapping Profile Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

    }
}
