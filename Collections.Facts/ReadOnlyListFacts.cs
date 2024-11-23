using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Facts
{
    public class ReadOnlyListFacts
    {
        [Fact]
        public void CanNotModifyReadOnlyList()
        {
            var array = new List<object>
            {
                1,
                "abc"
            };
            var readOnlyArray = array.AsReadOnly();
            Assert.Throws<NotSupportedException>(() => readOnlyArray[0] = 0);
            Assert.Throws<NotSupportedException>(() => readOnlyArray.Add(2));
            Assert.Throws<NotSupportedException>(() => readOnlyArray.Clear());
            Assert.Throws<NotSupportedException>(() => readOnlyArray.Insert(0, 2));
            Assert.Throws<NotSupportedException>(() => readOnlyArray.Remove("abc"));
            Assert.Throws<NotSupportedException>(() => readOnlyArray.RemoveAt(0));
        }

        [Fact]
        public void CanUseReadingMethods()
        {
            var array = new List<object>
            {
                1,
                "abc"
            };
            var readOnlyArray = array.AsReadOnly();
            Assert.Equal(1, readOnlyArray[0]);
            Assert.Equal(2, readOnlyArray.Count);
            Assert.True(readOnlyArray.IsReadOnly);
            Assert.True(readOnlyArray.Contains("abc"));
            Assert.Equal(1, readOnlyArray.IndexOf("abc"));
            var forCopyArray = new object[2];
            readOnlyArray.CopyTo(forCopyArray, 0);
            Assert.Equal(1, forCopyArray[0]);
            Assert.Equal("abc", forCopyArray[1]);
            IEnumerator<object> enumerator = readOnlyArray.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal("abc", enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }
    }
}
