using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab_no20
{
    public static class MathBicycle
    {
        public static async Task<double> Pow(double number, double power)
        {
            return await Task.Run(() =>
                                  {
                                      var result = number;

                                      while (power > 0)
                                      {
                                          result *= number;
                                          power--;
                                      }

                                      return result;
                                  });
        }
    }
}
