using System;

namespace SeondApp
{
    public class Program
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            string result = GetStringReversed(inputString);
            Console.WriteLine(result);
        }

        private static string GetStringReversed(string inputString)
        {
            if (inputString.Length == 1)
            {
                return inputString;
            }

            return inputString[inputString.Length - 1] + GetStringReversed(inputString.Remove(inputString.Length - 1));
        }
    }
}