using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulQpro.Math.Functions
{
    public class BasePolynomial
    {
        public byte Degree { get; }
        protected double[] Coefficients { get; set; }
        /// <summary>
        /// Returns the coefficient at the given location, indexing coefficients from coefficient of the highest order to the lowest
        /// (for example, 'a' in "ax^2+bx +c" has an index of 0, 'c' has an index of 2)
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public double GetCoefficient(byte place)
        {
            return Coefficients[place];
        }
        public BasePolynomial(byte degree, double[] coefficients)
        {
            Degree = degree;
            if(coefficients.Length >= degree)
            {
                Coefficients = new double[degree];
                for (int i = degree - 1; i >= 0; i--)
                {
                    Coefficients[i] = coefficients[coefficients.Length-degree+i];
                }
            }
            else if (coefficients.Length < degree)
            {
                Coefficients = new double[degree];
                for (int i = coefficients.Length - 1; i >= 0; i--)
                {
                    Coefficients[Coefficients.Length - coefficients.Length + i] = coefficients[i];
                }
            }
            else
            {
                Coefficients = coefficients;
            }
        }
        public override string ToString()
        {
            string res = "";
            for(int i = 0; i<Degree; i++)
            {
                res += Coefficients[i] + ";";
            }
            return res;
        }
    }
}
