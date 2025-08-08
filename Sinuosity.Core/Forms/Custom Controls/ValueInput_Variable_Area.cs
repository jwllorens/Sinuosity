using Sinuosity.Common;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinuosity.Forms.Custom_Controls
{
    [ToolboxItem(true)]
    public class ValueInput_Variable_Area : Control
    {
        public event EventHandler SelectedIndexChanged;
        private bool suppressSelectedIndexChanged = false;
        private string currentDisplayText = null;
        private decimal? currentValue = null;
        private UnitArea currentUnit = null;
        private UnitArea[] availableUnits;
        private int precision = 3;
        private int comboBoxWidth = 44;
        private int gap = 2;
        private bool isUserEditing = false; // Flag to track user edits

        private readonly TextBox textBox;
        private readonly ComboBox comboBox;
        private List<string> allowedUnitStrings = new List<string>();

        #region Designer Properties
        [Category("Data")]
        [Description("The list of allowed unit strings to filter available units.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> AllowedUnits
        {
            get => allowedUnitStrings;
            set
            {
                allowedUnitStrings = value ?? new List<string>();
                UpdateAvailableUnits();
            }
        }
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
        [Category("Appearance")]
        [Description("The width of the ComboBox.")]
        public int ComboBoxWidth
        {
            get => comboBoxWidth;
            set
            {
                comboBoxWidth = Math.Max(value, 20);
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

        public ValueInput_Variable_Area()
        {
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Arial", 8.25F),
                Margin = new Padding(1)
            };
            comboBox = new ComboBox
            {
                DrawMode = DrawMode.OwnerDrawVariable,
                Font = new Font("Arial", 8.25F, FontStyle.Bold),
                ItemHeight = 14,
                TabStop = false
            };

            Controls.Add(textBox);
            Controls.Add(comboBox);

            MinimumSize = new Size(comboBoxWidth + gap + 50, 20);
            MaximumSize = new Size(500, 20);
            Size = new Size(100, 20);

            UpdateLayout();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                textBox?.Dispose();
                comboBox?.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            comboBox.MeasureItem += ComboBox_MeasureItem;
            comboBox.DrawItem += ComboBox_DrawItem;
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.KeyPress += TextBox_KeyPress;
            textBox.Enter += TextBox_Enter; // Show full precision on enter
            textBox.Leave += TextBox_Leave; // Round on leave

            UpdateAvailableUnits();
            comboBox.Items.AddRange(availableUnits);
            comboBox.SelectedIndex = -1;
            currentUnit = (UnitArea)comboBox.SelectedItem;

            UpdateLayout();
            comboBox.Visible = true;
            comboBox.BringToFront();
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
            comboBox.Location = new Point(Width - comboBoxWidth, 0);
            comboBox.Size = new Size(comboBoxWidth, Height);

            int textBoxWidth = Width - comboBoxWidth - gap;
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
        public UnitArea Unit
        {
            get => !DesignMode ? (UnitArea)comboBox.SelectedItem : null;
            set => SetUnit(value);
        }
        public void SetUnit(UnitArea unit)
        {
            if (DesignMode || unit == null)
            {
                suppressSelectedIndexChanged = true;
                comboBox.SelectedIndex = -1;
                suppressSelectedIndexChanged = false;
                currentUnit = null;
                return;
            }
            UnitArea foundUnit = availableUnits.FirstOrDefault(u => u.ToString() == unit.ToString());
            if (foundUnit != null)
            {
                suppressSelectedIndexChanged = true;
                comboBox.SelectedItem = foundUnit;
                suppressSelectedIndexChanged = false;
                currentUnit = unit;
            }
            else
            {
                throw new ArgumentException($"Invalid unit string: {unit}. Must match one of the available units.");
            }
        }
        private void UpdateAvailableUnits()
        {
            if (AllowedUnits == null || !AllowedUnits.Any())
            {
                availableUnits = Units.AreaUnits.Values.ToArray();
            }
            else
            {
                availableUnits = Units.AreaUnits.Values
                    .Where(u => AllowedUnits.Contains(u.ToString()))
                    .ToArray();
            }

            if (!DesignMode && comboBox.Items.Count > 0)
            {
                suppressSelectedIndexChanged = true;
                comboBox.Items.Clear();
                comboBox.Items.AddRange(availableUnits);
                comboBox.SelectedIndex = -1;
                currentUnit = null;
                suppressSelectedIndexChanged = false;
            }
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
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressSelectedIndexChanged)
            {
                suppressSelectedIndexChanged = false;
                return;
            }
            if (!DesignMode)
            {
                UnitArea newUnit = comboBox.SelectedItem as UnitArea;

                // Determine the value to convert based on editing state
                decimal? valueToConvert = null;
                if (isUserEditing)
                {
                    // User is editing; parse the textbox text as the source value
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        currentValue = null;
                    }
                    else if (decimal.TryParse(textBox.Text, out decimal result))
                    {
                        currentValue = result; // Use user's input as full precision
                    }
                    valueToConvert = currentValue;
                    isUserEditing = false; // Reset flag after processing
                }
                else
                {
                    // Not editing; use the stored full-precision value
                    valueToConvert = currentValue;
                }

                // Perform conversion if unit changed and value exists
                if (newUnit != currentUnit && valueToConvert.HasValue && currentUnit != null)
                {
                    decimal? convertedValue = Units.ConvertArea(valueToConvert.Value, currentUnit, newUnit);
                    Value = convertedValue; // Store full precision
                }

                currentUnit = newUnit;
                UpdateTextBoxDisplay(); // Display rounded value
                SelectedIndexChanged?.Invoke(this, e);
            }
        }
        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (!DesignMode)
            {
                e.ItemHeight = comboBox.ItemHeight;
            }
        }
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                e.DrawBackground();
                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString("", comboBox.Font, textBrush, e.Bounds.X, e.Bounds.Y);
                }
                e.DrawFocusRectangle();
                return;
            }

            string text = DesignMode ? "Unit" : comboBox.Items[e.Index].ToString();
            e.DrawBackground();
            using (Brush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, comboBox.Font, textBrush, e.Bounds.X, e.Bounds.Y);
            }
            e.DrawFocusRectangle();
        }
        #endregion
    }
}