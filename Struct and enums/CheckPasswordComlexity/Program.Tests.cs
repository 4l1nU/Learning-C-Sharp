using Xunit;
using CheckPasswordComplexity;

namespace CheckPasswordComplexity.Tests
{
    public class TestProgram
    {
        [Fact]
        public void CheckPassword_OneLowerCaseShouldHaveMinimumOneLowerCase_ShouldReturnTrue()
        {
            string password = "z";
            PasswordRequirements passwordRequirements = new PasswordRequirements(1, 0, 0, 0, false, false);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_NoLowerCaseShouldHaveMinimumOneLowerCase_ShouldReturnFalse()
        {
            string password = "Z";
            PasswordRequirements passwordRequirements = new PasswordRequirements(1, 0, 0, 0, false, false);
            Assert.False(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_OneUpperCaseShouldHaveMinimumOneUpperCase_ShouldReturnTrue()
        {
            string password = "Z";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 1, 0, 0, false, false);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_NoUpperCaseShouldHaveMinimumOneUpperCase_ShouldReturnFalse()
        {
            string password = "a";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 1, 0, 0, false, false);
            Assert.False(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_OneDigitShouldHaveMinimumOneDigit_ShouldReturnTrue()
        {
            string password = "2";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 1, 0, false, false);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }
        [Fact]
        public void CheckPassword_NoDigitShouldHaveMinimumOneDigit_ShouldReturnFalse()
        {
            string password = "b";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 1, 0, false, false);
            Assert.False(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_OneSimbolShouldHaveMinimumOneSimbol_ShouldReturnTrue()
        {
            string password = "+";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 0, 1, false, false);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_NoSimbolShouldHaveMinimumOneSimbol_ShouldReturnFalse()
        {
            string password = "9";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 0, 1, false, false);
            Assert.False(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_OneSimilarCharCanHaveSimilarChar_ShouldReturnTrue()
        {
            string password = "l";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 0, 0, true, false);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_OneSimilarCharCantHaveSimilarChar_ShouldReturnFalse()
        {
            string password = "l";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 0, 0, false, false);
            Assert.False(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_OneAmbiguousCharCanHaveAmbiguousChar_ShouldReturnTrue()
        {
            string password = "\\";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 0, 0, false, true);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_OneAmbiguousCharCantHaveAmbiguousChar_ShouldReturnFalse()
        {
            string password = "\\";
            PasswordRequirements passwordRequirements = new PasswordRequirements(0, 0, 0, 0, false, false);
            Assert.False(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_FiveLowerCasesOneUpperOneDigitOneSimbolCantHaveSimilarCharOneAmbiguousCharCanHaveAmbiguousChar_ShouldReturnTrue()
        {
            string password = "abcdeA2+";
            PasswordRequirements passwordRequirements = new PasswordRequirements(5, 1, 1, 1, false, true);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }

        [Fact]
        public void CheckPassword_FiveLowerCasesTwoUpperTwoDigitTwoSimbolCanHaveSimilarCharTwoAmbiguousCharCanHaveAmbiguousChar_ShouldReturnTrue()
        {
            string password = @"abcde""AB\23";
            PasswordRequirements passwordRequirements = new PasswordRequirements(5, 2, 2, 2, true, true);
            Assert.True(Program.CheckIfPasswordCorrect(password, passwordRequirements));
        }
    }
}