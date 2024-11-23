using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
namespace Collections.Facts
{
    public class ListFacts
    {
        [Fact]
        public void CanAddDifferentDataTypeElements()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            Assert.Equal(1, array[0]);
            Assert.Equal("abc", array[1]);
            Assert.Equal(0.1244, array[2]);
            Assert.Equal(18446744073709551615, array[3]);
            Assert.Equal('c', array[4]);
            Assert.Equal(true, array[5]);
        }

        [Fact]
        public void CanReturnNumberOfElementsInArray()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            Assert.Equal(6, array.Count);
        }

        [Fact]
        public void CanModifyElementByIndex()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            array[2] = false;
            Assert.Equal(false, array[2]);
        }

        [Fact]
        public void VerifiesIfElementExists()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            Assert.True(array.Contains("abc"));
        }

        [Fact]
        public void VerifiesIfElementDoesNotExist()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            Assert.False(array.Contains('b'));
        }

        [Fact]
        public void ReturnsIndexOfElement()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            Assert.Equal(4, array.IndexOf('c'));
            Assert.Equal(3, array.IndexOf(18446744073709551615));
            Assert.Equal(1, array.IndexOf("abc"));
        }

        [Theory]
        [InlineData(4, 'a')]
        [InlineData(2, false)]

        public void InsertsElement(int index, object element)
        {
            var array = new List<object>();
            array.Add('c');
            array.Add("abc");
            array.Add(0.1244);
            array.Add(true);
            array.Insert(index, element);
            Assert.Equal(element, array[index]);
        }

        [Fact]
        public void ClearsArray()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            array.Clear();
            Assert.Equal(0, array.Count);
            Assert.Throws<ArgumentOutOfRangeException>(() => array[0]);
            Assert.Throws<ArgumentOutOfRangeException>(() => array[5]);
        }

        [Fact]
        public void RemovesElement()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            array.Remove(0.1244);
            Assert.Equal(5, array.Count);
            Assert.False(array.Contains(0.1244));
        }

        [Fact]
        public void RemovesElementByIndex()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            array.RemoveAt(1);
            Assert.Equal(5, array.Count);
            Assert.False(array.Contains("abc"));
        }

        [Fact]
        public void CanLoopWithForeachFullArray()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            IEnumerator enumerator = array.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal("abc", enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(0.1244, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(18446744073709551615, enumerator.Current);
            bool elementsLeft = enumerator.MoveNext();
            Assert.False(elementsLeft);
        }

        [Fact]
        public void CanLoopWithForeachPartiallyFullArray()
        {
            var array = new List<object>();
            array.Add(1);
            array.Add("abc");
            array.Add(0.1244);
            array.Add(18446744073709551615);
            array.Add('c');
            array.Add(true);
            IEnumerator enumerator = array.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal("abc", enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(0.1244, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(18446744073709551615, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal('c', enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(true, enumerator.Current);
            bool elementsLeft = enumerator.MoveNext();
            Assert.False(elementsLeft);
        }

        [Fact]
        public void CanUseSimplifiedInitialization()
        {
            var array = new List<object>
             {
                 1,
                 "abc",
                 0.1244,
                 18446744073709551615,
                 'c',
                 true
             };
            Assert.Equal(1, array[0]);
            Assert.Equal("abc", array[1]);
            Assert.Equal(0.1244, array[2]);
            Assert.Equal(18446744073709551615, array[3]);
            Assert.Equal('c', array[4]);
            Assert.Equal(true, array[5]);
        }

        [Fact]
        public void CanDoHaveMultipleLoops()
        {
            var array = new List<object>
            {
                1,
                "abc",
                0.1244,
                18446744073709551615,
                'c',
                true
            };
            IEnumerator firstEnumerator = array.GetEnumerator();
            firstEnumerator.MoveNext();
            Assert.Equal(1, firstEnumerator.Current);
            IEnumerator secondEnumerator = array.GetEnumerator();
            secondEnumerator.MoveNext();
            Assert.Equal(1, secondEnumerator.Current);
            firstEnumerator.MoveNext();
            firstEnumerator.MoveNext();
            firstEnumerator.MoveNext();
            Assert.Equal(18446744073709551615, firstEnumerator.Current);
            secondEnumerator.MoveNext();
            Assert.Equal("abc", secondEnumerator.Current);
            firstEnumerator.MoveNext();
            firstEnumerator.MoveNext();
            bool elementsLeft = firstEnumerator.MoveNext();
            Assert.False(elementsLeft);
            secondEnumerator.MoveNext();
            secondEnumerator.MoveNext();
            secondEnumerator.MoveNext();
            secondEnumerator.MoveNext();
            elementsLeft = secondEnumerator.MoveNext();
            Assert.False(elementsLeft);
        }

        [Fact]
        public void ListIsNotReadOnly()
        {
            var array = new List<object>();
            Assert.False(array.IsReadOnly);
        }

        [Fact]
        public void CanCopyToAnotherArray()
        {
            var originalArray = new List<object>
            {
                1,
                "abc",
            };
            var anotherArray = new object[3];
            originalArray.CopyTo(anotherArray, 1);
            Assert.Null(anotherArray[0]);
            Assert.Equal(1, anotherArray[1]);
            Assert.Equal("abc", anotherArray[2]);
        }

        [Fact]
        public void DoesNotReturnIndexOfElementOutOfCountScope()
        {
            var array = new List<object>
            {
                1,
                "abc",
            };
            Assert.Equal(-1, array.IndexOf(default));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenCopyToNullArray()
        {
            var originalArray = new List<object>
            {
                1,
                "abc",
            };
            object[] anotherArray = null;
            Assert.Throws<ArgumentNullException>(() => originalArray.CopyTo(anotherArray, 1));
        }

        [Fact]
        public void ThrowsArgumentOutOfRangeWhenCopyToHasNegativeIndex()
        {
            var originalArray = new List<object>
            {
                1,
                "abc",
            };
            object[] anotherArray = Array.Empty<object>();
            Assert.Throws<ArgumentOutOfRangeException>(() => originalArray.CopyTo(anotherArray, -1));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        public void ThrowsArgumentExceptionWhenCopyToSmallArray(int index, int length)
        {
            var originalArray = new List<object>
            {
                1,
                "abc",
            };
            object[] anotherArray = new object[length];
            Assert.Throws<ArgumentException>(() => originalArray.CopyTo(anotherArray, index));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(-1)]
        public void ThrowsArgumentOutOfRangeWhenIndexOfInsertIsNotValid(int index)
        {
            var array = new List<object> { 1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Insert(index, "abc"));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(-1)]
        [InlineData(1)]
        public void ThrowsArgumentOutOfRangeWhenIndexOfRemoveAtIsNotValid(int index)
        {
            var array = new List<object> { 1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => array.RemoveAt(index));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(-1)]
        public void ThrowsArgumentOutOfRangeWhenGetHasInvalidIndex(int index)
        {
            var array = new List<object>
            {
                1,
                "abc"
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => array[index]);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(-1)]
        public void ThrowsArgumentOutOfRangeWhenSetHasInvalidIndex(int index)
        {
            var array = new List<object>
            {
                1,
                "abc",
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => array[index] = true);
        }

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
        public void CanMakeReadOnlyListAndStillModifyInitialList()
        {
            var array = new List<object>
            {
                1,
                "abc"
            };
            var readOnlyArray = array.AsReadOnly();
            array.Clear();
            Assert.Equal(0, array.Count);
        }
    }
}
