using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sinuosity.Forms.Custom_Controls
{
    public class GroupBox_Bordered : GroupBox
    {
        private Color _borderColor = Color.Black;

        public GroupBox_Bordered()
        {
            // Enable double buffering to reduce flickering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        [Category("Appearance")]
        [Description("The color of the group box border")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate(); // Redraw when the border color changes
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Measure the text size
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);

            // Define the text rectangle (where the text will be drawn)
            Rectangle textRect = new Rectangle(6, 0, tSize.Width, tSize.Height);

            // Define the border rectangle
            int borderTop = tSize.Height / 2;
            Rectangle borderRect = new Rectangle(0, borderTop, Width - 1, Height - borderTop - 1);

            // Draw the background for the text area to match the control's background
            using (SolidBrush backBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(backBrush, textRect);
            }

            // Draw the text
            TextRenderer.DrawText(e.Graphics, Text, Font, textRect, ForeColor, TextFormatFlags.Left);

            // Draw the border as line segments to avoid the text area
            using (Pen borderPen = new Pen(_borderColor))
            {
                // Top-left segment (before text)
                e.Graphics.DrawLine(borderPen, 0, borderTop, 6, borderTop);

                // Top-right segment (after text)
                int textEndX = 6 + tSize.Width + 2; // Add small padding
                if (textEndX < Width - 1)
                {
                    e.Graphics.DrawLine(borderPen, textEndX, borderTop, Width - 1, borderTop);
                }

                // Right side
                e.Graphics.DrawLine(borderPen, Width - 1, borderTop, Width - 1, Height - 1);

                // Bottom
                e.Graphics.DrawLine(borderPen, Width - 1, Height - 1, 0, Height - 1);

                // Left side
                e.Graphics.DrawLine(borderPen, 0, Height - 1, 0, borderTop);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e); // Let the base class handle the background
        }
    }
}