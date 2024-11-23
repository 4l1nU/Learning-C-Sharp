using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Match : IMatch
    {
        readonly StringView remainingText;
        readonly bool matchFound;

        public Match(StringView remainingText, bool matchFound)
        {
            this.remainingText = remainingText;
            this.matchFound = matchFound;
        }

        public bool Success()
        {
            return this.matchFound;
        }

        public StringView RemainingText()
        {
            return this.remainingText;
        }
    }
}
