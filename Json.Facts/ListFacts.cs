using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ListFacts
    {
        [Theory]
        [InlineData("1,2,3", "")]
        [InlineData("1,2,3,", ",")]
        [InlineData("123", "23")]
        [InlineData("1,23", "3")]
        [InlineData("1a", "a")]
        [InlineData("abc", "abc")]
        [InlineData("", "")]

        public void FindsMatchWithRangeAndChar(string text, string remainingText)
        {
            var a = new List(new Range('0', '9'), new Char(','));
            IMatch match = a.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

        public void FindsMatchWithRangeAndCharAndNullText()
        {
            var a = new List(new Range('0', '9'), new Char(','));
            IMatch match = a.Match(new StringView(0, null));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }

        [Theory]
        [InlineData("1; 22  ;\n 333 \t; 22", "")]
        [InlineData("1 \n;", " \n;")]
        [InlineData("abc", "abc")]

        public void FindsMatchWithManyPatterns(string text, string remainingText)
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Char(';'), whitespace);
            var list = new List(digits, separator);

            IMatch match = list.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }
    }
}
