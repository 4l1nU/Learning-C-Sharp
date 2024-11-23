using SeondApp;
using System;
using System.Reflection;

namespace PascalTriangle.Test
{
    public class TestProgram
    {
        [Fact]
        public void GetCalculationResult_AdditionOfTwoInt_ShouldReturnAsAResultTwo()
        {
            string[] inputOperation = "+ 1 1".Split(" ");
            Assert.Equal(2, Program.GetCalculationResult(inputOperation));
        }

        [Fact]
        public void GetCalculationResult_AdditionOfTwoDouble_ShouldReturnAsAResultTwoDotTwo()
        {
            string[] inputOperation = "+ 1.1 1.1".Split(" ");
            Assert.Equal(2.2, Program.GetCalculationResult(inputOperation));
        }

        [Fact]
        public void GetCalculationResult_SubstractionOfTwoDouble_ShouldReturnAsAResultZero()
        {
            string[] inputOperation = "- 1.1 1.1".Split(" ");
            Assert.Equal(0, Program.GetCalculationResult(inputOperation));
        }

        [Fact]
        public void GetCalculationResult_MultiplicationOfTwoDouble_ShouldReturnAsAResultOne()
        {
            string[] inputOperation = "* 1 1".Split(" ");
            Assert.Equal(1, Program.GetCalculationResult(inputOperation));
        }

        [Fact]
        public void GetCalculationResult_DivisionOfTwoDouble_ShouldReturnAsAResultOne()
        {
            string[] inputOperation = "/ 1.1 1.1".Split(" ");
            Assert.Equal(1, Program.GetCalculationResult(inputOperation));
        }

        [Fact]
        public void GetCalculationResult_SingleDouble_ShouldReturnAsAResultOneDotOne()
        {
            string[] inputOperation = "1.1".Split(" ");
            Assert.Equal(1.1, Program.GetCalculationResult(inputOperation));
        }

        [Fact]
        public void GetCalculationResult_HighComplexityOperation_ShouldReturnAsAResultSix()
        {
            string[] inputOperation = "/ * 6 + 4 5 / * 9 4 - + 2 8 6".Split(" ");
            Assert.Equal(6, Program.GetCalculationResult(inputOperation));
        }
    }
}
