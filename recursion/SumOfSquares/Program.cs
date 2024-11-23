using System;

namespace SeondApp
{
    public class Program
    {
        // Suma Patratelor unui numar N
        public static void Main()
        {
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            int result = GetSumOfSquares(inputNumber);
            Console.WriteLine(result);
        }

        private static int GetSumOfSquares(int inputNumber)
        {
            if (inputNumber < 1)
            {
                return inputNumber;
            }

            return inputNumber * inputNumber + GetSumOfSquares(inputNumber - 1);
        }
    }
}