﻿using System;
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
            mass1.InputFromKeyboard();
            Console.WriteLine("Ввод Матрица B: ");
            mass2.InputFromKeyboard();

            Console.WriteLine("Матрица А: ");
            mass1.Output();
            Console.WriteLine();
            Console.WriteLine("Матрица В: ");
            Console.WriteLine();
            mass2.Output();

            Console.WriteLine("Сложение матриц А и Б: ");
            mass4 = (mass1 + mass2);
            mass4.Output();

            Console.WriteLine("Вычитание матриц А и Б: ");
            mass6 = (mass1 - mass2);
            mass6.Output();

            Console.WriteLine("Умножение матриц А и Б: ");
            mass8 = (mass1 * mass2);
            mass8.Output();

            Console.WriteLine("Умножение матрицы А на число 2: ");
            mass5 = (mass1 * 2);
            mass5.Output();

            Console.WriteLine("Матрица D по формуле  D=3AB+(A-B)A: ");
            mass7 = ((mass1 * 3) * mass2 + (mass1 - mass2) * mass1);
            mass7.Output();


            Console.ReadKey();
        }
    }
}