public static class Utilitary {
    public static void multiplyInplace(double[,] a, double[,] b) {
        if (a.Length != b.Length) {
            Console.WriteLine("multiplyInplace : matrices lenght mismatched !");
            throw new IndexOutOfRangeException();
        }
        for (int i = 0; i < a.GetLength(0); i++) {
            for (int j = 0; j < a.GetLength(1); j++) {
                a[i,j] = a[i,j] * b[i,j];
            }
        }
    }
}
