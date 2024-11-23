namespace SortByName.Tests
{

    public class TestProgram
    {
        [Fact]
        public void QuickSort_UnsortedCatalog_ShouldReturnAlphabeticallySortedCatalog()
        {
            Student[] students =
                {
                new Student("Vasile", 9.90),
                new Student("Ion", 8.67),
                new Student("Adi", 9.90),
                new Student("Ana", 10.00),
                new Student("George", 9.99),
                new Student("Maria", 9.10),
                new Student("Elena", 8.98),
                new Student("Ducu", 9.14)
            };
            Program.QuickSort(students);
            Student[] studentsSorted =
                {
                new Student("Adi", 9.90),
                new Student("Ana", 10.00),
                new Student("Ducu", 9.14),
                new Student("Elena", 8.98),
                new Student("George", 9.99),
                new Student("Ion", 8.67),
                new Student("Maria", 9.10),
                new Student("Vasile", 9.90)
            };
            Assert.Equal(studentsSorted, students);
        }
    }
}