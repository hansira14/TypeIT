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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            top = new Panel();
            profile = new PictureBox();
            menu = new PictureBox();
            title = new Label();
            bluetoothDevicesPanel = new Guna.UI2.WinForms.Guna2Panel();
            bluetoothDevicesLayoutPanel = new FlowLayoutPanel();
            RefreshButton = new Guna.UI2.WinForms.Guna2Button();
            top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menu).BeginInit();
            bluetoothDevicesPanel.SuspendLayout();
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
            // bluetoothDevicesPanel
            // 
            bluetoothDevicesPanel.AutoSize = true;
            bluetoothDevicesPanel.BorderColor = Color.FromArgb(106, 106, 106);
            bluetoothDevicesPanel.BorderRadius = 8;
            bluetoothDevicesPanel.BorderThickness = 2;
            bluetoothDevicesPanel.Controls.Add(bluetoothDevicesLayoutPanel);
            bluetoothDevicesPanel.CustomizableEdges = customizableEdges1;
            bluetoothDevicesPanel.FillColor = Color.FromArgb(17, 17, 17);
            bluetoothDevicesPanel.Location = new Point(380, 242);
            bluetoothDevicesPanel.Margin = new Padding(2);
            bluetoothDevicesPanel.MinimumSize = new Size(340, 48);
            bluetoothDevicesPanel.Name = "bluetoothDevicesPanel";
            bluetoothDevicesPanel.Padding = new Padding(14);
            bluetoothDevicesPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            bluetoothDevicesPanel.Size = new Size(547, 241);
            bluetoothDevicesPanel.TabIndex = 3;
            // 
            // bluetoothDevicesLayoutPanel
            // 
            bluetoothDevicesLayoutPanel.AutoScroll = true;
            bluetoothDevicesLayoutPanel.BackColor = Color.Transparent;
            bluetoothDevicesLayoutPanel.Dock = DockStyle.Fill;
            bluetoothDevicesLayoutPanel.FlowDirection = FlowDirection.TopDown;
            bluetoothDevicesLayoutPanel.Location = new Point(14, 14);
            bluetoothDevicesLayoutPanel.Name = "bluetoothDevicesLayoutPanel";
            bluetoothDevicesLayoutPanel.Size = new Size(519, 213);
            bluetoothDevicesLayoutPanel.TabIndex = 0;
            bluetoothDevicesLayoutPanel.WrapContents = false;
            // 
            // RefreshButton
            // 
            RefreshButton.BorderRadius = 5;
            RefreshButton.CustomizableEdges = customizableEdges3;
            RefreshButton.DisabledState.BorderColor = Color.DarkGray;
            RefreshButton.DisabledState.CustomBorderColor = Color.DarkGray;
            RefreshButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            RefreshButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            RefreshButton.FillColor = Color.DimGray;
            RefreshButton.Font = new Font("Segoe UI", 9F);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(788, 502);
            RefreshButton.Margin = new Padding(2);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            RefreshButton.Size = new Size(101, 34);
            RefreshButton.TabIndex = 4;
            RefreshButton.Text = "Refresh";
            RefreshButton.Click += RefreshButton_Click;
            RefreshButton.MouseEnter += RefreshButton_MouseEnter;
            RefreshButton.MouseLeave += RefreshButton_MouseLeave;
            // 
            // BluetoothDevices
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ClientSize = new Size(1328, 782);
            Controls.Add(RefreshButton);
            Controls.Add(bluetoothDevicesPanel);
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
            bluetoothDevicesPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel top;
        private PictureBox profile;
        private PictureBox menu;
        private Label title;
        private Guna.UI2.WinForms.Guna2Panel bluetoothDevicesPanel;
        private FlowLayoutPanel bluetoothDevicesLayoutPanel;
        private bluetoothDevice bluetoothDevice1;
        private bluetoothDevice bluetoothDevice3;
        private Guna.UI2.WinForms.Guna2Button RefreshButton;
    }
}