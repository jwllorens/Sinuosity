using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sinuosity.Forms.Custom_Controls
{
    public class TrackBar_Slim : TrackBar
    {
        private int _trackThickness = 10;
        private int _thumbSize = 16;
        private int _tickCount = 4;
        private Color _borderColor = Color.Black;
        private Color _trackColor = SystemColors.ControlDark;
        private bool _drawTrackBorder = false;

        public TrackBar_Slim()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            AutoSize = false;
        }

        [Category("Appearance")]
        [Description("The thickness of the track in pixels (height for horizontal, width for vertical)")]
        [DefaultValue(10)]
        public int TrackThickness
        {
            get => _trackThickness;
            set
            {
                _trackThickness = Math.Max(4, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The size of the thumb in pixels")]
        [DefaultValue(16)]
        public int ThumbSize
        {
            get => _thumbSize;
            set
            {
                _thumbSize = Math.Max(TrackThickness, value);
                Invalidate();
            }
        }

        [Category("Behavior")]
        [Description("The number of divisions for tick marks (minimum 1, results in tickCount + 1 ticks)")]
        [DefaultValue(4)]
        public int TickCount
        {
            get => _tickCount;
            set
            {
                _tickCount = Math.Max(1, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The color of the border around the control")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The color of the track")]
        [DefaultValue(typeof(Color), "ControlDark")]
        public Color TrackColor
        {
            get => _trackColor;
            set
            {
                _trackColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Whether to draw a black border around the track")]
        [DefaultValue(false)]
        public bool DrawTrackBorder
        {
            get => _drawTrackBorder;
            set
            {
                _drawTrackBorder = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle clientRect = ClientRectangle;

            // Clear the entire background to prevent artifacts
            g.Clear(BackColor);

            // Draw the border at the edge
            using (Pen borderPen = new Pen(BorderColor, 1))
            {
                Rectangle borderRect = new Rectangle(0, 0, clientRect.Width - 1, clientRect.Height - 1);
                g.DrawRectangle(borderPen, borderRect);
            }

            if (!Enabled)
            {
                base.OnPaint(e);
                return;
            }

            bool isVertical = Orientation == Orientation.Vertical;
            int trackLength = isVertical ? clientRect.Height : clientRect.Width;
            trackLength -= 3; // Your adjustment for spacing
            int borderOffset = 1; // 1px gap from border
            int thumbTravel = trackLength - ThumbSize - (2 * borderOffset); // 1px gap on each side
            int trackOffset = (ThumbSize / 2) + borderOffset + 1; // Your adjusted offset
            int adjustedTrackLength = thumbTravel; // Track matches thumb travel range

            // Calculate thumb position (left edge of thumb)
            int range = Maximum - Minimum;
            float valueRatio = range > 0 ? (float)(Value - Minimum) / range : 0;
            int thumbOffset = (int)(valueRatio * thumbTravel) + borderOffset + 1;

            // Draw the track
            Rectangle trackRect;
            int trackCenter;
            if (isVertical)
            {
                trackCenter = (clientRect.Width - TrackThickness) / 2;
                trackRect = new Rectangle(trackCenter, trackOffset, TrackThickness, adjustedTrackLength);
            }
            else
            {
                trackCenter = (clientRect.Height - TrackThickness) / 2 - 1;
                trackRect = new Rectangle(trackOffset, trackCenter, adjustedTrackLength, TrackThickness);
            }
            using (Brush trackBrush = new SolidBrush(TrackColor))
            {
                g.FillRectangle(trackBrush, trackRect);
            }
            if (DrawTrackBorder)
            {
                using (Pen trackBorderPen = new Pen(Color.Black, 1))
                {
                    g.DrawRectangle(trackBorderPen, trackRect);
                }
            }

            // Draw tick marks
            if (TickCount > 0)
            {
                using (Pen tickPen = new Pen(ForeColor, 1))
                {
                    int shortTickLength = 8;
                    int longTickLength = 12;
                    float tickSpacing = (float)thumbTravel / TickCount;

                    for (int i = 0; i <= TickCount; i++)
                    {
                        float tickPos = i * tickSpacing + trackOffset;
                        int roundedTickPos = (int)Math.Round(tickPos);
                        int tickLength = (i == 0 || i == TickCount) ? longTickLength : shortTickLength;

                        if (isVertical)
                        {
                            int tickX = trackCenter - (tickLength / 2) + (TrackThickness / 2);
                            g.DrawLine(tickPen, tickX, roundedTickPos, tickX + tickLength, roundedTickPos);
                        }
                        else
                        {
                            int tickY = trackCenter - (tickLength / 2) + (TrackThickness / 2);
                            g.DrawLine(tickPen, roundedTickPos, tickY, roundedTickPos, tickY + tickLength);
                        }
                    }
                }
            }

            // Draw the thumb
            Rectangle thumbRect;
            if (isVertical)
            {
                int thumbX = (clientRect.Width - ThumbSize) / 2;
                thumbRect = new Rectangle(thumbX, thumbOffset, ThumbSize, ThumbSize);
            }
            else
            {
                int thumbY = (clientRect.Height - ThumbSize) / 2 - 1;
                thumbRect = new Rectangle(thumbOffset, thumbY, ThumbSize, ThumbSize);
            }
            using (Brush thumbBrush = new SolidBrush(SystemColors.ControlLight))
            {
                g.FillEllipse(thumbBrush, thumbRect);
                using (Pen outlinePen = new Pen(SystemColors.ControlDark, 1))
                {
                    g.DrawEllipse(outlinePen, thumbRect);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateValueFromMouse(e.Location);
                Invalidate(); // Force redraw
                Capture = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Capture && e.Button == MouseButtons.Left)
            {
                UpdateValueFromMouse(e.Location);
                Invalidate(); // Force redraw
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Capture = false;
            Invalidate(); // Force redraw
            base.OnMouseUp(e);
        }

        private void UpdateValueFromMouse(Point mouseLocation)
        {
            int trackLength = Orientation == Orientation.Vertical ? Height : Width;
            trackLength -= 3; // Match OnPaint adjustment
            int borderOffset = 1;
            int thumbTravel = trackLength - ThumbSize - (2 * borderOffset);
            int mousePos = Orientation == Orientation.Vertical ? mouseLocation.Y : mouseLocation.X;
            float ratio = Math.Max(0f, Math.Min(1f, (float)(mousePos - (ThumbSize / 2) - borderOffset - 1) / thumbTravel));
            int range = Maximum - Minimum;
            Value = Minimum + (int)(ratio * range);
        }

        protected override Size DefaultSize => new Size(200, 20);
    }
}