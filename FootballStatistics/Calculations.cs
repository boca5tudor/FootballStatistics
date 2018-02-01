using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics
{
    class Calculations
    {
        private double freq = 0.2;

        public double meanMiuCalc(int n1, int n2,
            int n3, int n4, int n5)
        {
            return n1 * freq + n2 * freq + n3 * freq + n4 * freq + n5 * freq;

        }

        public double [] standardeviat(int n1, int n2,
            int n3, int n4, int n5)
        {
            double goalsPercent=0;
         double meanMiu = n1 * freq + n2 * freq + n3 * freq + 
                n4 * freq + n5 * freq;

            double miupower2 = meanMiu * meanMiu;

         double sumxpower2px= n1 * freq*n1 + n2 * freq*n2 + n3 * freq*n3 +
                n4 * freq*n4 + n5 * freq*n5;

            double variance = sumxpower2px - miupower2;

            double standardDeviation = Math.Sqrt(variance);

            double zNumberToLook = (1.5 - meanMiu) / standardDeviation;
            zNumberToLook = Math.Round(zNumberToLook, 5);

            double[] calculationsDeviat = {meanMiu, miupower2, sumxpower2px,
            variance, standardDeviation, zNumberToLook,
                goalsPercent};

            return calculationsDeviat;

        }
    }
}
