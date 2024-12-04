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
        }

        private void mapping_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Join("\n", combinationMappings), "Combinations");
        }
    }
}
