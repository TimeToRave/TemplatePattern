using System;
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
                    {1, 1},
                    {2, 2}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {1, 1},
                    {2, 2}
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
                new int[,]
                {
                    {6, 8},
                    {10, 12}
                }
            );

            Matrix a = new Matrix(
                new int[,]
                {
                    {1, 2},
                    {3, 4}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {5, 6},
                    {7, 8}
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
                    {5}
                }
            );

            Matrix a = new Matrix(
                new int[,]
                {
                    {2}
                }
            );

            Matrix b = new Matrix(
                new int[,]
                {
                    {3}
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
                    {1, 2, 3},
                    {4, 5, 6}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 4},
                    {2, 5},
                    {3, 6}
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
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 4, 7},
                    {2, 5, 8},
                    {3, 6, 9}
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
                    {1}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1}
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
                new int[0, 0]
            );

            Matrix etalon = new Matrix(
                new int[0, 0]
            );


            Matrix result = initial.Transposite();

            Assert.IsTrue(etalon.Equals(result));
        }

        /// <summary>
        /// Проверяет метод удаления колонки матрицы
        /// </summary>
        [Test]
        public void Matrix_CutColumn_From_Ordinary_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 3},
                    {4, 6},
                    {7, 9}
                }
            );

            Matrix result = initial.CutColumn(1);

            Assert.IsTrue(etalon.Equals(result));
        }

        /// <summary>
        /// Проверяет метод удаления колонки не квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_CutColumn_From_Non_Square_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {4, 5, 6}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 3},
                    {4, 6}
                }
            );

            Matrix result = initial.CutColumn(1);

            Assert.IsTrue(etalon.Equals(result));
        }
        
        /// <summary>
        /// Проверяет метод удаления колонки не квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_CutColumn_From_Single_Column_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1},
                    {4}
                }
            );

            Matrix etalon = new Matrix(
                new int[2,0]
            );

            Matrix result = initial.CutColumn(0);

            Assert.IsTrue(etalon.Equals(result));
        }

        /// <summary>
        /// Проверяет метод удаления колонки матрицы
        /// Указывается заведомо некорректный номер удаляемого столбца
        /// </summary>
        [Test]
        public void Matrix_CutColumn_Incorrect_Column_Index()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                }
            );

            var exception = Assert.Throws<ArgumentException>(() =>
                initial.CutColumn(5)
            );

            Assert.That(exception.Message, Is.EqualTo("Некорректно указан номер столбца"));
        }
        
        /// <summary>
        /// Проверяет метод удаления строки матрицы
        /// </summary>
        [Test]
        public void Matrix_CutRow_From_Ordinary_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {7, 8, 9}
                }
            );

            Matrix result = initial.CutRow(1);

            Assert.IsTrue(etalon.Equals(result));
        }

        /// <summary>
        /// Проверяет метод удаления строки не квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_CutRow_From_Non_Square_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2},
                    {4, 5},
                    {7, 8}
                }
            );

            Matrix etalon = new Matrix(
                new int[,]
                {
                    {1, 2},
                    {7, 8}
                }
            );

            Matrix result = initial.CutRow(1);

            Assert.IsTrue(etalon.Equals(result));
        }
        
        /// <summary>
        /// Проверяет метод удаления строки не квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_CutRow_From_Single_Column_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 4}
                }
            );

            Matrix etalon = new Matrix(
                new int[0,2]
            );

            Matrix result = initial.CutRow(0);

            Assert.IsTrue(etalon.Equals(result));
        }

        /// <summary>
        /// Проверяет метод удаления строки матрицы
        /// Указывается заведомо некорректный номер удаляемой строки
        /// </summary>
        [Test]
        public void Matrix_CutRow_Incorrect_Column_Index()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                }
            );

            var exception = Assert.Throws<ArgumentException>(() =>
                initial.CutRow(5)
            );

            Assert.That(exception.Message, Is.EqualTo("Некорректно указан номер строки"));
        }
        
        /// <summary>
        /// Проверяет является ли матрица квадратной
        /// </summary>
        [Test]
        public void Matrix_CheckMatrixIsSquare_Square_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                }
            );
            
            Assert.IsTrue(initial.CheckMatrixIsSquare());
        }
        
        /// <summary>
        /// Проверяет является ли матрица квадратной
        /// Проверка для не квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_CheckMatrixIsSquare_Non_Square_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2, 3},
                    {4, 5, 6}
                }
            );
            
            Assert.IsFalse(initial.CheckMatrixIsSquare());
        }
        
        /// <summary>
        /// Проверяет является ли матрица квадратной
        /// Проверка для не квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_CheckMatrixIsSquare_Single_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1}
                }
            );
            
            Assert.IsTrue(initial.CheckMatrixIsSquare());
        }
        
        /// <summary>
        /// Проверяет является ли матрица квадратной
        /// Проверка для не квадратной матрицы
        /// </summary>
        [Test]
        public void Matrix_CheckMatrixIsSquare_Zero_Matrix()
        {
            Matrix initial = new Matrix(
                new int[0,0]
            );
            
            Assert.IsTrue(initial.CheckMatrixIsSquare());
        }
        
        /// <summary>
        /// Вычисление определителя матрицы
        /// Проверка для квадратной матрицы 3x3
        /// </summary>
        [Test]
        public void Matrix_CalculateDeterminant_Square_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 4, 3},
                    {6, 2, 6},
                    {10, 10, 3}
                }
            );
            
            Assert.IsTrue(initial.CalculateDeterminant() == 234);
        }
        
        /// <summary>
        /// Вычисление определителя матрицы
        /// Проверка для квадратной матрицы 2x2
        /// </summary>
        [Test]
        public void Matrix_CalculateDeterminant_2x2_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {2, 1},
                    {1, 2}
                }
            );
            
            Assert.IsTrue(initial.CalculateDeterminant() == 3);
        }
        
        /// <summary>
        /// Вычисление определителя матрицы
        /// Проверка для единичной матрицы00000
        /// </summary>
        [Test]
        public void Matrix_CalculateDeterminant_Single_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {2} 
                }
            );
            
            Assert.IsTrue(initial.CalculateDeterminant() == 1);
        }
        
        /// <summary>
        /// Вычисление определителя матрицы
        /// Проверка для пустой матрицы
        /// </summary>
        [Test]
        public void Matrix_CalculateDeterminant_Zero_Matrix()
        {
            Matrix initial = new Matrix(
                new int[0,0]
            );
            
            Assert.IsTrue(initial.CalculateDeterminant() == 0);
        }

        /// <summary>
        /// Проверяет метод вычисления определителя матрицы
        /// На вход подается не квадратная матрица
        /// </summary>
        [Test] public void Matrix_CalculateDeterminant_NonSquare_Matrix()
        {
            Matrix initial = new Matrix(
                new int[,]
                {
                    {1, 2},
                    {4, 5},
                    {7, 8}
                }
            );

            var exception = Assert.Throws<InvalidOperationException>(() =>
                initial.CalculateDeterminant()
            );

            Assert.That(exception.Message, Is.EqualTo("Вычисление определителя доступно только для квадратных матриц"));
        }
    }
}