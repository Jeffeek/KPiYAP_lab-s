namespace Lab_no15._2
{
    public class FeudalGameSettings
    {
        private double _peasantSpawnChance = 0.3;
        public double PeasantSpawnChance
        {
            get => _peasantSpawnChance;
            internal set
            {
                if (value > 1.0 ||
                   value < 0.0) return;

                _peasantSpawnChance = value;
            }
        }

        public int MaxPeasantCount { get; internal set; } = 10;

        public int PeasantsTargetCount { get; }

        //for new game
        public FeudalGameSettings(int peasantsTargetCount) => PeasantsTargetCount = peasantsTargetCount;

        //for load
        public FeudalGameSettings(DTOGameSettingsSave dto)
        {
            PeasantSpawnChance = dto.PeasantSpawnChance;
            MaxPeasantCount = dto.MaxPeasantCount;
            PeasantsTargetCount = dto.PeasantsTargetCount;
        }
    }
}
