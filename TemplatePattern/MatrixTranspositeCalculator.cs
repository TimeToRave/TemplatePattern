using System.Linq;

namespace TemplatePattern
{
    public class MatrixTranspositeCalculator : MatrixCalculator
    {
        protected override Matrix[] OperateMatrix(Matrix[] matrices)
        {
            return matrices.Select(matrix => matrix.Transposite()).ToArray();
        }
    }
}