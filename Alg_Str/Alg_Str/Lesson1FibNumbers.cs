using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Str
{
    internal class Lesson1FibNumbers : ILesson
    {
        string ILesson.Name => "fib";

        string ILesson.Discription => "1.2 Вывод последовательности Фибоначчи.";

        public void Demo()
        {
            int[] Fib = GetSubsequenceFib_cycle(24);
            OutArray("Последовательность получега в цикле.", Fib);
            Console.WriteLine();

            Console.WriteLine($"Элемент последовательности номер 20. Вычислен рекурсивно. {GetFibNumber_recursion(20)}");

        }

        private void OutArray(string D, int[] ar)
        {

            Console.WriteLine(D);

            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }

        }

        /// <summary>
        /// Вычисляет n-ый член последовательности Фибоначчи. Рекурсивный метод.
        /// Номерация с 1.        
        /// </summary>
        /// <param name="n">Порядковый номер последовательности.</param>
        /// <returns>int</returns>
        /// 
        private int GetFibNumber_recursion(int n)
        {

            if (n == 1) return 0;
            if (n == 2 | n == 3) return 1;

            return GetFibNumber_recursion(n - 2) + GetFibNumber_recursion(n - 1);
        }
        /// <summary>
        /// Вычисляет последовательность Фибоначчи длинной length.
        /// </summary>
        /// <param name="length">количенство элеменотов последовательности.</param>
        /// <returns>int[]</returns>
        private int[] GetSubsequenceFib_cycle(int length)
        {
            int[] SubSq = new int[length];

            SubSq[0] = 0;
            SubSq[1] = 1;

            for (int i = 2; i < length; i++)
            {
                SubSq[i] = SubSq[i - 1] + SubSq[i - 2];
            }

            return SubSq;
        }
    }
}
