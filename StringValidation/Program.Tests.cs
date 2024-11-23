using Xunit;

namespace AutoCorrect.Tests
{
    public class TestProgram
    {
        [Fact]
        public void GetSuggestion_OneValidWord_ShouldReturnTextCorrect()
        {
            string[] words = { "test" };
            string[] validWords = { "test" };
            Assert.Equal("Text corect!", Program.GetTextSuggestions(words, validWords));
        }

        [Fact]
        public void GetSuggestion_OneInvalidWordWithoutSuggestions_ShouldReturnNoSuggestions()
        {
            string[] words = { "cutu" };
            string[] validWords = { "test" };
            Assert.Equal("cutu: (nu sunt sugestii)", Program.GetTextSuggestions(words, validWords));
        }

        [Fact]
        public void GetSuggestion_OneValidOneInvalidWordWithoutSuggestions_ShouldReturnNoSuggestions()
        {
            string[] words = {"test", "cutu" };
            string[] validWords = { "test" };
            Assert.Equal("cutu: (nu sunt sugestii)", Program.GetTextSuggestions(words, validWords));
        }

        [Fact]
        public void GetSuggestion_OneValidWordDifferentCase_ShouldReturnTextCorrect()
        {
            string[] words = { "Test" };
            string[] validWords = { "test" };
            Assert.Equal("Text corect!", Program.GetTextSuggestions(words, validWords));
        }

        [Fact]
        public void GetSuggestion_OneInvalidWordOneWrongLetter_ShouldReturnSuggestion()
        {
            string[] words = { "Test" };
            string[] validWords = { "text" };
            Assert.Equal("Test: text", Program.GetTextSuggestions(words, validWords));
        }

        [Fact]
        public void GetSuggestion_OneInvalidWordOneMoreLetter_ShouldReturnSuggestion()
        {
            string[] words = { "Test" };
            string[] validWords = { "est" };
            Assert.Equal("Test: est", Program.GetTextSuggestions(words, validWords));
        }

        [Fact]
        public void GetSuggestion_OneInvalidWordOneLessLetter_ShouldReturnSuggestion()
        {
            string[] words = { "est" };
            string[] validWords = { "test" };
            Assert.Equal("est: test", Program.GetTextSuggestions(words, validWords));
        }

    }
}