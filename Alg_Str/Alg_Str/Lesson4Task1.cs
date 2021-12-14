using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Str
{
    public class Lesson4Task1 : ILesson
    {

        public string Name => "4.1";

        public string Discription => "4.1 Реализация класса двоичного дерева";

        public void Demo()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(41);
            tree.Insert(23);
            tree.Insert(16);
            tree.Insert(22);
            tree.Insert(24);
            tree.Insert(6);
            tree.Insert(6);
            tree.Insert(25);
            tree.Insert(21);
            tree.Insert(65);
            tree.Insert(54);
            tree.Insert(98);
            tree.Insert(91);
            tree.Insert(73);

            Console.WriteLine($"Поиск значения 73 в дереве. Значение присутствует: {tree.Enters(73)}");
            Console.WriteLine($"Поиск значения 173 в дереве. Значение присутствует: {tree.Enters(173)}");

            Console.WriteLine();

            tree.PrintTree();
            Console.WriteLine();

            Console.WriteLine("------------------Удаляем элементы----------------");

            Console.WriteLine("Удаляем узел 65");
            tree.DelNode(tree.FindNode(65));
            Console.WriteLine("Удаляем узел 22");
            tree.DelNode(tree.FindNode(22));

            Console.WriteLine("------------------Проверяем результат----------------");

            tree.PrintTree();

        }

    }
}
