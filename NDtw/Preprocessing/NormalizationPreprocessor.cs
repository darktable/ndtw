// using System.Linq;

using System;
namespace NDtw.Preprocessing
{
    public class NormalizationPreprocessor : IPreprocessor
    {
        private readonly double _minBoundary;
        private readonly double _maxBoundary;

        /// <summary>
        /// Initialize to use normalization to range [0, 1]
        /// </summary>
        public NormalizationPreprocessor() : this (0, 1) { }

        /// <summary>
        /// Initialize to use normalization to range [minBoundary, maxBoundary]
        /// </summary>
        public NormalizationPreprocessor(double minBoundary, double maxBoundary)
        {
            _minBoundary = minBoundary;
            _maxBoundary = maxBoundary;
        }

        public double[] Preprocess(double[] data)
        {
            // x = ((x - min_x) / (max_x - min_x)) * (maxBoundary - minBoundary) + minBoundary

            int length = data.Length;

            var min = double.MaxValue;
            var max = double.MinValue;

            for (var i = 0; i < length; i++)
            {
                min = Math.Min(min, data[i]);
                max = Math.Max(max, data[i]);
            }

            double constFactor = (_maxBoundary - _minBoundary)/(max - min);

            var result = new double[length];

            for (var i = 0; i < length; i++)
            {
                result[i] = (data[i] - min) * constFactor + _minBoundary;
            }

            return result;
        }

        public override string ToString()
        {
            return "Normalization";
        }
    }
}
