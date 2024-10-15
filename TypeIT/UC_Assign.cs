using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeIT
{
    public partial class UC_Assign : UserControl
    {
        public UC_Assign()
        {
            InitializeComponent();
        }
        private void keyChoices_Leave(object sender, EventArgs e)
        {
            keyChoices.Size = MinimumSize;
        }

        private void keyChoice_Click(object sender, EventArgs e)
        {
            if (keyChoices.Size == new Size(133, 228))
            {
                keyChoices.Size = new Size(133, 38);
            }
            else
            {
                keyChoices.Size = new Size(133, 228);
            }
        }
    }
}
