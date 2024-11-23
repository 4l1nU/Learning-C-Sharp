using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class StringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted("abc")));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Theory]
        [InlineData("abc\"", "abc\"")]
        [InlineData("\"abc", "\"abc")]

        public void AlwaysStartsAndEndsWithQuotes(string input, string remaingText)
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, (input)));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(remaingText));
        }

        [Fact]
        public void IsNotNull()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, null));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().IsEmpty());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, string.Empty));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(string.Empty));
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(string.Empty)));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(string.Empty));
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted("a\nb\rc")));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(Quoted("a\nb\rc")));
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted("⛅⚾")));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Theory]
        [InlineData(@"\""a\"" b")]
        [InlineData(@"a \\ b")]
        [InlineData(@"a \/ b")]
        [InlineData(@"a \b b")]
        [InlineData(@"a \f b")]
        [InlineData(@"a \n b")]
        [InlineData(@"a \r b")]
        [InlineData(@"a \t b")]
        [InlineData(@"a \u26Be b")]


        public void CanContainEscapedSequences(string text)
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(text)));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a \u26Be b")));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a\x")));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(Quoted(@"a\x")));
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a\")));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(Quoted(@"a\")));
        }

        [Theory]
        [InlineData(@"a\u", @"a\u")]
        [InlineData(@"a\u123", @"a\u123")]
        public void DoesNotEndWithAnUnfinishedHexNumber(string text, string remainingText)
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(text)));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(Quoted(remainingText)));
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapeCharactersAfterRecognizedOne()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a\f\x")));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(Quoted(@"a\f\x")));
        }

        [Fact]
        public void CanContainValidCharacterAfterUnicode()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a\u12345")));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]
        public void CanContainSeveralUnicodes()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a\u0af9\uf9a0\uabcd\u09af")));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(""));
        }

        [Fact]
        public void DoesNotContainUnescapedQuotationMark()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a """)));
            Assert.True(match.Success());
            Assert.True(match.RemainingText().StartsWith(@""""));
        }

        [Fact]
        public void DoesNotContainBackslashAtTheEndOfUnicode()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, Quoted(@"a\u1234\ b")));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith(Quoted(@"a\u1234\ b")));
        }

        [Fact]
        public void DoesNotContainASingleQuotationMarkString()
        {
            var a = new String();
            IMatch match = a.Match(new StringView(0, "\""));
            Assert.False(match.Success());
            Assert.True(match.RemainingText().StartsWith("\""));
        }

        public static string Quoted(string text)
           => $"\"{text}\"";
    }
}
