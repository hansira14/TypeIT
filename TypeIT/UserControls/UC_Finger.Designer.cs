﻿namespace TypeIT.UserControls
{
    partial class UC_Finger
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
            mapping = new Label();
            SuspendLayout();
            // 
            // mapping
            // 
            mapping.AutoSize = true;
            mapping.Location = new Point(37, 36);
            mapping.Name = "mapping";
            mapping.Size = new Size(78, 32);
            mapping.TabIndex = 0;
            mapping.Text = "label1";
            // 
            // UC_Finger
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            Controls.Add(mapping);
            MaximumSize = new Size(205, 100);
            MinimumSize = new Size(205, 100);
            Name = "UC_Finger";
            Size = new Size(205, 100);
            DragDrop += UC_Finger_DragDrop;
            DragOver += UC_Finger_DragOver;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label mapping;
    }
}
