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
        public List<KeyValuePair<string, string>> combinations { get; set; }
        public UC_CombinationHover(List<KeyValuePair<string, string>> combinations)
        {
            InitializeComponent();
            this.combinations = combinations;
        }

        public void SetContent(string leftText, string rightText)
        {
            combination.Text = leftText;
            command.Text = rightText;
            
            // Force the control to recalculate its size
            this.PerformLayout();
        }
    }
}
