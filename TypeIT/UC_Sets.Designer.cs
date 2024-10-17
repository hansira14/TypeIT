namespace TypeIT
{
    partial class UC_Sets
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
            set = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // set
            // 
            set.BorderColor = Color.Transparent;
            set.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            set.Checked = true;
            set.CheckedState.CustomBorderColor = Color.FromArgb(19, 150, 255);
            set.CustomBorderColor = Color.Transparent;
            set.CustomBorderThickness = new Padding(0, 0, 0, 2);
            set.CustomizableEdges = customizableEdges1;
            set.DisabledState.BorderColor = Color.DarkGray;
            set.DisabledState.CustomBorderColor = Color.DarkGray;
            set.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            set.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            set.FillColor = Color.Transparent;
            set.Font = new Font("Segoe UI", 9F);
            set.ForeColor = Color.White;
            set.HoverState.CustomBorderColor = Color.FromArgb(19, 150, 255);
            set.Location = new Point(0, 0);
            set.Margin = new Padding(0);
            set.Name = "set";
            set.ShadowDecoration.CustomizableEdges = customizableEdges2;
            set.Size = new Size(111, 85);
            set.TabIndex = 1;
            set.Text = "Set 1";
            // 
            // UC_Sets
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(set);
            Margin = new Padding(0);
            Name = "UC_Sets";
            Size = new Size(111, 85);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button set;
    }
}
