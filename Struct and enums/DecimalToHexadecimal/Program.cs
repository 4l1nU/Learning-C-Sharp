using System;

namespace SeondApp
{
    public class Program
    {
        const int NumericalBase = 16;
        const int LastHexadecimalDigit = 9;

        public static void Main()
        {
            int decimalNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(TransformFromDecimalToHexadecimal(decimalNumber));
        }

        public static string TransformFromDecimalToHexadecimal(int decimalNumber)
        {
            double reminder = decimalNumber;
            string result = "";

            if (reminder < NumericalBase)
            {
                AddHexaNumber(reminder, ref result);
                return result;
            }

            CalculateHexadecimalValue(decimalNumber, ref result, reminder);
            return result;
        }

        public static int CalculateHexadecimalValue(int decimalNumber, ref string result, double reminder)
        {
            if (decimalNumber == 0 && reminder < 1)
            {
                return 0;
            }

            if (reminder < NumericalBase)
            {
                AddHexaNumber(reminder, ref result);
            }

            return CalculateHexadecimalValue(decimalNumber / NumericalBase, ref result, decimalNumber % NumericalBase);
        }

        private static void AddHexaNumber(double decimalNumber, ref string result)
        {
            if (decimalNumber > LastHexadecimalDigit)
            {
                result = result.Insert(0, GetHexadecimalNumber(decimalNumber));
                return;
            }

            result = result.Insert(0, Convert.ToString(decimalNumber));
        }

        private static string GetHexadecimalNumber(double decimalNumber)
        {
            const int BaseTwoTen = 10;
            const int BaseTwoEleven = 11;
            const int BaseTwoTwelve = 12;
            const int BaseTwoThirteen = 13;
            const int BaseTwoFourteen = 14;
            const int BaseTwoFiveteen = 15;

            switch (decimalNumber)
            {
                case BaseTwoTen: return "A";
                case BaseTwoEleven: return "B";
                case BaseTwoTwelve: return "C";
                case BaseTwoThirteen: return "D";
                case BaseTwoFourteen: return "E";
                case BaseTwoFiveteen: return "F";
            }

            return "";
        }
    }
}