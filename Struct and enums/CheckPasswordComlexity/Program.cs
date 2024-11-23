using System;

namespace CheckPasswordComplexity
{
    enum AsciiValues
    {
        AsciiNumberForLowerA = 97,
        AsciiNumberForLowerZ = 122,
        AsciiNumberForUpperA = 65,
        AsciiNumberForUpperZ = 90,
        AsciiNumberForZero = 48,
        AsciiNumberForNine = 57,
        FirstAsciiNumberForFirstSimbolInterval = 33,
        LastAsciiNumberForFirstSimbolInterval = 47,
        FirstAsciiNumberForSecondSimbolInterval = 58,
        LastAsciiNumberForSecondSimbolInterval = 64,
        FirstAsciiNumberForThirdSimbolInterval = 91,
        LastAsciiNumberForThirdSimbolInterval = 96
    }

    public struct PasswordRequirements
    {
        public int MinimumLowerCases;
        public int MinimumUpperCases;
        public int MinimumDigits;
        public int MinimumSimbols;
        public bool SimilarCharacters;
        public bool AmbiguousCharacters;

        public PasswordRequirements(
            int minimumLowerCases,
            int minimumUpperCases,
            int minimumDigits,
            int minimumSimbols,
            bool similarCharacters,
            bool ambiguousCharacters)
        {
            this.MinimumLowerCases = minimumLowerCases;
            this.MinimumUpperCases = minimumUpperCases;
            this.MinimumDigits = minimumDigits;
            this.MinimumSimbols = minimumSimbols;
            this.SimilarCharacters = similarCharacters;
            this.AmbiguousCharacters = ambiguousCharacters;
        }
    }

    public class Program
    {
        public static bool CheckIfPasswordCorrect(string password, PasswordRequirements passwordRequirements)
        {
            if (!CheckMinimumChars(password, passwordRequirements))
            {
                return false;
            }

            if (!passwordRequirements.SimilarCharacters &&
                CheckSimilarCharacters(password))
            {
                return false;
            }

            if (!passwordRequirements.AmbiguousCharacters &&
                 CheckAmbiguousCharacters(password))
            {
                return false;
            }

            return true;
        }

        private static bool CheckMinimumChars(string password, PasswordRequirements passwordRequirements)
        {
            if (passwordRequirements.MinimumLowerCases > 0 &&
                !CheckMinimumLowerCases(password, passwordRequirements.MinimumLowerCases))
            {
                return false;
            }

            if (passwordRequirements.MinimumUpperCases > 0 &&
                !CheckMinimumUpperCases(password, passwordRequirements.MinimumUpperCases))
            {
                return false;
            }

            if (passwordRequirements.MinimumDigits > 0 &&
                !CheckMinimumDigits(password, passwordRequirements.MinimumDigits))
            {
                return false;
            }

            if (passwordRequirements.MinimumSimbols > 0 &&
                !CheckMinimumSimbols(password, passwordRequirements.MinimumSimbols))
            {
                return false;
            }

            return true;
        }

        private static bool CheckAmbiguousCharacters(string password)
        {
            char[] ambigousChars = { '{', '}', '[', ']', '(', ')', '/', '\\', '"', '~', ',', ';', '.', '<', '>' };
            return SearchCharsInString(password, ambigousChars);
        }

        private static bool CheckSimilarCharacters(string password)
        {
            char[] similarChars = { 'l', '1', 'I', 'o', '0', 'O' };
            return SearchCharsInString(password, similarChars);
        }

        private static bool SearchCharsInString(string password, char[] givenChars)
        {
            for (int character = 0; character < password.Length; character++)
            {
                foreach (char c in givenChars)
                {
                    if (password[character] == c)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CheckMinimumSimbols(string password, int minimumSimbols)
        {
            int simbolsFound = 0;
            for (int character = 0; character < password.Length && simbolsFound < minimumSimbols; character++)
            {
                if ((int)password[character] >= (int)AsciiValues.FirstAsciiNumberForFirstSimbolInterval &&
                    (int)password[character] <= (int)AsciiValues.LastAsciiNumberForFirstSimbolInterval)
                {
                    simbolsFound++;
                }

                if ((int)password[character] >= (int)AsciiValues.FirstAsciiNumberForSecondSimbolInterval &&
                    (int)password[character] <= (int)AsciiValues.LastAsciiNumberForSecondSimbolInterval)
                {
                    simbolsFound++;
                }

                if ((int)password[character] >= (int)AsciiValues.FirstAsciiNumberForThirdSimbolInterval &&
                    (int)password[character] <= (int)AsciiValues.LastAsciiNumberForThirdSimbolInterval)
                {
                    simbolsFound++;
                }
            }

            return simbolsFound == minimumSimbols;
        }

        private static bool CheckMinimumDigits(string password, int minimumDigits)
        {
            return CheckCharactersInAsciiTable(
                password,
                minimumDigits,
                AsciiValues.AsciiNumberForZero,
                AsciiValues.AsciiNumberForNine);
        }

        private static bool CheckMinimumLowerCases(string password, int minimumLowerCases)
        {
            return CheckCharactersInAsciiTable(
                password,
                minimumLowerCases,
                AsciiValues.AsciiNumberForLowerA,
                AsciiValues.AsciiNumberForLowerZ);
        }

        private static bool CheckCharactersInAsciiTable(
            string password,
            int minimumCharacters,
            AsciiValues firstCharacterNumberInAscii,
            AsciiValues secondCharacterNumberInAscii)
        {
            int charactersFoundInPassword = 0;
            for (int character = 0; character < password.Length && charactersFoundInPassword < minimumCharacters; character++)
            {
                if ((int)password[character] >= (int)firstCharacterNumberInAscii &&
                    (int)password[character] <= (int)secondCharacterNumberInAscii)
                {
                    charactersFoundInPassword++;
                }
            }

            return charactersFoundInPassword == minimumCharacters;
        }

        private static bool CheckMinimumUpperCases(string password, int minimumUpperCases)
        {
            return CheckCharactersInAsciiTable(password, minimumUpperCases, AsciiValues.AsciiNumberForUpperA, AsciiValues.AsciiNumberForUpperZ);
        }

        static void Main()
        {
            string password = Console.ReadLine();
            PasswordRequirements passwordRequirements = new PasswordRequirements(
                ReadNumber(), ReadNumber(), ReadNumber(), ReadNumber(), ReadBoolean(), ReadBoolean());
            Console.WriteLine(CheckIfPasswordCorrect(password, passwordRequirements));
        }

        private static bool ReadBoolean()
        {
            return Convert.ToBoolean(Console.ReadLine());
        }

        private static int ReadNumber()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
