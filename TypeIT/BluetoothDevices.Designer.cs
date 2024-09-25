namespace TypeIT
{
    partial class BluetoothDevices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BluetoothDevices));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            top = new Panel();
            profile = new PictureBox();
            menu = new PictureBox();
            title = new Label();
            devicesList = new Guna.UI2.WinForms.Guna2Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            bluetoothDevice1 = new bluetoothDevice();
            bluetoothDevice3 = new bluetoothDevice();
            top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menu).BeginInit();
            devicesList.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // top
            // 
            top.Controls.Add(profile);
            top.Controls.Add(menu);
            top.Dock = DockStyle.Top;
            top.Location = new Point(0, 0);
            top.Margin = new Padding(2);
            top.Name = "top";
            top.Padding = new Padding(30);
            top.Size = new Size(1328, 108);
            top.TabIndex = 1;
            // 
            // profile
            // 
            profile.Dock = DockStyle.Right;
            profile.Image = (Image)resources.GetObject("profile.Image");
            profile.Location = new Point(1266, 30);
            profile.Margin = new Padding(2);
            profile.Name = "profile";
            profile.Padding = new Padding(15);
            profile.Size = new Size(32, 48);
            profile.SizeMode = PictureBoxSizeMode.Zoom;
            profile.TabIndex = 1;
            profile.TabStop = false;
            // 
            // menu
            // 
            menu.Dock = DockStyle.Left;
            menu.Image = (Image)resources.GetObject("menu.Image");
            menu.Location = new Point(30, 30);
            menu.Margin = new Padding(2);
            menu.Name = "menu";
            menu.Padding = new Padding(15);
            menu.Size = new Size(20, 48);
            menu.SizeMode = PictureBoxSizeMode.Zoom;
            menu.TabIndex = 0;
            menu.TabStop = false;
            // 
            // title
            // 
            title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.FromArgb(19, 150, 255);
            title.Location = new Point(503, 165);
            title.Name = "title";
            title.Size = new Size(316, 45);
            title.TabIndex = 2;
            title.Text = "Searching Devices...";
            title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // devicesList
            // 
            devicesList.AutoSize = true;
            devicesList.BorderColor = Color.FromArgb(106, 106, 106);
            devicesList.BorderRadius = 8;
            devicesList.BorderThickness = 2;
            devicesList.Controls.Add(flowLayoutPanel1);
            devicesList.CustomizableEdges = customizableEdges1;
            devicesList.FillColor = Color.FromArgb(17, 17, 17);
            devicesList.Location = new Point(380, 242);
            devicesList.Margin = new Padding(2);
            devicesList.MinimumSize = new Size(340, 48);
            devicesList.Name = "devicesList";
            devicesList.Padding = new Padding(14);
            devicesList.ShadowDecoration.CustomizableEdges = customizableEdges2;
            devicesList.Size = new Size(547, 241);
            devicesList.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(bluetoothDevice1);
            flowLayoutPanel1.Controls.Add(bluetoothDevice3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(14, 14);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(519, 213);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // bluetoothDevice1
            // 
            bluetoothDevice1.BackColor = Color.Transparent;
            bluetoothDevice1.ForeColor = Color.White;
            bluetoothDevice1.Location = new Point(3, 3);
            bluetoothDevice1.Name = "bluetoothDevice1";
            bluetoothDevice1.Size = new Size(518, 66);
            bluetoothDevice1.TabIndex = 0;
            // 
            // bluetoothDevice3
            // 
            bluetoothDevice3.BackColor = Color.Transparent;
            bluetoothDevice3.ForeColor = Color.White;
            bluetoothDevice3.Location = new Point(3, 75);
            bluetoothDevice3.Name = "bluetoothDevice3";
            bluetoothDevice3.Size = new Size(518, 66);
            bluetoothDevice3.TabIndex = 2;
            // 
            // BluetoothDevices
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ClientSize = new Size(1328, 782);
            Controls.Add(devicesList);
            Controls.Add(title);
            Controls.Add(top);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "BluetoothDevices";
            Text = "BluetoothDevices";
            Load += BluetoothDevices_Load;
            top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profile).EndInit();
            ((System.ComponentModel.ISupportInitialize)menu).EndInit();
            devicesList.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel top;
        private PictureBox profile;
        private PictureBox menu;
        private Label title;
        private Guna.UI2.WinForms.Guna2Panel devicesList;
        private FlowLayoutPanel flowLayoutPanel1;
        private bluetoothDevice bluetoothDevice1;
        private bluetoothDevice bluetoothDevice3;
    }
}