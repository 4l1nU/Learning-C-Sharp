using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ManyFacts
    {
        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("aaaabc", "bc")]
        [InlineData("bc", "bc")]
        [InlineData("", "")]

        public void FindsMatchWithCharacter(string text, string remainingText)
        {
            var a = new Many(new Char('a'));
            IMatch match = a.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

         public void FindsMatchWithNullCharacter()
        {
            var a = new Many(new Char('a'));
            IMatch match = a.Match(new StringView(0, null));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }

        [Theory]
        [InlineData("12345ab123", "ab123")]
        [InlineData("ab", "ab")]

        public void FindsMatchWithRange(string text, string remainingText)
        {
            var digits = new Many(new Range('0', '9'));
            IMatch match = digits.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }
    }
}
