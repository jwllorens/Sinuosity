using Sinuosity.Common;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;



namespace Sinuosity.Forms.Custom_Controls
{
    [ToolboxItem(true)]
    public class ValueInput_Static_Angle : Control
    {
        private string unitString = null;
        private string currentDisplayText = null;
        private decimal? currentValue = null;
        private UnitAngle currentUnit = null;
        private int precision = 3;
        private int unitBoxWidth = 44;
        private int gap = 4;
        private bool isUserEditing = false; // Flag to track user edits

        private readonly TextBox textBox;
        private readonly TextBox unitBox;

        #region Designer Properties
        [Category("Data")]
        [Description("Value will be read-only if true.")]
        public bool ReadOnly
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }
        [Category("Data")]
        [Description("Decimal place precision of displayed value.")]
        public int DisplayPrecision
        {
            get => precision;
            set
            {
                precision = value;
                UpdateTextBoxDisplay(); // Update display when precision changes
            }
        }
        [Category("Data")]
        [Description("Unit string.")]
        public string UnitString
        {
            get => unitString;
            set
            {
                unitString = value;
                currentUnit = Units.GetUnits<UnitAngle>().TryGetValue(unitString, out UnitAngle u) ? u : null;
            }
        }
        [Category("Appearance")]
        [Description("The width of the ComboBox.")]
        public int UnitBoxWidth
        {
            get => unitBoxWidth;
            set
            {
                unitBoxWidth = Math.Max(value, 20);
                UpdateLayout();
                Invalidate();
            }
        }
        [Category("Appearance")]
        [Description("The gap in pixels between the TextBox and ComboBox.")]
        public int Gap
        {
            get => gap;
            set
            {
                gap = Math.Max(value, 0);
                UpdateLayout();
                Invalidate();
            }
        }
        #endregion

        public ValueInput_Static_Angle()
        {
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Arial", 8.25F),
                Margin = new Padding(1)
            };
            unitBox = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Arial", 8.25F, FontStyle.Bold),
                Margin = new Padding(1),
                ReadOnly = true,
                TabStop = false
            };

            Controls.Add(textBox);
            Controls.Add(unitBox);

            MinimumSize = new Size(unitBoxWidth + gap + 50, 20);
            MaximumSize = new Size(500, 20);
            Size = new Size(100, 20);

            if (!string.IsNullOrEmpty(unitString) && Units.GetUnits<UnitAngle>().TryGetValue(unitString, out UnitAngle value))
            {
                currentUnit = value;
            }
            else
            {
                currentUnit = null;
            }
            UpdateLayout();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                textBox?.Dispose();
                unitBox?.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.KeyPress += TextBox_KeyPress;
            textBox.Enter += TextBox_Enter; // Show full precision on enter
            textBox.Leave += TextBox_Leave; // Round on leave
            unitBox.Text = currentUnit?.ToString();
        }
        protected override void OnLeave(EventArgs e)
        {
            if (!DesignMode && !ReadOnly)
            {
                isUserEditing = false;
                UpdateTextBoxDisplay(); // Restore rounded value
            }
            base.OnLeave(e);
        }

        #region Layout Management
        private void UpdateLayout()
        {
            unitBox.Location = new Point(Width - unitBoxWidth, 0);
            unitBox.Size = new Size(unitBoxWidth, Height);

            int textBoxWidth = Width - unitBoxWidth - gap;
            textBox.Location = new Point(0, 0);
            textBox.Size = new Size(Math.Max(textBoxWidth, 0), Height);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateLayout();
            Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateLayout();
            Invalidate();
        }
        #endregion

        #region Unit and Value Management
        public decimal? Value
        {
            get => DesignMode ? 0m : currentValue;
            set
            {
                if (!DesignMode)
                {
                    currentValue = value.HasValue ? (decimal?)value : null;
                    UpdateTextBoxDisplay();
                }
            }
        }
        public UnitAngle Unit
        {
            get => !DesignMode ? currentUnit : null;
        }
        private void UpdateTextBoxDisplay()
        {
            if (!DesignMode && !isUserEditing) // Only update if not user editing
            {
                textBox.Text = currentValue.HasValue ? Math.Round(currentValue.Value, precision).ToString($"F{precision}") : string.Empty;
                currentDisplayText = textBox.Text;
            }
        }
        private string RoundToString(decimal? value)
        {
            if (value != null)
            {
                string fullString = value.Value.ToString("G29");
                string[] parts = fullString.Split('.');
                if (parts.Length == 1) return $"{parts[0]}.{new string('0', precision)}";
                string decimalPart = parts[1].TrimEnd('0');
                if (decimalPart.Length < precision) return $"{parts[0]}.{decimalPart.PadRight(precision, '0')}";
                return $"{parts[0]}{(decimalPart.Length > 0 ? '.' + decimalPart : "")}";
            }
            return null;
        }
        #endregion

        #region Event Handlers
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (!DesignMode && !ReadOnly)
            {
                string displayValue = null;
                if (currentValue.HasValue) displayValue = RoundToString(currentValue.Value);
                textBox.Text = displayValue; // Full precision, no trailing zeros
            }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (!DesignMode && !ReadOnly)
            {
                if (currentValue.HasValue) UpdateTextBoxDisplay(); // Restore rounded value
            }
        }
        private void TextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                decimal? newValue = null;
                if (decimal.TryParse(textBox.Text, out decimal result)) newValue = result; // check user entry
                if (currentValue != newValue) isUserEditing = true; // Set flag to indicate user is editing
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ReadOnly)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        Value = null;
                    }
                    else if (decimal.TryParse(textBox.Text, out decimal result))
                    {
                        Value = result; // Store full precision
                    }
                    else
                    {
                        Value = currentValue; // Revert to original
                    }
                    isUserEditing = false; // Reset flag after commit
                    OnKeyDown(new KeyEventArgs(Keys.Enter));
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}