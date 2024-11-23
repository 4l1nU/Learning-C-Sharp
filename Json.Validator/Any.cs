using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(StringView text)
        {
            if (text.IsEmpty())
            {
                return new Match(text, false);
            }

            if (this.accepted.Contains(text.Peek()))
            {
                return new Match(text.Advance(), true);
            }

            return new Match(text, false);
        }
    }
}
