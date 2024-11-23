namespace SeondApp.Tests
{
    public class TestProgram
    {
        [Fact]
        public void GetCombinatonsOfExpresion_MaxNumberTwoResultOne_ShouldReturnNA()
        {
            int inputMaxNumber = 2;
            int inputResult = 1;
            string[] result = { "N/A" };
            Assert.Equal(result, Program.GetCombinatonsOfExpresion(inputMaxNumber, inputResult));
        }

        [Fact]
        public void GetCombinatonsOfExpresion_MaxNumberTwoResultThree_ShouldReturnOneCombination()
        {
            int inputMaxNumber = 2;
            int inputResult = 3;
            string[] result = { "1 + 2 = 3" };
            Assert.Equal(result, Program.GetCombinatonsOfExpresion(inputMaxNumber, inputResult));
        }

        [Fact]

        public void GetCombinatonsOfExpresion_MaxNumberSixResultThree_ShouldReturnThreeCombinations()
        {
            int inputMaxNumber = 6;
            int inputResult = 3;
            string[] result = { "1 + 2 - 3 + 4 + 5 - 6 = 3",
                                "1 + 2 + 3 - 4 - 5 + 6 = 3",
                                "1 - 2 - 3 - 4 + 5 + 6 = 3" };
            Assert.Equal(result, Program.GetCombinatonsOfExpresion(inputMaxNumber, inputResult));
        }

        [Fact]

        public void GetCombinatonsOfExpresion_MaxNumberTenResultFortyThree_ShouldReturnTwoCombinations()
        {
            int inputMaxNumber = 10;
            int inputResult = 43;
            string[] result = { "1 + 2 + 3 + 4 + 5 - 6 + 7 + 8 + 9 + 10 = 43",
                                "1 - 2 + 3 - 4 + 5 + 6 + 7 + 8 + 9 + 10 = 43" };
            Assert.Equal(result, Program.GetCombinatonsOfExpresion(inputMaxNumber, inputResult));
        }

        [Fact]

        public void GetCombinatonsOfExpresion_MaxNumberTenResultFortyFour_ShouldReturnNA()
        {
            int inputMaxNumber = 10;
            int inputResult = 44;
            string[] result = { "N/A" };
            Assert.Equal(result, Program.GetCombinatonsOfExpresion(inputMaxNumber, inputResult));
        }
    }
}