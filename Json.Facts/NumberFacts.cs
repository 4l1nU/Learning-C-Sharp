using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class NumberFacts
    {
        [Fact]

        public void CanBeZero()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "0"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void DoesNotContainLetters()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "a"));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith("a"));
        }

        [Fact]

        public void CanHaveASingleDigit()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "9"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void CanHaveMultipleDigits()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "90"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void IsNotNull()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, null));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }

        [Fact]

        public void IsNotAnEmptyString()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, string.Empty));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(string.Empty));
        }

        [Fact]

        public void DoesNotStartWithZero()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "07"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith("7"));
        }

        [Fact]

        public void CanBeNegative()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "-26"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void CanBeMinusZero()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "-0"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void CanBeFractional()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12.34"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void TheFractionCanHaveLeadingZeros()
        {
            var a = new Number();
            IMatch zeroMatch = a.Match(new StringView(0, "0.00000001"));
            IMatch tenMatch = a.Match(new StringView(0, "10.00000001"));
            Assert.True(zeroMatch.Success());
            Assert.True(zeroMatch.RemainingText().StartsWith(""));
            Assert.True(tenMatch.Success());
            Assert.True(tenMatch.RemainingText().StartsWith(""));
        }

        [Fact]

        public void DoesNotEndWithADot()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12."));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith("."));
        }

        [Fact]

        public void DoesNotHaveTwoFractionParts()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12.34.56"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(".56"));
        }

        [Fact]

        public void TheDecimalPartDoesNotAllowLetters()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12.3x"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith("x"));
        }

        [Fact]

        public void CanHaveAnExponent()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12e3"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void TheExponentCanStartWithCapitalE()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12E3"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void TheExponentCanHavePositive()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12e+3"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void TheExponentCanBeNegative()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "61e-9"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void CanHaveFractionAndExponent()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "12.34E3"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]

        public void TheExponentDoesNotAllowLetters()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "22e3x3"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith("x3"));
        }

        [Fact]

        public void DoesNotHaveTwoExponents()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "22e323e33"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith("e33"));
        }

        [Theory]
        [InlineData("22e+", "e+")]
        [InlineData("22E-", "E-")]
        [InlineData("22e", "e")]

        public void TheExponentIsAlwaysComplete(string text, string remainingText)
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

        public void TheExponentIsAfterTheFraction()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "22e3.3"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(".3"));
        }

        [Fact]

        public void HasInteger()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, ".1e+1"));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(".1e+1"));
        }

        [Theory]
        [InlineData("e+1", "e+1")]
        [InlineData("-", "-")]
        [InlineData(".", ".")]


        public void IsNotOnlyAcceptedCharacter(string text, string remainingText)
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, text));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

        public void FractionHasDigits()
        {
            var a = new Number();
            IMatch match = a.Match(new StringView(0, "1.e1"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(".e1"));
        }
    }
}
