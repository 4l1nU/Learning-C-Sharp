using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class OptionalFacts
    {
        [Theory]
        [InlineData('a', "abc", "bc")]
        [InlineData('a', "aabc", "abc")]
        [InlineData('a', "bc", "bc")]
        [InlineData('a', "", "")]
        [InlineData('-', "123", "123")]
        [InlineData('-', "-123", "123")]

        public void OptionallMatchWorksCorrectly(char pattern, string text, string remainingText)
        {
            var character = new Optional(new Char(pattern));

            IMatch match = character.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

        public void OptionallMatchWorksCorrectlyWithNull()
        {
            var character = new Optional(new Char('a'));

            IMatch match = character.Match(new StringView(0, null));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }
    }
}
