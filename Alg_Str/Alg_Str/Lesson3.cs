using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Alg_Str
{
    class Lesson3 : ILesson
    {
        public class PointClass
        {
            public int X;
            public int Y;
        }

        public struct PointStruct
        {
            public int X;
            public int Y;
        }

        /// <summary>
        /// Вычисление расстояния между точками PointStruct
        /// </summary>
        /// <param name="pointOne">PointStruct</param>
        /// <param name="pointTwo">PointStruct</param>
        /// <returns>расстояние</returns>
        public double PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            int x = pointOne.X - pointTwo.X;
            int y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Вычисление расстояния между точками PointClass
        /// </summary>
        /// <param name="pointOne">PointClass</param>
        /// <param name="pointTwo">PointClass</param>
        /// <returns>расстояние</returns>
        public double PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            int x = pointOne.X - pointTwo.X;
            int y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public string Name => "pcs";

        public string Discription => "3. Тесты производительности для расчёта дистанции между точками.";

        public void Demo()
        {
            Console.WriteLine("точек\t|\tPointStructDouble\t|\tPointClassDouble\t|\tRatio");

            Stopwatch sw = new Stopwatch();

            int steps = 10;
            int inc = 1000000;
            double rez = 0d;
            Random rnd = new Random(System.DateTime.Now.Millisecond);
            for (int i = 1; i < steps; i++)
            {
                PointClass[] arrayPC = new PointClass[inc * i];
                PointStruct[] arrayPS = new PointStruct[inc * i];

                for (int x = 0; x < arrayPC.Length; x++)
                {
                    //Инициализируем массив PointClass
                    arrayPC[x] = new PointClass() { X = rnd.Next(0, int.MaxValue), Y = rnd.Next(0, int.MaxValue) };
                    //Инициализируем массив PointStruct
                    arrayPS[x].X = arrayPC[x].X;
                    arrayPS[x].Y = arrayPC[x].Y;
                }

                sw.Reset();
                sw.Start();

                for (int x = 0; x < arrayPC.Length - 1; x++)
                {
                    rez = PointDistance(arrayPC[x], arrayPC[x + 1]);
                }

                sw.Stop();

                var pc = sw.Elapsed;

                sw.Reset();
                sw.Start();

                for (int x = 0; x < arrayPS.Length - 1; x++)
                {
                    rez = PointDistance(arrayPS[x], arrayPS[x + 1]);
                }

                sw.Stop();

                var ps = sw.Elapsed;

                Console.WriteLine($"{i * inc}\t|\t{ps}\t|\t{pc}\t|\t{(float)pc.Milliseconds / (float)ps.Milliseconds}");
            }
        }
    }
}
