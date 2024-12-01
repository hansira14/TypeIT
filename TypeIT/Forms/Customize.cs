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
    public partial class Customize : Form
    {
        public KeyMappingSet currentSet;
        private List<UC_Sets> setControls = new List<UC_Sets>();
        private string currentKeyMapType = "Keys";
        public Customize()
        {
            InitializeComponent();
            PopulateSets();
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
    }
}
