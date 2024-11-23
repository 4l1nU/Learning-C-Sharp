using System;

namespace SeondApp
{
    public class Program
    {
        const int NumberTwo = 2;

        public static void Main()
        {
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            int result = Fibonacci(inputNumber);
            Console.WriteLine(result);
        }

        private static int Fibonacci(int inputNumber)
        {
            if (inputNumber < NumberTwo)
            {
                return inputNumber;
            }

            return Fibonacci(inputNumber - 1) + Fibonacci(inputNumber - NumberTwo);
        }
    }
}