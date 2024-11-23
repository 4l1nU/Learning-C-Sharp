using Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace Json.Facts
{
    public class SequenceFacts
    {
        [Fact]

        public void SequenceHasMatches()
        {
            var ab = new Sequence(
                new Char('a'),
                new Char('b')
            );
            IMatch match = ab.Match(new StringView(0, "abcd"));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith("cd"));
        }

        [Theory]
        [InlineData("ax", "ax")]
        [InlineData("def", "def")]
        [InlineData("", "")]

        public void SequenceDoesntHaveMatches(string text, string remainingText)
        {
            var ab = new Sequence(
                new Char('a'),
                new Char('b')
            );
            IMatch match = ab.Match(new StringView(0, text));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

        public void SequenceDoesntHaveMatchesWithNullValue()
        {
            var ab = new Sequence(
                new Char('a'),
                new Char('b')
            );
            IMatch match = ab.Match(new StringView(0, null));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }

        [Theory]
        [InlineData("u1234", "")]
        [InlineData("uabcdef", "ef")]
        [InlineData("uB005 ab", " ab")]

        public void CombinatedSequencesHaveMatches(string text, string remainingText)
        {
            var hex = new Choice(
                 new Range('0', '9'),
                 new Range('a', 'f'),
                 new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Char('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            IMatch match = hexSeq.Match(new StringView(0, text));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(remainingText));
        }

        [Fact]

        public void CombinatedSequencesDoesntHaveMatches()
        {
            var hex = new Choice(
                 new Range('0', '9'),
                 new Range('a', 'f'),
                 new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Char('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            IMatch match = hexSeq.Match(new StringView(0, "abc"));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith("abc"));
        }

        [Fact]

        public void CombinatedSequencesDoesntHaveMatchesWithNullValue()
        {
            var hex = new Choice(
                 new Range('0', '9'),
                 new Range('a', 'f'),
                 new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Char('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            IMatch match = hexSeq.Match(new StringView(0, null));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }
    }
}