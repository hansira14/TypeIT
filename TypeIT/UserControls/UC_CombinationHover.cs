using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeIT.UserControls
{
    public partial class UC_CombinationHover : UserControl
    {
        public List<string> combinations { get; set; }
        
        public UC_CombinationHover(List<string> combinations)
        {
            InitializeComponent();
            this.combinations = combinations;
            PopulateTable();
        }

        public void PopulateTable()
        {
            mainTable.Controls.Clear();
            mainTable.RowStyles.Clear();
            mainTable.RowCount = combinations.Count;

            for (int i = 0; i < combinations.Count; i++)
            {
                string[] parts = combinations[i].Split(new[] { " -> " }, StringSplitOptions.None);
                if (parts.Length != 2) continue;

                var leftLabel = new Label
                {
                    Text = parts[0],
                    ForeColor = SystemColors.ActiveCaption,
                    AutoSize = true,
                    Dock = DockStyle.Fill
                };

                var rightLabel = new Label
                {
                    Text = parts[1],
                    ForeColor = SystemColors.ActiveBorder,
                    AutoSize = true,
                    Dock = DockStyle.Fill
                };

                mainTable.Controls.Add(leftLabel, 0, i);
                mainTable.Controls.Add(rightLabel, 1, i);
                mainTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // Force the control to recalculate its size
            this.PerformLayout();
        }
    }
}
