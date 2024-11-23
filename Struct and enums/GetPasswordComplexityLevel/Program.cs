using System;

namespace PasswordComplexityLevel
{
    enum PasswordComplexityLevel
    {
        High,
        Medium,
        Low
    }

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

    public struct PasswordComplexity
    {
        public int MinLowercaseChars;
        public int MinUpercaseChars;
        public int MinDigits;
        public int MinSymbols;
        public bool CanContainSimilarChars;
        public bool CanContainAmbiguousChars;
    }

    class Program
    {
        public static PasswordComplexity GetHighPasswordComplexity()
        {
            const int HighComplexityMinLowercaseChars = 5;
            const int HighComplexityMinUppercaseChars = 2;
            const int HighComplexityMinDigits = 2;
            const int HighComplexityMinSymbols = 2;

            return new PasswordComplexity
            {
                MinLowercaseChars = HighComplexityMinLowercaseChars,
                MinUpercaseChars = HighComplexityMinUppercaseChars,
                MinDigits = HighComplexityMinDigits,
                MinSymbols = HighComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }

        static void Main()
        {
            string password = Console.ReadLine();
            Console.WriteLine(GetPasswordComplexityLevel(password));
            Console.Read();
        }

        static PasswordComplexityLevel GetPasswordComplexityLevel(string password)
        {
            PasswordComplexity passwordComplexity = GetPasswordComplexity(password);
            if (CheckForComplexityLevel(passwordComplexity, GetHighPasswordComplexity()))
            {
                return PasswordComplexityLevel.High;
            }

            if (CheckForComplexityLevel(passwordComplexity, GetMediumPasswordComplexity()))
            {
                return PasswordComplexityLevel.Medium;
            }

            return PasswordComplexityLevel.Low;
        }

        private static bool CheckForComplexityLevel(PasswordComplexity passwordComplexity, PasswordComplexity neededPasswordComplexity)
        {
            if (passwordComplexity.MinLowercaseChars < neededPasswordComplexity.MinLowercaseChars)
            {
                return false;
            }

            if (passwordComplexity.MinUpercaseChars < neededPasswordComplexity.MinUpercaseChars)
            {
                return false;
            }

            if (passwordComplexity.MinDigits < neededPasswordComplexity.MinDigits)
            {
                return false;
            }

            if (passwordComplexity.MinSymbols < neededPasswordComplexity.MinSymbols)
            {
                return false;
            }

            if (!passwordComplexity.CanContainSimilarChars && neededPasswordComplexity.CanContainSimilarChars)
            {
                return false;
            }

            if (!passwordComplexity.CanContainAmbiguousChars && neededPasswordComplexity.CanContainAmbiguousChars)
            {
                return false;
            }

            return true;
        }

        private static PasswordComplexity GetPasswordComplexity(string password)
        {
            return new PasswordComplexity
            {
                MinLowercaseChars = GetNumberOfLowerCases(password),
                MinUpercaseChars = GetNumberOfUpperCases(password),
                MinDigits = GetNumberOfDigits(password),
                MinSymbols = GetNumberOfSimbols(password),
                CanContainSimilarChars = CheckSimilarCharacters(password),
                CanContainAmbiguousChars = CheckAmbiguousCharacters(password)
            };
        }

        private static bool CheckAmbiguousCharacters(string password)
        {
            char[] ambigousChars = { '{', '}', '[', ']', '(', ')', '/', '\\', '"', '~', ',', ';', '.', '<', '>', '+', '-' };
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

        private static int GetNumberOfSimbols(string password)
        {
            int simbolsFound = 0;
            for (int character = 0; character < password.Length; character++)
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

            return simbolsFound;
        }

        private static int GetNumberOfDigits(string password)
        {
            return CheckCharactersInAsciiTable(
                password,
                AsciiValues.AsciiNumberForZero,
                AsciiValues.AsciiNumberForNine);
        }

        private static int GetNumberOfUpperCases(string password)
        {
            return CheckCharactersInAsciiTable(password, AsciiValues.AsciiNumberForUpperA, AsciiValues.AsciiNumberForUpperZ);
        }

        private static int GetNumberOfLowerCases(string password)
        {
            return CheckCharactersInAsciiTable(
                password,
                AsciiValues.AsciiNumberForLowerA,
                AsciiValues.AsciiNumberForLowerZ);
        }

        private static int CheckCharactersInAsciiTable(
            string password,
            AsciiValues firstCharacterNumberInAscii,
            AsciiValues secondCharacterNumberInAscii)
        {
            int charactersFoundInPassword = 0;
            for (int character = 0; character < password.Length; character++)
            {
                if ((int)password[character] >= (int)firstCharacterNumberInAscii &&
                    (int)password[character] <= (int)secondCharacterNumberInAscii)
                {
                    charactersFoundInPassword++;
                }
            }

            return charactersFoundInPassword;
        }

        static PasswordComplexity GetMediumPasswordComplexity()
        {
            const int MediumComplexityMinLowercaseChars = 3;
            const int MediumComplexityMinUpercaseChars = 1;
            const int MediumComplexityMinDigits = 1;
            const int MediumComplexityMinSymbols = 1;

            return new PasswordComplexity
            {
                MinLowercaseChars = MediumComplexityMinLowercaseChars,
                MinUpercaseChars = MediumComplexityMinUpercaseChars,
                MinDigits = MediumComplexityMinDigits,
                MinSymbols = MediumComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }
    }
}
