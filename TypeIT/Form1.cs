
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
    }
}
