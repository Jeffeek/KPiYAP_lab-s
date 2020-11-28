using System;

namespace Labe_no12
{
    class Program
    {
        static void Main(string[] args)
        {
            IProgression geometricProgression;
            try
            {
                geometricProgression = new GeometricProgression(2.11, 0);
            }
            catch (BadQException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            geometricProgression = new GeometricProgression(2.11, 1.22);
            Console.WriteLine(geometricProgression.Sum(5));
            Console.ReadKey();
        }
    }
}
