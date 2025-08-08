using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Sinuosity.Forms.Custom_Controls
{
    public class Label_Subscript : Label
    {
        private string _subscriptText = string.Empty;
        private float _subscriptSizeRatio = 0.7f;
        private float _subscriptOffsetRatio = 0.3f;
        private float _subscriptHorizontalOffset = 0f;
        private const float RightPadding = 3f; // Standard padding for right edge, matching typical Label behavior

        [Category("Appearance")]
        [Description("The subscript text to display after the main text")]
        public string SubscriptText
        {
            get => _subscriptText;
            set { _subscriptText = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Ratio of subscript font size to main text size (0.1-1.0)")]
        [DefaultValue(0.7f)]
        public float SubscriptSizeRatio
        {
            get => _subscriptSizeRatio;
            set
            {
                _subscriptSizeRatio = Math.Max(0.1f, Math.Min(1.0f, value));
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Vertical offset ratio for subscript (0.0-1.0)")]
        [DefaultValue(0.3f)]
        public float SubscriptOffsetRatio
        {
            get => _subscriptOffsetRatio;
            set
            {
                _subscriptOffsetRatio = Math.Max(0.0f, Math.Min(1.0f, value));
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Horizontal offset for subscript in pixels (can be negative)")]
        [DefaultValue(0f)]
        public float SubscriptHorizontalOffset
        {
            get => _subscriptHorizontalOffset;
            set
            {
                _subscriptHorizontalOffset = value;
                Invalidate();
            }
        }

        public Label_Subscript()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Font regularFont = new Font(Font.FontFamily, Font.Size, Font.Style))
            using (Font subscriptFont = new Font(Font.FontFamily, Font.Size * SubscriptSizeRatio, Font.Style))
            {
                SizeF mainTextSize = g.MeasureString(Text, regularFont);
                SizeF subscriptSize = g.MeasureString(SubscriptText, subscriptFont);
                bool isRightJustified = TextAlign == ContentAlignment.TopRight ||
                                        TextAlign == ContentAlignment.MiddleRight ||
                                        TextAlign == ContentAlignment.BottomRight;
                string colonText = isRightJustified ? ":" : "";
                SizeF colonSize = isRightJustified ? g.MeasureString(colonText, regularFont) : SizeF.Empty;
                float contentWidth = mainTextSize.Width + SubscriptHorizontalOffset + subscriptSize.Width + colonSize.Width;
                float totalWidth = contentWidth + (isRightJustified ? RightPadding : 0);

                // Calculate starting positions based on TextAlign
                float startX = 0;
                float startY = 0;

                // Horizontal alignment
                switch (TextAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.BottomLeft:
                        startX = 0;
                        break;
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:
                        startX = (Width - totalWidth) / 2;
                        break;
                    case ContentAlignment.TopRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                        startX = Width - totalWidth;
                        break;
                }

                // Calculate the total height based only on the main text (and colon, which uses the same font)
                float totalHeight = mainTextSize.Height;

                // Vertical alignment
                switch (TextAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopRight:
                        startY = 0;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleRight:
                        // Center the main text's bounding box
                        startY = (Height - totalHeight) / 2;
                        // Fine-tune adjustment to match standard Label behavior
                        startY -= 1f; // Slight adjustment to align visually with standard Label
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        startY = Height - totalHeight;
                        break;
                }

                // Draw main text
                g.DrawString(Text, regularFont, new SolidBrush(ForeColor), startX, startY);

                // Draw subscript text if present
                if (!string.IsNullOrEmpty(SubscriptText))
                {
                    float subscriptX = startX + mainTextSize.Width + SubscriptHorizontalOffset;
                    float subscriptOffset = mainTextSize.Height * SubscriptOffsetRatio;
                    float subscriptY = startY + subscriptOffset;
                    g.DrawString(SubscriptText, subscriptFont, new SolidBrush(ForeColor), subscriptX, subscriptY);
                }

                // Draw colon if right-justified
                if (isRightJustified && !string.IsNullOrEmpty(colonText))
                {
                    float colonX = startX + mainTextSize.Width + SubscriptHorizontalOffset + subscriptSize.Width;
                    g.DrawString(colonText, regularFont, new SolidBrush(ForeColor), colonX, startY);
                }
            }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            using (Graphics g = CreateGraphics())
            using (Font regularFont = new Font(Font.FontFamily, Font.Size, Font.Style))
            using (Font subscriptFont = new Font(Font.FontFamily, Font.Size * SubscriptSizeRatio, Font.Style))
            {
                SizeF mainSize = g.MeasureString(Text, regularFont);
                SizeF subSize = g.MeasureString(SubscriptText, subscriptFont);
                bool isRightJustified = TextAlign == ContentAlignment.TopRight ||
                                        TextAlign == ContentAlignment.MiddleRight ||
                                        TextAlign == ContentAlignment.BottomRight;
                SizeF colonSize = isRightJustified ? g.MeasureString(":", regularFont) : SizeF.Empty;
                float contentWidth = mainSize.Width + subSize.Width + colonSize.Width + SubscriptHorizontalOffset;
                float totalWidth = contentWidth + (isRightJustified ? RightPadding : 0);

                // Calculate total height based only on the main text for centering purposes
                float totalHeight = mainSize.Height;

                // Adjust for preferred size to include space for subscript below
                float subscriptOffset = mainSize.Height * SubscriptOffsetRatio;
                if (!string.IsNullOrEmpty(SubscriptText))
                {
                    float subscriptHeight = subSize.Height;
                    float subscriptBottom = subscriptOffset + subscriptHeight;
                    totalHeight = Math.Max(totalHeight, subscriptBottom);
                }

                return new Size((int)totalWidth, (int)totalHeight);
            }
        }
    }
}