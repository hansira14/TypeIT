using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using TypeIT.Models;

namespace TypeIT
{
    public partial class Home : Form
    {
        private Form currentForm = null!;
        internal bool isConnected = false;
        List<bluetoothDevice> BTDevices = new List<bluetoothDevice>();
        public UC_ProfileList profileList;
        private static PictureBox _menuControl;
        public static PictureBox MenuControl => _menuControl;
        public Customize customizeForm;

        //courtney was here
        public Home()
        {
            InitializeComponent();
            _menuControl = menu;
            PopulateKeyMappingProfileComboBox();

            profileList = new UC_ProfileList(Program.CurrentSelectedMappingProfile, Program.KeyMappingProfiles, this);
            profileList.ProfileSelected += ProfileList_ProfileSelected;
            main.Controls.Add(profileList);
            profileList.Location = new Point(profile.Location.X - profileList.Width - 50, profile.Location.Y);
            profileList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            main.Controls.SetChildIndex(profileList, 0);
            content.Height = (int)(this.Height - (profileList.currentProf.Height * 1.5 + profileList.Location.Y));
        }

        private void PopulateKeyMappingProfileComboBox()
        {
            // First, preload the profiles (this is assuming that PreloadDefaultKeyMappingProfiles is called before this)
            // Populate the ComboBox with the names of the KeyMappingProfiles

            //KeyMappingProfileSelection.Items.Clear();  // Clear any existing items in the ComboBox

            foreach (var profile in Program.KeyMappingProfiles)
            {
                //KeyMappingProfileSelection.Items.Add(profile.Name); // Add the profile name to the ComboBox
            }

            // Optionally, you can set the selected profile if needed, for example:
            if (Program.CurrentSelectedMappingProfile != null)
            {
                //KeyMappingProfileSelection.SelectedItem = Program.CurrentSelectedMappingProfile.Name;
            }
            //else if (KeyMappingProfileSelection.Items.Count > 0)
            {
                // Set the first item as selected if no profile is set
                //KeyMappingProfileSelection.SelectedIndex = 0;
            }
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
                        MessageBox.Show($"Error creating a default connection to \"Type It Wireless Keyboard\".:\nError Message: {ex.Message}", "Default Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void openForm(Form newForm)
        {
            content.Controls.Clear();
            if (currentForm != null)
            {
                if (currentForm is Customize)
                {
                    currentForm.Hide();
                }
                else
                {
                    currentForm.Close();
                }
            }
            currentForm = newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            content.Controls.Add(newForm);
            content.Tag = newForm;
            newForm.Show();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
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

            if(profileList != null)
            {
                content.Height = (int)(this.Height - (profileList.currentProf.Height * 1.5 + profileList.Location.Y));
            }
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
            if (customizeForm == null || customizeForm.IsDisposed)
            {
                customizeForm = new Customize(this);
            }
            openForm(customizeForm);
        }

        private void ProfileList_ProfileSelected(object sender, KeyMappingProfile selectedProfile)
        {
            // Update the current selected profile
            Program.CurrentSelectedMappingProfile = selectedProfile;
            
            // If you need to refresh any UI elements that depend on the current profile
            if (currentForm is Customize customizeForm)
            {
                // Refresh the customize form if it's open
                customizeForm.PopulateSets();
            }
        }
    }
}
