namespace lab_no6.TableMatrixModels
{
    internal class Cell
    {
        private int _index;

        public Cell(int index, double value)
        {
            Index = index;
            Value = value;
        }

        public int Index
        {
            get => _index + 1;
            set => _index = value;
        }

        public double Value { get; set; }

        public override string ToString() => "--------\n" + $"|M[{Index}]={Value}|\n" + "--------";
    }
}