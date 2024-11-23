using System;


namespace Collections.Facts
{
    public class SortedListFacts
    {
        [Fact]

        public void CanSetSortedElement()
        {
            var sortedArray = new SortedList<int>();
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray[1] = 4;
            Assert.Equal(2, sortedArray[0]);
            Assert.Equal(4, sortedArray[1]);
        }

        [Fact]

        public void CanNotSetUnsortedElement()
        {
            var sortedArray = new SortedList<int>();
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray[1] = 1;
            Assert.Equal(2, sortedArray[0]);
            Assert.Equal(3, sortedArray[1]);
        }

        [Fact]
        public void CanReturnNumberOfElementsInArray()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);
            Assert.Equal(8, array.Count);
        }

        [Fact]
        public void VerifiesIfElementExists()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);
            Assert.True(array.Contains(7));
        }

        [Fact]
        public void VerifiesThatElementDoesNotExist()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);
            Assert.False(array.Contains(0));
        }

        [Fact]
        public void ReturnsIndexOfElement()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);
            Assert.Equal(6, array.IndexOf(7));
            Assert.Equal(-1, array.IndexOf(0));
            Assert.Equal(8, array.IndexOf(9));
        }

        [Theory]
        [InlineData(4, 9)]
        [InlineData(2, 3)]

        public void InsertsElement(int index, int element)
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Insert(index, element);
            Assert.Equal(element, array[index]);
        }


        [Fact]
        public void ClearsArray()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Clear();
            Assert.Equal(0, array.Count);
            Assert.Equal(0, array[0]);
            Assert.Equal(0, array[3]);
        }

        [Fact]
        public void RemovesElement()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Remove(2);
            Assert.Equal(4, array.Count);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(4, array[2]);
            Assert.Equal(5, array[3]);
            Assert.False(array.Contains(2));
        }

        [Fact]
        public void RemovesElementByIndex()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.RemoveAt(3);
            Assert.Equal(4, array.Count);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(5, array[3]);
            Assert.False(array.Contains(4));
        }

        [Fact]
        public void CanNotSetElementWithValueSmallerThanNextAndPrevValue()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array[2] = 1;
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(4, array[3]);
            Assert.Equal(5, array[4]);
        }

        [Fact]
        public void CanSetLastElement()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array[3] = 5;
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(5, array[3]);
        }

        [Fact]
        public void CanNotSetUnaddedElement()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array[7] = 7;
            Assert.Equal(0, array[7]);
        }

        [Fact]
        public void AddsElementsInTheRightPosition()
        {
            var array = new SortedList<int>();
            array.Add(5);
            array.Add(3);
            array.Add(2);
            array.Add(4);
            Assert.Equal(2, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(4, array[2]);
            Assert.Equal(5, array[3]);
        }
    }
}
