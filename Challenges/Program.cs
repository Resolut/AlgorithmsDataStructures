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
            int[] resArr = new int[10]; // для тестов
            //int[] resArr = new int[rand.Next(128)];
            //while (resArr.GetLength(0) % 2 == 0)
            //  resArr = new int[rand.Next(128)]; // генерируем массив случайной длины в диапазоне от 0 до 127 

            for (int i = 0; i < resArr.GetLength(0); i++)
            {
                resArr[i] = rand.Next(10) + 1;  // для тестов              
                for (int j = 0; j < i; j++)
                {
                    while (resArr[i] == resArr[j])
                    {
                        resArr[i] = rand.Next(10) + 1; // для тестов
                        j = 0;
                    }
                }
            }
            return resArr;
        }

        static int[] ConvertToStartPulse(int[] inArray)
        {
            int[] sortArr = new int[inArray.GetLength(0)];
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            foreach (int item in inArray)
            {
                if (item < min)
                    min = item;
                if (item > max)
                    max = item;
            }
            sortArr[0] = min;
            sortArr[sortArr.Length - 1] = max;

            return sortArr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Генерируем массивы");
            //for (int i = 0; i < 20; i++)
            //{
                int[] inArr = ConvertToStartPulse(GenerateArray());
                Console.WriteLine($"Длина массива {inArr.GetLength(0)}");

                foreach (int item in inArr)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
           // }

            Console.ReadKey();
        }
    }
}
