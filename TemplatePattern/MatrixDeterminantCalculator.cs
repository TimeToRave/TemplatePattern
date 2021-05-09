using System;
using System.Collections.Generic;

namespace TemplatePattern
{
    public class MatrixDeterminantCalculator : MatrixCalculator
    {
        protected override Matrix[] OperateMatrix(Matrix[] matrices)
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