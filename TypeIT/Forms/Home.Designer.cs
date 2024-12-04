namespace TypeIT
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            main = new Panel();
            profile = new PictureBox();
            menu = new PictureBox();
            content = new Panel();
            device = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox4 = new PictureBox();
            notConnected = new PictureBox();
            main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menu).BeginInit();
            content.SuspendLayout();
            device.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)notConnected).BeginInit();
            SuspendLayout();
            // 
            // main
            // 
            main.BackColor = Color.Transparent;
            main.Controls.Add(profile);
            main.Controls.Add(menu);
            main.Controls.Add(content);
            main.Dock = DockStyle.Fill;
            main.ForeColor = Color.White;
            main.Location = new Point(0, 0);
            main.Margin = new Padding(2);
            main.Name = "main";
            main.Size = new Size(1370, 804);
            main.TabIndex = 0;
            // 
            // profile
            // 
            profile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profile.Image = (Image)resources.GetObject("profile.Image");
            profile.Location = new Point(1291, 32);
            profile.Margin = new Padding(2);
            profile.Name = "profile";
            profile.Padding = new Padding(15);
            profile.Size = new Size(32, 48);
            profile.SizeMode = PictureBoxSizeMode.Zoom;
            profile.TabIndex = 5;
            profile.TabStop = false;
            profile.Click += profile_Click;
            // 
            // menu
            // 
            menu.Image = (Image)resources.GetObject("menu.Image");
            menu.Location = new Point(43, 32);
            menu.Margin = new Padding(2);
            menu.Name = "menu";
            menu.Padding = new Padding(15);
            menu.Size = new Size(20, 48);
            menu.SizeMode = PictureBoxSizeMode.Zoom;
            menu.TabIndex = 6;
            menu.TabStop = false;
            menu.Click += menu_Click_1;
            // 
            // content
            // 
            content.Controls.Add(device);
            content.Controls.Add(notConnected);
            content.Dock = DockStyle.Bottom;
            content.Location = new Point(0, 160);
            content.Margin = new Padding(2);
            content.Name = "content";
            content.Size = new Size(1370, 644);
            content.TabIndex = 1;
            // 
            // device
            // 
            device.BorderColor = Color.Transparent;
            device.BorderRadius = 16;
            device.Controls.Add(pictureBox3);
            device.Controls.Add(panel1);
            device.Controls.Add(panel2);
            device.CustomizableEdges = customizableEdges3;
            device.FillColor = Color.FromArgb(33, 34, 37);
            device.Location = new Point(470, 170);
            device.Margin = new Padding(2);
            device.Name = "device";
            device.Padding = new Padding(24);
            device.ShadowDecoration.CustomizableEdges = customizableEdges4;
            device.Size = new Size(376, 442);
            device.TabIndex = 0;
            device.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(24, 100);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(328, 258);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(24, 24);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 76);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(157, 158, 159);
            label3.Location = new Point(0, 38);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 1;
            label3.Text = "TypeIT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 0, 6);
            label2.Size = new Size(247, 38);
            label2.TabIndex = 0;
            label2.Text = "INFINITY GAUNTLET";
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2Panel1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(24, 358);
            panel2.Margin = new Padding(2, 0, 2, 2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 15, 0, 0);
            panel2.Size = new Size(328, 60);
            panel2.TabIndex = 3;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.FromArgb(56, 57, 59);
            guna2Panel1.BorderRadius = 12;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(pictureBox4);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Right;
            guna2Panel1.Location = new Point(283, 15);
            guna2Panel1.Margin = new Padding(2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(12);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(45, 45);
            guna2Panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(12, 12);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(21, 21);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // notConnected
            // 
            notConnected.Dock = DockStyle.Bottom;
            notConnected.Image = (Image)resources.GetObject("notConnected.Image");
            notConnected.Location = new Point(0, -31);
            notConnected.Name = "notConnected";
            notConnected.Size = new Size(1370, 675);
            notConnected.SizeMode = PictureBoxSizeMode.Zoom;
            notConnected.TabIndex = 4;
            notConnected.TabStop = false;
            notConnected.Click += notConnected_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1370, 804);
            Controls.Add(main);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Home";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TypeIT";
            Load += Form1_Load;
            Resize += Form1_Resize;
            main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profile).EndInit();
            ((System.ComponentModel.ISupportInitialize)menu).EndInit();
            content.ResumeLayout(false);
            device.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)notConnected).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel main;
        private Guna.UI2.WinForms.Guna2Panel device;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label2;
        private Label label3;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private PictureBox pictureBox4;
        private PictureBox profile;
        private PictureBox notConnected;
        public PictureBox menu;
        public Panel content;
    }
}
