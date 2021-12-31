using System;
using System.Collections;
using System.Collections.Generic;

namespace Alg_Str
{

    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }
        public BinaryTree<T> Parent { get; set; }

        private T data;

        public T GetData()
        {
            return data;
        }

        public void SetData(T value)
        {
            data = value;
        }

        public BinaryTree()
        {
        }

        public BinaryTree(T value)
        {
            Insert(value);
        }

        /// <summary>
        /// Вставка элемента в дерево
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        /// <exception cref="Exception">В исключение не попадет.</exception>
        public BinaryTree<T> Insert(T value)
        {
            BinaryTree<T> tmp = null;
            if (Parent == null)
            {
                Parent = GetFreeNode(value, null);
                return Parent;
            }

            tmp = Parent;
            while (tmp != null)
            {
                if (value.CompareTo(tmp.GetData()) > 0)
                {
                    if (tmp.Right != null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }
                    else
                    {
                        tmp.Right = GetFreeNode(value, tmp);
                        return Parent;
                    }
                }
                else if (value.CompareTo(tmp.GetData()) <= 0)
                {
                    if (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }
                    else
                    {
                        tmp.Left = GetFreeNode(value, tmp);
                        return Parent;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");                  // Дерево построено неправильно
                }
            }
            return Parent;
        }
        /// <summary>
        /// Получить новый узел дерева.
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="p">Родитель</param>
        /// <returns>Новый узел.</returns>
        private BinaryTree<T> GetFreeNode(T value, BinaryTree<T> p)
        {
            BinaryTree<T> newNode = new BinaryTree<T>();

            newNode.Parent = p;
            newNode.SetData(value);

            return newNode;
        }

        /// <summary>
        /// Проверяет принадлежнасть значения
        /// </summary>
        /// <param name="value">Искомое значение.</param>
        /// <returns>bool</returns>
        public bool Enters(T value)
        {
            BinaryTree<T> node = FindNode(value);
            if (node == null) return false;

            return true;
        }

        /// <summary>
        /// Поиск узла дерева по значениею.
        /// </summary>
        /// <param name="value">Значение поиска</param>
        /// <param name="startNode">Начальный узел поиска. По умолчанию корневой.</param>
        /// <returns>BinaryTree<T></returns>
        public BinaryTree<T> FindNode(T value, BinaryTree<T> startNode = null)
        {
            startNode = startNode ?? Parent;

            if (value.CompareTo(startNode.GetData()) == 0)
            {
                return startNode;
            }

            else if (value.CompareTo(startNode.GetData()) > 0)
            {
                if (startNode.Right == null)
                {
                    return null;
                };

                return FindNode(value, startNode.Right);
            }
            else if (value.CompareTo(startNode.GetData()) < 0)
            {
                if (startNode.Left == null)
                {
                    return null;
                };

                return FindNode(value, startNode.Left);
            }

            return null;

        }

        public BinaryTree<T> FindNodeBFS(T value, BinaryTree<T> startNode = null)
        {

            var queue = new Queue<BinaryTree<T>>();

            queue.Enqueue(startNode ?? Parent);

            if (queue.Peek() == null) return null;

            Console.WriteLine($"Добавляем корневой элемент в очередь: { queue.Peek().GetData()}");

            while (queue.Count > 0)
            {
                if (queue.Peek().Left != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Добавляем левый элемент в очередь: { queue.Peek().Left.GetData()}");
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Добавляем правый элемент в очередь: { queue.Peek().Right.GetData()}");
                    queue.Enqueue(queue.Peek().Right);
                }

                if (value.CompareTo(queue.Peek().GetData()) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Искомый элемент найден: { queue.Peek().GetData()}");
                    Console.ResetColor();
                    return queue.Peek();
                }

                Console.ResetColor();
                Console.WriteLine($"Удаляем элемент из очереди: { queue.Peek().GetData()}");
                queue.Dequeue();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Искомый элемент не найден!!!");
            Console.ResetColor();
            return null;
        }

        public BinaryTree<T> FindNodeDFS(T value, BinaryTree<T> startNode = null)
        {
            var stak = new Stack<BinaryTree<T>>();

            var root = startNode ?? Parent;

            if (root == null) return null;

            stak.Push(root);

            Console.WriteLine($"Добавляем корневой элемент стек: { root.GetData()}");

            while (stak.Count > 0)
            {
                var node = stak.Pop();

                Console.WriteLine($"Извлекаем элемент из стека: { node.GetData()}");

                if (node.Left != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Добавляем левый элемент в стек: { node.Left.GetData()}");
                    Console.ResetColor();
                    stak.Push(node.Left);
                }
                if (node.Right != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Добавляем правый элемент в стек: { node.Right.GetData()}");
                    Console.ResetColor();
                    stak.Push(node.Right);
                }

                if (value.CompareTo(node.GetData()) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Искомый элемент найден: { node.GetData()}");
                    Console.ResetColor();
                    return node;
                }

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Искомый элемент не найден!!!");
            Console.ResetColor();
            return null;
        }

        /// <summary>
        /// Вывод бинарного дерева
        /// </summary>
        public void PrintTree()
        {
            PrintTree(Parent);
        }

        /// <summary>
        /// Вывод бинарного дерева начиная с указанного узла
        /// </summary>
        /// <param name="startNode">Узел с которого начинается печать</param>
        /// <param name="indent">Отступ</param>
        /// <param name="side">Сторона </param>
        private void PrintTree(BinaryTree<T> startNode, string mov = "", string side = "root")
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side;
                Console.WriteLine($"{mov} [{nodeSide}]- {startNode.GetData()}");
                mov += new string(' ', 4);

                PrintTree(startNode.Left, mov, "L");
                PrintTree(startNode.Right, mov, "R");
            }
        }

        /// <summary>
        /// Удаление узла бинарного дерева. Кроме корня.
        /// </summary>
        /// <param name="node">Узел для удаления</param>
        public void DelNode(BinaryTree<T> node)
        {
            if (node == null)
            {
                return;
            }


            //если 'это не корневой узел
            if (node.Parent != null)
            {
                if (node.Parent.Left == node)
                {
                    node.Parent.Left = null;
                }
                else if (node.Parent.Right == node)
                {
                    node.Parent.Right = null;
                }
                else if (node.Parent == node)
                {
                    node.Parent = null;
                }
            }

        }


    }
}