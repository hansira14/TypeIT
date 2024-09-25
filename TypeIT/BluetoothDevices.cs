using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeIT
{
    public partial class BluetoothDevices : Form
    {
        public BluetoothDevices()
        {
            InitializeComponent();
        }

        private void BluetoothDevices_Load(object sender, EventArgs e)
        {
            Align.centerControlHorizontal(title);
        }
    }
}
