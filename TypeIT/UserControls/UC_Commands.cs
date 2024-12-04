using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeIT.UserControls;

namespace TypeIT
{
    public partial class UC_Commands : UserControl
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
        public string KeyCombination { get; private set; }
        public string Command { get; private set; }

        public UC_Commands()
        {
            InitializeComponent();
        }

        public UC_Commands(string keyCombination, string command)
        {
            InitializeComponent();
            KeyCombination = keyCombination;
            Command = command;

            mapping.Text = keyCombination;
            output.Text = command;
        }

        private void UC_Key_Load(object sender, EventArgs e)
        {
            mapping.Top = (this.Height - mapping.Height) / 2;
            output.Top = (this.Height - output.Height) / 2;
        }

        private void command_MouseDown(object sender, MouseEventArgs e)
        {
            if (_parentForm == null) return;
            if(_parentForm.combinationMode) return;

            var dragData = new DataObject();
            dragData.SetData("DisplayText", KeyCombination);
            dragData.SetData("Command", Command);

            DoDragDrop(dragData, DragDropEffects.All);
        }

        private void mapping_Click(object sender, EventArgs e)
        {
            if (_parentForm == null) return;
            _parentForm.HandleCombinationMapping(KeyCombination, Command);
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                OnMouseClick(e);
            }
        }
    }
}
