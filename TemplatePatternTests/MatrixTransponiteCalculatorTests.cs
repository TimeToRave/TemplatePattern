using NUnit.Framework;
using TemplatePattern;

namespace TemplatePatternTests
{
    [TestFixture]
    public class MatrixTransponiteCalculatorTests
    {
        /// <summary>
        /// Проверка класса - транспонирования  на двух матрицах
        /// </summary>
        [Test]
        public void MatrixTranspositeCalculator_OperateMatrix_TwoMatrices()
        {
            Matrix a = new Matrix(
                new int[,]
                {
                    {1, 1},
                    {2, 2}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {1, 1},
                    {2, 2},
                    {3, 3}
                }
            );

            Matrix etalonA = new Matrix(
                new int[,]
                {
                    {1, 2},
                    {1, 2}
                }
            );
            
            Matrix etalonB = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {1, 2, 3}
                }
            );
            
            
            var calculator = new MatrixTranspositeCalculator();
            var result = calculator.OperateMatrix(new Matrix[] {a, b});

            Assert.IsTrue(
                result[0].Equals(etalonA) && 
                result[1].Equals(etalonB)
            );
        }

        /// <summary>
        /// Проверка класса - на одной матрице
        /// </summary>
        [Test]
        public void MatrixTranspositeCalculator_OperateMatrix_OneMatrix()
        {
            Matrix a = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {1, 2, 3}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 1},
                    {2, 2},
                    {3, 3}
                }
            );

            var calculator = new MatrixTranspositeCalculator();
            var result = calculator.OperateMatrix(new Matrix[] {a});

            Assert.IsTrue(result[0].Equals(etalon));
        }
    }
}