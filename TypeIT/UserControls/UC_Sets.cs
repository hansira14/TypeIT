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
    public partial class UC_Sets : UserControl
    {
        public bool isSelected = false;
        public string SetName { get; private set; }
        public event EventHandler SetSelected;

        public UC_Sets(string setName, bool selected = false, string displayName="??")
        {
            InitializeComponent();
            SetName = setName;
            isSelected = selected;
            set.Text = displayName;
            UpdateSelection();
            
            set.Click += Set_Click;
        }

        private void Set_Click(object sender, EventArgs e)
        {
            SetSelected?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateSelection()
        {
            set.CustomBorderThickness = isSelected ? 
                new Padding(0, 0, 0, 2) : 
                new Padding(0, 0, 0, 0);
        }
    }
}
