using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class AnyFacts
    {
        [Theory]
        [InlineData("ea", "a", "eE")]
        [InlineData("Ea", "a", "eE")]
        [InlineData("+3", "3", "+-")]
        [InlineData("-2", "2", "+-")]

        public void CanFindAnyMatch(string text, string remainingText, string constructorValue)
        {
            var e = new Any(constructorValue);
            IMatch match = e.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }


        [Theory]
        [InlineData("a", "a", "eE")]
        [InlineData("", "", "eE")]
        [InlineData("2", "2", "-+")]
        [InlineData("", "", "-+")]


        public void CantFindAnyMatch(string text, string remainingText, string constructorValue)
        {
            var e = new Any(constructorValue);
            IMatch match = e.Match(new StringView(0, text));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Theory]
        [InlineData(null, null, "eE")]
        [InlineData(null, null, "-+")]


        public void CantFindAnyMatchWithNullValue(string text, string remainingText, string constructorValue)
        {
            var e = new Any(constructorValue);
            IMatch match = e.Match(new StringView(0, text));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }
    }
}
