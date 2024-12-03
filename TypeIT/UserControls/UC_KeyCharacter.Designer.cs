namespace TypeIT.UserControls
{
    partial class UC_KeyCharacter
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
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2Button4
            // 
            guna2Button4.BorderRadius = 4;
            guna2Button4.Cursor = Cursors.Hand;
            guna2Button4.CustomizableEdges = customizableEdges1;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.FromArgb(83, 83, 83);
            guna2Button4.Font = new Font("Segoe UI", 9F);
            guna2Button4.ForeColor = Color.White;
            guna2Button4.Location = new Point(0, 0);
            guna2Button4.Margin = new Padding(0, 0, 8, 8);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button4.Size = new Size(44, 45);
            guna2Button4.TabIndex = 1;
            guna2Button4.Text = "A";
            guna2Button4.Click += guna2Button4_Click;
            guna2Button4.MouseDown += guna2Button4_MouseDown;
            // 
            // UC_KeyCharacter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(guna2Button4);
            Margin = new Padding(0, 0, 9, 8);
            MaximumSize = new Size(44, 45);
            MinimumSize = new Size(44, 45);
            Name = "UC_KeyCharacter";
            Size = new Size(44, 45);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button4;
    }
}
