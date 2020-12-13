using System;
using System.Text;

namespace Labe_no13
{
    public class Matrix : IEquatable<Matrix>
    {
        private readonly double[][] _innerMatrix;
        public int ColumnsCount { get; }
        public int RowsCount { get; }
        public bool IsSquare => RowsCount == ColumnsCount;

        public double this[int row, int column]
        {
            get => Math.Round(_innerMatrix[row][column], 2);
            set => _innerMatrix[row][column] = Math.Round(value, 2);
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            ColumnsCount = columnsCount;
            RowsCount = rowsCount;
            _innerMatrix = new double[rowsCount][];
            FillColumns();
        }

        private void FillColumns()
        {
            for (int i = 0; i < RowsCount; i++)
                _innerMatrix[i] = new double[ColumnsCount];
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                    sb.Append( $"{this[i, j]} | ");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public override string ToString() => GetAsString();

        public bool Equals(Matrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_innerMatrix, other._innerMatrix) && 
                   ColumnsCount == other.ColumnsCount && 
                   RowsCount == other.RowsCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Matrix) obj);
        }

        public double DiagonalSum()
        {
            if (!IsSquare) return default;
            double sum = 0.0;
            for (int i = 0; i < RowsCount; i++)
                sum += this[i, i];
            return Math.Round(sum, 2);
        }

        public double AvgSum()
        {
            double sum = 0.0;
            for (int i = 0; i < RowsCount; i++)
                for (int j = 0; j < ColumnsCount; j++)
                    sum += this[i, j];
            return Math.Round(sum / (RowsCount * ColumnsCount), 2);
        }

        public double SumSaddlePoints()
        {
            double sum = 0.0;
            for (int i = 0; i < RowsCount; i++)
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (!IsMinInRow(i, j) || !IsMaxInCol(i, j)) continue;
                    sum += this[i, j];
                }
            return sum;
        }

        private bool IsMaxInCol(int i, int j)
        {
            for (int k = 0; k < RowsCount; k++)
                if (this[k, j] > this[i, j])
                    return false;
            return true;
        }

        private bool IsMinInRow(int i, int j)
        {
            for (int k = 0; k < ColumnsCount; k++)
                if (this[i, k] < this[i, j])
                    return false;
            return true;
        }

        public void FillRandomly(double min = -50, double max = 50)
        {
            var rnd = new Random();

            for (int i = 0; i < RowsCount; i++)
                for (int j = 0; j < ColumnsCount; j++)
                    this[i, j] = min + (max - min) * rnd.NextDouble();
        }
    }
}
