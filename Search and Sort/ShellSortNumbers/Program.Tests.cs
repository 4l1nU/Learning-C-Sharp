namespace SortRandomNumbers.Tests
{

    public class TestProgram
    {
        [Fact]
        public void ShellSort_UnsortedNumbers_ShouldReturnAscendingSortedNumbers()
        {
            int[] numbers = { 38, 34, 2, 5, 8, 12, 30, 81, 13, 29 };
            Program.ShellSort(numbers);
            int[] expected = { 2, 5, 8, 12, 13, 29, 30, 34, 38, 81 };
            Assert.Equal(expected, numbers);

        }
    }
}