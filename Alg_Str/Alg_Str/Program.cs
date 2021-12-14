using System;
using System.Collections.Generic;

namespace Alg_Str
{
    class Program
    {
        static List<ILesson> lessons = new List<ILesson>()
        {
        new Lesson1PrimeNumber(),
        new Lesson1FibNumbers(),
        new Lesson2(),
        new Lesson3(),
        new Lesson4Task1()
        };

        static void PrintHead()
        {
            Console.Clear();
            Console.WriteLine("Для запуска задания введите его код. Доступные задания: ");
            foreach (ILesson lesson in lessons)
            {
                Console.WriteLine($"{lesson.Discription} (код: {lesson.Name})");
            }

            Console.WriteLine("Завершение работы. (код: exit)");
        }
        static void Main(string[] args)
        {

            PrintHead();
            string key = Console.ReadLine();

            while (key != "exit")
            {
                foreach (ILesson lesson in lessons)
                {
                    if (lesson.Name == key)
                    {
                        lesson.Demo();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        PrintHead();
                    };
                }

                key = Console.ReadLine();
            }

            /*  Console.WriteLine(PrimeNumber.ItPrime(7));

              Console.WriteLine(PrimeNumber.ItPrime2(7));


              int[] a = FibonaciNumber.GetSubsequenceFib_cycle(10);

              for (int i = 0; i < a.Length; i++) 
                  {
                  Console.Write($"{ a[i]} ");
                  };

              Console.WriteLine();

              Console.Write(FibonaciNumber.GetFibNumber_recursion(1));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(2));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(3));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(4));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(5));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(6));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(7));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(8));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(9));
              Console.Write(" ");
              Console.Write(FibonaciNumber.GetFibNumber_recursion(10));
            */
        }
    }
}
