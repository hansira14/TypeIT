using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeIT.UserControls
{
    public partial class UC_KeyCharacter : UserControl
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
        public string KeyText { get; private set; }
        public string KeyValue { get; private set; }
        public Color KeyColor { get; private set; }

        public UC_KeyCharacter()
        {
            InitializeComponent();
        }

        public void SetKeyDetails(string text, string value, Color color)
        {
            KeyText = text;
            KeyValue = value;
            KeyColor = color;
            guna2Button4.Text = text;
            guna2Button4.FillColor = color;
        }

        private void guna2Button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (_parentForm.combinationMode) return;
            DoDragDrop(KeyText, DragDropEffects.All);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            _parentForm.HandleCombinationMapping(KeyValue, KeyText);
        }
    }
}
