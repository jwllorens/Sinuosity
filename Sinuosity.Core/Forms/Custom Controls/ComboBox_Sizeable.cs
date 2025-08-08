using System.Windows.Forms;
using System.Drawing; 
namespace Sinuosity.Forms.Custom_Controls
{
    class ComboBox_Sizeable : ComboBox
    {
        public ComboBox_Sizeable()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable; // Set the draw mode to owner-drawn
            this.MeasureItem += ComboBox_MeasureItem; // Measure item event
            this.DrawItem += ComboBox_DrawItem; // Draw item event
        }
        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ((ComboBox)sender).ItemHeight;
        }
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return; // Check if there’s a valid item to draw
            ComboBox combo = (ComboBox)sender; // Get the ComboBox
            string text = combo.Items[e.Index].ToString(); // Get the item text
            e.DrawBackground(); // Use the default background and text color based on selection state (white or highlighted if selected)
            using (Brush textBrush = new SolidBrush(e.ForeColor)) // Draw the text with the ComboBox's font
            {
                e.Graphics.DrawString(text, combo.Font, textBrush, e.Bounds.X, e.Bounds.Y);
            }
            e.DrawFocusRectangle();// Draw the focus rectangle if the item has focus
        }
    }
 }
