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
            combinationCount = new Label();
            SuspendLayout();
            // 
            // mapping
            // 
            mapping.AutoSize = true;
            mapping.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            mapping.ForeColor = Color.White;
            mapping.Location = new Point(7, 8);
            mapping.Margin = new Padding(2, 0, 2, 0);
            mapping.Name = "mapping";
            mapping.Size = new Size(12, 15);
            mapping.TabIndex = 0;
            mapping.Text = "?";
            mapping.Click += mapping_Click;
            // 
            // combinationCount
            // 
            combinationCount.AutoSize = true;
            combinationCount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            combinationCount.ForeColor = Color.Gray;
            combinationCount.Location = new Point(51, 8);
            combinationCount.Margin = new Padding(2, 0, 2, 0);
            combinationCount.Name = "combinationCount";
            combinationCount.Size = new Size(0, 15);
            combinationCount.TabIndex = 1;
            // 
            // UC_Finger
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(combinationCount);
            Controls.Add(mapping);
            Margin = new Padding(2, 1, 2, 1);
            MaximumSize = new Size(110, 30);
            MinimumSize = new Size(110, 30);
            Name = "UC_Finger";
            Size = new Size(110, 30);
            DragDrop += UC_Finger_DragDrop;
            DragOver += UC_Finger_DragOver;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label mapping;
        public Label combinationCount;
    }
}
