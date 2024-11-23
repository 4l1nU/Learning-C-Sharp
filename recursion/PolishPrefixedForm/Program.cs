using System;
using System.Reflection;

namespace SeondApp
{
    public class Program
    {
        const string AllOperators = "+-*/";

        public static void Main()
        {
            string[] inputOperation = Console.ReadLine().Split(" ");
            Console.WriteLine(GetCalculationResult(inputOperation));
        }

        public static double GetCalculationResult(string[] inputOperation)
        {
            int index = 0;
            return CalculateExpresion(inputOperation, ref index);
        }

        private static double CalculateExpresion(string[] inputOperation, ref int index)
        {
            if (!IsOperator(inputOperation[index], 0))
            {
                return Convert.ToDouble(inputOperation[index]);
            }

            int newIndex = index + 1;
            double firstOperand = CalculateExpresion(inputOperation, ref newIndex);
            newIndex++;
            double secondOperand = CalculateExpresion(inputOperation, ref newIndex);
            double result = 0;
            switch (inputOperation[index])
            {
                case "+":
                    result = firstOperand + secondOperand;
                    break;
                case "-":
                    result = firstOperand - secondOperand;
                    break;
                case "*":
                    result = firstOperand * secondOperand;
                    break;
                case "/":
                    result = firstOperand / secondOperand;
                    break;
            }

            index = newIndex;
            return result;
        }

        private static bool IsOperator(string element, int index)
        {
            if (index == AllOperators.Length || element.Length != 1)
            {
                return false;
            }

            if (Convert.ToChar(element) == AllOperators[index])
            {
                return true;
            }

            if (IsOperator(element, index + 1))
            {
                return true;
            }

            return false;
        }
    }
}