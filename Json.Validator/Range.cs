namespace Json
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(StringView text)
        {
            if (text.IsEmpty() || !(text.Peek() >= this.start && text.Peek() <= this.end))
            {
                return new Match(text, false);
            }

            return new Match(text.Advance(), true);
        }
    }
}
