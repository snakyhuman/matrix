using System;
using System.IO;
namespace matrix
{
    /*TODO
     * Консольное приложение
     * multiply, add, subtract, transpose
     * разделители ' ', '\n'
     * 
     *  1. Работаем с матрицами
     *      Необходимо определить класс матрицы Matrix, описать конструкторы и методы.
     *      Разумеется, не стоит забывать о финализаторе/деструкторе. используй using по полной!
     *  2.
     *  3.
     */
    class Matrix
    {
        private int m, n;
        private int[,] array;

        // Создаем конструкторы матрицы
        public Matrix() { }

        
        /// <summary>
        /// Матрица
        /// </summary>
        /// <param name="m">Количество строк</param>
        /// <param name="n">Количество столбцов</param>
        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            array = new int[this.m, this.n];
        }

        
        /// <summary>
        /// Количество строк
        /// </summary>
        public int M
        {
            get { return m; }
            set { if (value > 0) m = value; }
        }

        /// <summary>
        /// Количество столбцов
        /// </summary>
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

        /// <summary>
        /// Ввести матрицу с клавиатуры
        /// </summary>
        public void InputFromKeyboard()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    try
                    {
                        array[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("требуется число");
                        j--;
                    }
                }
            }
        }


        /// <summary>
        /// Считать матрицу из строки
        /// </summary>
        /// <param name="matrix">Строка матрицы</param>
        /// <param name="M_separator">Разделитель строк</param>
        /// <param name="N_separator">Разделитель столбцов</param>
        public void ReadFromString(string matrix, char N_separator = ' ', char M_separator='\n')
        {
            
            //using (StreamReader sr = File.OpenText(path))
            //{
            //    Console.WriteLine("из файла {0}")
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}

            try
            {
                string[] matrix_in_str = matrix.Split(M_separator);
                for (int i=0;i<matrix_in_str.Length;i++)
                {
                 var  MSNS = matrix_in_str[i].Split(N_separator);//matrix split n-separator
                    for(int j=0; j<MSNS.Length;j++)
                    {
                        array[i, j] = Convert.ToInt32(MSNS[j]);
                    }
                }
            }

            catch 
            {
                Console.WriteLine("Строка:\n{0}\n не может быть записана в целочисленную матрицу.", matrix);
            }

        }

        /// <summary>
        /// Вывести на экран матрицу
        /// </summary>
        public void Output()
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
        public static void IsUnit(Matrix a)
        {
            int count = 0;
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < a.N; j++)
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
        public static Matrix Multiply(Matrix a, int ch)
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
        public static Matrix Multiply(Matrix a, Matrix b)
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
            return Matrix.Multiply(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.Multiply(a, b);
        }


        // Метод вычитания матрицы Б из матрицы А
        public static Matrix Subtract(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.M, a.N);
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
            return Matrix.Subtract(a, b);
        }
        public static Matrix Add(Matrix a, Matrix b)
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
            return Matrix.Add(a, b);
        }

        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }


    }
}
