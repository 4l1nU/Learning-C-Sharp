using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var integer = new Sequence(
                new Optional(new Char('-')),
                new Choice(new Char('0'), digits));
            var fraction = new Sequence(new Char('.'), digits);
            var exponent = new Sequence(new Any("eE"), new Optional(new Any("+-")), digits);
            this.pattern = new Sequence(integer, new Optional(fraction), new Optional(exponent));
        }

        public IMatch Match(StringView text)
        {
            return this.pattern.Match(text);
        }
    }
}
