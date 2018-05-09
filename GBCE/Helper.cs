using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public static class Helper
    {
        /// <summary>
        /// Calculates the Geometric Mean of a list of values.
        /// If there are no values, 0 is returned.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double GetGeometricMean(List<double> values)
        {
            if (values.Count == 0)
            {
                return 0;
            }

            double product = 1d;
            double root = Convert.ToDouble(values.Count());
            double power = 1d / root;

            foreach (var value in values)
            {
                product *= value;
            }

            var geometricMean = Math.Pow(product, power);

            return geometricMean;
        }

        /// <summary>
        /// Calculates the Geometric Mean of a list of values.
        /// Uses logarithm otherwise if the values list has many high values, using the other method may result in overflow.
        /// If there are no values, 0 is returned.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double GetGeometricMeanUsingLog(List<double> values)
        {
            if (values.Count == 0)
            {
                return 0;
            }

            double sum = 0d;
            double count = Convert.ToDouble(values.Count());

            foreach (var value in values)
            {
                double logged = Math.Log(value);
                sum += logged;
            }

            var geometricMean = Math.Exp(sum/count);

            return geometricMean;
        }
    }
}
