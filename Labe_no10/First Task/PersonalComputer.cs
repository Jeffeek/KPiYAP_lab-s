using System;

namespace Labe_no10.First_Task
{
    public class PersonalComputer
    {
        public int ClockSpeed { get; }
        public int CoresCount { get; }
        public int RAM { get; }
        public int HardDriveCapacity { get; }

        public PersonalComputer(int clockSpeed, int coresCount, int ram, int hardDriveCapacity)
        {
            if (clockSpeed <= 300) throw new ArgumentException(nameof(clockSpeed));
            if (coresCount <= 1) throw new ArgumentException(nameof(coresCount));
            if (ram <= 512) throw new ArgumentException(nameof(ram));
            if (hardDriveCapacity < 60) throw new ArgumentException(nameof(hardDriveCapacity));
            ClockSpeed = clockSpeed;
            CoresCount = coresCount;
            RAM = ram;
            HardDriveCapacity = hardDriveCapacity;
        }


        public virtual double CalculatePrice() => ClockSpeed * CoresCount / 100.0 +
                                                  RAM / 80.0 +
                                                  HardDriveCapacity / 20.0;

        public virtual bool IsSuitable() => ClockSpeed >= 2000 &&
                                            CoresCount >= 2 &&
                                            RAM >= 2048 && 
                                            HardDriveCapacity >= 320;

        public override string ToString() => $"{nameof(ClockSpeed)}: {ClockSpeed} Mhz," +
                                             $" {nameof(CoresCount)}: {CoresCount}," +
                                             $" {nameof(RAM)}: {RAM} MB," +
                                             $" {nameof(HardDriveCapacity)}: {HardDriveCapacity} GB," +
                                             $" ~Price: {CalculatePrice()}," +
                                             $" IsSuitable: {IsSuitable()}";
    }
}
