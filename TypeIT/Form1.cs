
using System.Runtime.InteropServices;

namespace TypeIT
{
    public partial class Form1 : Form
    {
        private Form currentForm = null!;

        public Form1()
        {
            InitializeComponent();
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
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Get the width and height of the content panel
            int contentWidth = content.ClientSize.Width;
            int contentHeight = content.ClientSize.Height;

            // Get the width and height of the device control
            int deviceWidth = device.Width;
            int deviceHeight = device.Height;

            // Calculate the new position for the device control to center it
            int newDeviceX = (contentWidth - deviceWidth) / 2;
            int newDeviceY = (contentHeight - deviceHeight) / 2-50;

            // Set the new location of the device control
            device.Location = new Point(newDeviceX, newDeviceY);
        }
    }
}
