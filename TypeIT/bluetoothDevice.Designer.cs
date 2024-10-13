namespace TypeIT
{
    partial class bluetoothDevice
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bluetoothDevice));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            menu = new PictureBox();
            name = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            bluetoothConnectButton = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)menu).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Dock = DockStyle.Left;
            menu.Image = (Image)resources.GetObject("menu.Image");
            menu.Location = new Point(12, 0);
            menu.Margin = new Padding(2);
            menu.Name = "menu";
            menu.Padding = new Padding(15, 15, 15, 15);
            menu.Size = new Size(26, 66);
            menu.SizeMode = PictureBoxSizeMode.Zoom;
            menu.TabIndex = 1;
            menu.TabStop = false;
            // 
            // name
            // 
            name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            name.AutoSize = true;
            name.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold);
            name.Location = new Point(66, 21);
            name.Name = "name";
            name.Size = new Size(116, 23);
            name.TabIndex = 2;
            name.Text = "TypeIT Device";
            // 
            // panel1
            // 
            panel1.Controls.Add(name);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(369, 66);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(bluetoothConnectButton);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(369, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(16, 16, 16, 16);
            panel2.Size = new Size(149, 66);
            panel2.TabIndex = 4;
            // 
            // bluetoothConnectButton
            // 
            bluetoothConnectButton.BorderColor = Color.Transparent;
            bluetoothConnectButton.BorderRadius = 6;
            bluetoothConnectButton.CustomizableEdges = customizableEdges1;
            bluetoothConnectButton.DisabledState.BorderColor = Color.DarkGray;
            bluetoothConnectButton.DisabledState.CustomBorderColor = Color.DarkGray;
            bluetoothConnectButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            bluetoothConnectButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            bluetoothConnectButton.Dock = DockStyle.Fill;
            bluetoothConnectButton.FillColor = Color.FromArgb(71, 71, 71);
            bluetoothConnectButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bluetoothConnectButton.ForeColor = Color.White;
            bluetoothConnectButton.Location = new Point(16, 16);
            bluetoothConnectButton.Name = "bluetoothConnectButton";
            bluetoothConnectButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            bluetoothConnectButton.Size = new Size(117, 34);
            bluetoothConnectButton.TabIndex = 0;
            bluetoothConnectButton.Text = "Connect";
            bluetoothConnectButton.Click += bluetoothConnectButton_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(menu);
            guna2Panel1.Controls.Add(panel3);
            guna2Panel1.Controls.Add(panel1);
            guna2Panel1.Controls.Add(panel2);
            guna2Panel1.CustomBorderColor = Color.White;
            guna2Panel1.CustomBorderThickness = new Padding(0, 0, 0, 1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(518, 66);
            guna2Panel1.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(12, 66);
            panel3.TabIndex = 5;
            // 
            // bluetoothDevice
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            ForeColor = Color.White;
            Name = "bluetoothDevice";
            Size = new Size(518, 66);
            ((System.ComponentModel.ISupportInitialize)menu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox menu;
        private Label name;
        private Panel panel1;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button bluetoothConnectButton;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Panel panel3;
    }
}
