namespace TemplatePattern
{
    public class MatrixAdderCalculator : MatrixCalculator
    {
        protected override Matrix[] OperateMatrix(Matrix[] matrices)
        {
            var result = matrices[0];
            for (int i = 1; i < matrices.Length; i++)
            {
                result = result + matrices[i];
            }
            return new Matrix[] {result};
        }
    }
}