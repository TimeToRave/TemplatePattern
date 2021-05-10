namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получает название операции для выполнения над матрицами
            string matrixOperationName = args.Length > 0 && args[0].Length > 0 ? args[0].ToLower() : "transponsite";
            // Получает название файла, из которого будет производиться чтение
            string inputFilePath = (args.Length > 1 && args[1].Length > 0) ? args[1] :"input.txt";
            // Получает название файла, в который будет производиться запись
            string outputFilePath = (args.Length > 2 && args[2].Length > 0) ? args[2] : "output.txt";

            MatrixOperationChooser operationChooser = new MatrixOperationChooser();
            
            var calculator = operationChooser.GetMatrixOperation(matrixOperationName);
            calculator.CalculateMatrix(inputFilePath, outputFilePath);
        }
    }
}