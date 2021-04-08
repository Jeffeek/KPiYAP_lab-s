#region Using namespaces

using System;
using Lab_no5.Exceptions;

#endregion

namespace Lab_no5.Models
{
    internal class TimeVelosiped
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        private DateTime _timeCorrection;

        public TimeVelosiped() =>
            _timeCorrection = new DateTime(2020,
                                           10,
                                           5,
                                           0,
                                           0,
                                           0);

        public TimeVelosiped(int hours, int minutes, int seconds)
        {
            SetTime(hours, minutes, seconds);

            _timeCorrection = new DateTime(2020,
                                           10,
                                           5,
                                           0,
                                           0,
                                           0);

            _timeCorrection = _timeCorrection.AddHours(Hours);
            _timeCorrection = _timeCorrection.AddMinutes(Minutes);
            _timeCorrection = _timeCorrection.AddSeconds(Seconds);
        }

        public int Hours
        {
            get => _hours;
            set
            {
                if (value > 23
                    || value < 0)
                {
                    _hours = value / 23;

                    throw new TimeHourException();
                }

                _hours = value;

                _timeCorrection = new DateTime(2020,
                                               10,
                                               5,
                                               Hours,
                                               Minutes,
                                               Seconds);
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                if (value > 59
                    || value < 0)
                {
                    _minutes = value % 59;

                    throw new TimeMinuteException();
                }

                _minutes = value;

                _timeCorrection = new DateTime(2020,
                                               10,
                                               5,
                                               Hours,
                                               Minutes,
                                               Seconds);
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                if (value > 59
                    || value < 0)
                {
                    _seconds = value % 59;

                    throw new TimeSecondException();
                }

                _seconds = value;

                _timeCorrection = new DateTime(2020,
                                               10,
                                               5,
                                               Hours,
                                               Minutes,
                                               Seconds);
            }
        }

        public override string ToString() =>
            $"{Hours}:{Minutes}:{Seconds}";

        public void AddSeconds(int seconds)
        {
            var time = _timeCorrection.AddSeconds(seconds);
            Hours = time.Hour;
            Minutes = time.Minute;
            Seconds = time.Second;
            _timeCorrection = time;
        }

        public void AddMinutes(int minutes)
        {
            var time = _timeCorrection.AddMinutes(minutes);
            Hours = time.Hour;
            Minutes = time.Minute;
            Seconds = time.Second;
            _timeCorrection = time;
        }

        public void AddHours(int hours)
        {
            var time = _timeCorrection.AddHours(hours);
            Hours = time.Hour;
            Minutes = time.Minute;
            Seconds = time.Second;
            _timeCorrection = time;
        }

        public void SetTime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}