using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace Alg_Str
{

    /// <summary>
    /// Массив злементов заданий десериализация XML
    /// </summary>
    public class HWorks
    {
        public Task[] tasks;
    }
    /// <summary>
    /// Элемент задания. Десериализация XML
    /// </summary>
    public class Task
    {
        public string Tname;
    }

    class Program
    {

        static List<ILesson> lessons = new List<ILesson>();

        /*static List<ILesson> lessons = new List<ILesson>()
        {
        new Lesson1PrimeNumber(),
        new Lesson1FibNumbers(),
        new Lesson2(),
        new Lesson3(),
        new Lesson4Task1(),
        new Lesson5()
        };*/



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

            XmlSerializer formatter = new XmlSerializer(typeof(HWorks));
            HWorks newPerson = new();
            // десериализsация
            FileStream fs = new FileStream($"{Directory.GetCurrentDirectory()}\\ListXML.xml", FileMode.OpenOrCreate);

            HWorks hw = (HWorks)formatter.Deserialize(fs);


            for (int i = 0; i < hw.tasks.Length; i++)
            {
                lessons.Add((ILesson)Activator.CreateInstance(Type.GetType($"Alg_Str.{hw.tasks[i].Tname}")));
            }

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
        }
    }
}
