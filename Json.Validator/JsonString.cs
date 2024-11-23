namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input) && HasValidCharacters(input);
        }

        private static bool HasValidCharacters(string input)
        {
            const char Backslash = '\\';
            bool prevBackslash = false;
            for (int inputIndex = 1; inputIndex < input.Length - 1; inputIndex++)
            {
                if (ContainsControlCharacters(input[inputIndex]))
                {
                    return false;
                }

                if (prevBackslash)
                {
                    prevBackslash = false;
                    continue;
                }

                prevBackslash = input[inputIndex] == Backslash;
                if (prevBackslash && (inputIndex + 1 == input.Length - 1 || !IsValidEscapeCharacter(input, input[inputIndex + 1], inputIndex + 1)))
                {
                    return false;
                }

                if (input[inputIndex] == '"')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidUnicode(string input, int inputIndex)
        {
            const int UnicodeLength = 4;
            int indexAfterUnicode = inputIndex + UnicodeLength + 1;
            if (indexAfterUnicode > input.Length - 1)
            {
                return false;
            }

            input = input.ToLower();
            for (int indexOfUnicode = inputIndex + 1; indexOfUnicode <= inputIndex + UnicodeLength; indexOfUnicode++)
            {
                if (IsHexDigit(input[indexOfUnicode]))
                {
                    continue;
                }

                return false;
            }

            return true;
        }

        private static bool IsHexDigit(char character)
        {
            return character >= 'a' && character <= 'f' || character >= '0' && character <= '9';
        }

        private static bool IsValidEscapeCharacter(string input, char character, int inputIndex)
        {
            const string escapeChars = """/"\\bfnrtu""";
            if (character == 'u')
            {
                return IsValidUnicode(input, inputIndex);
            }

            for (int indexEscapeChars = 0; indexEscapeChars < escapeChars.Length; indexEscapeChars++)
            {
                if (character == escapeChars[indexEscapeChars])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsControlCharacters(char character)
        {
            const char LowerControlCharacter = ' ';
            return character < LowerControlCharacter;
        }

        private static bool IsDoubleQuoted(string input)
        {
            return input.Length > 1 &&
                input[0] == '"' &&
                input[input.Length - 1] == '"';
        }

        private static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
