using System;

namespace SortRandomNumbers
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = ReadNumbers();
            ShellSort(numbers);
            Print(numbers);
            Console.Read();
        }

        public static void ShellSort(int[] numbers)
        {
            GetArrayShellSorted(numbers, numbers.Length);
        }

        private static void GetArrayShellSorted(int[] numbers, int arraySize)
        {
            const int Half = 2;
            for (int gap = arraySize / Half; gap > 0; gap /= Half)
            {
                for (int index = gap; index < arraySize; index++)
                {
                    int temp = numbers[index];
                    int secondIndex = index;
                    while (secondIndex >= gap && numbers[secondIndex - gap] > temp)
                    {
                        numbers[secondIndex] = numbers[secondIndex - gap];
                        secondIndex -= gap;
                    }

                    numbers[secondIndex] = temp;
                }
            }
        }

        static void Print(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.Write("\n");
        }

        static int[] ReadNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToInt32(numbers[i]);
            }

            return result;
        }
    }
}
