using System;
using System.Collections.Generic;
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
        public event EventHandler<string> DataReceived;

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
            if (_serialPort.BytesToRead > 0)
            {
                byte[] buffer = new byte[_serialPort.BytesToRead];
                _serialPort.Read(buffer, 0, buffer.Length);
                string receivedData = Encoding.ASCII.GetString(buffer);
                DataReceived?.Invoke(this, receivedData);
            }
        }
    }
}
