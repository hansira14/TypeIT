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
        public event EventHandler<KeyMappingProfile> ProfileClicked;

        public UC_Profile(KeyMappingProfile profile)
        {
            InitializeComponent();
            this.profile = profile;
            profileNameTxt.Text = profile.Name;
            
            // Add click handlers
            profileMenu.Click += ProfileMenu_Click;
            profileNameTxt.Click += ProfileMenu_Click;
        }

        private void ProfileMenu_Click(object sender, EventArgs e)
        {
            // Notify parent that this profile was selected
            ProfileClicked?.Invoke(this, profile);
        }

        private void profileMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
