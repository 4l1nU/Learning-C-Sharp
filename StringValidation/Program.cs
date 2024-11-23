namespace AutoCorrect
{
    public class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');
            string[] validWords = ReadValidWords();
            Console.WriteLine(GetTextSuggestions(words, validWords));
        }

        public static string GetTextSuggestions(string[] words, string[] validWords)
        {
            string suggestions = "";
            foreach (string word in words)
            {
                if (!IsValidWord(word, validWords))
                {
                    suggestions += word + ":" + GetWordSuggestions(word, validWords);
                }
            }


            return suggestions == "" ? "Text corect!" : suggestions;
        }

        private static string GetWordSuggestions(string word, string[] validWords)
        {
            string wordSuggestions = "";
            foreach (var validWord in validWords)
            {
                if (IsValidSuggestion(validWord.ToLower(), word.ToLower()))
                {
                    wordSuggestions += " " + validWord;
                }
            }

            return wordSuggestions == "" ? " (nu sunt sugestii)" : wordSuggestions;
        }

        private static bool IsValidSuggestion(string validWord, string word)
        {
            return
                HasOneWrongLetter(word, validWord) ||
                HasOneMoreLetter(word, validWord) ||
                HasOneLessLetter(word, validWord);
        }

        private static bool HasOneLessLetter(string word, string validWord)
        {
            return HasOneMoreLetter(validWord, word);
        }

        private static bool HasOneMoreLetter(string word, string validWord)
        {
            if (word.Length != validWord.Length + 1)
            {
                return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (word.Remove(i, 1) == validWord)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasOneWrongLetter(string word, string validWord)
        {
            if (word.Length != validWord.Length)
            {
                return false;
            }

            int countWrongLetters = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != validWord[i])
                {
                    if (++countWrongLetters > 1)
                    {
                        return false;
                    };
                }
            }

            return countWrongLetters == 1;
        }

        private static bool IsValidWord(string word, string[] validWords)
        {
            foreach (var validWord in validWords)
            {
                if (word.ToLower() == validWord.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private static string[] ReadValidWords()
        {
            int numberOfValidWords = Convert.ToInt32(Console.ReadLine());
            string[] validWords = new string[numberOfValidWords];
            for (int i = 0; i < numberOfValidWords; i++)
            {
                validWords[i] = Console.ReadLine();
            }

            return validWords;
        }
    }
}
