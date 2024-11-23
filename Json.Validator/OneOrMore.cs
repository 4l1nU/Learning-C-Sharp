using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(
                pattern,
                new Many(pattern));
        }

        public IMatch Match(StringView text)
        {
            return pattern.Match(text);
        }
    }
}
