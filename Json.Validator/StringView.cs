using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class StringView
    {
        readonly string text;
        readonly int index;

        public StringView(int index, string text)
        {
            this.index = index;
            this.text = text;
        }

        public char Peek()
        {
            return this.text[this.index];
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.text) || this.index >= this.text.Length;
        }

        public StringView Advance(int count = 1)
        {
            return new StringView(this.index + count, this.text);
        }

        public bool StartsWith(string prefix)
        {
            return prefix.Length <= this.text.Length - this.index && this.text.IndexOf(prefix, this.index, prefix.Length) == this.index;
        }
    }
}
