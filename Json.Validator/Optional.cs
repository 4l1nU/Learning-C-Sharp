using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Optional : IPattern
    {
        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(StringView text)
        {
            IMatch match = this.pattern.Match(text);
            return new Match(match.RemainingText(), true);
        }
    }
}
