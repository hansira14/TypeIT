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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            main = new Panel();
            content = new Panel();
            notConnected = new PictureBox();
            device = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox4 = new PictureBox();
            top = new Panel();
            profileMenu = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            profile = new PictureBox();
            menu = new PictureBox();
            main.SuspendLayout();
            content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notConnected).BeginInit();
            device.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            top.SuspendLayout();
            profileMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menu).BeginInit();
            SuspendLayout();
            // 
            // main
            // 
            main.BackColor = Color.Transparent;
            main.Controls.Add(content);
            main.Controls.Add(top);
            main.Dock = DockStyle.Fill;
            main.ForeColor = Color.White;
            main.Location = new Point(0, 0);
            main.Margin = new Padding(2);
            main.Name = "main";
            main.Size = new Size(1640, 929);
            main.TabIndex = 0;
            // 
            // content
            // 
            content.Controls.Add(notConnected);
            content.Controls.Add(device);
            content.Dock = DockStyle.Fill;
            content.Location = new Point(0, 135);
            content.Margin = new Padding(2);
            content.Name = "content";
            content.Size = new Size(1640, 794);
            content.TabIndex = 1;
            // 
            // notConnected
            // 
            notConnected.Dock = DockStyle.Fill;
            notConnected.Image = (Image)resources.GetObject("notConnected.Image");
            notConnected.Location = new Point(0, 0);
            notConnected.Margin = new Padding(4);
            notConnected.Name = "notConnected";
            notConnected.Size = new Size(1640, 794);
            notConnected.SizeMode = PictureBoxSizeMode.Zoom;
            notConnected.TabIndex = 4;
            notConnected.TabStop = false;
            notConnected.Click += notConnected_Click;
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
            device.Location = new Point(588, 76);
            device.Margin = new Padding(2);
            device.Name = "device";
            device.Padding = new Padding(30);
            device.ShadowDecoration.CustomizableEdges = customizableEdges4;
            device.Size = new Size(470, 552);
            device.TabIndex = 0;
            device.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(30, 125);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(410, 322);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(30, 30);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(410, 95);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(157, 158, 159);
            label3.Location = new Point(0, 49);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
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
            label2.Padding = new Padding(0, 0, 0, 8);
            label2.Size = new Size(311, 49);
            label2.TabIndex = 0;
            label2.Text = "INFINITY GAUNTLET";
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2Panel1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(30, 447);
            panel2.Margin = new Padding(2, 0, 2, 2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 19, 0, 0);
            panel2.Size = new Size(410, 75);
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
            guna2Panel1.Location = new Point(354, 19);
            guna2Panel1.Margin = new Padding(2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(15);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(56, 56);
            guna2Panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(15, 15);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(26, 26);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // top
            // 
            top.Controls.Add(profileMenu);
            top.Controls.Add(panel3);
            top.Controls.Add(profile);
            top.Controls.Add(menu);
            top.Dock = DockStyle.Top;
            top.Location = new Point(0, 0);
            top.Margin = new Padding(2);
            top.Name = "top";
            top.Padding = new Padding(38);
            top.Size = new Size(1640, 135);
            top.TabIndex = 0;
            // 
            // profileMenu
            // 
            profileMenu.AutoSize = true;
            profileMenu.BorderColor = Color.FromArgb(106, 106, 106);
            profileMenu.BorderRadius = 8;
            profileMenu.BorderThickness = 1;
            profileMenu.Controls.Add(pictureBox2);
            profileMenu.Controls.Add(label1);
            profileMenu.Controls.Add(pictureBox1);
            profileMenu.CustomizableEdges = customizableEdges5;
            profileMenu.Dock = DockStyle.Right;
            profileMenu.FillColor = Color.FromArgb(17, 17, 17);
            profileMenu.Location = new Point(1089, 38);
            profileMenu.Margin = new Padding(2);
            profileMenu.MinimumSize = new Size(425, 60);
            profileMenu.Name = "profileMenu";
            profileMenu.Padding = new Padding(15, 8, 15, 8);
            profileMenu.ShadowDecoration.CustomizableEdges = customizableEdges6;
            profileMenu.Size = new Size(425, 60);
            profileMenu.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(398, 8);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Padding = new Padding(19);
            pictureBox2.Size = new Size(12, 44);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(75, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 28);
            label1.TabIndex = 3;
            label1.Text = "Default";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 8);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(19);
            pictureBox1.Size = new Size(40, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1514, 38);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(48, 59);
            panel3.TabIndex = 3;
            // 
            // profile
            // 
            profile.Dock = DockStyle.Right;
            profile.Image = (Image)resources.GetObject("profile.Image");
            profile.Location = new Point(1562, 38);
            profile.Margin = new Padding(2);
            profile.Name = "profile";
            profile.Padding = new Padding(19);
            profile.Size = new Size(40, 59);
            profile.SizeMode = PictureBoxSizeMode.Zoom;
            profile.TabIndex = 1;
            profile.TabStop = false;
            // 
            // menu
            // 
            menu.Dock = DockStyle.Left;
            menu.Image = (Image)resources.GetObject("menu.Image");
            menu.Location = new Point(38, 38);
            menu.Margin = new Padding(2);
            menu.Name = "menu";
            menu.Padding = new Padding(19);
            menu.Size = new Size(25, 59);
            menu.SizeMode = PictureBoxSizeMode.Zoom;
            menu.TabIndex = 0;
            menu.TabStop = false;
            menu.Click += menu_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ClientSize = new Size(1640, 929);
            Controls.Add(main);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(1656, 966);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "w";
            Load += Form1_Load;
            Resize += Form1_Resize;
            main.ResumeLayout(false);
            content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)notConnected).EndInit();
            device.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            top.ResumeLayout(false);
            top.PerformLayout();
            profileMenu.ResumeLayout(false);
            profileMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)profile).EndInit();
            ((System.ComponentModel.ISupportInitialize)menu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel main;
        private Panel content;
        private Panel top;
        private PictureBox menu;
        private PictureBox profile;
        private Guna.UI2.WinForms.Guna2Panel profileMenu;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Panel device;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label2;
        private Label label3;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private PictureBox pictureBox4;
        private Panel panel3;
        private PictureBox notConnected;
    }
}
