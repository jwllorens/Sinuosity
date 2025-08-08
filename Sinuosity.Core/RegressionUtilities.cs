using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;
using System.Linq;
using System;


namespace Sinuosity.Common
{
    public static class RegressionUtilities
    {
        public class RegressionResult
        {
            public double Intercept { get; set; }
            public double Coefficient { get; set; }
            public double RSquared { get; set; }
        }

        /// <summary>
        /// Performs power-law regression: y = a * x^b
        /// Returns intercept (a), exponent (b), and R²
        /// </summary>
        public static RegressionResult PowerLawRegression(IList<double> xValues, IList<double> yValues)
        {
            if (xValues == null || yValues == null || xValues.Count != yValues.Count || xValues.Count < 2)
                throw new ArgumentException("Invalid input data for regression");

            // Updated variable name in the lambda expression to avoid conflict
            var validPairs = xValues.Zip(yValues, (x, yValue) => new { X = x, Y = yValue })
                                    .Where(p => p.X > 0 && p.Y > 0)
                                    .ToList();

            if (validPairs.Count < 2)
                throw new ArgumentException("Insufficient valid data points for power-law regression");

            var logX = validPairs.Select(p => Math.Log10(p.X)).ToArray();
            var logY = validPairs.Select(p => Math.Log10(p.Y)).ToArray();

            // Linear regression: log(y) = log(a) + b * log(x)
            var designMatrix = DenseMatrix.OfArray(new double[logX.Length, 2]);
            for (int i = 0; i < logX.Length; i++)
            {
                designMatrix[i, 0] = 1;      // Intercept term
                designMatrix[i, 1] = logX[i]; // Slope term
            }
            var y = DenseVector.OfArray(logY);
            var coefficients = designMatrix.Transpose().Multiply(designMatrix).Inverse()
                                         .Multiply(designMatrix.Transpose()).Multiply(y);

            var logA = coefficients.At(0);
            var b = coefficients.At(1);
            var a = Math.Pow(10, logA);

            // Calculate R²
            var meanLogY = logY.Average();
            var ssTot = logY.Sum(ly => Math.Pow(ly - meanLogY, 2));
            var yPred = logX.Select(lx => logA + b * lx).ToArray();
            var ssRes = logY.Zip(yPred, (ly, yp) => Math.Pow(ly - yp, 2)).Sum();
            var rSquared = ssTot > 0 ? 1 - ssRes / ssTot : 0;

            return new RegressionResult
            {
                Intercept = a,
                Coefficient = b,
                RSquared = rSquared
            };
        }

        /// <summary>
        /// Performs linear regression: y = a + b * x
        /// Returns intercept (a), slope (b), and R²
        /// </summary>
        public static RegressionResult LinearRegression(IList<double> xValues, IList<double> yValues)
        {
            if (xValues == null || yValues == null || xValues.Count != yValues.Count || xValues.Count < 2)
                throw new ArgumentException("Invalid input data for regression");

            var designMatrix = DenseMatrix.OfArray(new double[xValues.Count, 2]);
            for (int i = 0; i < xValues.Count; i++)
            {
                designMatrix[i, 0] = 1;        // Intercept term
                designMatrix[i, 1] = xValues[i]; // Slope term
            }
            var y = DenseVector.OfArray(yValues.ToArray());
            var coefficients = designMatrix.Transpose().Multiply(designMatrix).Inverse()
                                         .Multiply(designMatrix.Transpose()).Multiply(y);

            var a = coefficients.At(0);
            var b = coefficients.At(1);

            // Calculate R²
            var meanY = yValues.Average();
            var ssTot = yValues.Sum(yValue => Math.Pow(yValue - meanY, 2));
            var yPred = xValues.Select(x => a + b * x).ToArray();
            var ssRes = yValues.Zip(yPred, (yValue, yp) => Math.Pow(yValue - yp, 2)).Sum();
            var rSquared = ssTot > 0 ? 1 - ssRes / ssTot : 0;

            return new RegressionResult
            {
                Intercept = a,
                Coefficient = b,
                RSquared = rSquared
            };
        }

        /// <summary>
        /// Performs exponential regression: y = a * e^(b * x)
        /// Returns intercept (a), exponent (b), and R²
        /// </summary>
        public static RegressionResult ExponentialRegression(IList<double> xValues, IList<double> yValues)
        {
            if (xValues == null || yValues == null || xValues.Count != yValues.Count || xValues.Count < 2)
                throw new ArgumentException("Invalid input data for regression");

            // Filter out non-positive y values for log transformation
            var validPairs = xValues.Zip(yValues, (xValue, yValue) => new { X = xValue, Y = yValue })
                                    .Where(p => p.Y > 0)
                                    .ToList();

            if (validPairs.Count < 2)
                throw new ArgumentException("Insufficient valid data points for exponential regression");

            var x = validPairs.Select(p => p.X).ToArray();
            var logY = validPairs.Select(p => Math.Log(p.Y)).ToArray();

            // Linear regression: ln(y) = ln(a) + b * x
            var designMatrix = DenseMatrix.OfArray(new double[x.Length, 2]);
            for (int i = 0; i < x.Length; i++)
            {
                designMatrix[i, 0] = 1;    // Intercept term
                designMatrix[i, 1] = x[i]; // Slope term
            }
            var y = DenseVector.OfArray(logY);
            var coefficients = designMatrix.Transpose().Multiply(designMatrix).Inverse()
                                         .Multiply(designMatrix.Transpose()).Multiply(y);

            var lnA = coefficients.At(0);
            var b = coefficients.At(1);
            var a = Math.Exp(lnA);

            // Calculate R²
            var meanLogY = logY.Average();
            var ssTot = logY.Sum(ly => Math.Pow(ly - meanLogY, 2));
            var yPred = x.Select(xi => lnA + b * xi).ToArray();
            var ssRes = logY.Zip(yPred, (ly, yp) => Math.Pow(ly - yp, 2)).Sum();
            var rSquared = ssTot > 0 ? 1 - ssRes / ssTot : 0;

            return new RegressionResult
            {
                Intercept = a,
                Coefficient = b,
                RSquared = rSquared
            };
        }

        /// <summary>
        /// Generates points for a power-law curve: y = a * x^b
        /// </summary>
        public static (double[] X, double[] Y) GeneratePowerLawCurve(double a, double b, double xMin, double xMax, int pointCount)
        {
            var x = Enumerable.Range(0, pointCount)
                             .Select(i => xMin * Math.Pow(xMax / xMin, i / (double)(pointCount - 1)))
                             .ToArray();
            var y = x.Select(cx => a * Math.Pow(cx, b)).ToArray();
            return (x, y);
        }

        /// <summary>
        /// Generates points for a linear curve: y = a + b * x
        /// </summary>
        public static (double[] X, double[] Y) GenerateLinearCurve(double a, double b, double xMin, double xMax, int pointCount)
        {
            var x = Enumerable.Range(0, pointCount)
                             .Select(i => xMin + (xMax - xMin) * i / (pointCount - 1))
                             .ToArray();
            var y = x.Select(cx => a + b * cx).ToArray();
            return (x, y);
        }

        /// <summary>
        /// Generates points for an exponential curve: y = a * e^(b * x)
        /// </summary>
        public static (double[] X, double[] Y) GenerateExponentialCurve(double a, double b, double xMin, double xMax, int pointCount)
        {
            var x = Enumerable.Range(0, pointCount)
                             .Select(i => xMin + (xMax - xMin) * i / (pointCount - 1))
                             .ToArray();
            var y = x.Select(cx => a * Math.Exp(b * cx)).ToArray();
            return (x, y);
        }
    }
}