using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_no7
{
    class QuadraticEqualation
    {
        private static Regex pattern = new Regex("([+-]?\\d+)[Xx]\\^2\\s*([+-]?\\d+)[Xx]\\s*([+-]?\\d+)\\s*=\\s*0");
        public int X1 { get; }
        public int X2 { get; }
        public int X3 { get; }

        private QuadraticEqualation(int a, int b, int c)
        {
            X1 = a;
            X2 = b;
            X3 = c;
        }

        public static QuadraticEqualation ParseEqualation(string eq)
        {
            var matches = pattern.Match(eq);
            if (matches.Length == 0)
            {
                throw new ArgumentException("Not a valid pattern " + eq);
            }
            int a = int.Parse(matches.Groups[1].ToString());
            int b = int.Parse(matches.Groups[2].ToString());
            int c = int.Parse(matches.Groups[3].ToString());
            return new QuadraticEqualation(a, b, c);
        }

        public double Discriminant => Math.Pow(X2, 2) - 4 * X1 * X3;
        public (double, double) Roots()
        {
            if (Discriminant < 0)
            {
                throw new Exception("D < 0");
            }

            if (Discriminant == 0.0)
            {
                return (-X2 / 2.0 * X1, -X2 / 2.0 * X1);
            }

            double DRoot = Math.Sqrt(Discriminant);

            return ((-X2 + DRoot) / (2.0 * X1),
                    (-X2 - DRoot) / (2.0 * X1));
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("QuadraticEqualation{");
            sb.Append($"a={X1}, b={X2}, c={X3}").Append("}").Append($"\nD: {Discriminant}\nRoots: {Roots().Item1}, {Roots().Item2}");
            return sb.ToString();
        }
    }
}
