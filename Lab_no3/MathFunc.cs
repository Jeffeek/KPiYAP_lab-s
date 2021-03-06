﻿#region Using namespaces

using System;

#endregion

namespace Lab_no3
{
    public static class MathFunc
    {
        public static double Function(int k, int z, int b)
        {
            var x = k < 1 ? z / (double)b : Math.Sqrt(Math.Pow(b * z, 3));

            return -Math.PI + Math.Pow(Math.Cos(Math.Pow(x, 2)), 3) + Math.Pow(Math.Sin(Math.Pow(x, 3)), 2);
        }

        public static int GetPessangerFloor(int roomNumber)
        {
            int floor = 0, room = 0;

            while (room < roomNumber)
            {
                room += 3;
                floor++;
            }

            if (floor % 2 == 0)
                floor--;

            return floor;
        }
    }
}