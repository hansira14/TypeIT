﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeIT.Forms;
using TypeIT.Models;

namespace TypeIT
{
    public partial class UC_ProfileList : UserControl
    {
        bool isExpanded = false;
        KeyMappingProfile currentProfile;
        List<KeyMappingProfile> allProfiles;
        private Home home;
        private bool disableProfileSwitching;

        public event EventHandler<KeyMappingProfile> ProfileSelected;

        public bool DisableProfileSwitching
        {
            get => disableProfileSwitching;
            set
            {
                disableProfileSwitching = value;
                otherProfiles.Enabled = !value;
            }
        }

        public UC_ProfileList(KeyMappingProfile currentProfile, List<KeyMappingProfile> allProfiles, Home home)
        {
            InitializeComponent();

            this.currentProfile = currentProfile;
            this.allProfiles = allProfiles;
            this.home = home;
            UpdateCurrentProfile(currentProfile);
            PopulateOtherProfiles();
        }

        public void UpdateCurrentProfile(KeyMappingProfile newProfile)
        {
            this.currentProfile = newProfile;
            currentProfileName.Text = currentProfile?.Name ?? "null";
            PopulateOtherProfiles();
        }

        private void PopulateOtherProfiles()
        {
            otherProfiles.Controls.Clear();
            foreach (var profile in allProfiles)
            {
                if (profile.Name != currentProfile.Name)
                {
                    var profileControl = new UC_Profile(profile);
                    profileControl.ProfileClicked += (s, selectedProfile) =>
                    {
                        UpdateCurrentProfile(selectedProfile);
                        ProfileSelected?.Invoke(this, selectedProfile);
                    };
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

                int totalHeight = (currentProf.Height*2) +
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

        protected virtual void OnProfileSelected(KeyMappingProfile profile)
        {
            ProfileSelected?.Invoke(this, profile);
        }

        private void UC_ProfileList_Leave_1(object sender, EventArgs e)
        {
            //isExpanded = false;
            //update_UI();
        }

        private void addProfile_Click(object sender, EventArgs e)
        {
            var inputForm = new InputProfileName();
            var homeForm = Application.OpenForms.OfType<Home>().FirstOrDefault();
            
            if (homeForm != null)
            {
                homeForm.Enabled = false;
                inputForm.FormClosed += (s, args) => 
                {
                    homeForm.Enabled = true;
                    if (inputForm.DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(inputForm.ProfileName))
                    {
                        // Create temporary profile
                        var tempProfile = new KeyMappingProfile
                        {
                            Name = inputForm.ProfileName,
                            Sets = new Dictionary<string, KeyMappingSet>()
                        };

                        Program.KeyMappingProfiles.Add(tempProfile);
                        Program.CurrentSelectedMappingProfile = tempProfile;

                        UpdateCurrentProfile(tempProfile);
                        
                        if (homeForm.customizeForm == null || homeForm.customizeForm.IsDisposed)
                        {
                            //homeForm.customizeForm = new Customize(homeForm);
                        }
                        homeForm.openForm(homeForm.customizeForm);
                        
                        // Now we can safely access and update the customize form
                        homeForm.customizeForm.PopulateSets();
                        homeForm.customizeForm.saveChanges.Visible = true;
                        homeForm.customizeForm.discardChanges.Visible = true;
                    }
                };
                inputForm.ShowDialog();
            }
        }
    }

}
