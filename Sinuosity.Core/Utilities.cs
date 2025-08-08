using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Sinuosity.Common
{
    public static class ControlExtensions
    {
        public static void SetParentWithSameScreenCoordinates(this Control source, Control parent)
        {
            source.Location = parent.PointToClient(source.PointToScreen(System.Drawing.Point.Empty));
            source.Parent = parent;
        }
    }
    public static class Utilities
    {
        /// <summary>
        /// Converts a decimal value to station notation (e.g., 123.456 -> "1+23.46") with specified decimal precision.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="decimalPlaces">The number of decimal places to round to (must be non-negative). If null, uses full precision with trailing zeros trimmed.</param>
        /// <returns>A string in station notation format (e.g., "X+YY.ZZ").</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if decimalPlaces is negative.</exception>
        public static string FormatToStationNotation(decimal value, int? decimalPlaces = null)
        {
            if (decimalPlaces.HasValue && decimalPlaces < 0)
                throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Decimal places must be non-negative.");

            int hundreds = (int)(value / 100); // Integer part (hundreds of feet)
            decimal remainder = value - (hundreds * 100); // Remainder (feet and decimals)

            if (decimalPlaces.HasValue)
            {
                remainder = decimal.Round(remainder, decimalPlaces.Value); // Round to specified decimal places
                                                                           // Split remainder into integer and fractional parts
                int remainderInt = (int)remainder; // Integer part of remainder
                decimal remainderFractional = remainder - remainderInt; // Fractional part
                                                                        // Format integer part as two digits, fractional part as specified decimal places
                string formatString = $"0.{new string('0', decimalPlaces.Value)}"; // Format for fractional part
                string formattedFractional = Math.Abs(remainderFractional).ToString(formatString).Substring(1); // Get ".ZZZ" part
                string formattedRemainder = $"{remainderInt:D2}{formattedFractional}"; // Combine "YY.ZZZ"
                return $"{hundreds}+{formattedRemainder}"; // Format as "X+YY.ZZZ..."
            }
            else
            {
                // Full precision with trailing zeros trimmed
                string remainderStr = remainder.ToString("G"); // "G" format removes trailing zeros after decimal
                if (!remainderStr.Contains(".")) remainderStr += ".0"; // Ensure at least one decimal place if whole number
                                                                       // Ensure two digits before decimal
                int remainderInt = (int)remainder;
                string[] parts = remainderStr.Split('.');
                string formattedRemainder = $"{remainderInt:D2}.{(parts.Length > 1 ? parts[1] : "0")}";
                return $"{hundreds}+{formattedRemainder}";
            }
        }

        /// <summary>
        /// Converts a string from station notation (e.g., "1+23.46") or plain decimal (e.g., "123.46") to a decimal value.
        /// </summary>
        /// <param name="input">The input string, either in station notation or decimal format.</param>
        /// <param name="result">The resulting decimal value, or null if parsing fails.</param>
        /// <returns>True if parsing succeeds, false otherwise.</returns>
        public static bool FormatFromStationNotation(string input, out decimal? result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Try parsing as station notation (e.g., "1+23.46")
            if (input.Contains("+"))
            {
                string[] parts = input.Split('+');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int hundreds) &&
                    decimal.TryParse(parts[1], out decimal remainder) &&
                    remainder >= 0 && remainder < 100) // Validate remainder range
                {
                    result = (hundreds * 100) + remainder;
                    return true;
                }
                return false; // Invalid station notation
            }

            // If no "+", try parsing as plain decimal (e.g., "123.46")
            if (decimal.TryParse(input, out decimal decimalResult))
            {
                result = decimalResult;
                return true;
            }

            return false; // Neither format worked
        }
        public static void Log(string debugID, string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {debugID}: {message}");
        }
        public static string PromptForFile(string title, string filter, string initialDirectory)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = filter,
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = initialDirectory,
                Title = title
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                else
                {
                    return "";
                }
            }
        }

        public static string PromptForString(string promptText)
        {
            using (Form stringPrompt = new Form
            {
                Width = 360,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Please enter text",
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            })
            {
                Label lbl = new Label
                {
                    Left = 20,
                    Top = 20,
                    Text = promptText,
                    MaximumSize = new Size(300, 0),
                    AutoSize = true
                };

                TextBox txt = new TextBox
                {
                    Left = 20,
                    Width = 300
                };

                Button ok = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Width = 75
                };

                Button cancel = new Button
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Width = 75
                };

                // Add controls first
                stringPrompt.Controls.Add(lbl);
                stringPrompt.Controls.Add(txt);
                stringPrompt.Controls.Add(ok);
                stringPrompt.Controls.Add(cancel);

                // Force layout update
                stringPrompt.PerformLayout();

                // Set positions
                txt.Top = lbl.Bottom + 10;
                ok.Top = txt.Bottom + 20;  // Increased padding from textbox
                cancel.Top = ok.Top;

                // Center buttons below textbox
                int totalButtonWidth = ok.Width + 10 + cancel.Width;  // Buttons plus spacing
                int buttonsLeft = txt.Left + (txt.Width - totalButtonWidth) / 2;  // Center under textbox
                ok.Left = buttonsLeft;
                cancel.Left = ok.Right + 10;  // 10px spacing between buttons

                stringPrompt.AcceptButton = ok;
                stringPrompt.CancelButton = cancel;

                // Set form height with more bottom padding (60 instead of 40)
                stringPrompt.Height = ok.Bottom + 60;

                return stringPrompt.ShowDialog() == DialogResult.OK ? txt.Text : null;
            }
        }
        public static string GetTimeAgoString(TimeSpan diff)
        {
            if (diff.TotalDays >= 365)
            {
                int years = (int)(diff.TotalDays / 365);
                return $"{years} year{(years == 1 ? "" : "s")} ago";
            }
            if (diff.TotalDays >= 30)
            {
                int months = (int)(diff.TotalDays / 30);
                return $"{months} month{(months == 1 ? "" : "s")} ago";
            }
            if (diff.TotalDays >= 7)
            {
                int weeks = (int)(diff.TotalDays / 7);
                return $"{weeks} week{(weeks == 1 ? "" : "s")} ago";
            }
            if (diff.TotalDays >= 1)
            {
                int days = (int)diff.TotalDays;
                return $"{days} day{(days == 1 ? "" : "s")} ago";
            }
            if (diff.TotalHours >= 1)
            {
                int hours = (int)diff.TotalHours;
                return $"{hours} hour{(hours == 1 ? "" : "s")} ago";
            }
            if (diff.TotalMinutes >= 1)
            {
                int minutes = (int)diff.TotalMinutes;
                return $"{minutes} minute{(minutes == 1 ? "" : "s")} ago";
            }
            return "just now";
        }
    }

    public static class Units
    {
        // Length Units
        public static readonly UnitLength Meter = new Length_Meter();
        public static readonly UnitLength Foot = new Length_Foot();
        public static readonly UnitLength SurveyFoot = new Length_SurveyFoot();
        public static readonly UnitLength Yard = new Length_Yard();
        public static readonly UnitLength Mile = new Length_Mile();
        public static readonly UnitLength Inch = new Length_Inch();
        public static readonly UnitLength Kilometer = new Length_Kilometer();

        // Area Units
        public static readonly UnitArea SquareMeter = new Area_SquareMeter();
        public static readonly UnitArea SquareFoot = new Area_SquareFoot();
        public static readonly UnitArea SquareSurveyFoot = new Area_SquareSurveyFoot();
        public static readonly UnitArea SquareYard = new Area_SquareYard();
        public static readonly UnitArea Acre = new Area_Acre();
        public static readonly UnitArea SquareMile = new Area_SquareMile();
        public static readonly UnitArea SquareInch = new Area_SquareInch();
        public static readonly UnitArea SquareKilometer = new Area_SquareKilometer();

        // Volume Units
        public static readonly UnitVolume CubicMeter = new Volume_CubicMeter();
        public static readonly UnitVolume CubicFoot = new Volume_CubicFoot();
        public static readonly UnitVolume CubicSurveyFoot = new Volume_CubicSurveyFoot();
        public static readonly UnitVolume CubicYard = new Volume_CubicYard();
        public static readonly UnitVolume CubicKilometer = new Volume_CubicKilometer();
        public static readonly UnitVolume CubicInch = new Volume_CubicInch();
        public static readonly UnitVolume Quart = new Volume_Quart();
        public static readonly UnitVolume Gallon = new Volume_Gallon();

        // Angle Units
        public static readonly UnitAngle Radian = new Angle_Radian();
        public static readonly UnitAngle Degree = new Angle_Degree();

        // Slope Units
        public static readonly UnitSlope SlopeRiseToRun = new Slope_RiseToRun();
        public static readonly UnitSlope SlopeDegree = new Slope_Degree();
        public static readonly UnitSlope SlopePercent = new Slope_PercentGrade();
        public static readonly UnitSlope SlopeRatio = new Slope_Ratio();

        // Time Units
        public static readonly UnitTime Second = new Time_Second();
        public static readonly UnitTime Minute = new Time_Minute();
        public static readonly UnitTime Hour = new Time_Hour();
        public static readonly UnitTime Day = new Time_Day();
        public static readonly UnitTime Week = new Time_Week();
        public static readonly UnitTime Month = new Time_Month();
        public static readonly UnitTime Year = new Time_Year();

        // Flow Rate Units
        public static readonly UnitFlowRate CubicMeterPerSecond = new FlowRate_CubicMeterPerSecond();
        public static readonly UnitFlowRate CubicFootPerSecond = new FlowRate_CubicFootPerSecond();
        public static readonly UnitFlowRate CubicInchPerSecond = new FlowRate_CubicInchPerSecond();
        public static readonly UnitFlowRate GallonPerMinute = new FlowRate_GallonPerMinute();
        public static readonly UnitFlowRate CubicMeterPerMinute = new FlowRate_CubicMeterPerMinute();
        public static readonly UnitFlowRate CubicFootPerMinute = new FlowRate_CubicFootPerMinute();
        public static readonly UnitFlowRate CubicInchPerMinute = new FlowRate_CubicInchPerMinute();
        public static readonly UnitFlowRate GallonPerSecond = new FlowRate_GallonPerSecond();
        public static readonly UnitFlowRate CubicMeterPerHour = new FlowRate_CubicMeterPerHour();
        public static readonly UnitFlowRate CubicFootPerHour = new FlowRate_CubicFootPerHour();
        public static readonly UnitFlowRate CubicInchPerHour = new FlowRate_CubicInchPerHour();
        public static readonly UnitFlowRate GallonPerHour = new FlowRate_GallonPerHour();
        public static readonly UnitFlowRate CubicMeterPerDay = new FlowRate_CubicMeterPerDay();
        public static readonly UnitFlowRate CubicFootPerDay = new FlowRate_CubicFootPerDay();
        public static readonly UnitFlowRate CubicInchPerDay = new FlowRate_CubicInchPerDay();
        public static readonly UnitFlowRate GallonPerDay = new FlowRate_GallonPerDay();


        // Length Units
        private class Length_Meter : UnitLength
        {
            public Length_Meter() : base(1.0m) { }
            public override string ToString() => "m";
        }
        private class Length_Foot : UnitLength
        {
            public Length_Foot() : base(0.3048m) { }
            public override string ToString() => "ft";
        }
        private class Length_SurveyFoot : UnitLength
        {
            public Length_SurveyFoot() : base(1200.0m / 3937.0m) { }
            public override string ToString() => "sft";
        }
        private class Length_Yard : UnitLength
        {
            public Length_Yard() : base(0.9144m) { }
            public override string ToString() => "yd";
        }
        private class Length_Mile : UnitLength
        {
            public Length_Mile() : base(1609.344m) { }
            public override string ToString() => "mi";
        }
        private class Length_Inch : UnitLength
        {
            public Length_Inch() : base(0.0254m) { }
            public override string ToString() => "in";
        }
        private class Length_Kilometer : UnitLength
        {
            public Length_Kilometer() : base(1000.0m) { }
            public override string ToString() => "km";
        }

        // Area Units
        private class Area_SquareMeter : UnitArea
        {
            public Area_SquareMeter() : base(1.0m) { }
            public override string ToString() => "m²";
        }
        private class Area_SquareFoot : UnitArea
        {
            public Area_SquareFoot() : base(0.09290304m) { }
            public override string ToString() => "ft²";
        }
        private class Area_SquareSurveyFoot : UnitArea
        {
            public Area_SquareSurveyFoot() : base((1200.0m / 3937.0m) * (1200.0m / 3937.0m)) { }
            public override string ToString() => "sft²";
        }
        private class Area_SquareYard : UnitArea
        {
            public Area_SquareYard() : base(0.83612736m) { }
            public override string ToString() => "yd²";
        }
        private class Area_Acre : UnitArea
        {
            public Area_Acre() : base(4046.8564224m) { }
            public override string ToString() => "ac";
        }
        private class Area_SquareMile : UnitArea
        {
            public Area_SquareMile() : base(2589988.110336m) { }
            public override string ToString() => "mi²";
        }
        private class Area_SquareInch : UnitArea
        {
            public Area_SquareInch() : base(0.00064516m) { }
            public override string ToString() => "in²";
        }
        private class Area_SquareKilometer : UnitArea
        {
            public Area_SquareKilometer() : base(1000000.0m) { }
            public override string ToString() => "km²";
        }

        // Volume Units
        private class Volume_CubicMeter : UnitVolume
        {
            public Volume_CubicMeter() : base(1.0m) { }
            public override string ToString() => "m³";
        }
        private class Volume_CubicFoot : UnitVolume
        {
            public Volume_CubicFoot() : base(0.028316846592m) { }
            public override string ToString() => "ft³";
        }
        private class Volume_CubicSurveyFoot : UnitVolume
        {
            public Volume_CubicSurveyFoot() : base((decimal)Math.Pow(1200.0 / 3937.0, 3)) { }
            public override string ToString() => "sft³";
        }
        private class Volume_CubicYard : UnitVolume
        {
            public Volume_CubicYard() : base(0.764554857984m) { }
            public override string ToString() => "yd³";
        }
        private class Volume_CubicKilometer : UnitVolume
        {
            public Volume_CubicKilometer() : base(1000000000.0m) { }
            public override string ToString() => "km³";
        }
        private class Volume_CubicInch : UnitVolume
        {
            public Volume_CubicInch() : base(0.000016387064m) { }
            public override string ToString() => "in³";
        }
        private class Volume_Quart : UnitVolume
        {
            public Volume_Quart() : base(0.000946352946m) { }
            public override string ToString() => "qt";
        }
        private class Volume_Gallon : UnitVolume
        {
            public Volume_Gallon() : base(0.0037854118m) { }
            public override string ToString() => "gal";
        }

        // Angle Units
        private class Angle_Radian : UnitAngle
        {
            public Angle_Radian() : base(1.0m) { }
            public override string ToString() => "rad";
        }
        private class Angle_Degree : UnitAngle
        {
            public Angle_Degree() : base((decimal)(Math.PI / 180.0)) { }
            public override string ToString() => "°";
        }

        // Slope Units
        private class Slope_RiseToRun : UnitSlope
        {
            public Slope_RiseToRun() : base(1.0m) { } // Already in rise/run
            public override string ToString() => "Y/X";
        }
        private class Slope_Degree : UnitSlope
        {
            public Slope_Degree() : base(0m) { } // Degrees don't use a fixed factor
            public override decimal ToRiseRun(decimal degrees)
            {
                double radians = (double)degrees * Math.PI / 180.0;
                return (decimal)Math.Tan(radians);
            }
            public override decimal FromRiseRun(decimal riseRun)
            {
                double angleRadians = Math.Atan((double)riseRun);
                return (decimal)(angleRadians * 180.0 / Math.PI);
            }
            public override string ToString() => "degrees";
        }
        private class Slope_PercentGrade : UnitSlope
        {
            public Slope_PercentGrade() : base(0.01m) { } // 1% = 0.01 rise/run
            public override string ToString() => "grade";
        }
        private class Slope_Ratio : UnitSlope
        {
            public Slope_Ratio() : base(1.0m) { } // Assuming 1:1 = 1 rise/run
            public override string ToString() => "slope";
            // Note: If ratio is run:rise (e.g., 2:1 = 0.5 rise/run), adjust logic below
            public override decimal ToRiseRun(decimal ratio) => 1m / ratio; // e.g., 2:1 = 0.5 rise/run
            public override decimal FromRiseRun(decimal riseRun) => 1m / riseRun;
        }

        // Time Units
        private class Time_Day : UnitTime
        {
            public Time_Day() : base(1.0m) { }
            public override string ToString() => "days";
        }
        private class Time_Second : UnitTime
        {
            public Time_Second() : base(1.0m / 86400.0m) { } // 1 second = 1/86400 days
            public override string ToString() => "seconds";
        }
        private class Time_Minute : UnitTime
        {
            public Time_Minute() : base(1.0m / 1440.0m) { } // 1 minute = 1/1440 days
            public override string ToString() => "minutes";
        }
        private class Time_Hour : UnitTime
        {
            public Time_Hour() : base(1.0m / 24.0m) { } // 1 hour = 1/24 days
            public override string ToString() => "hours";
        }
        private class Time_Week : UnitTime
        {
            public Time_Week() : base(1.0m / 7.0m) { } // 1 week = 1/7 days
            public override string ToString() => "weeks";
        }
        private class Time_Month : UnitTime
        {
            public Time_Month() : base(1.0m / 30.44m) { } // 1 month = 1/30.44 days (average)
            public override string ToString() => "months";
        }
        private class Time_Year : UnitTime
        {
            public Time_Year() : base(1.0m) { } // 1 year = 365.25 days (average)
            public override string ToString() => "years";
        }

        // Flow Rate Units
        private class FlowRate_CubicMeterPerSecond : UnitFlowRate
        {
            public FlowRate_CubicMeterPerSecond() : base(1.0m) { }
            public override string ToString() => "m³/s";
        }
        private class FlowRate_CubicFootPerSecond : UnitFlowRate
        {
            public FlowRate_CubicFootPerSecond() : base(0.028316846592m) { }
            public override string ToString() => "ft³/s";
        }
        private class FlowRate_CubicInchPerSecond : UnitFlowRate
        {
            public FlowRate_CubicInchPerSecond() : base(0.000016387064m) { }
            public override string ToString() => "in³/s";
        }
        private class FlowRate_GallonPerMinute : UnitFlowRate
        {
            public FlowRate_GallonPerMinute() : base(0.0000630902m) { }
            public override string ToString() => "gal/min";
        }
        private class FlowRate_CubicMeterPerMinute : UnitFlowRate
        {
            public FlowRate_CubicMeterPerMinute() : base(0.01666666667m) { }
            public override string ToString() => "m³/min";
        }
        private class FlowRate_CubicFootPerMinute : UnitFlowRate
        {
            public FlowRate_CubicFootPerMinute() : base(0.00047194745m) { }
            public override string ToString() => "ft³/min";
        }
        private class FlowRate_CubicInchPerMinute : UnitFlowRate
        {
            public FlowRate_CubicInchPerMinute() : base(0.0000005787037m) { }
            public override string ToString() => "in³/min";
        }
        private class FlowRate_GallonPerSecond : UnitFlowRate
        {
            public FlowRate_GallonPerSecond() : base(0.0037854118m) { }
            public override string ToString() => "gal/s";
        }
        private class FlowRate_CubicMeterPerHour : UnitFlowRate
        {
            public FlowRate_CubicMeterPerHour() : base(0.00027777778m) { }
            public override string ToString() => "m³/h";
        }
        private class FlowRate_CubicFootPerHour : UnitFlowRate
        {
            public FlowRate_CubicFootPerHour() : base(0.0000083333333m) { }
            public override string ToString() => "ft³/h";
        }
        private class FlowRate_CubicInchPerHour : UnitFlowRate
        {
            public FlowRate_CubicInchPerHour() : base(0.00000027777778m) { }
            public override string ToString() => "in³/h";
        }
        private class FlowRate_GallonPerHour : UnitFlowRate
        {
            public FlowRate_GallonPerHour() : base(0.0000158503m) { }
            public override string ToString() => "gal/h";
        }
        private class FlowRate_CubicMeterPerDay : UnitFlowRate
        {
            public FlowRate_CubicMeterPerDay() : base(0.00001157407407m) { }
            public override string ToString() => "m³/d";
        }
        private class FlowRate_CubicFootPerDay : UnitFlowRate
        {
            public FlowRate_CubicFootPerDay() : base(0.00000011574074m) { }
            public override string ToString() => "ft³/d";
        }
        private class FlowRate_CubicInchPerDay : UnitFlowRate
        {
            public FlowRate_CubicInchPerDay() : base(0.00000000011574074m) { }
            public override string ToString() => "in³/d";
        }
        private class FlowRate_GallonPerDay : UnitFlowRate
        {
            public FlowRate_GallonPerDay() : base(0.00000069444444m) { }
            public override string ToString() => "gal/d";
        }

        public static decimal? ConvertValue<T>(decimal value, T fromUnit, T toUnit) where T : class
        {
            if (fromUnit == null || toUnit == null)
                throw new ArgumentNullException("Unit parameters cannot be null");

            if (typeof(T) == typeof(UnitLength))
                return ConvertLength(value, (UnitLength)(object)fromUnit, (UnitLength)(object)toUnit);
            if (typeof(T) == typeof(UnitArea))
                return ConvertArea(value, (UnitArea)(object)fromUnit, (UnitArea)(object)toUnit);
            if (typeof(T) == typeof(UnitVolume))
                return ConvertVolume(value, (UnitVolume)(object)fromUnit, (UnitVolume)(object)toUnit);
            if (typeof(T) == typeof(UnitAngle))
                return ConvertAngle(value, (UnitAngle)(object)fromUnit, (UnitAngle)(object)toUnit);
            if (typeof(T) == typeof(UnitSlope))
                return ConvertSlope(value, (UnitSlope)(object)fromUnit, (UnitSlope)(object)toUnit);

            throw new InvalidOperationException($"Conversion not supported for unit type {typeof(T).Name}");
        }

        public static decimal ConvertLength(decimal value, UnitLength fromUnit, UnitLength toUnit)
        {
            if (fromUnit == null || toUnit == null)
                throw new ArgumentNullException("Unit parameters cannot be null");
            if (!(fromUnit is UnitLength) || !(toUnit is UnitLength))
                throw new ArgumentException("Both units must be of type UnitLength");
            decimal meters = value * fromUnit.ToMetersFactor;
            return meters / toUnit.ToMetersFactor;
        }

        public static decimal ConvertArea(decimal value, UnitArea fromUnit, UnitArea toUnit)
        {
            if (fromUnit == null || toUnit == null)
                throw new ArgumentNullException("Unit parameters cannot be null");
            if (!(fromUnit is UnitArea) || !(toUnit is UnitArea))
                throw new ArgumentException("Both units must be of type UnitArea");
            decimal squareMeters = value * fromUnit.ToSquareMetersFactor;
            return squareMeters / toUnit.ToSquareMetersFactor;
        }

        public static decimal ConvertVolume(decimal value, UnitVolume fromUnit, UnitVolume toUnit)
        {
            if (fromUnit == null || toUnit == null)
                throw new ArgumentNullException("Unit parameters cannot be null");
            if (!(fromUnit is UnitVolume) || !(toUnit is UnitVolume))
                throw new ArgumentException("Both units must be of type UnitVolume");
            decimal cubicMeters = value * fromUnit.ToCubicMetersFactor;
            return cubicMeters / toUnit.ToCubicMetersFactor;
        }

        public static decimal ConvertAngle(decimal value, UnitAngle fromUnit, UnitAngle toUnit)
        {
            if (fromUnit == null || toUnit == null)
                throw new ArgumentNullException("Unit parameters cannot be null");
            if (!(fromUnit is UnitAngle) || !(toUnit is UnitAngle))
                throw new ArgumentException("Both units must be of type UnitAngle");
            decimal radians = value * fromUnit.ToRadiansFactor;
            return radians / toUnit.ToRadiansFactor;
        }
        public static decimal ConvertSlope(decimal value, UnitSlope fromUnit, UnitSlope toUnit)
        {
            if (fromUnit == null || toUnit == null)
                throw new ArgumentNullException("Unit parameters cannot be null");
            if (!(fromUnit is UnitSlope) || !(toUnit is UnitSlope))
                throw new ArgumentException("Both units must be of type UnitSlope");

            // Convert from source unit to rise/run
            decimal riseToRun = fromUnit.ToRiseRun(value);
            // Convert from rise/run to target unit
            return toUnit.FromRiseRun(riseToRun);
        }
        // Generic method to get the appropriate units dictionary
        public static IReadOnlyDictionary<string, T> GetUnits<T>() where T : class
        {
            if (typeof(T) == typeof(UnitLength))
                return (IReadOnlyDictionary<string, T>)(object)LengthUnits;
            if (typeof(T) == typeof(UnitArea))
                return (IReadOnlyDictionary<string, T>)(object)AreaUnits;
            if (typeof(T) == typeof(UnitVolume))
                return (IReadOnlyDictionary<string, T>)(object)VolumeUnits;
            if (typeof(T) == typeof(UnitAngle))
                return (IReadOnlyDictionary<string, T>)(object)AngleUnits;
            if (typeof(T) == typeof(UnitSlope))
                return (IReadOnlyDictionary<string, T>)(object)SlopeUnits;
            if (typeof(T) == typeof(UnitTime))
                return (IReadOnlyDictionary<string, T>)(object)TimeUnits;
            if (typeof(T) == typeof(UnitFlowRate))
                return (IReadOnlyDictionary<string, T>)(object)FlowRateUnits;

            throw new ArgumentException($"No units defined for type {typeof(T).Name}");
        }
        public static readonly Dictionary<string, UnitLength> LengthUnits = new Dictionary<string, UnitLength>
        {
            { "m", Units.Meter },
            { "ft", Units.Foot },
            { "sft", Units.SurveyFoot },
            { "yd", Units.Yard },
            { "mi", Units.Mile },
            { "in", Units.Inch },
            { "km", Units.Kilometer }
        };
        public static readonly Dictionary<string, UnitArea> AreaUnits = new Dictionary<string, UnitArea>
        {
            { "ac", Units.Acre },
            { "mi²", Units.SquareMile },
            { "ft²", Units.SquareFoot },
            { "yd²", Units.SquareYard },
            { "km²", Units.SquareKilometer },
            { "m²", Units.SquareMeter },
            { "in²", Units.SquareInch },
            { "sft²", Units.SquareSurveyFoot }
        };
        public static readonly Dictionary<string, UnitVolume> VolumeUnits = new Dictionary<string, UnitVolume>
        {
            { "m³", Units.CubicMeter },
            { "ft³", Units.CubicFoot },
            { "sft³", Units.CubicSurveyFoot },
            { "yd³", Units.CubicYard },
            { "km³", Units.CubicKilometer }
        };
        public static readonly Dictionary<string, UnitAngle> AngleUnits = new Dictionary<string, UnitAngle>
        {
            { "rad", Units.Radian },
            { "°", Units.Degree }
        };
        public static readonly Dictionary<string, UnitSlope> SlopeUnits = new Dictionary<string, UnitSlope>
        {
            { "Y/X", Units.SlopeRiseToRun },
            { "degrees", Units.SlopeDegree },
            { "grade", Units.SlopePercent },
            { "slope", Units.SlopeRatio }
        };
        public static readonly Dictionary<string, UnitTime> TimeUnits = new Dictionary<string, UnitTime>
        {
            { "day", Units.Day },
            { "sec", Units.Second },
            { "min", Units.Minute },
            { "hr", Units.Hour },
            { "wk", Units.Week },
            { "mo", Units.Month },
            { "yr", Units.Year }
        };
        public static readonly Dictionary<string, UnitFlowRate> FlowRateUnits = new Dictionary<string, UnitFlowRate>
        {
            { "m³/sec", Units.CubicMeterPerSecond },
            { "ft³/sec", Units.CubicFootPerSecond },
            { "in³/sec", Units.CubicInchPerSecond },
            { "gal/min", Units.GallonPerMinute },
            { "m³/min", Units.CubicMeterPerMinute },
            { "ft³/min", Units.CubicFootPerMinute },
            { "in³/min", Units.CubicInchPerMinute },
            { "gal/sec", Units.GallonPerSecond },
            { "m³/hr", Units.CubicMeterPerHour },
            { "ft³/hr", Units.CubicFootPerHour },
            { "in³/hr", Units.CubicInchPerHour },
            { "gal/hr", Units.GallonPerHour },
            { "m³/day", Units.CubicMeterPerDay },
            { "ft³/day", Units.CubicFootPerDay },
            { "in³/day", Units.CubicInchPerDay },
            { "gal/day", Units.GallonPerDay }
        };
        public static T GetPriorityUnit<T>(T unit1, T unit2, object priority) where T : class
        {
            if (unit1 == null || unit2 == null)
                throw new ArgumentNullException("Unit parameters cannot be null");

            return typeof(T) == typeof(UnitLength) ? (T)(object)GetPriorityUnitLength((UnitLength)(object)unit1, (UnitLength)(object)unit2, priority) :
                   typeof(T) == typeof(UnitArea) ? (T)(object)GetPriorityUnitArea((UnitArea)(object)unit1, (UnitArea)(object)unit2, priority) :
                   typeof(T) == typeof(UnitVolume) ? (T)(object)GetPriorityUnitVolume((UnitVolume)(object)unit1, (UnitVolume)(object)unit2, priority) :
                   typeof(T) == typeof(UnitAngle) ? (T)(object)GetPriorityUnitAngle((UnitAngle)(object)unit1, (UnitAngle)(object)unit2, priority) :
                   typeof(T) == typeof(UnitTime) ? (T)(object)GetPriorityUnitTime((UnitTime)(object)unit1, (UnitTime)(object)unit2, priority) :
                   typeof(T) == typeof(UnitFlowRate) ? (T)(object)GetPriorityUnitFlowRate((UnitFlowRate)(object)unit1, (UnitFlowRate)(object)unit2, priority) :
                   throw new ArgumentException($"No priority unit selection defined for type {typeof(T).Name}");
        }
        public static UnitLength GetPriorityUnitLength(UnitLength unit1, UnitLength unit2, object priority)
        {
            if (priority == null)
            {
                return unit1;
            }
            else if (priority.GetType() == typeof(string))
            {
                if (AreaUnits.ContainsKey((string)priority))
                {
                    return LengthUnits[(string)priority];
                }
                else
                {
                    throw new ArgumentException($"Priority unit '{priority}' is not a valid length unit.");
                }
            }
            else if (priority.GetType() == typeof(string[]))
            {
                string[] priorities = (string[])priority;
                foreach (var p in priorities)
                {
                    if (LengthUnits.ContainsKey(p))
                    {
                        if (unit1.ToString() == p || unit2.ToString() == p) return LengthUnits[p];
                    }
                }
                return unit1;
            }
            else
            {
                throw new ArgumentException("Priority must be a string or an array of strings representing unit keys.");
            }
        }
        public static UnitArea GetPriorityUnitArea(UnitArea unit1, UnitArea unit2, object priority)
        {
            if (priority == null)
            {
                return unit1;
            }
            else if (priority.GetType() == typeof(string))
            {
                if (AreaUnits.ContainsKey((string)priority))
                {
                    return AreaUnits[(string)priority];
                }
                else
                {
                    throw new ArgumentException($"Priority unit '{priority}' is not a valid area unit.");
                }
            }
            else if (priority.GetType() == typeof(string[]))
            {
                string[] priorities = (string[])priority;
                foreach (var p in priorities)
                {
                    if (AreaUnits.ContainsKey(p))
                    {
                        if (unit1.ToString() == p || unit2.ToString() == p) return AreaUnits[p];
                    }
                }
                throw new ArgumentException($"None of the priority units '{string.Join(", ", priorities)}' are valid area units.");
            }
            else
            {
                throw new ArgumentException("Priority must be a string or an array of strings representing unit keys.");
            }
        }
        public static UnitVolume GetPriorityUnitVolume(UnitVolume unit1, UnitVolume unit2, object priority)
        {
            if (priority == null)
            {
                return unit1;
            }
            else if (priority.GetType() == typeof(string))
            {
                if (VolumeUnits.ContainsKey((string)priority))
                {
                    return VolumeUnits[(string)priority];
                }
                else
                {
                    throw new ArgumentException($"Priority unit '{priority}' is not a valid volume unit.");
                }
            }
            else if (priority.GetType() == typeof(string[]))
            {
                string[] priorities = (string[])priority;
                foreach (var p in priorities)
                {
                    if (VolumeUnits.ContainsKey(p))
                    {
                        if (unit1.ToString() == p || unit2.ToString() == p) return VolumeUnits[p];
                    }
                }
                throw new ArgumentException($"None of the priority units '{string.Join(", ", priorities)}' are valid volume units.");
            }
            else
            {
                throw new ArgumentException("Priority must be a string or an array of strings representing unit keys.");
            }
        }
        public static UnitAngle GetPriorityUnitAngle(UnitAngle unit1, UnitAngle unit2, object priority)
        {
            if (priority == null)
            {
                return unit1;
            }
            else if (priority.GetType() == typeof(string))
            {
                if (AngleUnits.ContainsKey((string)priority))
                {
                    return AngleUnits[(string)priority];
                }
                else
                {
                    throw new ArgumentException($"Priority unit '{priority}' is not a valid angle unit.");
                }
            }
            else if (priority.GetType() == typeof(string[]))
            {
                string[] priorities = (string[])priority;
                foreach (var p in priorities)
                {
                    if (AngleUnits.ContainsKey(p))
                    {
                        if (unit1.ToString() == p || unit2.ToString() == p) return AngleUnits[p];
                    }
                }
                throw new ArgumentException($"None of the priority units '{string.Join(", ", priorities)}' are valid angle units.");
            }
            else
            {
                throw new ArgumentException("Priority must be a string or an array of strings representing unit keys.");
            }
        }
        public static UnitTime GetPriorityUnitTime(UnitTime unit1, UnitTime unit2, object priority)
        {
            if (priority == null)
            {
                return unit1;
            }
            else if (priority.GetType() == typeof(string))
            {
                if (TimeUnits.ContainsKey((string)priority))
                {
                    return TimeUnits[(string)priority];
                }
                else
                {
                    throw new ArgumentException($"Priority unit '{priority}' is not a valid time unit.");
                }
            }
            else if (priority.GetType() == typeof(string[]))
            {
                string[] priorities = (string[])priority;
                foreach (var p in priorities)
                {
                    if (TimeUnits.ContainsKey(p))
                    {
                        if (unit1.ToString() == p || unit2.ToString() == p) return TimeUnits[p];
                    }
                }
                throw new ArgumentException($"None of the priority units '{string.Join(", ", priorities)}' are valid time units.");
            }
            else
            {
                throw new ArgumentException("Priority must be a string or an array of strings representing unit keys.");
            }
        }
        public static UnitFlowRate GetPriorityUnitFlowRate(UnitFlowRate unit1, UnitFlowRate unit2, object priority)
        {
            if (priority == null)
            {
                return unit1;
            }
            else if (priority.GetType() == typeof(string))
            {
                if (FlowRateUnits.ContainsKey((string)priority))
                {
                    return FlowRateUnits[(string)priority];
                }
                else
                {
                    throw new ArgumentException($"Priority unit '{priority}' is not a valid flow rate unit.");
                }
            }
            else if (priority.GetType() == typeof(string[]))
            {
                string[] priorities = (string[])priority;
                foreach (var p in priorities)
                {
                    if (FlowRateUnits.ContainsKey(p))
                    {
                        if (unit1.ToString() == p || unit2.ToString() == p) return FlowRateUnits[p];
                    }
                }
                throw new ArgumentException($"None of the priority units '{string.Join(", ", priorities)}' are valid flow rate units.");
            }
            else
            {
                throw new ArgumentException("Priority must be a string or an array of strings representing unit keys.");
            }
        }
    }

    // Base and derived unit classes
    public abstract class UnitLength
    {
        public decimal ToMetersFactor { get; protected set; }
        protected UnitLength(decimal toMetersFactor) => ToMetersFactor = toMetersFactor;
        public override bool Equals(object obj)
        {
            if (obj is UnitLength other)
            {
                return ToMetersFactor == other.ToMetersFactor && ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToMetersFactor.GetHashCode() ^ ToString().GetHashCode();
        }
        public abstract override string ToString(); // Make ToString abstract
    }
    public abstract class UnitArea
    {
        public decimal ToSquareMetersFactor { get; protected set; }
        protected UnitArea(decimal toSquareMetersFactor) => ToSquareMetersFactor = toSquareMetersFactor;
        public override bool Equals(object obj)
        {
            if (obj is UnitArea other)
            {
                return ToSquareMetersFactor == other.ToSquareMetersFactor && ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToSquareMetersFactor.GetHashCode() ^ ToString().GetHashCode();
        }
        public abstract override string ToString();
    }
    public abstract class UnitVolume
    {
        public decimal ToCubicMetersFactor { get; protected set; }
        protected UnitVolume(decimal toCubicMetersFactor) => ToCubicMetersFactor = toCubicMetersFactor;
        public override bool Equals(object obj)
        {
            if (obj is UnitVolume other)
            {
                return ToCubicMetersFactor == other.ToCubicMetersFactor && ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToCubicMetersFactor.GetHashCode() ^ ToString().GetHashCode();
        }
        public abstract override string ToString();
    }
    public abstract class UnitAngle
    {
        public decimal ToRadiansFactor { get; protected set; }
        protected UnitAngle(decimal toRadiansFactor) => ToRadiansFactor = toRadiansFactor;
        public override bool Equals(object obj)
        {
            if (obj is UnitAngle other)
            {
                return ToRadiansFactor == other.ToRadiansFactor && ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToRadiansFactor.GetHashCode() ^ ToString().GetHashCode();
        }
        public abstract override string ToString();
    }
    public abstract class UnitSlope
    {
        public decimal ToRiseToRunFactor { get; protected set; }
        protected UnitSlope(decimal toRiseToRunFactor) => ToRiseToRunFactor = toRiseToRunFactor;

        // Convert from this unit to rise/run
        public virtual decimal ToRiseRun(decimal value) => value * ToRiseToRunFactor;

        // Convert from rise/run to this unit
        public virtual decimal FromRiseRun(decimal riseRun) => riseRun / ToRiseToRunFactor;

        public override bool Equals(object obj)
        {
            if (obj is UnitSlope other)
            {
                return ToRiseToRunFactor == other.ToRiseToRunFactor && ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToRiseToRunFactor.GetHashCode() ^ ToString().GetHashCode();
        }
        public abstract override string ToString();
    }
    public abstract class UnitTime
    {
        public decimal ToDaysFactor { get; protected set; }
        protected UnitTime(decimal toDaysFactor) => ToDaysFactor = toDaysFactor;
        public override bool Equals(object obj)
        {
            if (obj is UnitTime other)
            {
                return ToDaysFactor == other.ToDaysFactor && ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToDaysFactor.GetHashCode() ^ ToString().GetHashCode();
        }
        public abstract override string ToString();
    }
    public abstract class UnitFlowRate
    {
        public decimal ToCubicMetersPerSecondFactor { get; protected set; }
        protected UnitFlowRate(decimal toCubicMetersPerSecondFactor) => ToCubicMetersPerSecondFactor = toCubicMetersPerSecondFactor;
        public override bool Equals(object obj)
        {
            if (obj is UnitFlowRate other)
            {
                return ToCubicMetersPerSecondFactor == other.ToCubicMetersPerSecondFactor && ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToCubicMetersPerSecondFactor.GetHashCode() ^ ToString().GetHashCode();
        }
        public abstract override string ToString();
    }
    public abstract class ValueValidator
    {
        public string ErrorMessage { get; protected set; }

        public ValueValidator(string errorMessage = "Invalid input")
        {
            ErrorMessage = errorMessage;
        }

        public abstract bool Validate(string input, out object parsedValue);
    }
    public class DecimalValidator : ValueValidator
    {
        public decimal? MinValue { get; }
        public decimal? MaxValue { get; }
        public bool AllowNegative { get; }
        public DecimalValidator(decimal? minValue = null,
                              decimal? maxValue = null,
                              bool allowNegative = true,
                              string errorMessage = "Please enter a valid decimal number.")
            : base(errorMessage)
        {
            // Validate that if both min and max are provided, min <= max
            if (minValue.HasValue && maxValue.HasValue && minValue > maxValue)
                throw new ArgumentException("MinValue cannot be greater than MaxValue");

            MinValue = minValue;
            MaxValue = maxValue;
            AllowNegative = allowNegative;
        }

        public override bool Validate(string input, out object parsedValue)
        {
            parsedValue = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                parsedValue = null; // Allow null/empty to clear the value, consistent with your SetValue
                return true;
            }

            if (!decimal.TryParse(input, out decimal result))
                return false;

            if (!AllowNegative && result < 0)
            {
                ErrorMessage = "Negative numbers are not allowed";
                return false;
            }

            // Optional range checking
            if (MinValue.HasValue && result < MinValue.Value)
            {
                ErrorMessage = $"Value must be greater than or equal to {MinValue.Value}";
                return false;
            }

            if (MaxValue.HasValue && result > MaxValue.Value)
            {
                ErrorMessage = $"Value must be less than or equal to {MaxValue.Value}";
                return false;
            }

            parsedValue = result;
            return true;
        }
    }
    public class TaggedListBoxItem
    {
        public object Tag { get; set; }
        private string _name;
        public TaggedListBoxItem(string displayName, object tag)
        {
            _name = displayName;
            Tag = tag;

        }
        override public string ToString()
        {
            return _name;
        }
    }
}