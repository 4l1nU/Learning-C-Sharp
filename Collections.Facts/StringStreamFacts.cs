using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class StringStreamFacts
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void CanWriteAndReadStreamString(bool compressed, bool encrypted)
        {
            var stream = new MemoryStream();
            StringStream.StringStreamWriter(stream, "abc", compressed, encrypted);
            Assert.Equal("abc", StringStream.StringStreamReader(stream, compressed, encrypted));
        }
    }
}
