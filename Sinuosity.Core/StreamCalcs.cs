using System;
using System.Collections.Generic;


namespace Sinuosity
{
    public static class StreamCalcs
    {
        public static Dictionary<string, double> CalculateGradeControlSectionData(
        double bankfullCrossSectionAreaInput, // Bankfull Cross-Section Area (Input)
        double bankfullWidthToDepthRatioInput, // Bankfull Width to Depth Ratio (Input)
        double bankfullSideSlopeInput, // Bankfull Side Slope (Input)
        double? lowFlowPercentInput = null, // Low Flow Percent (Input), optional
        double? lowFlowWidthToDepthRatioInput = null, // Low Flow Width to Depth Ratio (Input), optional
        double? lowFlowSideSlopeInput = null // Low Flow Side Slope (Input), optional
        )
        {
            var results = new Dictionary<string, double>
        {
            { "Bankfull Cross-Section Area (Input)", bankfullCrossSectionAreaInput },
            { "Bankfull Width to Depth Ratio (Input)", bankfullWidthToDepthRatioInput },
            { "Bankfull Side Slope (Input)", bankfullSideSlopeInput },
            { "Low Flow Percent (Input)", lowFlowPercentInput ?? double.NaN },
            { "Low Flow Width to Depth Ratio (Input)", lowFlowWidthToDepthRatioInput ?? double.NaN },
            { "Low Flow Side Slope (Input)", lowFlowSideSlopeInput ?? double.NaN }
        };

            // Always calculate Stage 2 values (trapezoidal channel) regardless of low flow
            double effectiveLowFlowPercent = lowFlowPercentInput.HasValue && lowFlowPercentInput.Value != 0 ? lowFlowPercentInput.Value : 0;

            // Stage 2 Area (D40)
            results["Stage 2 Area"] = bankfullCrossSectionAreaInput * (1 - effectiveLowFlowPercent);

            // Stage 2 Clamped W/d (D39)
            results["Stage 2 Clamped W/d"] = (bankfullWidthToDepthRatioInput / (1 - effectiveLowFlowPercent)) / bankfullSideSlopeInput < 4
                ? bankfullSideSlopeInput * 4
                : bankfullWidthToDepthRatioInput / (1 - effectiveLowFlowPercent);

            // Stage 2 Top Width (D41)
            results["Stage 2 Top Width"] = Math.Sqrt(results["Stage 2 Area"] * results["Stage 2 Clamped W/d"]);

            // Stage 2 Bottom Width (D42)
            results["Stage 2 Bottom Width"] = Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput) -
                                              2 * bankfullSideSlopeInput * (Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput) -
                                              Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput - 4 * bankfullSideSlopeInput *
                                              bankfullCrossSectionAreaInput * (1 - effectiveLowFlowPercent))) / (2 * bankfullSideSlopeInput);

            // Stage 2 Mean Depth (D43)
            results["Stage 2 Mean Depth"] = results["Stage 2 Area"] / results["Stage 2 Top Width"];

            // Stage 2 Max Depth (D44)
            results["Stage 2 Max Depth"] = (results["Stage 2 Top Width"] - Math.Sqrt(results["Stage 2 Area"] * results["Stage 2 Clamped W/d"] - 4 * bankfullSideSlopeInput * results["Stage 2 Area"])) / (2 * bankfullSideSlopeInput);

            // Bankfull outputs (always calculated)
            results["Bankfull Cross-Section Area"] = bankfullCrossSectionAreaInput; // Will be updated if low flow exists
            results["Bankfull Width"] = results["Stage 2 Top Width"];
            results["Bankfull Mean Depth"] = results["Bankfull Cross-Section Area"] / results["Bankfull Width"];
            results["Bankfull Width to Depth Ratio"] = results["Bankfull Width"] / results["Bankfull Mean Depth"];

            // Handle simple trapezoidal channel case when low flow percent is null or 0
            bool hasLowFlow = lowFlowPercentInput.HasValue && lowFlowPercentInput.Value != 0;

            if (!hasLowFlow)
            {
                // Bankfull Max Depth for simple trapezoidal case
                results["Bankfull Max Depth"] = (results["Bankfull Width"] - Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput - 4 * bankfullSideSlopeInput * bankfullCrossSectionAreaInput)) / (2 * bankfullSideSlopeInput);

                // Set low-flow-specific and Stage 1 outputs to NaN
                results["Low Flow Width to Depth Ratio Max"] = double.NaN;
                results["Low Flow Width to Depth Ratio Min"] = double.NaN;
                results["Low Flow Width to Depth Ratio"] = double.NaN;
                results["Low Flow Area Percent"] = double.NaN;
                results["Low Flow Cross-Section Area"] = double.NaN;
                results["Low Flow Width"] = double.NaN;
                results["Low Flow Mean Depth"] = double.NaN;
                results["Low Flow Max Depth"] = double.NaN;
                results["Inner Berm Bench Width"] = double.NaN;
                results["Stage 1 Area"] = double.NaN;
                results["Stage 1 Clamped W/d"] = double.NaN;
                results["Stage 1 Top Width"] = double.NaN;
                results["Stage 1 Bottom Width"] = double.NaN;
                results["Stage 1 Mean Depth"] = double.NaN;
                results["Stage 1 Max Depth"] = double.NaN;

                return results;
            }

            // Full calculation when low flow percent is provided and non-zero
            double lowFlowPercent = lowFlowPercentInput.Value;
            double lowFlowWidthToDepthRatio = lowFlowWidthToDepthRatioInput ?? 0; // Default to 0 if not provided
            double lowFlowSideSlope = lowFlowSideSlopeInput ?? 0; // Default to 0 if not provided

            // Low Flow Width to Depth Ratio Max (D22)
            results["Low Flow Width to Depth Ratio Max"] = Math.Floor(Math.Pow(
                (Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput) -
                 2 * bankfullSideSlopeInput * (Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput) -
                                               Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput - 4 * bankfullSideSlopeInput * bankfullCrossSectionAreaInput * (1 - lowFlowPercent))) /
                 (2 * bankfullSideSlopeInput)), 2) / (lowFlowPercent * bankfullCrossSectionAreaInput) * 10) / 10;

            // Low Flow Width to Depth Ratio Min (D24)
            results["Low Flow Width to Depth Ratio Min"] = Math.Ceiling(lowFlowSideSlope * 4 * 10) / 10;

            // Stage 1 Area (D46)
            results["Stage 1 Area"] = lowFlowPercent * bankfullCrossSectionAreaInput;

            // Stage 1 Clamped W/d (D45)
            double temp = Math.Pow(
                Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput) -
                2 * bankfullSideSlopeInput * (Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput) -
                Math.Sqrt(bankfullCrossSectionAreaInput * bankfullWidthToDepthRatioInput - 4 * bankfullSideSlopeInput * 
                bankfullCrossSectionAreaInput * (1 - lowFlowPercent))) / (2 * bankfullSideSlopeInput), 2) / (lowFlowPercent *
                bankfullCrossSectionAreaInput);
            results["Stage 1 Clamped W/d"] = lowFlowWidthToDepthRatio > temp ? temp : (lowFlowWidthToDepthRatio < lowFlowSideSlope * 4 ? lowFlowSideSlope * 4 : lowFlowWidthToDepthRatio);

            // Stage 1 Top Width (D47)
            results["Stage 1 Top Width"] = Math.Sqrt(results["Stage 1 Area"] * results["Stage 1 Clamped W/d"]);

            // Stage 1 Max Depth (D50)
            results["Stage 1 Max Depth"] = (results["Stage 1 Top Width"] - Math.Sqrt(results["Stage 1 Area"] * results["Stage 1 Clamped W/d"] - 4 * lowFlowSideSlope * results["Stage 1 Area"])) / (2 * lowFlowSideSlope);

            // Stage 1 Bottom Width (D48)
            results["Stage 1 Bottom Width"] = results["Stage 1 Top Width"] - 2 * lowFlowSideSlope * results["Stage 1 Max Depth"];

            // Stage 1 Mean Depth (D49)
            results["Stage 1 Mean Depth"] = double.TryParse((results["Stage 1 Area"] / results["Stage 1 Top Width"]).ToString(), out double meanDepth) ? meanDepth : 0;

            // Update Bankfull Cross-Section Area (D28)
            results["Bankfull Cross-Section Area"] = results["Stage 1 Area"] + results["Stage 2 Area"];

            // Update Bankfull Mean Depth (D30)
            results["Bankfull Mean Depth"] = results["Bankfull Cross-Section Area"] / results["Bankfull Width"];

            // Bankfull Max Depth (D31)
            results["Bankfull Max Depth"] = (double.TryParse(results["Stage 1 Max Depth"].ToString(), out double stage1MaxDepth) ? stage1MaxDepth : 0) + results["Stage 2 Max Depth"];

            // Low Flow Area Percent (D32)
            results["Low Flow Area Percent"] = results["Stage 1 Area"] / (results["Stage 1 Area"] + results["Stage 2 Area"]);

            // Low Flow Width to Depth Ratio (D33)
            results["Low Flow Width to Depth Ratio"] = lowFlowWidthToDepthRatio / lowFlowSideSlope < 4
                ? lowFlowSideSlope * 4
                : results["Stage 1 Clamped W/d"];

            // Low Flow Cross-Section Area (D34)
            results["Low Flow Cross-Section Area"] = results["Stage 1 Area"];

            // Low Flow Width (D35)
            results["Low Flow Width"] = results["Stage 1 Top Width"];

            // Low Flow Mean Depth (D36)
            results["Low Flow Mean Depth"] = results["Stage 1 Mean Depth"];

            // Low Flow Max Depth (D37)
            results["Low Flow Max Depth"] = results["Stage 1 Max Depth"];

            // Inner Berm Bench Width (D38)
            results["Inner Berm Bench Width"] = (results["Stage 2 Bottom Width"] - results["Stage 1 Top Width"]) / 2;

            // Update Bankfull Width to Depth Ratio (D27)
            results["Bankfull Width to Depth Ratio"] = results["Bankfull Width"] / results["Bankfull Mean Depth"];

            return results;
        }
    }
}
