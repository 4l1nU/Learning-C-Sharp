using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Json
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var ws = new Many(new Any(" \n\r\t"));
            var value = new Choice(
                new String(),
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null"));
            var element = new Sequence(ws, value, ws);
            var elements = new List(element, new Char(','));
            var array = new Sequence(
                new Char('['),
                elements,
                ws,
                new Char(']'));
            value.Add(array);
            var member = new Sequence(ws, new String(), ws, new Char(':'), element);
            var members = new List(member, new Char(','));
            var objectt = new Sequence(
                new Char('{'),
                members,
                ws,
                new Char('}'));
            value.Add(objectt);
            this.pattern = element;
        }

        public IMatch Match(StringView text)
        {
            return pattern.Match(text);
        }
    }
}
