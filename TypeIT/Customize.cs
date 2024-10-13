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
    public partial class Customize : Form
    {
        public Customize()
        {
            InitializeComponent();
        }
        bool expand = false;
        private void uC_set1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void uC_set3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand == false)
            {
                flowLayoutPanel1.Height += 15;
                if (flowLayoutPanel1.Height >= flowLayoutPanel1.MaximumSize.Height)
                {
                    timer1.Stop();
                    expand = false;
                }
            }
            else
            {
                flowLayoutPanel1.Height -= 15;
                if (flowLayoutPanel1.Height <= flowLayoutPanel1.MinimumSize.Height)
                {
                    timer1.Stop();
                    expand = true;
                }
            }
        }

        private void selectClick(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void uC_set6_Load(object sender, EventArgs e)
        {

        }
    }
}
