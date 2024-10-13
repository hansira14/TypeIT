
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TypeIT
{
    public partial class Home : Form
    {
        private Form currentForm = null!;
        internal bool isConnected = false;
        List<bluetoothDevice> BTDevices = new List<bluetoothDevice>();
        //courtney was here
        public Home()
        {
            InitializeComponent();
        }

        private async Task<bool> checkTypeITConnection()
        {
            //FUNCTION TO CHECK IF TYPEIT IS CONNECTED
            //DAPAT AUTOCONECT IF PAIRED NA
            bool typeITDeviceFound = false, successfulConnection = false; //flag for checking if typeItDevice is found, by default this is false

            BTDevices = await BluetoothDevices.GetBluetoothInfoAsync();

            Debug.WriteLine($"Total number of bluetooth devices found: {BTDevices.Count}");
            foreach (bluetoothDevice BTDevice in BTDevices) //find "Type IT Wireless Keyboard" from the bluetooth name
            {
                if (BTDevice.BluetoothName == "Type It Wireless Keyboard")
                {
                    try
                    {
                        successfulConnection = await BTDevice.bluetoothAutoConnect();
                        if (successfulConnection)
                        {
                            MessageBox.Show($"Successfully established default connection with \"Type It Wireless Keyboard\".",
                            "Default Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating a default connection to \"Type It Wireless Keyboard\".:\nError Message: {ex.Message}");
                    }
                    typeITDeviceFound = true; //found the device
                    break; //break for loop, already found the device
                }
            }

            if (!typeITDeviceFound || !successfulConnection) //If typeITDevice not found from the list of the bluetooth devices or connection is not successful even if the device is found
            {
                MessageBox.Show($"Failed to create default connection with \"Type It Wireless Keyboard\".\nEither your bluetooth is turned off or the devices isn't yet successfully paired.",
                "Default Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //if false walay device makita
            return typeITDeviceFound;
        }

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        private void openForm(Form newForm)
        {
            main.Controls.Clear();
            if (currentForm != null) currentForm.Close();
            currentForm = newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            main.Controls.Add(newForm);
            main.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //Responsive.AdjustWindowSizeForDPI(this);

            //check if autoconnect is successful
            bool autoconnect = await checkTypeITConnection();
            device.Visible = autoconnect;
            notConnected.Visible = !autoconnect;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int contentWidth = content.ClientSize.Width;
            int contentHeight = content.ClientSize.Height;
            int deviceWidth = device.Width;
            int deviceHeight = device.Height;
            int newDeviceX = (contentWidth - deviceWidth) / 2;
            int newDeviceY = (contentHeight - deviceHeight) / 2 - 50;
            device.Location = new Point(newDeviceX, newDeviceY);
        }

        private void notConnected_Click(object sender, EventArgs e)
        {
            openForm(new BluetoothDevices());
        }

        private void menu_Click(object sender, EventArgs e)
        {

        }

        private void profile_Click(object sender, EventArgs e)
        {
            openForm(new Customize());
        }
    }
}
