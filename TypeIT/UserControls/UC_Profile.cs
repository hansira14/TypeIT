using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeIT.Models;

namespace TypeIT
{
    public partial class UC_Profile : UserControl
    {
        public KeyMappingProfile profile;
        public UC_Profile(KeyMappingProfile profile)
        {
            InitializeComponent();
            this.profile = profile;
            profileNameTxt.Text = profile.Name;
        }

        private void profileMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
