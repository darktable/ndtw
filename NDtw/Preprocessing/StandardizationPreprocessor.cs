using System;
using System.Linq;

namespace NDtw.Preprocessing
{
    public class StandardizationPreprocessor : IPreprocessor
    {
        public double[] Preprocess(double[] data)
        {
            //http://stats.stackexchange.com/questions/1944/what-is-the-name-of-this-normalization
            //http://stats.stackexchange.com/questions/13412/what-are-the-primary-differences-between-z-scores-and-t-scores-and-are-they-bot
            //http://mathworld.wolfram.com/StandardDeviation.html

            // x = (x - mean) / std dev
            var sum = 0.0;
            int length = data.Length;

            for (var i = 0; i < length; i++)
            {
                sum += data[i];
            }

            double mean = sum / length;

            sum = 0.0;
            for (var i = 0; i < length; i++)
            {
                double value = data[i] - mean;
                sum += value * value;
            }

            double stdDev = Math.Sqrt(sum / (length - 1));

            var result = new double[length];

            for (var i = 0; i < length; i++)
            {
                result[i] = (data[i] - mean) / stdDev;
            }

            return result;
        }

        public override string ToString()
        {
            return "Standardization";
        }
    }
}
