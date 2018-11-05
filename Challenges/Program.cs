using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    class Program
    {
        static int[] GenerateArray()
        {
            DateTime time = DateTime.Now;
            int seed = time.Millisecond;
            Random rand = new Random(seed);
            // int[] resArr = new int[10]; // для тестов
            int[] resArr = new int[rand.Next(128)];
            while (resArr.GetLength(0) % 2 == 0)
                resArr = new int[rand.Next(128)]; // генерируем массив произвольной длины
            for (int i = 0; i < resArr.GetLength(0); i++)
            {
                // resArr[i] = rand.Next(10);  // для тестов
                resArr[i] = rand.Next(256);
                for (int j = 0; j < i; j++)
                {
                    while (resArr[i] == resArr[j])
                    {
                        //resArr[i] = rand.Next(10); // для тестов
                        resArr[i] = rand.Next(256);
                        j = 0;
                    }
                }
            }
            return resArr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Генерируем массив");
            int[] inArr = GenerateArray();
            Console.WriteLine($"Длина массива {inArr.GetLength(0)}");

            foreach (int item in inArr)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
    }
}
