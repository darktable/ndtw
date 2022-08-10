namespace NDtw.Preprocessing
{
    public class CentralizationPreprocessor : IPreprocessor
    {
        public double[] Preprocess(double[] data)
        {
            var sum = 0.0;
            int length = data.Length;

            for (var i = 0; i < length; i++)
            {
                sum += data[i];
            }

            double avg = sum / length;

            var result = new double[length];

            for (var i = 0; i < length; i++)
            {
                result[i] = data[i] - avg;
            }

            return result;
        }

        public override string ToString()
        {
            return "Centralization";
        }
    }
}
