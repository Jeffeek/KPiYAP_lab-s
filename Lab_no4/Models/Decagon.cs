using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_no4.Models
{
    class Decagon
    {
        public Point Point_1 { get; set; }
        public Point Point_2 { get; set; }
        public Point Point_3 { get; set; }
        public Point Point_4 { get; set; }
        public Point Point_5 { get; set; }
        public Point Point_6 { get; set; }
        public Point Point_7 { get; set; }
        public Point Point_8 { get; set; }
        public Point Point_9 { get; set; }
        public Point Point_10 { get; set; }

        private Point[] allPoints = new Point[10];

        public double GetPerimeter()
        {
            double P = 0.0;

            for (int i = 0; i < allPoints.Length - 1; i++)
            {
                P += GetLengthFromPointToPoint(allPoints[i], allPoints[i+1]);
            }

            return P;
        }

        public double GetLengthFromPointToPoint(Point first, Point second)
        {
            double result = Math.Sqrt((first.X - first.X) * (second.X - first.X) + (second.Y - first.Y) * (second.Y - first.Y));
            return result;
        }

        public void FillCoordinatesRandomly()
        {
            Random rnd = new Random();
            var points = new Point[]
            {
                Point_1,
                Point_2,
                Point_3,
                Point_4,
                Point_5,
                Point_6,
                Point_7,
                Point_8,
                Point_9,
                Point_10
            };

            allPoints = points;
            for (int i = 0; i < 10; i++)
            {
                allPoints[i].X = rnd.Next(-20, 20);
                allPoints[i].Y = rnd.Next(-25, 25);
            }
        }

        public void FillCoordinates(params Point[] points)
        {
            if (points.Length == 10)
                allPoints = points;
            else
                throw new ArgumentException("Должно быть 10 точек!");
        }
    }
}
