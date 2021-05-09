using System;
using System.Linq;

namespace TemplatePattern
{
    /// <summary>
    /// Класс реализующий основные операции над матрицами
    /// </summary>	
    public class Matrix
    {
        public int[,] Data { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="data"></param>
        public Matrix(int[,] data)
        {
            Data = data;
            SizeX = data.GetLength(0);
            SizeY = data.GetLength(1);
        }

        public Matrix(string input)
        {
            int i = 0, j = 0;
            int[,] result = new int[0, 0];
            foreach (var row in input.Split('|'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    if (result.GetLength(0) * result.GetLength(1) == 0)
                    {
                        result = new int[input.Split('|').Length, row.Trim().Split(' ').Length];
                    }

                    result[i, j] = int.Parse(col.Trim());
                    j++;
                }

                i++;
            }

            Data = result;
            SizeX = result.GetLength(0);
            SizeY = result.GetLength(1);
        }

        /// <summary>
        /// Конструктор
        /// Создает пустую матрицу с заданным размером
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public Matrix(int sizeX, int sizeY)
        {
            Data = new int[sizeX, sizeY];
            SizeX = sizeX;
            SizeY = sizeY;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Matrix() : this(0, 0)
        {
        }

        /// <summary>
        /// Опеератор сложения двух матриц
        /// </summary>
        /// <returns>Матрица - результат сложения</returns>
        public static Matrix operator +(Matrix source, Matrix addendum)
        {
            if (MatrixSizesAreEqual(source, addendum))
            {
                Matrix result = new Matrix(source.SizeX, source.SizeY);

                for (int i = 0; i < source.SizeX; i++)
                {
                    for (int j = 0; j < source.SizeY; j++)
                    {
                        result.Data[i, j] = source.Data[i, j] + addendum.Data[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new Exception("Sizes of matrix are not equal");
            }
        }

        private static bool MatrixSizesAreEqual(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.SizeX == matrix2.SizeX && matrix1.SizeY == matrix2.SizeY;
        }

        /// <summary>
        /// Метод для сравнивания двух матриц
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            bool result = false;

            Matrix equalsMatrix = obj as Matrix;

            if (equalsMatrix != null)
            {
                result =
                    Data.Rank == equalsMatrix.Data.Rank &&
                    Enumerable.Range(0, Data.Rank).All(dimension =>
                        Data.GetLength(dimension) == equalsMatrix.Data.GetLength(dimension)) &&
                    Data.Cast<int>().SequenceEqual(equalsMatrix.Data.Cast<int>());
            }

            return result;
        }

        /// <summary>
        /// Переопределение метода
        /// </summary>
        /// <returns>Хэш объекта</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Выполняет транспонирование матрицы
        /// </summary>
        /// <returns>Транспонированная матрица</returns>
        public Matrix Transposite()
        {
            int[,] transpondedMatrix = new int[Data.GetLength(1), Data.GetLength(0)];
            
            for (int i = 0; i < Data.GetLength(1); i++)
            {
                for (int j = 0; j < Data.GetLength(0); j++)
                {
                    transpondedMatrix[i, j] = Data[j, i];
                }
            }

            return new Matrix(transpondedMatrix);
        }
        
        public int CalculateDeterminant()
        {
            if (!CheckMatrixIsSquare())
            {
                throw new InvalidOperationException(
                    "Вычисление определителя доступно только для квадратных матриц");
            }
            
            if (Data.GetLength(0) == 1)
            {
                return 1;
            }
            if (Data.GetLength(0) == 2)
            {
                return Data[0, 0] * Data[1, 1] - Data[0, 1] * Data[1, 0];
            }
            
            int result = 0;
            for (var j = 0; j < Data.GetLength(0); j++)
            {
                result += (j % 2 == 1 ? 1 : -1) * Data[1, j] * 
                        CutColumn(j)
                        .CutRow(1).CalculateDeterminant();
            }
            return result;
        }

        /// <summary>
        /// Проверяет является ли матрица квадратной
        /// </summary>
        /// <returns></returns>
        public bool CheckMatrixIsSquare()
        {
            return Data.GetLength(0) == Data.GetLength(1);
        }

        /// <summary>
        /// Удаляет колонку с заданным номером из матрицы
        /// </summary>
        /// <param name="column">Номер удаляемого столбца</param>
        /// <returns>Сокращенную матрицу</returns>
        public Matrix CutColumn(int column)
        {
            if (column < 0 || column >= Data.GetLength(1))
            {
                throw new ArgumentException("Некорректно указан номер столбца");
            }
            var result = new Matrix(Data.GetLength(0), Data.GetLength(1) - 1);
            result.ProcessFunctionOverData((i, j) => 
                result.Data[i, j] = j < column ? Data[i, j] : Data[i, j + 1]);
            return result;
        }
        
        /// <summary>
        /// Удаляет строку с заданным номером из матрицы
        /// </summary>
        /// <param name="row">Номер удаляемой строки</param>
        /// <returns>Сокращенная матрица</returns>
        public Matrix CutRow(int row)
        {
            if (row < 0 || row >= Data.GetLength(0))
            {
                throw new ArgumentException("Некорректно указан номер строки");
            }
            var result = new Matrix(Data.GetLength(0) - 1, Data.GetLength(1));
            result.ProcessFunctionOverData((i, j) => result.Data[i, j] = i < row ? Data[i, j] : Data[i + 1, j]);
            return result;
        }
            

        /// <summary>
        /// Метод для вывода матрицы в консоль
        /// </summary>
        public override string ToString()
        {
            string result = string.Empty;

            if (Data.GetLength(0) == 0 || Data.GetLength(1) == 0)
            {
                return result;
            }
            
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    result += ($" {Data[i, j]}");
                }

                result += " |\n";
            }

            return result.Substring(0, result.Length - 2);
        }

        private void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < Data.GetLength(0); i++)
            {
                for (var j = 0; j < Data.GetLength(1); j++)
                {
                    func(i, j);
                }
            }
        }
    }
}