using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class String : IPattern
    {
        const string EscapeChars = """/"\\bfnrt""";
        private readonly IPattern pattern;

        public String()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexNumber = new Sequence(new Char('u'), hex, hex, hex, hex);
            var escapedChars = new Sequence(
                new Char('\\'), new Choice(new Any(EscapeChars), hexNumber));
            var character = new Choice(
                new Range(' ', '!'), new Range('#', '['), new Range(']', char.MaxValue), escapedChars);
            var characters = new Many(character);
            this.pattern = new Sequence(new Char('"'), characters, new Char('"'));
        }

        public IMatch Match(StringView text)
        {
            return this.pattern.Match(text);
        }
    }
}
