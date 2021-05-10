using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public abstract class MatrixCalculator
    {
        public abstract Matrix[] OperateMatrix(Matrix[] matrices);


        /// <summary>
        /// Выполняет операции над матрицами
        /// </summary>
        /// <param name="inputFilePath">Название входного файла</param>
        /// <param name="outputFilePath">Название итогового файла</param>
        public void CalculateMatrix(string inputFilePath, string outputFilePath)
        {
            Matrix[] matrices = PrepareMatrix(inputFilePath);
            Matrix[] result = OperateMatrix(matrices);
            SaveMatrix(result, outputFilePath);
        }

        /// <summary>
        /// Считывает матрицу из указанного файла
        /// </summary>
        /// <returns>Подготовленная матрица</returns>
        private Matrix[] PrepareMatrix(string inputFilePath)
        {
            FileOperator fileOperator = new FileOperator();
            string fileContent = fileOperator.ReadTextFromFile(inputFilePath);
            fileContent = fileContent.Replace("\r\n", string.Empty);
            string[] stringMatrices = fileContent.Split('#');

            List<Matrix> matrices = new List<Matrix>();
            foreach (string stringMatrix in stringMatrices)
            {
                matrices.Add(new Matrix(stringMatrix));
            }

            return matrices.ToArray();
        }

        /// <summary>
        /// Сохраняет матрицу в указанный файл
        /// </summary>
        /// <param name="matrix">Сохраняемая матрица</param>
        /// <param name="outputFilePath">Адрес файла, в который записывается матрица</param>
        private void SaveMatrix(Matrix[] matrices, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var matrix in matrices)
            {
                sb.Append(matrix.ToString() + "\n#\n");
            }

            FileOperator fileOperator = new FileOperator();
            fileOperator.WriteTextToFile(outputFilePath, sb.ToString());
        }
    }
}