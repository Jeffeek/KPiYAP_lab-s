namespace lab_no6
{
    static class MatrixConvertor
    {
        public static Matrix VectorToMatrix(double[] vector)
        {
            Matrix matrix = new Matrix(vector.Length, 1);
            for (int i = 0; i < vector.Length; i++)
                matrix[i, 0] = vector[i];
            return matrix;
        }

        public static double[] MatrixToVector(Matrix matrix)
        {
            double[] vector = new double[matrix.RowsCount];
            for (int i = 0; i < vector.Length; i++)
                vector[i] = matrix[i, 0];
            
            return vector;
        }
    }
}
