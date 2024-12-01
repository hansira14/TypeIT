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
            string keyValue = (string)e.Data.GetData(typeof(string));
            mapping.Text = keyValue;
            e.Effect = DragDropEffects.All;

            if (_parentForm?.currentSet != null)
            {
                // Get the finger mapping based on the control name
                string fingerMapping = _parentForm.UpdateFingerMapping(this.Name);
                
                // Update or add the mapping
                if (_parentForm.currentSet.KeyMappings.ContainsKey(fingerMapping))
                {
                    _parentForm.currentSet.KeyMappings[fingerMapping] = new List<string> { keyValue };
                }
                else
                {
                    _parentForm.currentSet.KeyMappings.Add(fingerMapping, new List<string> { keyValue });
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
