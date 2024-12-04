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

namespace TypeIT.UserControls
{
    public partial class UC_Finger : UserControl
    {
        private Customize _parentForm;
        private UC_CombinationHover hoverControl;

        public List<string> combinationMappings { get; set; }
        public Customize ParentForm
        {
            get { return _parentForm; }
            set
            {
                _parentForm = value;
                LoadCombinations();
            }
        }

        public UC_Finger()
        {
            InitializeComponent();
            combinationMappings = new List<string>();
            
            // Create hover control
            hoverControl = new UC_CombinationHover(new List<string>());
            hoverControl.Visible = false;

            this.MouseEnter += Mapping_MouseEnter;
            this.MouseLeave += Mapping_MouseLeave;
            mapping.MouseEnter += Mapping_MouseEnter;
            mapping.MouseLeave += Mapping_MouseLeave;
        }

        private void Mapping_MouseEnter(object sender, EventArgs e)
        {
            mapping.ForeColor = Color.FromArgb(94, 148, 255);
            // Ensure combinations are up-to-date before showing hover
            LoadCombinations();
            
            if (combinationMappings.Count > 0)
            {
                hoverControl.combinations = combinationMappings;
                
                // Get mouse position relative to screen
                Point mousePosition = Control.MousePosition;
                
                // Convert screen coordinates to control's parent coordinates
                Point locationInParent = this.Parent.PointToClient(mousePosition);
                
                hoverControl.Location = new Point(
                    locationInParent.X + 5, // Add small offset from cursor
                    locationInParent.Y + 5
                );
                
                hoverControl.PopulateTable();
                hoverControl.BringToFront();
                hoverControl.Visible = true;
            }
        }

        private void Mapping_MouseLeave(object sender, EventArgs e)
        {
            hoverControl.Visible = false;
            mapping.ForeColor = Color.White;
        }

        private void UC_Finger_DragDrop(object sender, DragEventArgs e)
        {
            string displayText = null;
            string commandValue = null;

            // Check if this is a command drag-drop
            if (e.Data.GetDataPresent("DisplayText") && e.Data.GetDataPresent("Command"))
            {
                displayText = (string)e.Data.GetData("DisplayText");
                commandValue = (string)e.Data.GetData("Command");
            }
            else
            {
                // Handle regular key drag-drop
                commandValue = (string)e.Data.GetData(typeof(string));
                displayText = commandValue;
            }

            mapping.Text = displayText;
            e.Effect = DragDropEffects.All;

            if (_parentForm?.currentSet != null)
            {
                // Get the finger mapping based on the control name
                string fingerMapping = _parentForm.UpdateFingerMapping(this.Name);

                // Update or add the mapping using the actual command value
                if (_parentForm.currentSet.KeyMappings.ContainsKey(fingerMapping))
                {
                    _parentForm.currentSet.KeyMappings[fingerMapping] = new List<string> { commandValue };
                }
                else
                {
                    _parentForm.currentSet.KeyMappings.Add(fingerMapping, new List<string> { commandValue });
                }

                // Mark the profile as modified instead of directly manipulating buttons
                _parentForm.MarkAsModified();

                // Refresh the key mappings display
                _parentForm.PopulateKeyMappings(_parentForm.currentSet);
            }
        }

        private void UC_Finger_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private int GetFingerPosition()
        {
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

            return fingerPositions.TryGetValue(this.Name, out int position) ? position : -1;
        }
        public void LoadCombinations()
        {
            if (_parentForm?.currentSet == null) return;
            this.Parent.Controls.Add(hoverControl);
            combinationMappings = new List<string>();
            int fingerPosition = GetFingerPosition();

            if (fingerPosition == -1) return;

            foreach (var mapping in _parentForm.currentSet.KeyMappings)
            {
                string fingerCode = mapping.Key;
                if (fingerCode.Length == 12 &&
                    fingerCode.StartsWith("S") &&
                    fingerCode.EndsWith("E") &&
                    fingerCode[fingerPosition] == '1')
                {
                    // Count active fingers to determine if it's a combination
                    int activeFingers = fingerCode.Count(c => c == '1');
                    if (activeFingers > 1)
                    {
                        string displayText = $"{KeyCodeConverter.ConvertToFingerCombination2(fingerCode)} -> {string.Join(" + ", mapping.Value)}";
                        combinationMappings.Add(displayText);
                    }
                }
            }

            // Update hover control with new combinations
            if (hoverControl != null)
            {
                hoverControl.combinations = combinationMappings;
                hoverControl.PopulateTable();
            }
        }

        private void mapping_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Join("\n", combinationMappings), "Combinations");
        }
    }
}
