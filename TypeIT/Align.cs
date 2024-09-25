using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeIT
{
    internal static class Align
    {
        public static void centerControl(Control control)
        {
            control.Location = new Point((control.Parent.ClientSize.Width - control.Width) / 2, (control.Parent.ClientSize.Height - control.Height) / 2);
        }
        public static void centerControlVertical(Control control)
        {
            int x = control.Location.X; // Keep the original X position
            int y = (control.Parent.ClientSize.Height - control.Height) / 2; // Center vertically
            control.Location = new Point(x, y);
        }
        public static void centerControlHorizontal(Control control)
        {
            int x = (control.Parent.ClientSize.Width - control.Width) / 2; // Center horizontally
            int y = control.Location.Y; // Keep the original Y position
            control.Location = new Point(x, y);
        }
    }
}
