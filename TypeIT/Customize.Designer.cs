namespace TypeIT
{
    partial class Customize
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customize));
            top = new Panel();
            label2 = new Label();
            profileMenu = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            profile = new PictureBox();
            menu = new PictureBox();
            top.SuspendLayout();
            profileMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menu).BeginInit();
            SuspendLayout();
            // 
            // top
            // 
            top.Controls.Add(label2);
            top.Controls.Add(profileMenu);
            top.Controls.Add(panel3);
            top.Controls.Add(profile);
            top.Controls.Add(menu);
            top.Dock = DockStyle.Top;
            top.Location = new Point(0, 0);
            top.Margin = new Padding(2);
            top.Name = "top";
            top.Padding = new Padding(30);
            top.Size = new Size(1312, 108);
            top.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label2.Location = new Point(50, 30);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(30, 0, 0, 0);
            label2.Size = new Size(359, 45);
            label2.TabIndex = 5;
            label2.Text = "INFINITY GAUNTLET";
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
            profileMenu.CustomizableEdges = customizableEdges1;
            profileMenu.Dock = DockStyle.Right;
            profileMenu.FillColor = Color.FromArgb(17, 17, 17);
            profileMenu.Location = new Point(872, 30);
            profileMenu.Margin = new Padding(2);
            profileMenu.MinimumSize = new Size(340, 48);
            profileMenu.Name = "profileMenu";
            profileMenu.Padding = new Padding(12, 6, 12, 6);
            profileMenu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            profileMenu.Size = new Size(340, 48);
            profileMenu.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(318, 6);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Padding = new Padding(15);
            pictureBox2.Size = new Size(10, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(72, 14);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 3;
            label1.Text = "Default";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 6);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(15);
            pictureBox1.Size = new Size(32, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1212, 30);
            panel3.Name = "panel3";
            panel3.Size = new Size(38, 48);
            panel3.TabIndex = 3;
            // 
            // profile
            // 
            profile.Dock = DockStyle.Right;
            profile.Image = (Image)resources.GetObject("profile.Image");
            profile.Location = new Point(1250, 30);
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
            // Customize
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(16, 17, 19);
            ClientSize = new Size(1312, 743);
            Controls.Add(top);
            ForeColor = Color.White;
            Name = "Customize";
            Text = "Customize";
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

        private Panel top;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Panel profileMenu;
        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private PictureBox profile;
        private PictureBox menu;
    }
}