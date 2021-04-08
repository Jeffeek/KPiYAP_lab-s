#region Using namespaces

using System.Collections.Generic;

#endregion

namespace lab_no6.TableMatrixModels
{
    internal class Table
    {
        public Table(double[,] matrix)
        {
            Columns = new List<Column>();
            FillColumns(matrix);
        }

        public List<Column> Columns { get; }

        private double[] MatrixToColumn(double[,] matrix, int columnIndex)
        {
            var vector = new double[matrix.GetLength(0)];

            for (var i = 0; i < matrix.GetLength(0); i++)
                vector[i] = matrix[i, columnIndex];

            return vector;
        }

        private void FillColumns(double[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(1); i++)
                Columns.Add(new Column(MatrixToColumn(matrix, i)));
        }

        public override string ToString()
        {
            var str = "";

            for (var i = 0; i < Columns.Count; i++)
            {
                str += Columns[i]
                    .ToString();

                str += "\n";
            }

            return "----------------------------------------------------------------\n"
                   + str
                   + "\n----------------------------------------------------------------";
        }
    }
}