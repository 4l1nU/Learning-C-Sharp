using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class OneOrMoreFacts
    {
        [Theory]
        [InlineData("123", "")]
        [InlineData("1a", "a")]

        public void FindsMatch(string text, string remainingText)
        {
            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Theory]
        [InlineData("bc", "bc")]
        [InlineData("", "")]

        public void DoesntFindMatch(string text, string remainingText)
        {
            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match(new StringView(0, text));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

        public void DoesntFindMatchWithNullValue()
        {
            var a = new OneOrMore(new Range('0', '9'));
            IMatch match = a.Match(new StringView(0, null));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }
    }
}
