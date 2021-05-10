using NUnit.Framework;
using TemplatePattern;

namespace TemplatePatternTests
{
    [TestFixture]
    public class MatrixDetermainantCalculator
    {
        /// <summary>
        /// Проверка класса - транспонирования  на двух матрицах
        /// </summary>
        [Test]
        public void MatrixDeterminantCalculator_OperateMatrix_TwoMatrices()
        {
            Matrix a = new Matrix(
                new int[,]
                {
                    {4, 1},
                    {2, 11}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {1, 1, 1},
                    {2, 5, 2},
                    {3, 9, 3}
                }
            );


            var calculator = new MatrixDeterminantCalculator();
            var result = calculator.OperateMatrix(new Matrix[] {a, b});

            Assert.IsTrue(
                result[0].Data[0, 0] == 42 &&
                result[1].Data[0, 0] == 0
            );
        }

        /// <summary>
        /// Проверка класса - транспонирования на одной матрице
        /// </summary>
        [Test]
        public void MatrixDeterminantCalculator_OperateMatrix_OneMatrix()
        {
            Matrix a = new Matrix(
                new int[,]
                {
                    {4, 1},
                    {2, 11}
                }
            );

            var calculator = new MatrixDeterminantCalculator();
            var result = calculator.OperateMatrix(new Matrix[] {a});

            Assert.IsTrue(
                result[0].Data[0, 0] == 42
            );
        }
    }
}