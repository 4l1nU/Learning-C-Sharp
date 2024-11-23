namespace Collections.Facts
{
    public class IntArrayFacts
    {
        [Fact]
        public void CanAddFirstElementAndReturnElementByIndex()
        {
            var array = new IntArray();
            array.Add(9);
            Assert.Equal(9, array[0]);
        }

        [Fact]
        public void CanAddManyElements()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);
            Assert.Equal(9, array[8]);
        }

        [Fact]
        public void CanReturnNumberOfElementsInArray()
        {
            var array = new IntArray();
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
        public void CanModifyElementByIndex()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);
            array[5] = 20;
            Assert.Equal(20, array[5]);
        }

        [Fact]
        public void VerifiesIfElementExists()
        {
            var array = new IntArray();
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
            var array = new IntArray();
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
            var array = new IntArray();
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
        [InlineData(2, 9)]

        public void InsertsElement(int index, int element)
        {
            var array = new IntArray();
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
            var array = new IntArray();
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
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Remove(5);
            Assert.Equal(4, array.Count);
            Assert.False(array.Contains(5));
        }

        [Fact]
        public void RemovesElementByIndex()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.RemoveAt(4);
            Assert.Equal(4, array.Count);
            Assert.False(array.Contains(5));
        }
    }
}