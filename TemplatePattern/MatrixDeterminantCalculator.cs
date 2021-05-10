using System;
using System.Collections.Generic;

namespace TemplatePattern
{
    public class MatrixDeterminantCalculator : MatrixCalculator
    {
        /// <summary>
        /// Подсчитывает определитель матриц
        /// </summary>
        /// <param name="matrices">Массив матриц</param>
        /// <returns>Определители матриц</returns>
        public override Matrix[] OperateMatrix(Matrix[] matrices)
        {
            List<Matrix> result = new List<Matrix>();
            foreach (var matrix in matrices)
            {
                try
                {
                    result.Add( new Matrix(matrix.CalculateDeterminant().ToString()));
                }
                catch (Exception)
                {
                    result.Add(new Matrix());
                }
            }

            return result.ToArray();
        }
    }
}