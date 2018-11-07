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
            int[] resArr = new int[11]; // для тестов
            //int[] resArr = new int[rand.Next(128)];
            //while (resArr.GetLength(0) % 2 == 0)
            //  resArr = new int[rand.Next(128)]; // генерируем массив случайной длины в диапазоне от 0 до 127 

            for (int i = 0; i < resArr.GetLength(0); i++)
            {
                resArr[i] = rand.Next(11) + 1;  // для тестов              
                for (int j = 0; j < i; j++)
                {
                    while (resArr[i] == resArr[j])
                    {
                        resArr[i] = rand.Next(11) + 1; // для тестов
                        j = 0;
                    }
                }
            }
            return resArr;
        }

        static int[] ConvertToStartPulse(int[] inArray)
        {
            // копируем массив
            int[] sortArr = new int[inArray.GetLength(0)];
            for (int i = 0; i < sortArr.GetLength(0); i++)
            {
                sortArr[i] = inArray[i];
            }
            // сортируем массив по возрастанию
            int max = Int32.MinValue;
            for (int i = 0; i < sortArr.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < sortArr.GetLength(0); j++)

                    if (sortArr[i] > sortArr[j])
                    {
                        int temp = sortArr[j];
                        sortArr[j] = sortArr[i];
                        sortArr[i] = temp;
                    }
                if (sortArr[i] > max)
                    max = sortArr[i];
            }

            int lastIndex = sortArr.GetLength(0) - 1;
            for (int i = sortArr.GetLength(0) / 2; i < sortArr.GetLength(0) / 2 + sortArr.GetLength(0) / 4 + 1; i++)
            {
                int temp = sortArr[i];
                sortArr[i] = sortArr[lastIndex];
                sortArr[lastIndex--] = temp;
            }
            return sortArr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Генерируем массивы");

            int[] inArr = GenerateArray();
            int[] resArr = ConvertToStartPulse(inArr);
            Console.WriteLine($"Длина массива {inArr.GetLength(0)}");
            Console.WriteLine("Входная последовательность");
            foreach (int item in inArr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Стартовый имплуьс:");
            foreach (int item in resArr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
