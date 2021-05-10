using System;
using System.Collections.Generic;

namespace TemplatePattern
{
    public class MatrixOperationChooser
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
        
        /// <summary>
        /// Возвращает экземпляр класса для работы над матрицами по названию метода
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public MatrixCalculator GetMatrixOperation(string methodName)
        {
            try
            {
                return availableMatrixOperation[methodName.ToLower()];
                
            }
            catch (Exception)
            {
                return availableMatrixOperation["transponsite"];
            }
        }
    }
}