namespace TypeIT
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
            otherProfiles = new Guna.UI2.WinForms.Guna2Panel();
            currentProf = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox2 = new PictureBox();
            currentProfileName = new Label();
            pictureBox1 = new PictureBox();
            currentProf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // otherProfiles
            // 
            otherProfiles.BackColor = Color.FromArgb(17, 17, 17);
            otherProfiles.CustomizableEdges = customizableEdges1;
            otherProfiles.Dock = DockStyle.Fill;
            otherProfiles.Location = new Point(0, 48);
            otherProfiles.Margin = new Padding(2, 1, 2, 1);
            otherProfiles.Name = "otherProfiles";
            otherProfiles.ShadowDecoration.CustomizableEdges = customizableEdges2;
            otherProfiles.Size = new Size(340, 0);
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
            currentProf.MinimumSize = new Size(340, 48);
            currentProf.Name = "currentProf";
            currentProf.Padding = new Padding(12, 6, 12, 6);
            currentProf.ShadowDecoration.CustomizableEdges = customizableEdges4;
            currentProf.Size = new Size(340, 48);
            currentProf.TabIndex = 8;
            currentProf.Click += currentProf_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(318, 6);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Padding = new Padding(15, 15, 15, 15);
            pictureBox2.Size = new Size(10, 36);
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
            currentProfileName.Location = new Point(62, 14);
            currentProfileName.Margin = new Padding(2, 0, 2, 0);
            currentProfileName.Name = "currentProfileName";
            currentProfileName.Size = new Size(63, 21);
            currentProfileName.TabIndex = 3;
            currentProfileName.Text = "Default";
            currentProfileName.Click += currentProfileName_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 6);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(15, 15, 15, 15);
            pictureBox1.Size = new Size(32, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // UC_ProfileList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(otherProfiles);
            Controls.Add(currentProf);
            Margin = new Padding(2, 1, 2, 1);
            MinimumSize = new Size(340, 48);
            Name = "UC_ProfileList";
            Size = new Size(340, 48);
            currentProf.ResumeLayout(false);
            currentProf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel otherProfiles;
        private Guna.UI2.WinForms.Guna2Panel currentProf;
        private PictureBox pictureBox2;
        private Label currentProfileName;
        private PictureBox pictureBox1;
    }
}
