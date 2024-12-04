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

namespace TypeIT.Forms
{
    public partial class EditActivation : Form
    {
        public StringBuilder editActivationCombination = new StringBuilder("S0000000000E");
        private HashSet<string> selectedFingers = new HashSet<string>();
        public string SelectedCombination => editActivationCombination.ToString();
        private KeyMappingSet currentSet;
        private Action<string> onComplete;

        public EditActivation(KeyMappingSet set, Action<string> onCompleteCallback)
        {
            InitializeComponent();
            currentSet = set;
            onComplete = onCompleteCallback;
        }

        private void Lpinky_Click(object sender, EventArgs e)
        {

        }

        private void finger_click(object sender, EventArgs e)
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
                if (editActivationCombination[position] == '0')
                {
                    editActivationCombination[position] = '1';
                    selectedFingers.Add(fingerName);
                }
                else
                {
                    editActivationCombination[position] = '0';
                    selectedFingers.Remove(fingerName);
                }

                recordedCombinationTextBox.Text = KeyCodeConverter.ConvertToFingerCombination(editActivationCombination.ToString());
            }
        }
        private void ResetCombinationState()
        {
            editActivationCombination.Clear();
            editActivationCombination.Append("S0000000000E");
            selectedFingers.Clear();
            recordedCombinationTextBox.Text = "";

            foreach (var button in fingerList.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                button.Checked = false;
            }
        }

        private void completeActivationEdit_Click(object sender, EventArgs e)
        {
            if (editActivationCombination.ToString().Count(c => c == '1') < 1)
            {
                MessageBox.Show("Please select at least one finger for the activation combination.",
                    "Invalid Combination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if this combination is already used by another set
            bool isUsed = Program.CurrentSelectedMappingProfile.Sets.Any(s => 
                s.Value != currentSet && s.Value.ActivationKey == editActivationCombination.ToString());

            if (isUsed)
            {
                MessageBox.Show("This finger combination is already used by another set.",
                    "Duplicate Combination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            onComplete?.Invoke(editActivationCombination.ToString());
            this.Close();
        }

        private void cancelActivationEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
