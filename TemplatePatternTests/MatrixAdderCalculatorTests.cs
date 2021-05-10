using NUnit.Framework;
using TemplatePattern;

namespace TemplatePatternTests
{
    [TestFixture]
    public class MatrixAdderCalculatorTests
    {
        /// <summary>
        /// Проверка класса - сумматора матриц
        /// </summary>
        [Test]
        public void MatrixAdderCalculator_OperateMatrix_TwoMatrices()
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
                    {2, 3}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {2, 2},
                    {4, 5}
                }
            );
            
            var calculator = new MatrixAdderCalculator();
            var result = calculator.OperateMatrix(new Matrix[] {a, b});

            Assert.IsTrue(result[0].Equals(etalon));
        }

        /// <summary>
        /// Проверка класса - сумматора матриц
        /// </summary>
        [Test]
        public void MatrixAdderCalculator_OperateMatrix_OneMatrix()
        {
            Matrix a = new Matrix(
                new int[,]
                {
                    {1, 1},
                    {2, 2}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 1},
                    {2, 2}
                }
            );

            var calculator = new MatrixAdderCalculator();
            var result = calculator.OperateMatrix(new Matrix[] {a});

            Assert.IsTrue(result[0].Equals(etalon));
        }
    }
}