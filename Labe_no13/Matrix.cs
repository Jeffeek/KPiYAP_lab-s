#region Using namespaces

using System;
using System.Text;

#endregion

namespace Labe_no13
{
    public class Matrix : IEquatable<Matrix>
    {
        private readonly double[][] _innerMatrix;

        public Matrix(int rowsCount, int columnsCount)
        {
            ColumnsCount = columnsCount;
            RowsCount = rowsCount;
            _innerMatrix = new double[rowsCount][];
            FillColumns();
        }

        public int ColumnsCount { get; }

        public int RowsCount { get; }

        public bool IsSquare => RowsCount == ColumnsCount;

        public double this[int row, int column]
        {
            get => Math.Round(_innerMatrix[row][column], 2);
            set => _innerMatrix[row][column] = Math.Round(value, 2);
        }

        public bool Equals(Matrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Equals(_innerMatrix, other._innerMatrix)
                   && ColumnsCount == other.ColumnsCount
                   && RowsCount == other.RowsCount;
        }

        private void FillColumns()
        {
            for (var i = 0; i < RowsCount; i++) _innerMatrix[i] = new double[ColumnsCount];
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < RowsCount; i++)
            {
                for (var j = 0; j < ColumnsCount; j++) sb.Append($"{this[i, j]} | ");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public override string ToString() => GetAsString();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Matrix)obj);
        }

        public double DiagonalSum()
        {
            if (!IsSquare) return default;
            var sum = 0.0;
            for (var i = 0; i < RowsCount; i++) sum += this[i, i];

            return Math.Round(sum, 2);
        }

        public double AvgSum()
        {
            var sum = 0.0;

            for (var i = 0; i < RowsCount; i++)
            {
                for (var j = 0; j < ColumnsCount; j++) sum += this[i, j];
            }

            return Math.Round(sum / (RowsCount * ColumnsCount), 2);
        }

        public double SumSaddlePoints()
        {
            var sum = 0.0;

            for (var i = 0; i < RowsCount; i++)
            {
                for (var j = 0; j < ColumnsCount; j++)
                {
                    if (!IsMinInRow(i, j)
                        || !IsMaxInCol(i, j))
                        continue;

                    sum += this[i, j];
                }
            }

            return sum;
        }

        private bool IsMaxInCol(int i, int j)
        {
            for (var k = 0; k < RowsCount; k++)
                if (this[k, j] > this[i, j])
                    return false;

            return true;
        }

        private bool IsMinInRow(int i, int j)
        {
            for (var k = 0; k < ColumnsCount; k++)
                if (this[i, k] < this[i, j])
                    return false;

            return true;
        }

        public void FillRandomly(double min = -50, double max = 50)
        {
            var rnd = new Random();

            for (var i = 0; i < RowsCount; i++)
            {
                for (var j = 0; j < ColumnsCount; j++) this[i, j] = min + (max - min) * rnd.NextDouble();
            }
        }
    }
}