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
            
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    transpondedMatrix[i, j] = Data[j, i];
                }
            }

            return new Matrix(transpondedMatrix);
        }
            

        /// <summary>
        /// Метод для вывода матрицы в консоль
        /// </summary>
        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    result += ($"	{Data[i, j]}");
                }

                result += "|";
            }

            return result.Substring(0, result.Length - 1);
        }
    }
}