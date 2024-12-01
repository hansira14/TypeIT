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
using System.Text.Json;
using System.IO;

namespace TypeIT
{
    public partial class Customize : Form
    {
        public KeyMappingSet currentSet;
        private List<UC_Sets> setControls = new List<UC_Sets>();
        private string currentKeyMapType = "Keys";
        private Home home;
        public Customize(Home home)
        {
            InitializeComponent();
            PopulateSets();
            this.home = home;
        }
        bool expand = false;
        public void PopulateSets()
        {
            setList.Controls.Clear();
            setControls.Clear();

            if (Program.CurrentSelectedMappingProfile?.Sets == null) return;

            int setIndex = 1;
            foreach (var set in Program.CurrentSelectedMappingProfile.Sets)
            {
                var isCurrentSet = Program.CurrentSelectedMappingProfile.CurrentMappingsSelected?.ActivationKey == set.Key;
                var setControl = new UC_Sets(set.Key, isCurrentSet, $"Set {setIndex}");
                setControl.SetSelected += SetControl_Selected;

                setControls.Add(setControl);
                setList.Controls.Add(setControl);

                // Set the initial activation key label for the current set
                if (isCurrentSet)
                {
                    setActivationKey.Text = KeyCodeConverter.ConvertToFingerCombination(Program.CurrentSelectedMappingProfile.CurrentMappingsSelected.ActivationKey);
                }

                setIndex++;
            }

            // Populate initial mappings if there's a current set
            if (Program.CurrentSelectedMappingProfile?.CurrentMappingsSelected != null)
            {
                PopulateKeyMappings(Program.CurrentSelectedMappingProfile.CurrentMappingsSelected);
            }
        }
        private void PopulateKeyMappings(KeyMappingSet mappingSet)
        {
            keyMaps.Visible = false;
            keyMaps.Controls.Clear();
            if (mappingSet?.KeyMappings == null || !mappingSet.KeyMappings.Any())
            {
                blank.Visible = true;
                return;
            }

            blank.Visible = false;

            foreach (var mapping in mappingSet.KeyMappings.Reverse())
            {
                var fingerCombination = KeyCodeConverter.ConvertToFingerCombination(mapping.Key);
                var command = string.Join(" + ", mapping.Value);

                var commandControl = new UC_Commands(fingerCombination, command);
                commandControl.Dock = DockStyle.Top;
                keyMaps.Controls.Add(commandControl);
            }
            keyMaps.PerformLayout();
            keyMaps.Visible = true;
        }
        private void SetControl_Selected(object sender, EventArgs e)
        {
            var selectedSet = (UC_Sets)sender;

            // Update selection state for all controls
            foreach (var control in setControls)
            {
                control.isSelected = control == selectedSet;
                control.UpdateSelection();
            }

            // Update current mapping set
            if (Program.CurrentSelectedMappingProfile?.Sets.TryGetValue(selectedSet.SetName, out var mappingSet) == true)
            {
                Program.CurrentSelectedMappingProfile.CurrentMappingsSelected = mappingSet;
                currentSet = mappingSet;

                // Update the activation key label
                setActivationKey.Text = KeyCodeConverter.ConvertToFingerCombination(mappingSet.ActivationKey);

                // Populate the key mappings
                PopulateKeyMappings(mappingSet);
            }
        }
        private void assignButton_Click(object sender, EventArgs e)
        {
            keySet.Visible = false;
            assignSingleKey.Visible = true;
        }

        private void keyChoice_Click(object sender, EventArgs e)
        {
            if (keyChoices.Size == keyChoices.MaximumSize)
            {
                keyChoices.Size = keyChoices.MinimumSize;
            }
            else
            {
                keyChoices.Size = keyChoices.MaximumSize;
            }
        }

        private void keyChoices_Leave(object sender, EventArgs e)
        {
            keyChoices.Size = MinimumSize;
        }

        private void closeAssign_Click(object sender, EventArgs e)
        {
            keySet.Visible = true;
            assignSingleKey.Visible = false;
        }

        private void Customize_Paint(object sender, PaintEventArgs e)
        {
            var homeForm = Application.OpenForms.OfType<Home>().FirstOrDefault();
            if (homeForm != null)
            {
                //Main.Padding = new Padding(homeForm.menu.Location.X + (int)(homeForm.menu.Width * 1.2), 0, 0, 0);
                Main.Padding = new Padding(homeForm.menu.Location.X, 0, 0, 0);
            }
        }

        private void keyMaps_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HideAssignOptions()
        {
            if (assignOptions.Visible)
            {
                assignOptions.Visible = false;
                keySet.Visible = true;
                assignSingleKey.Visible = false;
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            HideAssignOptions();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            HideAssignOptions();
        }

        private void assignMapping_Click(object sender, EventArgs e)
        {
            assignOptions.Visible = !assignOptions.Visible;
        }

        private void singleKeyButton_Click(object sender, EventArgs e)
        {
            assignSingleKey.Visible = true;
            keySet.Visible = false;
            recordCombination.Visible = false;
            assignOptions.Visible = false;
        }

        private void combinationButton_Click(object sender, EventArgs e)
        {
            recordCombination.Visible = true;
            keySet.Visible = false;
            assignSingleKey.Visible = false;
            assignOptions.Visible = false;
        }

        private void cancelRecord_Click(object sender, EventArgs e)
        {
            keySet.Visible = true;
            recordCombination.Visible = false;
            assignSingleKey.Visible = false;
        }

        private void keyTypeButton_Click(object sender, EventArgs e)
        {
            currentKeyMapType = ((Button)sender).Text;
            currentKeyType.Text = currentKeyMapType;
            ((Button)sender).Visible = false;
            keyTypeButton.Visible=(currentKeyType.Text != "Keys");
            commandTypeButton.Visible = (currentKeyType.Text != "Commands");
            macroTypeButton.Visible = (currentKeyType.Text != "Macros");
            if (keyChoices.Size == keyChoices.MaximumSize)
            {
                keyChoices.Size = keyChoices.MinimumSize;
            }
            else
            {
                keyChoices.Size = keyChoices.MaximumSize;
            }
        }

        private void discardChanges_Click(object sender, EventArgs e)
        {
            // If this is a new profile (temp profile)
            if (!File.Exists(GetProfilePath(Program.CurrentSelectedMappingProfile.Name)))
            {
                var tempProfile = Program.CurrentSelectedMappingProfile;
                Program.KeyMappingProfiles.Remove(tempProfile);
                
                var previousProfile = Program.KeyMappingProfiles.FirstOrDefault();
                Program.CurrentSelectedMappingProfile = previousProfile;
                home.profileList.UpdateCurrentProfile(previousProfile);
            }
            else // This is an existing profile that was modified
            {
                // Reload the profile from file
                string jsonContent = File.ReadAllText(GetProfilePath(Program.CurrentSelectedMappingProfile.Name));
                var originalProfile = KeyMappingProfile.FromJsonManual(jsonContent);
                
                // Replace the current profile with the original
                int index = Program.KeyMappingProfiles.FindIndex(p => p.Name == originalProfile.Name);
                if (index != -1)
                {
                    Program.KeyMappingProfiles[index] = originalProfile;
                    Program.CurrentSelectedMappingProfile = originalProfile;
                    home.profileList.UpdateCurrentProfile(originalProfile);
                }
            }
            
            PopulateSets();
            saveChanges.Visible = false;
            discardChanges.Visible = false;
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = GetProfilePath(Program.CurrentSelectedMappingProfile.Name);
                
                // Convert to our JSON-friendly format
                var jsonProfile = KeyMappingProfileJson.FromKeyMappingProfile(Program.CurrentSelectedMappingProfile);
                
                // Serialize with proper formatting
                var options = new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                
                string jsonContent = JsonSerializer.Serialize(jsonProfile, options);
                File.WriteAllText(filePath, jsonContent);
                
                saveChanges.Visible = false;
                discardChanges.Visible = false;
                
                MessageBox.Show("Profile saved successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving profile: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addSet_Click(object sender, EventArgs e)
        {
            // Get the next set number
            int nextSetNumber = Program.CurrentSelectedMappingProfile.Sets.Count + 1;
            
            // Create a new empty mapping set
            var newSet = new KeyMappingSet
            {
                ActivationKey = $"Set{nextSetNumber}Key", // Default activation key
                KeyMappings = new Dictionary<string, List<string>>()
            };
            
            // Add the new set to the current profile
            Program.CurrentSelectedMappingProfile.Sets.Add(newSet.ActivationKey, newSet);
            
            // Show save/discard buttons since we've modified the profile
            saveChanges.Visible = true;
            discardChanges.Visible = true;
            
            // Refresh the sets display
            PopulateSets();
        }

        private string GetProfilePath(string profileName)
        {
            string projectFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.Parent.Parent.FullName;
            string folderPath = Path.Combine(projectFolder, "DefaultKeyMappingProfiles");
            return Path.Combine(folderPath, $"{profileName}.json");
        }
    }
}
