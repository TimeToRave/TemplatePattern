using NUnit.Framework;
using TemplatePattern;

namespace TemplatePatternTests
{
    [TestFixture]
    public class MatrixTests
    {
        /// <summary>
        /// Проверка метода сравнения двух матриц
        /// </summary>
        [Test]
        public void Matrix_AreEquals()
        {
            Matrix a = new Matrix(
                new int[,]
                {
                    {1,1},
                    {2,2}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {1,1},
                    {2,2}
                }
            );

            Assert.IsTrue(a.Equals(b));
        }

        /// <summary>
        /// Проверка метода сравнения двух матриц 
        /// На вход подаются не равные матрицы
        /// </summary>
        [Test]
        public void Matrix_AreNotEquals()
        {
            Matrix a = new Matrix(
                new int[,]
                {
                    {1,1},
                    {2,2}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {1,1},
                    {2,3}
                }
            );

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Проверка сложения матриц
        /// Размерность матриц : 2
        /// </summary>
        [Test]
        public void Matrix_Sum_2x2()
        {
            Matrix etalon = new Matrix(
                new int [,]
                {
                    {6, 8},
                    {10, 12}
                }

            );

            Matrix a = new Matrix(
                new int[,]
                {
                    {1,2},
                    {3,4}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {5,6},
                    {7,8}
                }
            );

            Matrix matrixSumResult = a + b;

            Assert.IsTrue(etalon.Equals(matrixSumResult));
        }

        /// <summary>
        /// Проверка сложения матриц
        /// Размерность матриц : 1
        /// Граничный случай
        /// </summary>
        [Test]
        public void Matrix_Sum_1x1()
        {
            Matrix etalon = new Matrix(
                new int[,]
                {
                    { 5 }
                }

            );
            
            Matrix a = new Matrix(
                new int[,]
                {
                    { 2 }
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    { 3 }
                }
            );

            Matrix matrixSumResult = a + b;

            Assert.IsTrue(etalon.Equals(matrixSumResult));
        }
        
        /// <summary>
        /// Проверяет метод транспонирования матрицы
        /// </summary>
        [Test]
        public void Matrix_Transposite_2x3_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 }
                }
            );
            
            Matrix etalon = new Matrix(
                new int[,]
                {
                    { 1, 4 },
                    { 2, 5 },
                    { 3, 6 }
                }
            );

            
            Matrix result = initial.Transposite();

            Assert.IsTrue(etalon.Equals(result));
        }
        
        /// <summary>
        /// Проверяет метод транспонирования квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_Transposite_Square_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }
                }
            );
            
            Matrix etalon = new Matrix(
                new int[,]
                {
                    { 1, 4, 7},
                    { 2, 5 , 8},
                    { 3, 6, 9 }
                }
            );

            
            Matrix result = initial.Transposite();

            Assert.IsTrue(etalon.Equals(result));
        }
        
        /// <summary>
        /// Проверяет метод транспонирования единичной матрицы
        /// </summary>
        [Test]
        public void Matrix_Transposite_Single_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    { 1 }
                }
            );
            
            Matrix etalon = new Matrix(
                new int[,]
                {
                    { 1 }
                }
            );

            
            Matrix result = initial.Transposite();

            Assert.IsTrue(etalon.Equals(result));
        }
        
        /// <summary>
        /// Проверяет метод транспонирования пустой матрицы
        /// </summary>
        [Test]
        public void Matrix_Transposite_Zero_Matrix()
        {
            Matrix initial = new Matrix(
                new int[0,0]
            );
            
            Matrix etalon = new Matrix(
                new int[0,0]
            );

            
            Matrix result = initial.Transposite();

            Assert.IsTrue(etalon.Equals(result));
        }
        
    }
}