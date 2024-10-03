using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        //Constructor
        public bluetoothDevice(string BTName, string CPName, string address)
        {
            InitializeComponent();
            this.BluetoothName = BTName;
            this.ComPortName = CPName;
            this.Address = address;
            this.name.Text = BTName; //name of the blueotooth device from the UI
        }

        private void bluetoothConnectButton_Click(object sender, EventArgs e)
        {

        }
    }
}
