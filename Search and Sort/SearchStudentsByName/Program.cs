using System;

namespace SearchByName
{
    struct Student
    {
        public string Name;
        public double Grade;

        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }

    class Program
    {
        static void Main()
        {
            Student[] students = ReadStudents();
            string studentName = Console.ReadLine();
            Console.WriteLine(SearchStudent(students, studentName));
            Console.Read();
        }

        static int SearchStudent(Student[] students, string studentName)
        {
           for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Name == studentName)
                {
                    return i;
                }
            }

           return -1;
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
