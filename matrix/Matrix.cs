using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    /*Консольное приложение
     * multiply, add, subtract, transpose
     * разделители ' ', '\n'
     * 
     *  1. Работаем с матрицами
     *      Необходимо определить класс матрицы Matrix, описать конструкторы и методы.
     *      Разумеется, не стоит забывать о деструкторе!
     *  2.
     *  3.
     */
    class Matrix
    {
        private int m,n;
        private int[,] array;

        // Создаем конструкторы матрицы
        public Matrix() { }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            array = new int[this.m, this.n];
        }

        //строки
        public int M
        {
            get { return m; }
            set { if (value > 0) m = value; }
        }

        //столбцы
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
       
        public int this[int i, int j]
        {
            get
            {
                return array[i, j];
            }
            set
            {
                array[i, j] = value;
            }
        }

        // Ввод матрицы с клавиатуры
        public void WriteMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        // Вывод матрицы с клавиатуры
        public void ReadMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        // Проверка матрицы А на единичность
        public void oneMat(Matrix a)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == 1 && i == j)
                    {
                        count++;
                    }
                }

            }
            if (count == a.N)
            {
                Console.WriteLine("Единичная");
            }
            else Console.WriteLine("Не единичная");
        }


        // Умножение матрицы А на число
        public static Matrix umnch(Matrix a, int ch)
        {
            Matrix resMass = new Matrix(a.M, a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] = a[i, j] * ch;
                }
            }
            return resMass;
        }

        // Умножение матрицы А на матрицу Б
        public static Matrix umn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.M, a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }



        // перегрузка оператора умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.umn(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.umnch(a, b);
        }


        // Метод вычитания матрицы Б из матрицы А
        public static Matrix razn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.M,a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }

        // Перегрузка оператора вычитания
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.razn(a, b);
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.M, a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }
        // Деструктор Matrix
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }

    }
}
