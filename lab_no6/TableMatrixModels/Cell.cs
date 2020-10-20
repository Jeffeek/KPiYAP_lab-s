using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6.TableMatrixModels
{
    class Cell
    {
        private int _index;
        private double _value;

        public int Index
        {
            get => _index + 1;
            set => _index = value;
        }

        public double Value
        {
            get => _value;
            set => _value = value;
        }

        public Cell(int index, double value)
        {
            Index = index;
            Value = value;
        }

        public override string ToString()
        {
            return "--------\n" +
                   $"|M[{Index}]={Value}|\n" +
                   "--------";
        }
    }
}
