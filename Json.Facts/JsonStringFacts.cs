using Xunit;
using static Json.JsonString;

namespace Json.Facts
{
    public class JsonStringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            Assert.True(IsJsonString(Quoted("abc")));
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            Assert.False(IsJsonString("abc\""));
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            Assert.False(IsJsonString("\"abc"));
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.False(IsJsonString(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.False(IsJsonString(string.Empty));
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            Assert.True(IsJsonString(Quoted(string.Empty)));
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            Assert.False(IsJsonString(Quoted("a\nb\rc")));
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted("⛅⚾")));
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            Assert.True(IsJsonString(Quoted(@"\""a\"" b")));
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \\ b")));
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \/ b")));
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            Assert.True(IsJsonString(Quoted(@"a \b b")));
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \f b")));
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \n b")));
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            Assert.True(IsJsonString(Quoted(@"a \r b")));
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            Assert.True(IsJsonString(Quoted(@"a \t b")));
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \u26Be b")));
        }

        [Fact]
        public void CanContainAnyMultipleEscapeSequences()
        {
            Assert.True(IsJsonString(Quoted(@"\\\u1212\n\t\r\\\b")));
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            Assert.False(IsJsonString(Quoted(@"a\x")));
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            Assert.False(IsJsonString(Quoted(@"a\")));
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            Assert.False(IsJsonString(Quoted(@"a\u")));
            Assert.False(IsJsonString(Quoted(@"a\u123")));
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharactersAfterRecognizedOne()
        {
            Assert.False(IsJsonString(Quoted(@"a\f\x")));
        }

        [Fact]
        public void CanContainValidCharacterAfterUnicode()
        {
            Assert.True(IsJsonString(Quoted(@"a\u12345")));
        }

        [Fact]
        public void CanContainSeveralUnicodes()
        {
            Assert.True(IsJsonString(Quoted(@"a\u0af9\uf9a0\uabcd\u09af")));
        }

        [Fact]
        public void DoesNotContainUnescapedQuotationMark()
        {
            Assert.False(IsJsonString(Quoted(@"a """)));
        }

        [Fact]
        public void DoesNotContainQuotationMarkAtTheEndOfUnicodeButInTheMiddleOfString()
        {
            Assert.False(IsJsonString(Quoted(@"a\u1234"" b")));
        }

        [Fact]
        public void DoesNotContainIllegalBackslashAtTheEndOfUnicode()
        {
            Assert.False(IsJsonString(Quoted(@"a\u1234\ b")));
        }

        [Fact]
        public void DoesNotContainUnicodeEndedWithIllegalQuotationMark()
        {
            Assert.False(IsJsonString(Quoted(@"a\u1234""")));
        }

        [Fact]
        public void DoesNotEndWithBackslash()
        {
            Assert.False(IsJsonString(Quoted(@"a\f\")));
        }

        [Fact]
        public void DoesNotContainASingleQuotationMarkString()
        {
            Assert.False(IsJsonString("\""));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
