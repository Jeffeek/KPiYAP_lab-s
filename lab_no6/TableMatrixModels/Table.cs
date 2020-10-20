using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6.TableMatrixModels
{
    class Table
    {
        public List<Column> Columns { get; }

        public Table(double[,] matrix)
        {
            Columns = new List<Column>();
            FillColumns(matrix);
        }

        private double[] MatrixToColumn(double[,] matrix, int columnIndex)
        {
            double[] vector = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                vector[i] = matrix[i, columnIndex];
            }

            return vector;
        }

        private void FillColumns(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                Columns.Add(new Column(MatrixToColumn(matrix, i)));
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Columns.Count; i++)
            {
                str += Columns[i].ToString();
                str += "\n";
            }


            return "----------------------------------------------------------------\n" +
                   str +
                   "\n----------------------------------------------------------------";
        }
    }
}
