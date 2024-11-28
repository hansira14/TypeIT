using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeIT.Models;

namespace TypeIT
{
    public partial class UC_ProfileList : UserControl
    {
        bool isExpanded = false;
        KeyMappingProfile currentProfile;
        List<KeyMappingProfile> allProfiles;

        public UC_ProfileList(KeyMappingProfile currentProfile, List<KeyMappingProfile> allProfiles)
        {
            InitializeComponent();

            // Store the profiles
            this.currentProfile = currentProfile;
            this.allProfiles = allProfiles;

            // Set current profile name
            currentProfileName.Text = currentProfile?.Name ?? "null";

            // Populate other profiles
            PopulateOtherProfiles();
        }

        private void PopulateOtherProfiles()
        {
            // Clear existing controls
            otherProfiles.Controls.Clear();

            // Add each profile except the current one
            foreach (var profile in allProfiles)
            {
                if (profile.Name != currentProfile.Name)
                {
                    var profileControl = new UC_Profile(profile);
                    profileControl.Dock = DockStyle.Top;
                    otherProfiles.Controls.Add(profileControl);
                }
            }
        }
        private void currentProf_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            update_UI();
        }
        private void update_UI()
        {
            if (isExpanded)
            {
                this.Size = MinimumSize;
                otherProfiles.Visible = false;
            }
            else
            {
                int profileHeight = currentProf.Height;

                int totalHeight = currentProf.Height +
                    (otherProfiles.Controls.Count * profileHeight);

                this.Size = new Size(this.Width, totalHeight);
                otherProfiles.Visible = true;
            }
        }

        private void currentProfileName_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            update_UI();
        }
    }

}
