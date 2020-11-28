using System;

namespace Labe_no12
{
    public class GeometricProgression : IProgression
    {
        /// <summary>
        /// знаменатель прогрессии
        /// </summary>
        private double _q;
        /// <summary>
        /// первый член геометрический последовательности
        /// </summary>
        private double _startPoint;

        public double Q
        {
            get => _q;
            private set
            {
                var roundedValue = Math.Round(value, 2);
                if (Math.Abs(roundedValue - 0.00) < 0.001)
                {
                    throw new BadQException();
                }

                _q = roundedValue;
            }
        }

        public double StartPoint
        {
            get => _startPoint;
            private set
            {
                var roundedValue = Math.Round(value, 2);
                _startPoint = roundedValue;
            }
        }

        /// <summary>
        /// инициализатор
        /// </summary>
        /// <param name="startPoint">начальная точка прогрессии</param>
        /// <param name="q">знаменатель прогрессии</param>
        public GeometricProgression(double startPoint, double q)
        {
            StartPoint = startPoint;
            Q = q;
        }

        /// <summary>
        /// вычисление суммы прогрессии до заданного числа
        /// </summary>
        /// <param name="n">заданное число, до которого идёт вычисление суммы прогрессии</param>
        /// <returns>сумма элементов последовательности до n</returns>
        public double Sum(long n) => Math.Round((Get(n) * Q - StartPoint) / (Q - 1), 2);

        /// <summary>
        /// получение n-ого члена прогрессии
        /// </summary>
        /// <param name="n">заданный "индекс" в прогрессии</param>
        /// <returns>n-ый член прогрессии</returns>
        public double Get(long n) => Math.Round(StartPoint * Math.Pow(Q, n - 1), 2);
    }
}
