using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(StringView text)
        {
            IMatch match = this.pattern.Match(text);
            while (match.Success())
            {
                match = this.pattern.Match(match.RemainingText());
            }

            return new Match(match.RemainingText(), true);
        }
    }
}
