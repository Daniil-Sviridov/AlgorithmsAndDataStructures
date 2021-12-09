using System;

namespace Alg_Str
{
 
    static class PrimeNumber
    {
        /// <summary>
        /// Определить является ли аргумент простым числом. Реализовано по блок-схеме из задания.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>boolean false/true</returns>
        public static bool ItPrime(int n)
        {

            int i = 2;
            int d = 0;

            while(i<n) 
            {
                if (n % i == 0)
                {
                    d++;
                }                
                i++;                
            };

            return d == 0 ? true: false;
        }

        /// <summary>
        /// Определить является ли аргумент простым числом. Иная реализация.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>boolean false/true</returns>
        public static bool ItPrime2(int n)
        {
            for (int i = 2; i < n; i++) 
            { 
                if (n % i == 0) return false;
            };
            return true;
        }
    }
}
