using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeIT
{
    public partial class UC_Commands : UserControl
    {
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
            // Create a custom data object that contains both the display text and actual command
            var dragData = new DataObject();
            dragData.SetData("DisplayText", KeyCombination);
            dragData.SetData("Command", Command);
            
            DoDragDrop(dragData, DragDropEffects.All);
        }
    }
}
