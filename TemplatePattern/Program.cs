using System.Collections.Generic;

namespace TemplatePattern
{
    class Program
    {
        /// <summary>
        /// Содержит список доступных операций, которые можно выполнить над матрицами
        /// </summary>
        private static Dictionary<string, MatrixCalculator> availableMatrixOperation =
            new Dictionary<string, MatrixCalculator>()
            {
                {"transponsite", new MatrixTranspositeCalculator()},
                {"determinant", new MatrixDeterminantCalculator()},
                {"summ", new MatrixAdderCalculator()}
            };

        static void Main(string[] args)
        {
            // Получает название операции для выполнения над матрицами
            string matrixOperationName = args.Length > 0 && args[0].Length > 0 ? args[0].ToLower() : "transponsite";
            // Получает название файла, из которого будет производиться чтение
            string inputFilePath = (args.Length > 1 && args[1].Length > 0) ? args[1] :"input.txt";
            // Получает название файла, в который будет производиться запись
            string outputFilePath = (args.Length > 2 && args[2].Length > 0) ? args[2] : "output.txt";
            
            var calculator = GetMatrixOperation(matrixOperationName);
            calculator.CalculateMatrix(inputFilePath, outputFilePath);
        }

        /// <summary>
        /// Возвращает экземпляр класса для работы над матрицами по названию метода
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        private static MatrixCalculator GetMatrixOperation(string methodName)
        {
            return availableMatrixOperation[methodName.ToLower()];
        }
    }
}