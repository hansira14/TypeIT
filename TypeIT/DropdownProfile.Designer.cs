namespace TypeIT
{
    partial class Dropdown_Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dropdown_Profile));
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            profile = new PictureBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoSize = true;
            guna2Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2Panel1.BorderColor = Color.FromArgb(106, 106, 106);
            guna2Panel1.BorderRadius = 12;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(profile);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.FillColor = Color.Transparent;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(0, 0);
            guna2Panel1.TabIndex = 0;
            // 
            // profile
            // 
            profile.Dock = DockStyle.Right;
            profile.Image = (Image)resources.GetObject("profile.Image");
            profile.Location = new Point(-63, 0);
            profile.Name = "profile";
            profile.Padding = new Padding(30);
            profile.Size = new Size(63, 0);
            profile.SizeMode = PictureBoxSizeMode.Zoom;
            profile.TabIndex = 2;
            profile.TabStop = false;
            // 
            // Dropdown_Profile
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            Margin = new Padding(0);
            Name = "Dropdown_Profile";
            Size = new Size(0, 0);
            Paint += Dropdown_Profile_Paint;
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private PictureBox profile;
    }
}
