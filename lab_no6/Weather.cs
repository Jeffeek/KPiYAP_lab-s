using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6
{
    class Weather
    {
        private Dictionary<string, double[]> _weatherDictionary { get; }

        public Weather()
        {
            _weatherDictionary = new Dictionary<string, double[]>();
            FillMonthsRand();
        }

        private void FillMonthsRand()
        {
            _weatherDictionary.Add("January", GetRandTemps(-15, 10, 31));
            _weatherDictionary.Add("February", GetRandTemps(-20, 15, 28));
            _weatherDictionary.Add("March", GetRandTemps(-5, 15));
            _weatherDictionary.Add("April", GetRandTemps(5, 20, 31));
            _weatherDictionary.Add("May", GetRandTemps(8, 23));
            _weatherDictionary.Add("June", GetRandTemps(15, 28, 31));
            _weatherDictionary.Add("July", GetRandTemps(20, 35));
            _weatherDictionary.Add("August", GetRandTemps(18, 33, 31));
            _weatherDictionary.Add("September", GetRandTemps(7, 25, 31));
            _weatherDictionary.Add("October", GetRandTemps(6, 20));
            _weatherDictionary.Add("November", GetRandTemps(0, 15, 31));
            _weatherDictionary.Add("December", GetRandTemps(-10, 5));
        }

        private double[] GetRandTemps(int min, int max, int days = 30)
        {
            var rnd = new Random();
            double[] temps = new double[days];
            for (int i = 0; i < days; i++)
                temps[i] = (double)rnd.Next();
            return temps;
        }

        public int GetCountOfDaysLessAvg(string key)
        {
            if (!_weatherDictionary.ContainsKey(key)) throw new ArgumentException();
            var temps = _weatherDictionary[key];
            var avg = temps.Average();
            var result = temps.Count(x => x < avg);
            return result;
        }
    }
}
