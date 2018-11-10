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
            const int MaxSizeArray = 128;                      // Максимальное количество элементов массива 
            const int MaxValue = 256;                          // Максимальное значение для элемента массива 
            int[] resArr = new int[rand.Next(MaxSizeArray)];   // Генерируем массив случайной длины в диапазоне [0 - MaxSizeArray), MaxSizeArray в диапазон не входит

            while (resArr.GetLength(0) % 2 == 0)
                resArr = new int[rand.Next(MaxSizeArray)]; 

            // Заполняем массив случайными значениями в диапазоне [0 - MaxValue), MaxValue в диапазон не входит
            for (int i = 0; i < resArr.GetLength(0); i++)
            {
                resArr[i] = rand.Next(MaxValue);
                for (int j = 0; j < i; j++)
                {
                    while (resArr[i] == resArr[j])
                    {
                        resArr[i] = rand.Next(MaxValue);
                        j = 0;
                    }
                }
            }
            return resArr;
        }

        static int[] ConvertToStartPulse(int[] inArray)
        {
            // Копируем массив
            int[] sortArr = new int[inArray.GetLength(0)];
            for (int i = 0; i < sortArr.GetLength(0); i++)
            {
                sortArr[i] = inArray[i];
            }

            // Сортируем весь массив по возрастанию
            for (int i = 0; i < sortArr.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < sortArr.GetLength(0); j++)

                    if (sortArr[i] > sortArr[j])
                    {
                        int temp = sortArr[j];
                        sortArr[j] = sortArr[i];
                        sortArr[i] = temp;
                    }
            }

            // Сортируем вторую половину массива по убыванию
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
            const int countArrays = 100;                    // Число отсортированных массивов
            bool isFault = false;                           // Флаг ошибки

            for (int count = 0; count < countArrays; count++)
            {
                int[] inArr = GenerateArray();              // Входной массив
                int[] testArr = ConvertToStartPulse(inArr); // Отсортированный массив
                int max = Int32.MinValue;
                int min = Int32.MaxValue;

                for (int i = 0; i < testArr.Length; i++)
                {
                    // Массив с одним элементом является отсортированным
                    if (testArr.Length > 1)
                    {
                        // Проверка на возрастание первой половины массива: 
                        // каждый элемент первой половины, начиная с элемента с индексом = 1 больше предыдущего
                        if (i > 0 && i < testArr.Length / 2)
                        {
                            if (testArr[i] <= testArr[i - 1])
                            {
                                isFault = true;
                                Console.WriteLine("Ошибка 001! Первая половина массива сформирована некорректно!");
                                break;
                            }

                        }

                        // Проверка на убывание второй половины массива: 
                        // каждый элемент второй половины меньше предыдущего
                        if (i > testArr.Length / 2)
                        {
                            if (testArr[i] >= testArr[i - 1])
                            {
                                isFault = true;
                                Console.WriteLine("Ошибка 002! Вторая половина массива сформирована некорректно!");
                                break;
                            }

                        }

                        // Проверка: наименьший элемент второй половины больше любого элемента из первой половины масива 
                        if (i == testArr.Length - 1 && testArr[i] <= testArr[testArr.Length / 2 - 1])
                        {
                            isFault = true;
                            Console.WriteLine("Ошибка 003! Массив отсоритрован некоректно!");
                        }
                    }

                    // Определение максимального и минимального элементов
                    if (testArr[i] > max)
                        max = testArr[i];
                    if (testArr[i] < min)
                        min = testArr[i];
                }

                // Проверка расположения максимального и минимального элементов
                if (max != testArr[testArr.Length / 2] || min != testArr[0])
                {
                    isFault = true;
                    Console.WriteLine("Ошибка 004! Минимум и максимум расставлены некорректно!");
                }

            }
            Console.WriteLine($"Общее количество тестов: {countArrays}");

            if (isFault)
                Console.WriteLine("НЕУДАЧА! Двигатель работает не в полную силу!");
            else
                Console.WriteLine("УСПЕХ! Двигатель работает на максимальных оборотах!");

            Console.ReadKey();
        }
    }
}
