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
        private static readonly Color CommandsColor = Color.FromArgb(128, 128, 64);
        private string recordedCombination;
        private bool combinationMode = false;
        private HashSet<string> selectedFingers = new HashSet<string>();
        private StringBuilder currentCombination = new StringBuilder("S0000000000E");
        private SerialCommunicationModel _serialComm;

        public SerialCommunicationModel SerialComm
        {
            get { return _serialComm; }
            set
            {
                _serialComm = value;
            }
        }
        public Customize(Home home)
        {
            InitializeComponent();
            PopulateSets();
            PopulateToBeAssignedList();
            this.home = home;
            setParent();

            keyChoices.Parent.Controls.Remove(keyChoices);
            //keyChoices.Location = new Point(panel6.Width - keyChoices.Width - 10, (panel6.Height - keyChoices.Height) / 2);
            int xPos = panel6.Location.X + panel6.Width - keyChoices.Width;
            int yPos = panel6.Location.Y + (panel6.Height - keyChoices.Height) / 2;
            keyChoices.Location = new Point(xPos, yPos);
            assignMenu.Controls.Add(keyChoices);
            keyChoices.BringToFront();
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
            keyMaps.PerformLayout();
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
            keySet.Visible = false;
            assignMenu.Visible = true;
            combinationMode = false;
            recordedCombinationTextBox2.Visible = false;
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
            assignMenu.Visible = false;
            combinationMode = false;
            recordedCombinationTextBox2.Visible = false;
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
                combinationMode = false;
                recordedCombinationTextBox2.Visible = false;
                assignOptions.Visible = false;
                keySet.Visible = true;
                assignMenu.Visible = false;
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
            assignMenu.Visible = true;
            keySet.Visible = false;
            recordCombination.Visible = false;
            assignOptions.Visible = false;
            combinationMode = false;
            recordedCombinationTextBox2.Visible = false;
        }

        private void combinationButton_Click(object sender, EventArgs e)
        {
            recordCombination.Visible = true;
            keySet.Visible = false;
            assignMenu.Visible = false;
            assignOptions.Visible = false;

            currentCombination.Clear();
            currentCombination.Append("S0000000000E");
            selectedFingers.Clear();
            recordedCombinationTextBox.Text = "";
            recordedCombinationTextBox2.Text = "";
            //_serialComm.CombinationReceived += HandleGloveInput;
        }

        private void cancelRecord_Click(object sender, EventArgs e)
        {
            keySet.Visible = true;
            recordCombination.Visible = false;
            assignMenu.Visible = false;
            combinationMode = false;
            recordedCombinationTextBox2.Visible = false;

            //_serialComm.CombinationReceived -= HandleGloveInput;
            foreach(var button in fingerList.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                button.Checked = false;
            }
            currentCombination.Clear();
            currentCombination.Append("S0000000000E");
            selectedFingers.Clear();
            recordedCombinationTextBox.Text = "";
            recordedCombinationTextBox2.Text = "";
        }

        private void keyTypeButton_Click(object sender, EventArgs e)
        {
            currentKeyMapType = ((Button)sender).Text;
            currentKeyType.Text = currentKeyMapType;
            ((Button)sender).Visible = false;
            keyTypeButton.Visible = (currentKeyType.Text != "Keys");
            commandTypeButton.Visible = (currentKeyType.Text != "Commands");
            macroTypeButton.Visible = (currentKeyType.Text != "Macros");

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
                ActivationKey = "", // Default activation key
                KeyMappings = new Dictionary<string, List<string>>()
            };

            Program.CurrentSelectedMappingProfile.Sets.Add(newSet.ActivationKey, newSet);

            saveChanges.Visible = true;
            discardChanges.Visible = true;

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
            toBeAssignedList.Controls.Clear();

            switch (currentKeyMapType)
            {
                case "Keys":
                    // Basic Keys
                    foreach (var key in KeyboardConstants.BasicKeys)
                    {
                        AddKeyControl(key.Key, key.Value, BasicKeysColor);
                    }

                    // Function Keys
                    foreach (var key in KeyboardConstants.FunctionKeys)
                    {
                        AddKeyControl(key.Key, key.Value, FunctionKeysColor);
                    }

                    // Special Keys
                    foreach (var key in KeyboardConstants.SpecialKeys)
                    {
                        AddKeyControl(key.Key, key.Value, SpecialKeysColor);
                    }

                    // Modifier Keys
                    foreach (var key in KeyboardConstants.ModifierKeys)
                    {
                        AddKeyControl(key.Key, key.Value, ModifierKeysColor);
                    }
                    break;

                case "Commands":
                    foreach (var command in KeyboardConstants.CommonCombinations)
                    {
                        var commandControl = new UC_Commands(command.Key, string.Join(" + ", command.Value));
                        commandControl.Dock = DockStyle.Top;
                        toBeAssignedList.Controls.Add(commandControl);
                    }
                    break;

                case "Macros":
                    // To be implemented later
                    break;
            }
        }

        private void AddKeyControl(string text, string value, Color color)
        {
            var keyControl = new UC_KeyCharacter();
            keyControl.SetKeyDetails(text, value, color);
            keyControl.Margin = new Padding(0, 0, 15, 17);
            keyControl.Size = new Size(82, 96);
            toBeAssignedList.Controls.Add(keyControl);
        }

        public string UpdateFingerMapping(string fingerName)
        {
            // Initialize a char array with '0's and 'S' prefix and 'E' suffix
            char[] mapping = "S0000000000E".ToCharArray();

            // Map finger names to their positions (1-based index)
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

            // Set the corresponding position to '1'
            if (fingerPositions.TryGetValue(fingerName, out int position))
            {
                mapping[position] = '1';
            }

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
            // Clear all finger displays first
            leftPinky.mapping.Text = "";
            leftRing.mapping.Text = "";
            leftMiddle.mapping.Text = "";
            leftIndex.mapping.Text = "";
            leftThumb.mapping.Text = "";
            rightThumb.mapping.Text = "";
            rightIndex.mapping.Text = "";
            rightMiddle.mapping.Text = "";
            rightRing.mapping.Text = "";
            rightPinky.mapping.Text = "";

            if (currentSet?.KeyMappings == null) return;

            // Dictionary to map finger positions to controls
            var fingerControls = new Dictionary<int, UC_Finger>
            {
                {1, leftPinky},
                {2, leftRing},
                {3, leftMiddle},
                {4, leftIndex},
                {5, leftThumb},
                {6, rightThumb},
                {7, rightIndex},
                {8, rightMiddle},
                {9, rightRing},
                {10, rightPinky}
            };

            foreach (var mapping in currentSet.KeyMappings)
            {
                string fingerCode = mapping.Key;
                if (fingerCode.Length != 12 || !fingerCode.StartsWith("S") || !fingerCode.EndsWith("E"))
                    continue;

                // Find which finger position has '1'
                for (int i = 1; i <= 10; i++)
                {
                    if (fingerCode[i] == '1' && fingerControls.ContainsKey(i))
                    {
                        // Display the first command/key for this finger
                        fingerControls[i].mapping.Text = string.Join(" + ", mapping.Value);
                        break;
                    }
                }
            }
        }

        private void proceedToAssign_Click(object sender, EventArgs e)
        {
            if (currentCombination.ToString().Count(c => c == '1') > 1)
            {
                combinationMode = true;
                recordedCombinationTextBox2.Visible = true;
                recordedCombinationTextBox2.Text = KeyCodeConverter.ConvertToFingerCombination(currentCombination.ToString());
                recordedCombination = currentCombination.ToString();

                assignMenu.Visible = true;
                keySet.Visible = false;
                recordCombination.Visible = false;
                assignOptions.Visible = false;
                combinationMode = true;
                recordedCombinationTextBox2.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select at least two finger for the combination.",
                    "Invalid Combination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleGloveInput(string fingerCombination)
        {
            // Only process input when recording is active and the combination is valid
            if (recordCombination.Visible &&
                fingerCombination.Length == 12 &&
                fingerCombination.StartsWith("S") &&
                fingerCombination.EndsWith("E"))
            {
                // Count the number of active fingers (1s)
                int activeFingers = fingerCombination.Count(c => c == '1');

                // Only process if there are multiple fingers pressed
                if (activeFingers >= 2)
                {
                    this.Invoke(() =>
                    {
                        currentCombination.Clear();
                        currentCombination.Append(fingerCombination);
                        recordedCombinationTextBox.Text = KeyCodeConverter.ConvertToFingerCombination(fingerCombination);
                        recordedCombinationTextBox2.Text = KeyCodeConverter.ConvertToFingerCombination(fingerCombination);

                        // Update UI buttons to match the input
                        UpdateFingerButtons(fingerCombination);
                    });
                }
            }
        }

        private void UpdateFingerButtons(string combination)
        {
            Dictionary<int, string> buttonMapping = new Dictionary<int, string>
            {
                {1, "Lpinky"},
                {2, "Lring"},
                {3, "Lmiddle"},
                {4, "Lindex"},
                {5, "Lthumb"},
                {6, "Rthumb"},
                {7, "Rindex"},
                {8, "Rmiddle"},
                {9, "Rring"},
                {10, "Rpinky"}
            };

            for (int i = 1; i <= 10; i++)
            {
                if (buttonMapping.TryGetValue(i, out string buttonName))
                {
                    var button = this.Controls.Find(buttonName, true).FirstOrDefault() as Guna.UI2.WinForms.Guna2Button;
                    if (button != null)
                    {
                        button.Checked = combination[i] == '1';
                    }
                }
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

                // Update the textbox with the current combination
                recordedCombinationTextBox.Text = KeyCodeConverter.ConvertToFingerCombination(currentCombination.ToString());
                recordedCombinationTextBox2.Text = KeyCodeConverter.ConvertToFingerCombination(currentCombination.ToString());
            }
        }
    }
}
