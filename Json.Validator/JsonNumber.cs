using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return IsNumber(input.ToLower());
        }

        private static bool IsNumber(string input)
        {
            int exponentIndex = input.IndexOf("e");
            int fractionIndex = input.IndexOf(".");
            return
                IsInteger(ExtractInteger(input, fractionIndex, exponentIndex)) &&
                IsFraction(ExtractFraction(input, fractionIndex, exponentIndex)) &&
                IsExponent(ExtractExponent(input, exponentIndex));
        }

        private static string ExtractInteger(string input, int fractionIndex, int exponentIndex)
        {
            if (fractionIndex != -1)
            {
                return input[..fractionIndex];
            }

            if (exponentIndex != -1)
            {
                return input[..exponentIndex];
            }

            return input;
        }

        private static string ExtractFraction(string input, int fractionIndex, int exponentIndex)
        {
            if (fractionIndex == -1)
            {
                return string.Empty;
            }

            if (exponentIndex != -1)
            {
                return input[fractionIndex..exponentIndex];
            }

            return input[fractionIndex..];
        }

        private static string ExtractExponent(string input, int exponentIndex)
        {
            if (exponentIndex == -1)
            {
                return string.Empty;
            }

            return input[exponentIndex..];
        }

        private static bool IsInteger(string input)
        {
            if (input.StartsWith('-'))
            {
                input = input[1..];
            }

            if (input.Length > 1 && input.StartsWith('0'))
            {
                return false;
            }

            return AreDigits(input);
        }

        private static bool IsExponent(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            input = input[1..];
            if (input.StartsWith('+') || input.StartsWith('-'))
            {
                input = input[1..];
            }

            return AreDigits(input);
        }

        private static bool IsFraction(string input)
        {
            return string.IsNullOrEmpty(input) || AreDigits(input[1..]);
        }

        private static bool AreDigits(string input)
        {
            foreach (char character in input)
            {
                if (!IsDigit(character))
                {
                    return false;
                }
            }

            return !string.IsNullOrEmpty(input);
        }

        private static bool IsDigit(char character)
        {
            return character >= '0' && character <= '9';
        }
    }
}
