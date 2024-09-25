using System;
using System.Drawing; // For Graphics and Size
using System.Windows.Forms; // For Form

namespace TypeIT
{
    internal static class Responsive
    {
        public static void AdjustWindowSizeForDPI(Form form)
        {
            using (Graphics g = form.CreateGraphics()) // Use form to call CreateGraphics
            {
                float dpiX = g.DpiX;
                float dpiY = g.DpiY;

                // Let's assume we want the window to be 21cm tall (about 8.27 inches).
                float baseHeightInInches = 8.27f; // 21 cm in inches
                float baseHeightInPixels = baseHeightInInches * 96; // 96 DPI is standard

                // Adjust height based on current DPI
                float adjustedHeightInPixels = baseHeightInInches * dpiY;
                float adjustedWidthInPixels = form.Width * (adjustedHeightInPixels / form.Height); // Maintain aspect ratio

                form.Size = new Size((int)adjustedWidthInPixels, (int)adjustedHeightInPixels);
            }
        }
    }
}