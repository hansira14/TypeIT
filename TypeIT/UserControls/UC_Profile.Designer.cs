namespace TypeIT
{
    partial class UC_Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Profile));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            profileNameTxt = new Label();
            profileMenu = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            profileMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 13);
            pictureBox1.Margin = new Padding(3, 5, 3, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(28, 32, 28, 32);
            pictureBox1.Size = new Size(60, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // profileNameTxt
            // 
            profileNameTxt.AutoSize = true;
            profileNameTxt.FlatStyle = FlatStyle.Flat;
            profileNameTxt.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profileNameTxt.ForeColor = Color.White;
            profileNameTxt.Location = new Point(122, 29);
            profileNameTxt.Name = "profileNameTxt";
            profileNameTxt.Size = new Size(127, 45);
            profileNameTxt.TabIndex = 3;
            profileNameTxt.Text = "Default";
            // 
            // profileMenu
            // 
            profileMenu.AutoSize = true;
            profileMenu.BorderColor = Color.Transparent;
            profileMenu.Controls.Add(profileNameTxt);
            profileMenu.Controls.Add(pictureBox1);
            profileMenu.CustomizableEdges = customizableEdges1;
            profileMenu.Dock = DockStyle.Fill;
            profileMenu.FillColor = Color.FromArgb(17, 17, 17);
            profileMenu.Location = new Point(0, 0);
            profileMenu.Margin = new Padding(0);
            profileMenu.MinimumSize = new Size(632, 102);
            profileMenu.Name = "profileMenu";
            profileMenu.Padding = new Padding(23, 13, 23, 13);
            profileMenu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            profileMenu.Size = new Size(632, 102);
            profileMenu.TabIndex = 3;
            profileMenu.Paint += profileMenu_Paint;
            // 
            // UC_Profile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(profileMenu);
            MaximumSize = new Size(632, 102);
            Name = "UC_Profile";
            Size = new Size(632, 102);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            profileMenu.ResumeLayout(false);
            profileMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label profileNameTxt;
        private Guna.UI2.WinForms.Guna2Panel profileMenu;
    }
}
