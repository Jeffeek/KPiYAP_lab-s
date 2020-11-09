using System;

namespace Labe_no10.First_Task
{
    public class Notebook : PersonalComputer
    {
        public int BatteryLife { get; }

        public Notebook(int batteryLife,int clockSpeed, int coresCount, int ram, int hardDriveCapacity) 
                                     : base(clockSpeed, coresCount, ram, hardDriveCapacity)
        {
            if (batteryLife < 20) throw new ArgumentException(nameof(batteryLife));
            BatteryLife = batteryLife;
        }

        public override double CalculatePrice() => base.CalculatePrice() + BatteryLife / 10.0;
        public override bool IsSuitable() => base.IsSuitable() && BatteryLife >= 60;
        public override string ToString() => base.ToString() + $", {nameof(BatteryLife)}: {BatteryLife}";
    }
}
