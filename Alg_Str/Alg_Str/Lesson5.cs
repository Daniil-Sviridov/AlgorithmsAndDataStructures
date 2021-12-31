using System;
using System.Collections;
using System.Collections.Generic;

namespace Alg_Str
{
    internal class Lesson5 : ILesson
    {
        public string Name => "5";

        public string Discription => "5. Поиск в дереве в ширину и глубину";



        public void Demo()
        {

            BinaryTree<int> binaryTree = new BinaryTree<int>(10);

            binaryTree.Insert(100);
            binaryTree.Insert(1);
            binaryTree.Insert(14);
            binaryTree.Insert(150);
            binaryTree.Insert(45);
            binaryTree.Insert(0);
            binaryTree.Insert(9);
            binaryTree.Insert(7);

            binaryTree.PrintTree();

            Console.WriteLine();
            Console.WriteLine("Поиск в ширину:");
            binaryTree.FindNodeBFS(7);

            Console.WriteLine();
            Console.WriteLine("Поиск в глубину:");
            binaryTree.FindNodeDFS(7);



        }
    }
}
