using System;

namespace Alg_Str
{
    static class FibonaciNumber
    {
        /// <summary>
        /// Вычисляет n-ый член последовательности Фибоначчи. Рекурсивный метод.
        /// Номерация с 1.        
        /// </summary>
        /// <param name="n">Порядковый номер последовательности.</param>
        /// <returns>int</returns>
        public static int GetFibNumber_recursion(int n)
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
        public static int[] GetSubsequenceFib_cycle(int length)
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
