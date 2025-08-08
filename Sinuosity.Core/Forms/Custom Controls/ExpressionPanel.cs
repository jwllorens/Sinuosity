using System;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Windows.Forms;
using SkiaSharp;

namespace Sinuosity.Forms.Custom_Controls
{
    public enum ImageAlignment
    {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    [DesignerCategory("Code")]
    public class MathExpressionPanel : Panel
    {
        private string _text = string.Empty;
        private ImageAlignment _imageAlignment = ImageAlignment.MiddleCenter;
        private Bitmap _renderedBitmap;
        private static float superScriptFactor = 0.5f;
        private static float subScriptFactor = 0.3f;
        private static float scriptSizeFactor = 0.7f;
        private static float rescaleFactor = 10.0f;
        private static int imgPadding = 5;

        public MathExpressionPanel()
        {
            DoubleBuffered = true;
            BorderStyle = BorderStyle.FixedSingle;
            ResizeRedraw = true;
        }

        [Category("Appearance")]
        [Description("The mathematical expression to render (e.g., A_(bkf)={X}DA^(Y)).")]
        [DefaultValue("")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    UpdateRenderedBitmap();
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("The alignment of the rendered image within the control.")]
        [DefaultValue(ImageAlignment.MiddleCenter)]
        public ImageAlignment ImageAlignment
        {
            get => _imageAlignment;
            set
            {
                if (_imageAlignment != value)
                {
                    _imageAlignment = value;
                    Invalidate();
                }
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            UpdateRenderedBitmap();
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _renderedBitmap?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DesignMode)
            {
                string placeholderText = string.IsNullOrEmpty(_text) ? "MathExpressionPanel" : _text;
                using (Font font = new Font("Arial", 10f))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(placeholderText, font, Brushes.Black, ClientRectangle, sf);
                }
            }
            else if (_renderedBitmap != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                float x, y;
                switch (_imageAlignment)
                {
                    case ImageAlignment.TopLeft:
                        x = 0;
                        y = 0;
                        break;
                    case ImageAlignment.TopCenter:
                        x = (ClientSize.Width - _renderedBitmap.Width) / 2f;
                        y = 0;
                        break;
                    case ImageAlignment.TopRight:
                        x = ClientSize.Width - _renderedBitmap.Width;
                        y = 0;
                        break;
                    case ImageAlignment.MiddleLeft:
                        x = 0;
                        y = (ClientSize.Height - _renderedBitmap.Height) / 2f;
                        break;
                    case ImageAlignment.MiddleCenter:
                        x = (ClientSize.Width - _renderedBitmap.Width) / 2f;
                        y = (ClientSize.Height - _renderedBitmap.Height) / 2f;
                        break;
                    case ImageAlignment.MiddleRight:
                        x = ClientSize.Width - _renderedBitmap.Width;
                        y = (ClientSize.Height - _renderedBitmap.Height) / 2f;
                        break;
                    case ImageAlignment.BottomLeft:
                        x = 0;
                        y = ClientSize.Height - _renderedBitmap.Height;
                        break;
                    case ImageAlignment.BottomCenter:
                        x = (ClientSize.Width - _renderedBitmap.Width) / 2f;
                        y = ClientSize.Height - _renderedBitmap.Height;
                        break;
                    case ImageAlignment.BottomRight:
                        x = ClientSize.Width - _renderedBitmap.Width;
                        y = ClientSize.Height - _renderedBitmap.Height;
                        break;
                    default:
                        x = 0;
                        y = 0;
                        break;
                }

                e.Graphics.DrawImage(_renderedBitmap, x, y);
            }
        }

        private void UpdateRenderedBitmap()
        {
            _renderedBitmap?.Dispose();

            if (DesignMode)
            {
                _renderedBitmap = null;
                return;
            }

            if (!string.IsNullOrEmpty(_text))
            {
                try
                {
                    _renderedBitmap = RenderMathExpression(_text, Font);
                }
                catch (Exception)
                {
                    _renderedBitmap = null;
                }
            }
            else
            {
                _renderedBitmap = null;
            }
        }

        private static Bitmap RenderMathExpression(string expression, Font font)
        {
            
            float baseFontSize = font.Size * rescaleFactor;
            float scriptFontSize = font.Size * scriptSizeFactor * rescaleFactor;
            float kerningFactor = 0.0f;

            // Map System.Drawing.FontStyle to SkiaSharp.SKFontStyle
            SKFontStyle skFontStyle;
            if (font.Style.HasFlag(FontStyle.Bold) && font.Style.HasFlag(FontStyle.Italic))
                skFontStyle = SKFontStyle.BoldItalic;
            else if (font.Style.HasFlag(FontStyle.Bold))
                skFontStyle = SKFontStyle.Bold;
            else if (font.Style.HasFlag(FontStyle.Italic))
                skFontStyle = SKFontStyle.Italic;
            else
                skFontStyle = SKFontStyle.Normal;

            var typeface = SKTypeface.FromFamilyName(font.Name, skFontStyle);
            var baseFont = new SKFont(typeface, baseFontSize);
            baseFont.Edging = SKFontEdging.SubpixelAntialias;
            var scriptFont = new SKFont(typeface, scriptFontSize);
            scriptFont.Edging = SKFontEdging.SubpixelAntialias;
            var paint = new SKPaint();
            paint.IsAntialias = true;

            var segments = new List<(string text, string type)>();
            int i = 0;
            while (i < expression.Length)
            {
                if (i + 1 < expression.Length && (expression[i] == '^' || expression[i] == '_') && expression[i + 1] == '(')
                {
                    char marker = expression[i];
                    i += 2;
                    int start = i;
                    int parenCount = 1;

                    while (i < expression.Length && parenCount > 0)
                    {
                        if (expression[i] == '(') parenCount++;
                        else if (expression[i] == ')') parenCount--;
                        i++;
                    }

                    if (parenCount != 0)
                    {
                        throw new ArgumentException("Unmatched parenthesis in expression");
                    }

                    string scriptText = expression.Substring(start, i - start - 1);
                    string scriptType = marker == '^' ? "superscript" : "subscript";
                    segments.Add((scriptText, scriptType));
                }
                else
                {
                    int start = i;
                    while (i < expression.Length && (expression[i] != '^' && expression[i] != '_') || (i + 1 < expression.Length && expression[i + 1] != '('))
                    {
                        i++;
                    }
                    string normalText = expression.Substring(start, i - start);
                    segments.Add((normalText, "normal"));
                }
            }

            float totalWidth = 0;
            float currentX = 0;

            float baseAscent = -baseFont.Metrics.Ascent;
            float baseDescent = baseFont.Metrics.Descent;
            float baseHeight = baseAscent + baseDescent;

            float scriptAscent = -scriptFont.Metrics.Ascent;
            float scriptDescent = scriptFont.Metrics.Descent;
            float scriptHeight = scriptAscent + scriptDescent;

            float superscriptBaselineOffset = baseAscent * superScriptFactor;
            float superscriptTop = superscriptBaselineOffset + scriptAscent;
            float maxHeightAboveBaseline = Math.Max(baseAscent, superscriptTop);
            float maxHeightBelowBaseline = Math.Max(baseDescent, scriptDescent + baseHeight * subScriptFactor);
            float totalHeight = maxHeightAboveBaseline + maxHeightBelowBaseline;

            float[] widths = new float[segments.Count];
            float[] scriptXOffsets = new float[segments.Count];
            for (int j = 0; j < segments.Count; j++)
            {
                var (text, type) = segments[j];
                var fontToUse = type == "normal" ? baseFont : scriptFont;

                widths[j] = fontToUse.MeasureText((ReadOnlySpan<ushort>)(text.Split(' ').Select(s => ushort.Parse(s)).ToArray()));

                if (type == "subscript")
                {
                    scriptXOffsets[j] = -kerningFactor * baseFontSize;
                }
                else if (type == "superscript")
                {
                    scriptXOffsets[j] = -(2 * kerningFactor) * baseFontSize;
                }
                else
                {
                    scriptXOffsets[j] = 0;
                }

                widths[j] += 2f * scriptXOffsets[j];
                totalWidth += widths[j];
            }

            int bitmapWidth = (int)totalWidth + 2 * imgPadding;
            int bitmapHeight = (int)totalHeight + 2 * imgPadding;
            var highResBitmap = new SKBitmap(bitmapWidth, bitmapHeight);
            var canvas = new SKCanvas(highResBitmap);
            canvas.Clear(SKColors.Transparent);

            float baseLineY = maxHeightAboveBaseline;

            currentX = 0;
            for (int j = 0; j < segments.Count; j++)
            {
                var (text, type) = segments[j];
                var fontToUse = type == "normal" ? baseFont : scriptFont;
                paint.Color = SKColors.Black;
                float yOffset = 0;

                if (type == "subscript")
                {
                    yOffset = baseLineY + baseAscent * subScriptFactor;
                }
                else if (type == "superscript")
                {
                    yOffset = baseLineY - baseAscent * superScriptFactor;
                }
                else
                {
                    yOffset = baseLineY;
                }

                canvas.DrawText(text, currentX + scriptXOffsets[j] + imgPadding, yOffset + imgPadding, fontToUse, paint);
                currentX += widths[j];
            }

            var highResImage = SKImage.FromBitmap(highResBitmap);
            var highResData = highResImage.Encode(SKEncodedImageFormat.Png, 100);
            var highResStream = new MemoryStream(highResData.ToArray());
            var highResBitmapGdi = new Bitmap(highResStream);

            int finalWidth = (int)(bitmapWidth / rescaleFactor);
            int finalHeight = (int)(bitmapHeight / rescaleFactor);
            Bitmap finalBitmap = new Bitmap(finalWidth, finalHeight);

            using (Graphics graphics = Graphics.FromImage(finalBitmap))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphics.DrawImage(highResBitmapGdi, 0, 0, finalWidth, finalHeight);
            }

            return finalBitmap;
        }
    }
}