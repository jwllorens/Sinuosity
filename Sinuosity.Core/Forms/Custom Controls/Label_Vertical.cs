using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sinuosity.Forms.Custom_Controls
{
    public class Label_Vertical : System.Windows.Forms.Label
    {

        private bool bFlip = true;

        public Label_Vertical()
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            Brush textBrush = new SolidBrush(this.ForeColor);

            Matrix storedState = g.Transform;

            if (bFlip)
            {
                g.RotateTransform(180f);
                g.TranslateTransform(-ClientRectangle.Width, -ClientRectangle.Height);
            }
            g.DrawString(
                this.Text,
                this.Font,
                textBrush,
                ClientRectangle,
                stringFormat);

            g.Transform = storedState;
        }

        [Description("When this parameter is true the VLabel flips at 180 degrees."), Category("Appearance")]
        public bool Flip180
        {
            get
            {
                return bFlip;
            }
            set
            {
                bFlip = value;
                this.Invalidate();
            }
        }
    }
}