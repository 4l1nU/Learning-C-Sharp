using Microsoft.VisualBasic;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace SupportCases
{
/*    Problema de rezolvat:

Descarcă proiectul atașat problemei și continuă rezolvarea.Trebuie implementată funcția Quick3Sort și apoi se trimite – ca de obicei – fișierul Program.cs pentru validare.

Problema:
La un centru de reparații fiecare caz are o prioritate: Critical, Important, Medium și Low.

Se dă o listă de N cazuri, câte unul pe linie, în următorul format:
 <id> - <descriere> - <prioritate>

Să se scrie o aplicație consolă ce ordonează cazurile în ordine descrescătoare a priorității.

Important: Implementează algoritmul Quick3Sort pentru a rezolva problema.Acesta este o soluție de sortare foarte eficientă pentru cazurile când datele ce trebuie ordonate au un număr limitat de valori posibile.

Exemplu:

Pentru datele de intrare:

8
1 - Incorrect behavior - Medium
2 - Device not working - Important
3 - Battery drain - Important
4 - Device immediately turns off - Critical
5 - Strange behavior - Low
6 - Occasionally freeze - Critical
7 - Application not working - Low
8 - Internet connection problems - Medium
La consolă se va afișa:

6 - Occasionally freeze - Critical
4 - Device immediately turns off - Critical
3 - Battery drain - Important
2 - Device not working - Important
1 - Incorrect behavior - Medium
8 - Internet connection problems - Medium
7 - Application not working - Low
5 - Strange behavior - Low

    Rezolvarea trimisă este corectă.

 5/29/2023, 10:55:29 PM - rezolvarea corectă - ascunde detaliie...

Fișier: Program.cs

Rezultate:

Compilare executată cu succes.
Testul 1: Ordonează corect după prioritate lista de cazuri (8, 1 - Incorrect behavior - Medium, 2 - Device not working - Important, 3 - Battery drain - Important, 4 - Device immediately turns off - Critical, 5 - Strange behavior - Low, 6 - Occasionally freeze - Critical, 7 - Application not working - Low, 8 - Internet connection problems - Medium) - succes
Testul 2: Tratează corect situația când unele valori apar o singură dată în listă(6, 1 - Incorrect behavior - Medium, 2 - Device not working - Important, 3 - Battery drain - Important, 4 - Device immediately turns off - Critical, 5 - Strange behavior - Low, 6 - Occasionally freeze - Critical) - succes
Testul 3: Tratează corect situația când lista conține un singur caz(1, 1 - Incorrect behavior - Medium) - succes
Testul 4: Tratează corect situația când lista e deja ordonată(8, 6 - Occasionally freeze - Critical, 4 - Device immediately turns off - Critical, 3 - Battery drain - Important, 2 - Device not working - Important, 1 - Incorrect behavior - Medium, 8 - Internet connection problems - Medium, 7 - Application not working - Low, 5 - Strange behavior - Low) - succes
Testul 5: Rezolvarea merge cu date de intrare aleatoare - succes*/
    public enum PriorityLevel
    {
        Critical,
        Important,
        Medium,
        Low
    }

    public struct SupportTicket
    {
        public long Id;
        public string Description;
        public PriorityLevel Priority;

        public SupportTicket(long id, string description, PriorityLevel priority)
        {
            this.Id = id;
            this.Description = description;
            this.Priority = priority;
        }
    }

    public class Program
    {
        public static void Main()
        {
            SupportTicket[] tickets = ReadSupportTickets();
            Quick3Sort(tickets);
            Print(tickets);
            Console.Read();
        }

        public static void Quick3Sort(SupportTicket[] tickets)
        {
            GetArrayQuick3Sorted(tickets, 0, tickets.Length - 1);
        }

        public static void GetArrayQuick3Sorted(SupportTicket[] array, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            SupportTicket pivot = array[low];
            int lt = low;
            int gt = high;
            int i = low + 1;

            while (i <= gt)
            {
                if (array[i].Priority < pivot.Priority)
                {
                    Swap(array, i, lt);
                    i++;
                    lt++;
                }
                else if (array[i].Priority > pivot.Priority)
                {
                    Swap(array, i, gt);
                    gt--;
                }
                else
                {
                    i++;
                }
            }

            GetArrayQuick3Sorted(array, low, lt - 1);
            GetArrayQuick3Sorted(array, gt + 1, high);
        }

        private static void Swap(SupportTicket[] array, int i, int j)
        {
            SupportTicket temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static void Print(SupportTicket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                Console.WriteLine(tickets[i].Id + " - " + tickets[i].Description + " - " + tickets[i].Priority);
            }
        }

        static SupportTicket[] ReadSupportTickets()
        {
            const int ticketIdIndex = 0;
            const int descriptionIndex = 1;
            const int priorityLevelIndex = 2;

            int ticketsNumber = Convert.ToInt32(Console.ReadLine());
            SupportTicket[] result = new SupportTicket[ticketsNumber];

            for (int i = 0; i < ticketsNumber; i++)
            {
                string[] ticketData = Console.ReadLine().Split('-');
                long id = Convert.ToInt64(ticketData[ticketIdIndex]);
                result[i] = new SupportTicket(id, ticketData[descriptionIndex].Trim(), GetPriorityLevel(ticketData[priorityLevelIndex]));
            }

            return result;
        }

        static PriorityLevel GetPriorityLevel(string priority)
        {
            return priority.ToLower().Trim() switch
            {
                "critical" => PriorityLevel.Critical,
                "important" => PriorityLevel.Important,
                "medium" => PriorityLevel.Medium,
                _ => PriorityLevel.Low,
            };
        }
    }
}
