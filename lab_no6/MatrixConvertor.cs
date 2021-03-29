namespace lab_no6
{
    internal static class MatrixConvertor
    {
        public static Matrix VectorToMatrix(double[] vector)
        {
            var matrix = new Matrix(vector.Length, 1);
            for (var i = 0; i < vector.Length; i++) matrix[i, 0] = vector[i];

            return matrix;
        }

        public static double[] MatrixToVector(Matrix matrix)
        {
            var vector = new double[matrix.RowsCount];
            for (var i = 0; i < vector.Length; i++) vector[i] = matrix[i, 0];

            return vector;
        }
    }
}