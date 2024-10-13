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
    public partial class UC_set : UserControl
    {
        public UC_set()
        {
            InitializeComponent();
        }


        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font, FontStyle.Bold);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font, FontStyle.Regular);
        }
    }
}
