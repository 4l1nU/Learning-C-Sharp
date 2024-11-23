using System;

namespace SeondApp
{
    public class Program
    {

        /* Problema de rezolvat:

 Scrie un program ce determină toate combinațiile de  operatori + -  care se pot pune între numerele naturale de la 1 la un N>=2 dat astfel încât rezultatul expresiei formate să fie un număr X dat.Dacă nu există nici o combinație va afișa N/A.

 Exemplu:

 Pentru datele de intrare:

 6
 3
 La consolă se va afișa:

 1 + 2 + 3 - 4 - 5 + 6 = 3
 1 + 2 - 3 + 4 + 5 - 6 = 3
 1 - 2 - 3 - 4 + 5 + 6 = 3

 Rezultate:

 Compilare executată cu succes.
 Testul 1: Găsește o combinație simplă (2 3) - succes
 Testul 2: Determină corect că nu există combinații(2 4) - succes
 Testul 3: Găsește o combinație mai complexă(6 -11) - succes
 Testul 4: Tipărește toate combinațiile atunci când acestea sunt mai multe(10 43) - succes
 Testul 5: Determină corect că nu există combinații pentru un N mai mare(10 44) - succes
 Testul 6: Rezolvarea merge cu date de intrare aleatoare - succes



 */
        public static void Main()
        {
            int inputMaxNumber = Convert.ToInt32(Console.ReadLine());
            int inputResult = Convert.ToInt32(Console.ReadLine());
            GetCombinatonsOfExpresion(inputMaxNumber, inputResult);
        }

        public static void GetCombinatonsOfExpresion(int inputMaxNumber, int inputResult)
        {
            int numberOfPositionsOfOperators = inputMaxNumber - 1;
            int numberOfPossibleCombinations = (int)Math.Pow(2, inputMaxNumber - 1);
            string[] allPossibleCombinationsOfOperators = new string[numberOfPossibleCombinations];
            GetAllPossibleCombinationsOfOperators(allPossibleCombinationsOfOperators, 0, numberOfPositionsOfOperators);
            bool combinationForInputResultExists = false;
            CalculateCombinations(allPossibleCombinationsOfOperators, inputResult, inputMaxNumber, allPossibleCombinationsOfOperators.Length - 1, ref combinationForInputResultExists);
            Console.WriteLine("{0}", combinationForInputResultExists ? "" : "N/A");
        }

        private static void CalculateCombinations(string[] allPossibleCombinationsOfOperators, int inputResult, int inputMaxNumber, int index, ref bool combinationExists)
        {
            if (index < 0)
            {
                return;
            }

            int result = GetResultOfCombination(allPossibleCombinationsOfOperators[index], inputMaxNumber);
            if (result == inputResult)
            {
                combinationExists = true;
                PrintCombination(allPossibleCombinationsOfOperators[index], inputMaxNumber, inputResult, 1);
            }

            CalculateCombinations(allPossibleCombinationsOfOperators, inputResult, inputMaxNumber, index - 1, ref combinationExists);
        }

        private static void PrintCombination(string operatorsCombination, int inputMaxNumber, int inputResult, int currentNumber)
        {
            if (currentNumber == inputMaxNumber)
            {
                Console.Write(inputMaxNumber + " = " + inputResult);
                Console.WriteLine();
                return;
            }

            Console.Write(currentNumber + " {0} ", operatorsCombination[currentNumber - 1] == '0' ? "+" : "-");
            PrintCombination(operatorsCombination, inputMaxNumber, inputResult, currentNumber + 1);
        }

        private static int GetResultOfCombination(string operatorsCombination, int inputMaxNumber)
        {
            if (inputMaxNumber == 1)
            {
                return inputMaxNumber;
            }

            int result = 0;
            int indexOfCurrentOperator = inputMaxNumber - 2;
            if (operatorsCombination[indexOfCurrentOperator] == '0')
            {
                result = GetResultOfCombination(operatorsCombination, inputMaxNumber - 1) + inputMaxNumber;
            }

            if (operatorsCombination[indexOfCurrentOperator] == '1')
            {
                result = GetResultOfCombination(operatorsCombination, inputMaxNumber - 1) - inputMaxNumber;
            }

            return result;
        }

        private static void GetAllPossibleCombinationsOfOperators(string[] allPossibleCombinationsOfOperators, int index, int numberOfPositionsOfOperators)
        {
            if (allPossibleCombinationsOfOperators.Length == index)
            {
                return;
            }

            allPossibleCombinationsOfOperators[index] = GetOperatorsCombinations(index, numberOfPositionsOfOperators);
            GetAllPossibleCombinationsOfOperators(allPossibleCombinationsOfOperators, index + 1, numberOfPositionsOfOperators);
        }

        static string GetOperatorsCombinations(int inputNumber, int numberOfPositionsOfOperators)
        {
            const int Base = 2;
            string resturi = "";
            while (resturi.Length != numberOfPositionsOfOperators)
            {
                resturi += Convert.ToString(inputNumber % Base);
                inputNumber /= Base;
            }

            return resturi;
        }
    }
}