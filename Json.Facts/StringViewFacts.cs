using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class StringViewFacts
    {
        [Fact]

        public void CanReturnCorrectChar()
        {
            var stringView = new StringView(0, "a");
            Assert.Equal('a', stringView.Peek());
        }

        [Theory]
        [InlineData(4, "abcd")]
        [InlineData(0, "")]
        [InlineData(0, null)]
        [InlineData(2, "")]

        public void ReturnsTrueIfStringIsNullOrEmptyOrIndexIsNotTooBig(int index, string text)
        {
            var stringView = new StringView(index, text);
            Assert.True(stringView.IsEmpty());
        }

        [Theory]
        [InlineData(3, "abcd")]
        [InlineData(0, "abcd")]
        [InlineData(2, "abcd")]

        public void ReturnsFalseIfStringIsNotNullOrEmptyAndIndexIsNotTooBig(int index, string text)
        {
            var stringView = new StringView(index, text);
            Assert.False(stringView.IsEmpty());
        }

        [Fact]

        public void ReturnsTrueIfStartsWithGivenText()
        {
            var stringView = new StringView(2, "abcde");
            Assert.True(stringView.StartsWith("cd"));

        }

        [Fact]

        public void ReturnsFalseIfItDoesNotStartWithGivenText()
        {
            var stringView = new StringView(3, "abcde");
            Assert.False(stringView.StartsWith("cd"));

        }

        [Theory]
        [InlineData("a", "b")]
        [InlineData("abc", "d")]

        public void CanMakeNewAdvancedStringView(string initialPrefix, string advancedPrefix)
        {
            var stringView = new StringView(0, "abcd");
            Assert.True(stringView.StartsWith(initialPrefix));
            stringView = stringView.Advance(initialPrefix.Length);
            Assert.True(stringView.StartsWith(advancedPrefix));

        }
    }
}
