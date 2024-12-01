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
            main.Margin = new Padding(4);
            main.Name = "main";
            main.Size = new Size(2453, 1553);
            main.TabIndex = 0;
            // 
            // profile
            // 
            profile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profile.Image = (Image)resources.GetObject("profile.Image");
            profile.Location = new Point(2305, 68);
            profile.Margin = new Padding(4);
            profile.Name = "profile";
            profile.Padding = new Padding(28, 32, 28, 32);
            profile.Size = new Size(59, 102);
            profile.SizeMode = PictureBoxSizeMode.Zoom;
            profile.TabIndex = 5;
            profile.TabStop = false;
            profile.Click += profile_Click;
            // 
            // menu
            // 
            menu.Image = (Image)resources.GetObject("menu.Image");
            menu.Location = new Point(80, 68);
            menu.Margin = new Padding(4);
            menu.Name = "menu";
            menu.Padding = new Padding(28, 32, 28, 32);
            menu.Size = new Size(37, 102);
            menu.SizeMode = PictureBoxSizeMode.Zoom;
            menu.TabIndex = 6;
            menu.TabStop = false;
            // 
            // content
            // 
            content.Controls.Add(device);
            content.Controls.Add(notConnected);
            content.Dock = DockStyle.Bottom;
            content.Location = new Point(0, 179);
            content.Margin = new Padding(4);
            content.Name = "content";
            content.Size = new Size(2453, 1374);
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
            device.Location = new Point(873, 363);
            device.Margin = new Padding(4);
            device.Name = "device";
            device.Padding = new Padding(45, 51, 45, 51);
            device.ShadowDecoration.CustomizableEdges = customizableEdges4;
            device.Size = new Size(698, 943);
            device.TabIndex = 0;
            device.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(45, 213);
            pictureBox3.Margin = new Padding(4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(608, 551);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(45, 51);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(608, 162);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(157, 158, 159);
            label3.Location = new Point(0, 78);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(115, 45);
            label3.TabIndex = 1;
            label3.Text = "TypeIT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 0, 13);
            label2.Size = new Size(492, 78);
            label2.TabIndex = 0;
            label2.Text = "INFINITY GAUNTLET";
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2Panel1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(45, 764);
            panel2.Margin = new Padding(4, 0, 4, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 32, 0, 0);
            panel2.Size = new Size(608, 128);
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
            guna2Panel1.Location = new Point(524, 32);
            guna2Panel1.Margin = new Padding(4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(22, 26, 22, 26);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(84, 96);
            guna2Panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(22, 26);
            pictureBox4.Margin = new Padding(4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(40, 44);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // notConnected
            // 
            notConnected.Dock = DockStyle.Bottom;
            notConnected.Image = (Image)resources.GetObject("notConnected.Image");
            notConnected.Location = new Point(0, -66);
            notConnected.Margin = new Padding(6);
            notConnected.Name = "notConnected";
            notConnected.Size = new Size(2453, 1440);
            notConnected.SizeMode = PictureBoxSizeMode.Zoom;
            notConnected.TabIndex = 4;
            notConnected.TabStop = false;
            notConnected.Click += notConnected_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(2453, 1553);
            Controls.Add(main);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(1909, 1012);
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
