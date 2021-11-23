using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Занятие_21
{
    class Program
    { //Многопоточное приложение, которое моделирует работу садовников
        static int[,] garden; //двумерный массив участок земли
        static int a; //переменная для длины участка земли
        static int b;//переменная для ширины участка земли
        static void Gardener1()//метод для первого садовника
        {
            for (int i = 0; i < a; i++) //цикл прохождения для первого садовника
            {
                for (int j = 0; j < b; j++)
                {
                    if (garden[i, j] == 0)
                    {
                        garden[i, j] = 1;
                    }
                    Thread.Sleep(1); //приостановка потока для первого садовника
                }                
            }
            Console.WriteLine("Первый (1) садовник закончил работу");
        }
        static void Gardener2()//метод для второго садовника
        {
            for (int i = b - 1; i > 0; i--) //цикл прохождения для второго садовника
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                    {
                        garden[j, i] = 2;
                    }
                    Thread.Sleep(1); //приостановка потока 2го садовника
                }
             }
            Console.WriteLine("Второй (2) садовник закончил работу");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите длину участка земли: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину участка земли: ");
            b = Convert.ToInt32(Console.ReadLine());

            garden = new int[a, b];

            Thread plot1 = new Thread(Gardener1); //делегат и экземпляр потока 1го садовника
            Thread plot2 = new Thread(Gardener2); //делегат и экземпляр потока 2го садовника

            plot1.Start();
            plot2.Start();
            plot1.Join();
            plot2.Join();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(garden[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
