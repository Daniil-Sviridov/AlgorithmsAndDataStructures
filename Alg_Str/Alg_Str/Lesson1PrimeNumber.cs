using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Str
{
    internal class Lesson1PrimeNumber : ILesson
    {
        string ILesson.Name => "prime";

        string ILesson.Discription => "1.1 Аналз принадлежности к множеству простых чисел.";

        public void Demo()
        {

            int num = 127;
            Console.WriteLine($"Является простым {num} числом (метод 1){ ItPrime(127) }");
            Console.WriteLine($"Является простым {num} числом (метод 2){ ItPrime2(127) }");

            num = 98;
            Console.WriteLine($"Является простым {num} числом (метод 1){ ItPrime(98) }");
            Console.WriteLine($"Является простым {num} числом (метод 2){ ItPrime2(98) }");
        }

        /// <summary>
        /// Определить является ли аргумент простым числом. Реализовано по блок-схеме из задания.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>boolean false/true</returns>
        private bool ItPrime(int n)
        {

            int i = 2;
            int d = 0;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            };

            return d == 0 ? true : false;
        }

        /// <summary>
        /// Определить является ли аргумент простым числом. Иная реализация.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>boolean false/true</returns>
        private bool ItPrime2(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            };
            return true;
        }
    }
}
