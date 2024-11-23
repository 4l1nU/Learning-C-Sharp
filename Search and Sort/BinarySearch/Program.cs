using System;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;

namespace BinarySearch
{
    class Program
    {
        /*        Problema de rezolvat:

        Descarcă proiectul atașat problemei și continuă rezolvarea.Trebuie implementată funcția BinarySearch și apoi se trimite – ca de obicei – fișierul Program.cs pentru validare.

        Problema:

        Se dă o listă ordonată crescător de numere întregi, pe o singură linie, despărțite între ele printr-un singur spațiu.
                Pe linia următoare se dă un număr întreg M.

        Să se scrie o aplicație consolă ce folosește algoritmul de căutare binară pentru a determina indexul numărului M în lista de numere. Dacă M nu se află în șir atunci se va tipări -1.

        Important:
        Aplicația trebuie să afișeze logul complet de comparări făcute pentru a determina dacă M se află în listă. Pentru a genera logul de comparări trebuie folosită funcția CheckNumberAtIndex (vezi proiectul atașat problemei) de fiecare dată când se verifică dacă numărul din șir de la un anumit index e egal cu M.

        Exemplu:

        Pentru datele de intrare:

        0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181
        100
        La consolă se va afișa:

        Checking index 9 (value 34)
        Checking index 14 (value 377)
        Checking index 11 (value 89)
        Checking index 12 (value 144)
        -1
        Compilare executată cu succes.
        Testul 1: Aplică corect căutarea binară pentru un număr din listă (2 4 8 10 12 14 16 18 20, 8) - succes
        Testul 2: Tratează corect cazul când lista conține un singur număr (1, 2) - succes
        Testul 3: Aplică corect căutarea binară pentru primul număr din listă (1 3 5 7 9 11 13 15 17 19 21, 1) - succes
        Testul 4: Aplică corect căutarea binară pentru ultimul număr din listă (0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181, 4181) - succes
        Testul 5: Aplică corect căutarea binară pentru un număr mai mic decât primul din listă (0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181, -3) - succes
        Testul 6: Aplică corect căutarea binară pentru un număr mai mare decât ultimul număr din listă (0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181, 10000) - succes
        Testul 7: Aplică corect căutarea binară pentru un număr care nu e în listă, dar e în intervalul cuprins între cel mai mic și mai mare număr din listă (0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181, 150) - succes
        Testul 8: Rezolvarea merge cu date de intrare aleatoare - succes
         */
        static void Main()
        {
            int[] numbers = ReadNumbers();
            int numberToFind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(BinarySearch(numbers, numberToFind));
            Console.Read();
        }

        private static int[] ReadNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToInt32(numbers[i]);
            }

            return result;
        }

        static int BinarySearch(int[] numbers, int numberToFind)
        {
            int start = 0;
            int end = numbers.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (CheckNumberAtIndex(numbers, mid, numberToFind))
                {
                    return mid;
                }

                if (numbers[mid] < numberToFind)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        static bool CheckNumberAtIndex(int[] numbers, int index, int numberToCheck)
        {
            Console.WriteLine("Checking index " + index + " (value " + numbers[index] + ")");
            return numbers[index] == numberToCheck;
        }
    }
}
