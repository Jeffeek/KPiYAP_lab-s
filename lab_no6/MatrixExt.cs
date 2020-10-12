using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6
{
    static class MatrixExt
    {
        public static int RowsCount(this double[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }

        public static int ColumnsCount(this double[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
}
