using System.Linq;

namespace TemplatePattern
{
    public class MatrixTranspositeCalculator : MatrixCalculator
    {
        /// <summary>
        /// Выполняет транспонирование всех матриц
        /// </summary>
        /// <param name="matrices">Массив матриц</param>
        /// <returns>Транспонированные матрицы</returns>
        public override Matrix[] OperateMatrix(Matrix[] matrices)
        {
            return matrices.Select(matrix => matrix.Transposite()).ToArray();
        }
    }
}