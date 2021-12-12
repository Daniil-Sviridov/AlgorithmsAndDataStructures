using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Str
{

    class Lesson2 : ILesson
    {
        public string Name => "ltd";

        public string Discription => "2. Реализация типа двусвязного списка.";

        public void Demo()
        {
            Random rnd = new Random();

            int i = 10;//rnd.Next(1, int.MaxValue);

            Console.WriteLine($" Создание списка длинной {i}");

            ListToDirection LstTD = new ListToDirection();
            for (int x = 0; x < i; x++)
            {
                LstTD.AddNode(rnd.Next(1, 1000));

                Console.WriteLine($"{x} - {LstTD.GetItem(x).value}");
            }

            Console.WriteLine($"Список содержит значений: {LstTD.GetCount()}");

            Console.WriteLine($" Указатель на значении {LstTD.CursItem.value}");
            Console.WriteLine($" Удаляем по индексу 0");
            LstTD.RemoveNode(0);
            Console.WriteLine($"Список содержит значений: {LstTD.GetCount()}");

            Console.WriteLine();
            Console.WriteLine($" Указатель на значении {LstTD.CursItem.value}");

            Console.WriteLine($" Удаляем по индексу 1");
            LstTD.RemoveNode(1);
            Console.WriteLine($"Список содержит значений: {LstTD.GetCount()}");
            Console.WriteLine();

            i = rnd.Next();
            Console.WriteLine($" Добавляем слева значение {i}");
            LstTD.AddHome(i);

            Console.WriteLine();
            Console.WriteLine($"Список содержит значений: {LstTD.GetCount()}");
            Console.WriteLine($" Указатель на значении {LstTD.CursItem.value}");

            Console.WriteLine($" Удаляем по позиции указателя");
            LstTD.RemoveNode(LstTD.CursItem);
            Console.WriteLine($" Указатель на значении {LstTD.CursItem.value}");
            Console.WriteLine();
            i = rnd.Next();
            Console.WriteLine($"Добавим после указателя элемент со значением{i}");
            LstTD.AddNodeAfter(LstTD.CursItem, i);
            Console.WriteLine();
            i = rnd.Next();
            Console.WriteLine($" Ищем с списке значение {i}");
            Item It = LstTD.FindNode(i);

            if (It != null)
            {
                Console.WriteLine($"Значение {i} есть в списке");
            }
            else
            {
                Console.WriteLine($"Значения {i} нет в списке");
            }


            i = LstTD.GetCount();
            Console.WriteLine($"В списке содержаться значения:");
            for (int x = 0; x < i; x++)
            {
                Console.WriteLine($"{x} - {LstTD.GetItem(x).value}");
            }

        }
    }
}
