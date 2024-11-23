using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(StringView text)
        {
            if (text.IsEmpty() || !text.StartsWith(this.prefix))
            {
                return new Match(text, false);
            }

            return new Match(text.Advance(this.prefix.Length), true);
        }
    }
}
