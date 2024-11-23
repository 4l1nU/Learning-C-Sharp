using System.Text.RegularExpressions;
using Xunit;

namespace Json.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void StringIsntNullOrEmpty()
        {
            Range range = new Range('0', '1');
            IMatch match = range.Match(new StringView(0, ""));
            Assert.False(match.Success());
        }

        [Fact]
        public void FirstLetterIsInRange()
        {
            Range range = new Range('0', '9');
            IMatch match = range.Match(new StringView(0, "5"));
            Assert.True(match.Success());
        }

        [Fact]
        public void FirstLetterIsNotInRange()
        {
            Range range = new Range('0', '9');
            IMatch match = range.Match(new StringView(0, "a"));
            Assert.False(match.Success());
        }

        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        public void FirstLetterIsFirstOrLastCharInRange(string text)
        {
            Range range = new Range('a', 'b');
            IMatch match = range.Match(new StringView(0, text));
            Assert.True(match.Success());
        }
    }
}
