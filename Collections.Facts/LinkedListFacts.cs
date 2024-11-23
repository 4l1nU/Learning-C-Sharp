using System;

namespace Collections.Facts
{
    public class LinkedListFacts
    {
        [Fact]
        public void CanAddToLinkedList()
        {
            var linkedList = new LinkedList<string> { "a" };
            Assert.Equal(new string[] { "a" }, linkedList);
        }

        [Fact]
        public void CanAddMultipleItemsToLinkedList()
        {
            var linkedList = new LinkedList<string> { "a" , "b", "c"};
            Assert.Equal(new string[] { "a", "b", "c" }, linkedList);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void CanAddItemFirstIntoLinkedList()
        {
            var linkedList = new LinkedList<string>() { "a" };
            linkedList.AddFirst("c");
            Assert.Equal(new string[] { "c", "a" }, linkedList);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void CanAddNodeFirstIntoLinkedList()
        {
            var linkedList = new LinkedList<string>() { "a" };
            linkedList.AddFirst(new Node<string>("c"));
            Assert.Equal(new string[] { "c", "a" }, linkedList);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void CanAddItemLastIntoLinkedList()
        {
            var linkedList = new LinkedList<string>() { "a" };
            linkedList.AddLast("c");
            Assert.Equal(new string[] { "a", "c" }, linkedList);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void CanAddNodeLastIntoLinkedList()
        {
            var linkedList = new LinkedList<string>() { "a" };
            linkedList.AddLast(new Node<string>("c"));
            Assert.Equal(new string[] { "a", "c" }, linkedList);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void CanAddItemAfterGivenNode()
        {
            var linkedList = new LinkedList<string>() { "a", "b"};
            linkedList.AddAfter(linkedList.First, "c");
            Assert.Equal(new string[] { "a", "c", "b" }, linkedList);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void CanAddNodeAfterGivenNode()
        {
            var linkedList = new LinkedList<string>() { "a", "b" };
            linkedList.AddAfter(linkedList.First, new Node<string>("c"));
            Assert.Equal(new string[] { "a", "c", "b" }, linkedList);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void CanAddItemBeforeGivenNode()
        {
            var linkedList = new LinkedList<string>() { "a", "b" };
            linkedList.AddBefore(linkedList.Last, "c");
            Assert.Equal(new string[] { "a", "c", "b" }, linkedList);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void CanAddNodeBeforeGivenNode()
        {
            var linkedList = new LinkedList<string>() { "a", "b" };
            linkedList.AddBefore(linkedList.Last, new Node<string>("c"));
            Assert.Equal(new string[] { "a", "c", "b" }, linkedList);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void CanAddItemBeforeFirstNode()
        {
            var linkedList = new LinkedList<string>() { "a", "b" };
            linkedList.AddBefore(linkedList.First, "c");
            Assert.Equal(new string[] { "c", "a", "b" }, linkedList);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void CanClearLinkedList()
        {
            var linkedList = new LinkedList<string>() { "a", "b" };
            linkedList.Clear();
            Assert.Null(linkedList.First);
            Assert.Null(linkedList.Last);
            Assert.Equal(0, linkedList.Count);
        }

        [Fact]
        public void VerifiesIfElementExistsInLinkedList()
        {
            var linkedList = new LinkedList<object>() { "a"};
            Assert.True(linkedList.Contains("a"));
            Assert.False(linkedList.Contains(2));
        }

        [Fact]
        public void CanCopyLinkedListToArray()
        {
            var linkedList = new LinkedList<object>() { "a", 2, true };
            object[] copiedArray = new object[4];
            linkedList.CopyTo(copiedArray, 1);
            Assert.Equal(new object[] { null, "a", 2, true }, copiedArray);
        }

        [Fact]
        public void CanLoopWithForeachThroughLinkedList()
        {
            var linkedList = new LinkedList<object>() { "a", 2};
            IEnumerator<object> enumerator = linkedList.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal("a", enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(2, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void CanNotLoopWithForeachThroughEmptyLinkedList()
        {
            var linkedList = new LinkedList<object>();
            IEnumerator<object> enumerator = linkedList.GetEnumerator();
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void CanFindNode()
        {
            var linkedList = new LinkedList<object>() { "a", 2, "a" };
            Assert.Equal(linkedList.First, linkedList.Find("a"));
            Assert.Null(linkedList.Find(1));
        }

        [Fact]
        public void CanFindLastNode()
        {
            var linkedList = new LinkedList<object>() { "a", 2, "a" };
            Assert.Equal(linkedList.Last, linkedList.FindLast("a"));
            Assert.Null(linkedList.FindLast(1));
        }

        [Fact]
        public void CanRemoveItem()
        {
            var linkedList = new LinkedList<object>() { "a", 2 };
            Assert.True(linkedList.Remove("a"));
            Assert.Equal(new object[] { 2 }, linkedList);
        }

        [Fact]
        public void CanNotRemoveNonExistentItem()
        {
            var linkedList = new LinkedList<object>() { "a", 2 };
            Assert.False(linkedList.Remove("b"));
            Assert.Equal(new object[] { "a", 2 }, linkedList);
        }

        [Fact]
        public void CanRemoveNode()
        {
            var linkedList = new LinkedList<object>() { "a", 2 };
            linkedList.Remove(linkedList.First);
            Assert.Equal(new object[] { 2 }, linkedList);
        }

        [Fact]
        public void CanRemoveFirstNode()
        {
            var linkedList = new LinkedList<object>() { "a", 2 };
            linkedList.RemoveFirst();
            Assert.Equal(new object[] { 2 }, linkedList);
        }

        [Fact]
        public void CanRemoveLastNode()
        {
            var linkedList = new LinkedList<object>() { "a", 2 };
            linkedList.RemoveLast();
            Assert.Equal(new object[] { "a" }, linkedList);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenAddFirstNullNode()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<ArgumentNullException>(() => linkedList.AddFirst(null));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenAddFirstNodeThatBelongsToAnotherList()
        {
            var linkedList = new LinkedList<object>();
            var anotherList = new LinkedList<object>() { 0 };
            Assert.Throws<InvalidOperationException>(() => linkedList.AddFirst(anotherList.First));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenAddLastNullNode()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<ArgumentNullException>(() => linkedList.AddLast(null));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenAddLastNodeThatBelongsToAnotherList()
        {
            var linkedList = new LinkedList<object>();
            var anotherList = new LinkedList<object>() { 0 };
            Assert.Throws<InvalidOperationException>(() => linkedList.AddLast(anotherList.First));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenAddItemAfterNullNode()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<ArgumentNullException>(() => linkedList.AddAfter(null, 1));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenAddNullNodeAfterNode()
        {
            var linkedList = new LinkedList<object>() { 0 };
            Assert.Throws<ArgumentNullException>(() => linkedList.AddAfter(linkedList.First, null));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenAddItemAfterNodeThatIsNotInTheList()
        {
            var linkedList = new LinkedList<object>();
            var anotherList = new LinkedList<object> { 0 };
            Assert.Throws<InvalidOperationException>(() => linkedList.AddAfter(anotherList.First, 2));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenAddAfterNodeThatBelongsToAnotherList()
        {
            var linkedList = new LinkedList<object>() { 0 };
            var anotherList = new LinkedList<object>() { 0 };
            Assert.Throws<InvalidOperationException>(() => linkedList.AddAfter(linkedList.First, anotherList.First));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenAddBeforeNullNode()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<ArgumentNullException>(() => linkedList.AddBefore(null, 1));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenAddNullNodeBeforeNode()
        {
            var linkedList = new LinkedList<object>() { 0 };
            Assert.Throws<ArgumentNullException>(() => linkedList.AddBefore(linkedList.First, null));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenAddBeforeNodeThatIsNotInTheList()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<InvalidOperationException>(() => linkedList.AddBefore(new Node<object>(1), 2));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenAddBeforerNodeThatBelongsToAnotherList()
        {
            var linkedList = new LinkedList<object>() { 0 };
            var anotherList = new LinkedList<object>() { 0 };
            Assert.Throws<InvalidOperationException>(() => linkedList.AddBefore(linkedList.First, anotherList.First));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenCopyToNullArray()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<ArgumentNullException>(() => linkedList.CopyTo(null, 0));
        }

        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenGivenIndexIsLessThanZero()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.CopyTo(new object[0], -1));
        }

        [Fact]
        public void ThrowsArgumentExceptionWhenIsntEnoughSpaceAvailableInArray()
        {
            var linkedList = new LinkedList<object> { "a" };
            Assert.Throws<ArgumentException>(() => linkedList.CopyTo(new object[10], 10));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenRemoveNullNode()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<ArgumentNullException>(() => linkedList.Remove(null));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenRemoveNodeThatIsNotInTheList()
        {
            var linkedList = new LinkedList<object>() { 1 };
            Assert.Throws<InvalidOperationException>(() => linkedList.Remove(new Node<object>(1)));
        }

        [Fact]
        public void ThrowsInvalidOperationExceptionWhenRemovingFirstOrLastElementFromEmptyList()
        {
            var linkedList = new LinkedList<object>();
            Assert.Throws<InvalidOperationException>(() => linkedList.RemoveFirst());
            Assert.Throws<InvalidOperationException>(() => linkedList.RemoveLast());
        }
    }
}
