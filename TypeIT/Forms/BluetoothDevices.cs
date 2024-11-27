using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Management; 
using System.IO;

using TypeIT.Models;

namespace TypeIT
{
    public partial class BluetoothDevices : Form
    {

        private List<bluetoothDevice> BTDevices = new List<bluetoothDevice>();
        private SerialCommunicationModel serialComm = new SerialCommunicationModel();

        public BluetoothDevices()
        {
            InitializeComponent();
        }

        private async void BluetoothDevices_Load(object sender, EventArgs e)
        {
            Align.centerControlHorizontal(title);
            BTDevices = await GetBluetoothInfoAsync();
            PopulateBluetoothDevicesLayoutPanel(BTDevices);
        }

        //******************** Listing Bluetooth Devices List w/ Ports: START *********************************//
        private void PopulateBluetoothDevicesLayoutPanel(List<bluetoothDevice> BTDevices)
        {
            bluetoothDevicesLayoutPanel.Controls.Clear(); //Clear the bluetoothDevicesPanel to get a new one (UI)
                                                          //RefreshButton.IsEnabled = false; //Uncomment if a Refresh Button exist in BluetoothDevices.Designer.cs
                                                          //RefreshIcon.Visibility = Visibility.Visible; //Uncomment If RefreshIcon exist in BluetoothDevices.Designer.cs

            int TotalPorts = BTDevices.Count;
            Debug.WriteLine($"Total number of bluetooth devices found: {TotalPorts}");

            foreach (bluetoothDevice BTDevice in BTDevices)
            {
                bluetoothDevicesLayoutPanel.Controls.Add(BTDevice);  // Update the list on the UI thread
            }

            //Uncomment the following if RefreshButton, Refresh Icon, Spinner is added on the UI
            //RefreshButton.IsEnabled = true;
            //Spinner.Spin = false;
            //RefreshIcon.Spin = false;
            //RefreshIcon.Visibility = Visibility.Collapsed;
        }

        public static async Task<List<bluetoothDevice>> GetBluetoothInfoAsync()
        {
            var btDevices = new List<bluetoothDevice>();

            await Task.Run(() =>
            {
                ManagementObjectCollection bluetooth =
                    new ManagementObjectSearcher(@"SELECT PNPDeviceID, Name, HardwareID FROM Win32_PnPEntity WHERE PNPClass = 'Bluetooth' AND PNPDeviceID LIKE '%BTHENUM\\DEV%'").Get();

                ManagementObjectCollection ports =
                    new ManagementObjectSearcher(@"SELECT PNPClass, PNPDeviceID, Name, HardwareID FROM Win32_PnPEntity WHERE Name LIKE '%COM%' AND PNPDeviceID LIKE '%BTHENUM%' AND PNPClass = 'Ports'").Get();

                foreach (ManagementObject BluetoothDev in bluetooth)
                {
                    foreach (ManagementObject PortDev in ports)
                    {
                        // Looking for Outgoing Connection from Bluetooth Device
                        string Bluetooth_Address = ExtractBluetoothDev(BluetoothDev["PNPDeviceID"].ToString());
                        if (Bluetooth_Address == ExtractDevice(PortDev["PNPDeviceID"].ToString()))
                        {
                            string BluetoothDevName = BluetoothDev["Name"].ToString();
                            string PortName = ExtractCOMPortFromName(PortDev["Name"].ToString());

                            try
                            {
                                btDevices.Add(new bluetoothDevice(BluetoothDevName, PortName, Bluetooth_Address));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error creating a bluetoothDevice object:\n {ex.Message}");
                            }
                        }
                    }
                }
            });

            return btDevices;
        }


        ////******************** Listing Bluetooth Devices List w/ Ports: END *********************************/

        //************* Bluetooth and Ports Identification Functions: START **************************//

        private static string ExtractBluetoothDev(string pnpDeviceID)
        {
            int startPos = pnpDeviceID.LastIndexOf('_') + 1;
            return pnpDeviceID.Substring(startPos);
        }

        private static string ExtractDevice(string pnpDeviceID)
        {
            int startPos = pnpDeviceID.LastIndexOf('&') + 1;
            int length = pnpDeviceID.LastIndexOf('_') - startPos;
            return pnpDeviceID.Substring(startPos, length);
        }

        private static string ExtractCOMPortFromName(string name)
        {
            int openBracket = name.IndexOf('(');
            int closeBracket = name.IndexOf(')');
            return name.Substring(openBracket + 1, closeBracket - openBracket - 1);
        }


        //************* Bluetooth and Ports Identification Functions: END **************************/


        //************* Bluetooth Devices Refresher: START ***********************************//

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            //Uncomment the following if RefreshButton, Refresh Icon, Spinner is added on the UI
            //Spinner.Spin = true;
            //RefreshIcon.Spin = true;

            BTDevices = await GetBluetoothInfoAsync();
            PopulateBluetoothDevicesLayoutPanel(BTDevices);
        }

        private void RefreshButton_MouseEnter(object sender, EventArgs e)
        {
            //Uncomment the following if RefreshButton, Refresh Icon, Spinner is added on the UI
            //RefreshIcon.Visibility = Visibility.Visible;
        }

        private void RefreshButton_MouseLeave(object sender, EventArgs e)
        {
            //Uncomment the following if RefreshButton, Refresh Icon, Spinner is added on the UI
            //if (RefreshButton.IsEnabled)
            //{
            //    RefreshIcon.Visibility = Visibility.Collapsed;
            //}
        }

        //************* Bluetooth Devices Refresher: END ***********************/


    }
}
