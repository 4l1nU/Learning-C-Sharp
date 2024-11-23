using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class TextFacts
    {
        [Theory]
        [InlineData("true", "true", "")]
        [InlineData("true", "trueX", "X")]
        [InlineData("false", "false", "")]
        [InlineData("false", "falseX", "X")]
        [InlineData("", "true", "true")]

        public void MatchesPrefix(string prefix, string text, string remainingText)
        {
            var textPrefix = new Text(prefix);
            IMatch match = textPrefix.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Theory]
        [InlineData("true", "false", "false")]
        [InlineData("true", "", "")]
        [InlineData("false", "true", "true")]
        [InlineData("false", "", "")]

        public void DoesntMatchPrefix(string prefix, string text, string remainingText)
        {
            var textPrefix = new Text(prefix);
            IMatch match = textPrefix.Match(new StringView(0, text));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Theory]
        [InlineData("true", null)]
        [InlineData("false", null)]
        [InlineData("", null)]

        public void DoesntMatchPrefixWithNullValues(string prefix, string text)
        {
            var textPrefix = new Text(prefix);
            IMatch match = textPrefix.Match(new StringView(0, text));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }
    }
}
