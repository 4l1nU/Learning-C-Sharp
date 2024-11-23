using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(StringView text)
        {
            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(text);
                if (match.Success())
                {
                    return match;
                }
            }

            return new Match(text, false);
        }

        public void Add(IPattern newPattern)
        {
            Array.Resize(ref this.patterns, patterns.Length + 1);
            this.patterns[patterns.Length - 1] = newPattern;
        }
    }
}
