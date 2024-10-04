using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using TypeIT.Models;


namespace TypeIT
{
    public partial class bluetoothDevice : UserControl
    {
        //Fields
        public string BluetoothName { get; set; }
        public string ComPortName { get; set; }
        public string Address { get; set; }
        private SerialCommunicationModel serialComm = new SerialCommunicationModel();


        //Constructor
        public bluetoothDevice(string BTName, string CPName, string address)
        {
            InitializeComponent();
            this.BluetoothName = BTName;
            this.ComPortName = CPName;
            this.Address = address;
            this.name.Text = BTName; //name of the blueotooth device from the UI
        }

        internal async Task<bool> bluetoothAutoConnect()
        {   
            //This function is for the HomePage trying to create default/auto connection with Type It Wireless Keyboard
            bool isConnected = await Task.Run(() => serialComm.Connect(ComPortName, BluetoothName));
            if (isConnected)
            {
                //ConnectionStatus.Text = "Connected"; // Uncomment when a label is created on the UI stating the connection status of the bluetooth device
                serialComm.DataReceived += SerialComm_DataReceived;
                MessageBox.Show($"Successfully connected to {BluetoothName}.\nCOM Port Address: {ComPortName}.",
                                "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //No need to add else clause for showing failed connection it will be handled by the serialComm.Connect() method

            return isConnected;
        }

        private async void bluetoothConnectButton_Click(object sender, EventArgs e)
        {
            // Attempt to connect using the serialComm object
            // Do await the task since it will allow the task if the serial communication between the device is successfully established.
            bool isConnected = await Task.Run(() => serialComm.Connect(ComPortName, BluetoothName));
            if (isConnected)
            {
                //ConnectionStatus.Text = "Connected"; // Uncomment when a label is created on the UI stating the connection status of the bluetooth device
                serialComm.DataReceived += SerialComm_DataReceived;
                MessageBox.Show($"Successfully connected to {BluetoothName}.\nCOM Port Address: {ComPortName}.",
                                "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //No need to add else clause for showing failed connection it will be handled by the serialComm.Connect() method
        }

        private void SerialComm_DataReceived(object sender, string receivedData)
        {
            // This method will be called when data is received
            // You can process the ASCII codes here
            this.Invoke(() =>
            {
                // For demonstration, we'll just show the received data in a message box
                // In a real application, you might want to update a TextBox or other UI element
                Debug.WriteLine($"Received ASCII: {receivedData}");
                if (receivedData.Contains("A")) // For example, if the received data contains the letter 'A'
                {
                    SendKeys.SendWait("A"); // Sends the 'A' keystroke to the active window
                }
            });
        }
    }
}
