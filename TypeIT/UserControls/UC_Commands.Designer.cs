namespace TypeIT
{
    partial class UC_Commands
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            mapping = new Label();
            panel2 = new Panel();
            output = new Label();
            panel3 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(19, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(876, 70);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(mapping);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(438, 70);
            panel1.TabIndex = 0;
            panel1.MouseDown += command_MouseDown;
            // 
            // mapping
            // 
            mapping.AutoSize = true;
            mapping.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mapping.ForeColor = Color.FromArgb(19, 150, 255);
            mapping.Location = new Point(2, 19);
            mapping.Margin = new Padding(6, 0, 6, 0);
            mapping.Name = "mapping";
            mapping.Size = new Size(99, 32);
            mapping.TabIndex = 1;
            mapping.Text = "Ctrl + V";
            mapping.MouseDown += command_MouseDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(output);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(438, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(438, 70);
            panel2.TabIndex = 1;
            panel2.MouseDown += command_MouseDown;
            // 
            // output
            // 
            output.AutoSize = true;
            output.Font = new Font("Segoe UI", 9F);
            output.ForeColor = Color.DimGray;
            output.Location = new Point(13, 19);
            output.Margin = new Padding(6, 0, 6, 0);
            output.Name = "output";
            output.Size = new Size(69, 32);
            output.TabIndex = 1;
            output.Text = "Paste";
            output.MouseDown += command_MouseDown;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(125, 64, 65, 66);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(19, 70);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(876, 2);
            panel3.TabIndex = 2;
            // 
            // UC_Commands
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel3);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(0);
            Name = "UC_Commands";
            Padding = new Padding(19, 0, 19, 0);
            Size = new Size(914, 73);
            Load += UC_Key_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label mapping;
        private Panel panel2;
        private Label output;
        private Panel panel3;
    }
}
