using System;
using System.Runtime.Intrinsics.X86;
using static System.Formats.Asn1.AsnWriter;

namespace SortByName
{
    /*https://www.geeksforgeeks.org/quick-sort/
     * Problema de rezolvat:

    Descarcă proiectul atașat problemei și continuă rezolvarea.Trebuie implementată funcția QuickSort și apoi se trimite – ca de obicei – fișierul Program.cs pentru validare.

    Problema:

    Se dă o listă de N elevi.Pentru fiecare elev se primesc datele de la tastatură pe câte o linie în următorul format:
     <nume>: < media generală>

    Să se scrie o aplicație consolă ce ordonează lista de elevi în ordine alfabetică.

    Important: Implementează algoritmul QuickSort pentru a rezolva problema.Acesta este una dintre cele mai eficiente soluții generale de ordonare a datelor.

    Exemplu:

    Pentru datele de intrare:

    8
    Vasile: 9.90
    Ion: 8.67
    Adi: 9.90
    Ana: 10.00
    George: 9.99
    Maria: 9.10
    Elena: 8.98
    Ducu: 9.14
    La consolă se va afișa:

    Adi: 9.90
    Ana: 10.00
    Ducu: 9.14
    Elena: 8.98
    George: 9.99
    Ion: 8.67
    Maria: 9.10
    Vasile: 9.90

        Rezultate:

    Compilare executată cu succes.
    Testul 1: Ordonează alfabetic lista de elevi (8, Vasile 9.90, Ion 8.67, Adi 9.90, Ana 10.00, George 9.99, Maria 9.10, Elena: 8.98, Ducu 9.14) - succes
    Testul 2: Tratează corect cazul când lista are doar un elev(1, Ion 8.67) - succes
    Testul 3: Tratează corect cazul când lista e deja ordonată(8, Adi 9.90, Ana 10.00, Ducu 9.14, Elena 8.98, George 9.99, Ion 8.67, Maria 9.10, Vasile 9.90) - succes
    Testul 4: Ordonează alfabetic o listă mai lungă(15, Alin 7.80, Vasile 9.90, Ion 8.67, Adi 9.90, Radu 9.92, Ana 10.00, George 9.99, Maria 9.10, Elena 8.98, Ducu 9.14, Liana 9.50, Irina 7.33, Ema 8.22, Relu 9.71, Ina 9.04) - succes
    Testul 5: Rezolvarea merge cu date de intrare aleatoare - succes*/
    public struct Student
    {
        public string Name;
        public double Grade;

        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Student[] students = ReadStudents();
            QuickSort(students);
            Print(students);
            Console.Read();
        }

        public static void QuickSort(Student[] students)
        {
            QuickSortRecursively(students, 0, students.Length - 1);
        }

        private static void QuickSortRecursively(Student[] students, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int pi = Partition(students, low, high);
            QuickSortRecursively(students, low, pi - 1);
            QuickSortRecursively(students, pi + 1, high);
        }

        private static int Partition(Student[] students, int low, int high)
        {
            Student pivot = students[high];
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                if (IsAlphabeticallySorted(students[j], pivot))
                {
                    i++;
                    Swap(students, i, j);
                }
            }

            Swap(students, i + 1, high);
            return i + 1;
        }

        private static void Swap(Student[] students, int i, int j)
        {
            Student temp = students[i];
            students[i] = students[j];
            students[j] = temp;
        }

        static bool IsAlphabeticallySorted(Student firststudent, Student secondStudent)
        {
            int maxLettersToCompare = firststudent.Name.Length < secondStudent.Name.Length ?
                firststudent.Name.Length : secondStudent.Name.Length;
            for (int index = 0; index < maxLettersToCompare; index++)
            {
                if (firststudent.Name[index] < secondStudent.Name[index])
                {
                    return true;
                }

                if (firststudent.Name[index] > secondStudent.Name[index])
                {
                    return false;
                }
            }

            return false;
        }

        static void Print(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(string.Format("{0}: {1:F2}", students[i].Name, students[i].Grade));
            }
        }

        static Student[] ReadStudents()
        {
            int studentsNumber = Convert.ToInt32(Console.ReadLine());
            Student[] result = new Student[studentsNumber];

            for (int i = 0; i < studentsNumber; i++)
            {
                string[] studentData = Console.ReadLine().Split(':');
                result[i] = new Student(studentData[0], Convert.ToDouble(studentData[1]));
            }

            return result;
        }
    }
}
