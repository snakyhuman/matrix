using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    
    class MainProgram
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы: ");
            int nn = Convert.ToInt32(Console.ReadLine());
            // Инициализация
            Matrix mass1 = new Matrix(nn);
            Matrix mass2 = new Matrix(nn);
            Matrix mass3 = new Matrix(nn);
            Matrix mass4 = new Matrix(nn);
            Matrix mass5 = new Matrix(nn);
            Matrix mass6 = new Matrix(nn);
            Matrix mass7 = new Matrix(nn);
            Matrix mass8 = new Matrix(nn);
            Console.WriteLine("ввод Матрица А: ");
            mass1.WriteMat();
            Console.WriteLine("Ввод Матрица B: ");
            mass2.WriteMat();

            Console.WriteLine("Матрица А: ");
            mass1.ReadMat();
            Console.WriteLine();
            Console.WriteLine("Матрица В: ");
            Console.WriteLine();
            mass2.ReadMat();

            Console.WriteLine("Сложение матриц А и Б: ");
            mass4 = (mass1 + mass2);
            mass4.ReadMat();

            Console.WriteLine("Вычитание матриц А и Б: ");
            mass6 = (mass1 - mass2);
            mass6.ReadMat();

            Console.WriteLine("Умножение матриц А и Б: ");
            mass8 = (mass1 * mass2);
            mass8.ReadMat();

            Console.WriteLine("Умножение матрицы А на число 2: ");
            mass5 = (mass1 * 2);
            mass5.ReadMat();

            Console.WriteLine("Матрица D по формуле  D=3AB+(A-B)A: ");
            mass7 = ((mass1 * 3) * mass2 + (mass1 - mass2) * mass1);
            mass7.ReadMat();


            Console.ReadKey();
        }
    }
}