using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Char : IPattern
    {
        readonly char pattern;

        public Char(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(StringView text)
        {
            if (text.IsEmpty() || text.Peek() != this.pattern)
            {
                return new Match(text, false);
            }

            return new Match(text.Advance(), true);
        }
    }
}