using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Json.Facts
{
    public class ChoiceFacts
    {
        [Fact]

        public void FirstLetterIsSameAsCharacterAndInRange()
        {
            var choice = new Choice(new Char('a'), new Range('a', 'a'));
            IMatch match = choice.Match(new StringView(0, "a"));
            Assert.True(match.Success());
        }

        [Fact]

        public void FirstLetterIsNotSameAsCharacterOrInRange()
        {
            var choice = new Choice(new Char('a'), new Range('a', 'a'));
            IMatch match = choice.Match(new StringView(0, "b"));
            Assert.False(match.Success());
        }

        [Theory]
        [InlineData("a")]
        [InlineData("b")]

        public void FirstLetterCanBeOnlyInRangeOrCharacter(string text)
        {
            var choice = new Choice(new Char('a'), new Range('b', 'b'));
            IMatch match = choice.Match(new StringView(0, text));
            Assert.True(match.Success());
        }

        [Theory]
        [InlineData("012")]
        [InlineData("12")]
        [InlineData("92")]

        public void MethodFindsAMatchWithOneChoice(string text)
        {
            var digit = new Choice(
                new Char('0'),
                new Range('1', '9')
            );
            var match = digit.Match(new StringView(0, text));
            Assert.True(match.Success());
        }

        [Theory]
        [InlineData("a9")]
        [InlineData("")]
        [InlineData(null)]

        public void MethodDoesntFindAMatchWithOneChoice(string text)
        {
            var digit = new Choice(
                new Char('0'),
                new Range('1', '9')
            );
            IMatch match = digit.Match(new StringView(0, text));
            Assert.False(match.Success());
        }

        [Theory]
        [InlineData("12")]
        [InlineData("a9")]
        [InlineData("92")]
        [InlineData("f8")]
        [InlineData("A9")]
        [InlineData("F8")]

        public void MethodFindsAMatchWithTwoChoices(string text)
        {
            var digit = new Choice(
                new Char('0'),
                new Range('1', '9')
            );
            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );
            IMatch match = hex.Match(new StringView(0, text));
            Assert.True(match.Success());
        }

        [Theory]
        [InlineData("g8")]
        [InlineData("G8")]
        [InlineData("")]
        [InlineData(null)]

        public void MethodDoesntFindAMatchWithTwoChoices(string text)
        {
            var digit = new Choice(
                new Char('0'),
                new Range('1', '9')
            );
            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );
            IMatch match = hex.Match(new StringView(0, text));
            Assert.False(match.Success());
        }

        [Fact]
        public void NewPatternCanBeAddedToChoice()
        {
            var initialChoice = new Choice(new Char('a'));
            var patternToAdd = new Char('b');
            initialChoice.Add(patternToAdd);
            var bMatch = initialChoice.Match(new StringView(0, "b"));
            Assert.True(bMatch.Success());
            Assert.True(bMatch.RemainingText().StartsWith(""));
        }
    }
}
