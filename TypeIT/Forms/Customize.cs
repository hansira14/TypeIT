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
using TypeIT.UserControls;

namespace TypeIT
{
    public partial class Customize : Form
    {
        public KeyMappingSet currentSet;
        private List<UC_Sets> setControls = new List<UC_Sets>();
        private string currentKeyMapType = "Keys";
        private Home home;
        private static readonly Color BasicKeysColor = Color.FromArgb(83, 83, 83);
        private static readonly Color FunctionKeysColor = Color.FromArgb(128, 64, 64);
        private static readonly Color SpecialKeysColor = Color.FromArgb(64, 128, 64);
        private static readonly Color ModifierKeysColor = Color.FromArgb(64, 64, 128);
        private string recordedCombination;
        public bool combinationMode = false;
        private HashSet<string> selectedFingers = new HashSet<string>();
        private StringBuilder currentCombination = new StringBuilder("S0000000000E");
        private SerialCommunicationModel _serialComm;
        private readonly Dictionary<string, (int Position, UC_Finger Control)> fingerMappings;
        private enum PanelState
        {
            KeySet,
            AssignMenu,
            RecordCombination
        }
        public SerialCommunicationModel SerialComm
        {
            get { return _serialComm; }
            set
            {
                _serialComm = value;
            }
        }
        private bool hasUnsavedChanges = false;
        public bool HasUnsavedChanges
        {
            get => hasUnsavedChanges;
            private set
            {
                hasUnsavedChanges = value;
                saveChanges.Visible = value;
                discardChanges.Visible = value;
            }
        }
        public Customize(Home home)
        {
            InitializeComponent();
            
            fingerMappings = new Dictionary<string, (int Position, UC_Finger Control)>
            {
                {"leftPinky", (1, leftPinky)},
                {"leftRing", (2, leftRing)},
                {"leftMiddle", (3, leftMiddle)},
                {"leftIndex", (4, leftIndex)},
                {"leftThumb", (5, leftThumb)},
                {"rightThumb", (6, rightThumb)},
                {"rightIndex", (7, rightIndex)},
                {"rightMiddle", (8, rightMiddle)},
                {"rightRing", (9, rightRing)},
                {"rightPinky", (10, rightPinky)}
            };

            PopulateSets();
            PopulateToBeAssignedList();
            this.home = home;
            setParent();
            moveDropdown();
        }
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
                    currentSet = Program.CurrentSelectedMappingProfile.CurrentMappingsSelected;
                }

                setIndex++;
            }

            // Populate initial mappings if there's a current set
            if (Program.CurrentSelectedMappingProfile?.CurrentMappingsSelected != null)
            {
                PopulateKeyMappings(Program.CurrentSelectedMappingProfile.CurrentMappingsSelected);
            }

            UpdateFingerMappingsDisplay();
        }
        public void PopulateKeyMappings(KeyMappingSet mappingSet)
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
            //keyMaps.PerformLayout();
            keyMaps.Visible = true;

            UpdateFingerMappingsDisplay();
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

            UpdateFingerMappingsDisplay();
        }
        private void assignButton_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelState.AssignMenu);
        }

        private void keyChoice_Click(object sender, EventArgs e)
        {
            if (keyChoices.Size == keyChoices.MaximumSize)keyChoices.Size = keyChoices.MinimumSize;
            else keyChoices.Size = keyChoices.MaximumSize;
        }

        private void keyChoices_Leave(object sender, EventArgs e)
        {
            keyChoices.Size = MinimumSize;
        }

        private void closeAssign_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelState.KeySet);
        }

        private void Customize_Paint(object sender, PaintEventArgs e)
        {
            var homeForm = Application.OpenForms.OfType<Home>().FirstOrDefault();
            if (homeForm != null)
            {
                Main.Padding = new Padding(homeForm.menu.Location.X, 0, 0, 0);
            }
        }

        private void keyMaps_Paint(object sender, PaintEventArgs e)
        {

        }
        private void assignMapping_Click(object sender, EventArgs e)
        {
            assignOptions.Visible = !assignOptions.Visible;
        }

        private void singleKeyButton_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelState.AssignMenu);
        }

        private void combinationButton_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelState.RecordCombination);
        }

        private void cancelRecord_Click(object sender, EventArgs e)
        {
            ShowPanel(PanelState.KeySet);
        }

        private void keyTypeButton_Click(object sender, EventArgs e)
        {
            currentKeyMapType = ((Button)sender).Text;
            currentKeyType.Text = currentKeyMapType;
            ((Button)sender).Visible = false;
            keyTypeButton.Visible = currentKeyType.Text != "Keys";
            commandTypeButton.Visible = currentKeyType.Text != "Commands";
            macroTypeButton.Visible = currentKeyType.Text != "Macros";

            PopulateToBeAssignedList();

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
            var result = MessageBox.Show("Are you sure you want to discard all changes?",
                "Confirm Discard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
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
                HasUnsavedChanges = false;
                if (home?.profileList != null)
                {
                    home.profileList.DisableProfileSwitching = false;
                }
            }
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = GetProfilePath(Program.CurrentSelectedMappingProfile.Name);
                var jsonProfile = KeyMappingProfileJson.FromKeyMappingProfile(Program.CurrentSelectedMappingProfile);
                
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonContent = JsonSerializer.Serialize(jsonProfile, options);
                File.WriteAllText(filePath, jsonContent);

                HasUnsavedChanges = false;
                if (home?.profileList != null)
                {
                    home.profileList.DisableProfileSwitching = false;
                }

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
            var newSet = new KeyMappingSet
            {
                ActivationKey = "",
                KeyMappings = new Dictionary<string, List<string>>()
            };

            Program.CurrentSelectedMappingProfile.Sets.Add(newSet.ActivationKey, newSet);
            MarkAsModified();
            PopulateSets();
        }

        private string GetProfilePath(string profileName)
        {
            string projectFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.Parent.Parent.FullName;
            string folderPath = Path.Combine(projectFolder, "DefaultKeyMappingProfiles");
            return Path.Combine(folderPath, $"{profileName}.json");
        }

        private void PopulateToBeAssignedList()
        {
            toBeAssignedList.Visible = false;
            toBeAssignedList2.Visible = false;
            toBeAssignedList.Controls.Clear();
            toBeAssignedList2.Controls.Clear();



            switch (currentKeyMapType)
            {
                case "Keys":
                    foreach (var key in KeyboardConstants.BasicKeys) AddKeyControl(key.Key, key.Value, BasicKeysColor);
                    foreach (var key in KeyboardConstants.FunctionKeys) AddKeyControl(key.Key, key.Value, FunctionKeysColor);
                    foreach (var key in KeyboardConstants.SpecialKeys) AddKeyControl(key.Key, key.Value, SpecialKeysColor);
                    foreach (var key in KeyboardConstants.ModifierKeys) AddKeyControl(key.Key, key.Value, ModifierKeysColor);
                    toBeAssignedList.Visible = true;
                    break;

                case "Commands":
                    foreach (var command in KeyboardConstants.CommonCombinations)
                    {
                        var commandControl = new UC_Commands(command.Key, string.Join(" + ", command.Value));
                        commandControl.ParentForm = this;
                        commandControl.Dock = DockStyle.Top;
                        toBeAssignedList2.Controls.Add(commandControl);
                    }
                    toBeAssignedList2.Visible = true;
                    break;

                case "Macros":
                    toBeAssignedList2.Visible = true;
                    // HELP
                    break;
            }
        }

        private void AddKeyControl(string text, string value, Color color)
        {
            var keyControl = new UC_KeyCharacter();
            keyControl.SetKeyDetails(text, value, color);
            keyControl.ParentForm = this;

            keyControl.Margin = new Padding(0, 0, 15, 17);
            keyControl.Size = new Size(82, 96);
            toBeAssignedList.Controls.Add(keyControl);
        }

        public string UpdateFingerMapping(string fingerName)
        {
            char[] mapping = "S0000000000E".ToCharArray();

            Dictionary<string, int> fingerPositions = new Dictionary<string, int>
            {
                {"leftPinky", 1},
                {"leftRing", 2},
                {"leftMiddle", 3},
                {"leftIndex", 4},
                {"leftThumb", 5},
                {"rightThumb", 6},
                {"rightIndex", 7},
                {"rightMiddle", 8},
                {"rightRing", 9},
                {"rightPinky", 10}
            };

            if (fingerPositions.TryGetValue(fingerName, out int position)) mapping[position] = '1';

            return new string(mapping);
        }
        private void setParent()
        {
            leftPinky.ParentForm = this;
            leftRing.ParentForm = this;
            leftMiddle.ParentForm = this;
            leftIndex.ParentForm = this;
            leftThumb.ParentForm = this;
            rightThumb.ParentForm = this;
            rightIndex.ParentForm = this;
            rightMiddle.ParentForm = this;
            rightRing.ParentForm = this;
            rightPinky.ParentForm = this;
        }

        public void UpdateFingerMappingsDisplay()
        {
            foreach (var mapping in fingerMappings.Values)
            {
                mapping.Control.mapping.Text = "Assign";
                mapping.Control.mapping.ForeColor = Color.Gray;
                mapping.Control.mapping.Font = new Font(mapping.Control.mapping.Font, FontStyle.Regular);
            }

            if (currentSet?.KeyMappings == null) return;

            foreach (var mapping in currentSet.KeyMappings)
            {
                string fingerCode = mapping.Key;
                if (fingerCode.Length != 12 || !fingerCode.StartsWith("S") || !fingerCode.EndsWith("E"))
                    continue;

                // Count how many fingers are used in this combination
                int activeFingers = fingerCode.Count(c => c == '1');

                for (int i = 1; i <= 10; i++)
                {
                    if (fingerCode[i] == '1')
                    {
                        var finger = fingerMappings.Values.FirstOrDefault(f => f.Position == i);
                        if (finger.Control != null)
                        {
                            // Only show the mapping on each finger if it's a single finger mapping
                            if (activeFingers == 1)
                            {
                                finger.Control.mapping.Text = string.Join(" + ", mapping.Value);
                                finger.Control.mapping.ForeColor = Color.White;
                                finger.Control.mapping.Font = new Font(finger.Control.mapping.Font, FontStyle.Bold);
                                finger.Control.LoadCombinations();
                            }
                        }
                    }
                }
            }
        }

        private void proceedToAssign_Click(object sender, EventArgs e)
        {
            if (currentCombination.ToString().Count(c => c == '1') > 1)
            {
                recordedCombinationTextBox2.Text = KeyCodeConverter.ConvertToFingerCombination(currentCombination.ToString());
                recordedCombination = currentCombination.ToString();
                combinationMode = true;
                ShowPanel(PanelState.AssignMenu);
            }
            else
            {
                MessageBox.Show("Please select at least two finger for the combination.",
                    "Invalid Combination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fingerClick(object sender, EventArgs e)
        {
            var button = (Guna.UI2.WinForms.Guna2Button)sender;
            string buttonName = button.Name;
            buttonName = buttonName.Substring(0, 1) + char.ToUpper(buttonName[1]) + buttonName.Substring(2);

            string fingerName;
            if (buttonName.StartsWith("L"))
            {
                fingerName = "left" + buttonName.Substring(1);
            }
            else if (buttonName.StartsWith("R"))
            {
                fingerName = "right" + buttonName.Substring(1);
            }
            else
            {
                return;
            }

            Dictionary<string, int> fingerPositions = new Dictionary<string, int>
            {
                {"leftPinky", 1},
                {"leftRing", 2},
                {"leftMiddle", 3},
                {"leftIndex", 4},
                {"leftThumb", 5},
                {"rightThumb", 6},
                {"rightIndex", 7},
                {"rightMiddle", 8},
                {"rightRing", 9},
                {"rightPinky", 10}
            };

            if (fingerPositions.TryGetValue(fingerName, out int position))
            {
                // Toggle the finger state
                if (currentCombination[position] == '0')
                {
                    currentCombination[position] = '1';
                    selectedFingers.Add(fingerName);
                }
                else
                {
                    currentCombination[position] = '0';
                    selectedFingers.Remove(fingerName);
                }

                recordedCombinationTextBox.Text = KeyCodeConverter.ConvertToFingerCombination(currentCombination.ToString());
            }

        }
        private void ShowPanel(PanelState state)
        {
            assignMenu.BorderThickness = 0;
            keySet.Visible = false;
            assignMenu.Visible = false;
            recordCombination.Visible = false;
            assignOptions.Visible = false;
            recordedCombinationTextBox2.Visible = false;
            combinationLabel.Visible = false;

            if (!(state == PanelState.AssignMenu && combinationMode)) combinationMode = false;

            switch (state)
            {
                case PanelState.KeySet:
                    keySet.Visible = true;
                    break;
                case PanelState.AssignMenu:
                    assignMenu.Visible = true;
                    if (combinationMode)
                    {
                        recordedCombinationTextBox2.Visible = true;
                        combinationLabel.Visible = true;
                        assignMenu.BorderThickness = 2;
                    }
                    break;
                case PanelState.RecordCombination:
                    recordCombination.Visible = true;
                    ResetCombinationState();
                    break;
            }
            moveDropdown();
        }

        private void ResetCombinationState()
        {
            currentCombination.Clear();
            currentCombination.Append("S0000000000E");
            selectedFingers.Clear();
            recordedCombinationTextBox.Text = "";
            recordedCombinationTextBox2.Text = "";

            foreach (var button in fingerList.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                button.Checked = false;
            }
        }
        private void moveDropdown()
        {
            keyChoices.Parent.Controls.Remove(keyChoices);
            int xPos = panel6.Location.X + panel6.Width - keyChoices.Width;
            int yPos = panel6.Location.Y + (panel6.Height - keyChoices.Height) / 2;
            keyChoices.Location = new Point(xPos, yPos);
            assignMenu.Controls.Add(keyChoices);
            keyChoices.BringToFront();
        }

        public void MarkAsModified()
        {
            HasUnsavedChanges = true;
            
            // Notify the parent Home form that there are unsaved changes
            if (home?.profileList != null)
            {
                home.profileList.DisableProfileSwitching = true;
            }
        }
        public void HandleCombinationMapping(string displayText, string commandValue)
        {
            if (!combinationMode) return;
            var result = MessageBox.Show(
                $"Do you want to map '{displayText}' to the finger combination '{KeyCodeConverter.ConvertToFingerCombination(recordedCombination)}'?",
                "Confirm Mapping",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (currentSet?.KeyMappings == null) return;

                // Update or add the mapping
                if (currentSet.KeyMappings.ContainsKey(recordedCombination))
                {
                    currentSet.KeyMappings[recordedCombination] = new List<string> { commandValue };
                }
                else
                {
                    currentSet.KeyMappings.Add(recordedCombination, new List<string> { commandValue });
                }

                // Mark as modified and update display
                MarkAsModified();
                PopulateKeyMappings(currentSet);

                // Return to key set view
                ShowPanel(PanelState.KeySet);
            }
        }
    }
}
