
using System.Runtime.InteropServices;

namespace TypeIT
{
    public partial class Home : Form
    {
        private Form currentForm = null!;
        internal bool isConnected = false;
        public Home()
        {
            InitializeComponent();
        }
        private bool checkTypeITConnection()
        {
            //FUNCTION TO CHECK IF TYPEIT IS CONNECTED
            //DAPAT AUTOCONECT IF PAIRED NA
            //if false walay device makita
            return false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Responsive.AdjustWindowSizeForDPI(this);

            //check if autoconnect is successful
            device.Visible = checkTypeITConnection();
            notConnected.Visible = !checkTypeITConnection();
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
    }
}
