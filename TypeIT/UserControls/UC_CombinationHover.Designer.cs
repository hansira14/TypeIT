namespace TypeIT.UserControls
{
    partial class UC_CombinationHover : UserControl
    {
        private TableLayoutPanel mainTable;
        private Label combination;
        private Label command;

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
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            mainTable = new TableLayoutPanel();
            combination = new Label();
            command = new Label();
            guna2Panel1.SuspendLayout();
            mainTable.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoSize = true;
            guna2Panel1.BorderColor = Color.FromArgb(40, 40, 40);
            guna2Panel1.BorderRadius = 6;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(mainTable);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.FromArgb(16, 17, 19);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(150, 44);
            guna2Panel1.TabIndex = 0;
            // 
            // mainTable
            // 
            mainTable.AutoSize = true;
            mainTable.BackColor = Color.Transparent;
            mainTable.ColumnCount = 2;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTable.Controls.Add(combination, 0, 0);
            mainTable.Controls.Add(command, 1, 0);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(0, 0);
            mainTable.Name = "mainTable";
            mainTable.Padding = new Padding(10);
            mainTable.RowCount = 1;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTable.Size = new Size(150, 44);
            mainTable.TabIndex = 0;
            // 
            // combination
            // 
            combination.AutoSize = true;
            combination.Dock = DockStyle.Fill;
            combination.ForeColor = SystemColors.ActiveCaption;
            combination.Location = new Point(13, 10);
            combination.Name = "combination";
            combination.Size = new Size(59, 24);
            combination.TabIndex = 0;
            // 
            // command
            // 
            command.AutoSize = true;
            command.Dock = DockStyle.Fill;
            command.ForeColor = SystemColors.ActiveBorder;
            command.Location = new Point(78, 10);
            command.Name = "command";
            command.Size = new Size(59, 24);
            command.TabIndex = 1;
            // 
            // UC_CombinationHover
            // 
            AutoSize = true;
            Controls.Add(guna2Panel1);
            ForeColor = SystemColors.ActiveCaption;
            Name = "UC_CombinationHover";
            Size = new Size(150, 44);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            mainTable.ResumeLayout(false);
            mainTable.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
