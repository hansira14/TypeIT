using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeIT.UserControls
{
    public partial class UC_Finger : UserControl
    {
        private Customize _parentForm;
        
        public Customize ParentForm
        {
            get { return _parentForm; }
            set 
            { 
                _parentForm = value;
            }
        }

        public UC_Finger()
        {
            InitializeComponent();
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

                // Show save/discard buttons
                if (_parentForm.saveChanges != null && _parentForm.discardChanges != null)
                {
                    _parentForm.saveChanges.Visible = true;
                    _parentForm.discardChanges.Visible = true;
                }

                // Refresh the key mappings display
                _parentForm.PopulateKeyMappings(_parentForm.currentSet);
            }
        }

        private void UC_Finger_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
