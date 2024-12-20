﻿namespace TypeIT
{
    partial class UC_ProfileList
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ProfileList));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            otherProfiles = new Guna.UI2.WinForms.Guna2Panel();
            currentProf = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox2 = new PictureBox();
            currentProfileName = new Label();
            pictureBox1 = new PictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            addProfile = new Label();
            currentProf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // otherProfiles
            // 
            otherProfiles.BackColor = Color.FromArgb(17, 17, 17);
            otherProfiles.CustomizableEdges = customizableEdges1;
            otherProfiles.Dock = DockStyle.Fill;
            otherProfiles.Location = new Point(0, 102);
            otherProfiles.Margin = new Padding(0);
            otherProfiles.Name = "otherProfiles";
            otherProfiles.ShadowDecoration.CustomizableEdges = customizableEdges2;
            otherProfiles.Size = new Size(631, 0);
            otherProfiles.TabIndex = 7;
            // 
            // currentProf
            // 
            currentProf.AutoSize = true;
            currentProf.BorderColor = Color.FromArgb(106, 106, 106);
            currentProf.BorderRadius = 8;
            currentProf.BorderThickness = 1;
            currentProf.Controls.Add(pictureBox2);
            currentProf.Controls.Add(currentProfileName);
            currentProf.Controls.Add(pictureBox1);
            currentProf.CustomizableEdges = customizableEdges3;
            currentProf.Dock = DockStyle.Top;
            currentProf.FillColor = Color.FromArgb(17, 17, 17);
            currentProf.Location = new Point(0, 0);
            currentProf.Margin = new Padding(0);
            currentProf.MinimumSize = new Size(631, 102);
            currentProf.Name = "currentProf";
            currentProf.Padding = new Padding(22, 13, 22, 13);
            currentProf.ShadowDecoration.CustomizableEdges = customizableEdges4;
            currentProf.Size = new Size(631, 102);
            currentProf.TabIndex = 8;
            currentProf.Click += currentProf_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(590, 13);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Padding = new Padding(28, 32, 28, 32);
            pictureBox2.Size = new Size(19, 76);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // currentProfileName
            // 
            currentProfileName.AutoSize = true;
            currentProfileName.FlatStyle = FlatStyle.Flat;
            currentProfileName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currentProfileName.ForeColor = Color.White;
            currentProfileName.Location = new Point(115, 30);
            currentProfileName.Margin = new Padding(4, 0, 4, 0);
            currentProfileName.Name = "currentProfileName";
            currentProfileName.Size = new Size(127, 45);
            currentProfileName.TabIndex = 3;
            currentProfileName.Text = "Default";
            currentProfileName.Click += currentProfileName_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 13);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(28, 32, 28, 32);
            pictureBox1.Size = new Size(59, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoSize = true;
            guna2Panel1.BorderColor = Color.FromArgb(106, 106, 106);
            guna2Panel1.Controls.Add(addProfile);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.FillColor = Color.FromArgb(17, 17, 17);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(0);
            guna2Panel1.MinimumSize = new Size(631, 102);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(22, 13, 22, 13);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(631, 102);
            guna2Panel1.TabIndex = 10;
            // 
            // addProfile
            // 
            addProfile.AutoSize = true;
            addProfile.FlatStyle = FlatStyle.Flat;
            addProfile.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addProfile.ForeColor = Color.FromArgb(94, 148, 255);
            addProfile.Location = new Point(137, 30);
            addProfile.Margin = new Padding(4, 0, 4, 0);
            addProfile.Name = "addProfile";
            addProfile.Size = new Size(181, 45);
            addProfile.TabIndex = 3;
            addProfile.Text = "Add profile";
            addProfile.Click += addProfile_Click;
            // 
            // UC_ProfileList
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(otherProfiles);
            Controls.Add(currentProf);
            Controls.Add(guna2Panel1);
            Margin = new Padding(4, 2, 4, 2);
            MinimumSize = new Size(631, 102);
            Name = "UC_ProfileList";
            Size = new Size(631, 102);
            Leave += UC_ProfileList_Leave_1;
            currentProf.ResumeLayout(false);
            currentProf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox2;
        private Label currentProfileName;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label addProfile;
        public Guna.UI2.WinForms.Guna2Panel otherProfiles;
        public Guna.UI2.WinForms.Guna2Panel currentProf;
    }
}
