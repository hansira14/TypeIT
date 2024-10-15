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
    public partial class UC_Key : UserControl
    {
        public UC_Key()
        {
            InitializeComponent();
        }

        private void UC_Key_Load(object sender, EventArgs e)
        {
            //label1 and label2 shold be centered vertically inside their parent containers
            label1.Top = (this.Height - label1.Height) / 2;
            label2.Top = (this.Height - label2.Height) / 2;
        }
    }
}
