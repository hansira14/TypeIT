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
    public partial class UC_Finger : UserControl
    {
        public UC_Finger()
        {
            InitializeComponent();
        }

        private void UC_Finger_DragDrop(object sender, DragEventArgs e)
        {
            mapping.Text = (string)e.Data.GetData(typeof(string));
            e.Effect = DragDropEffects.All;
        }

        private void UC_Finger_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
