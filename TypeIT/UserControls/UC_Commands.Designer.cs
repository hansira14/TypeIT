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
            tableLayoutPanel1.Location = new Point(10, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(472, 33);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Click += mapping_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(mapping);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 33);
            panel1.TabIndex = 0;
            panel1.Click += mapping_Click;
            panel1.MouseDown += command_MouseDown;
            panel1.MouseClick += new MouseEventHandler(Control_MouseClick);
            // 
            // mapping
            // 
            mapping.AutoSize = true;
            mapping.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mapping.ForeColor = Color.FromArgb(19, 150, 255);
            mapping.Location = new Point(1, 9);
            mapping.Name = "mapping";
            mapping.Size = new Size(47, 15);
            mapping.TabIndex = 1;
            mapping.Text = "Ctrl + V";
            mapping.Click += mapping_Click;
            mapping.MouseDown += command_MouseDown;
            mapping.MouseClick += new MouseEventHandler(Control_MouseClick);
            // 
            // panel2
            // 
            panel2.Controls.Add(output);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(236, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 33);
            panel2.TabIndex = 1;
            panel2.Click += mapping_Click;
            panel2.MouseDown += command_MouseDown;
            panel2.MouseClick += new MouseEventHandler(Control_MouseClick);
            // 
            // output
            // 
            output.AutoSize = true;
            output.Font = new Font("Segoe UI", 9F);
            output.ForeColor = Color.DimGray;
            output.Location = new Point(7, 9);
            output.Name = "output";
            output.Size = new Size(35, 15);
            output.TabIndex = 1;
            output.Text = "Paste";
            output.Click += mapping_Click;
            output.MouseDown += command_MouseDown;
            output.MouseClick += new MouseEventHandler(Control_MouseClick);
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(125, 64, 65, 66);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(10, 33);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(472, 1);
            panel3.TabIndex = 2;
            panel3.Click += mapping_Click;
            // 
            // UC_Commands
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel3);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(0);
            Name = "UC_Commands";
            Padding = new Padding(10, 0, 10, 0);
            Size = new Size(492, 34);
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
        private Panel panel2;
        private Label output;
        private Panel panel3;
        public Panel panel1;
        public Label mapping;
    }
}
