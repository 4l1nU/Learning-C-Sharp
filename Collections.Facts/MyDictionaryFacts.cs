namespace Collections.Facts
{
    public class MyDictionaryFacts
    {
        [Fact]

        public void CanAddItems()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 2, "b" },
                { 3, "c" }
            };
            Assert.Equal("a", dictionary[1]);
            Assert.Equal("b", dictionary[2]);
            Assert.Equal("c", dictionary[3]);
        }

        [Fact]

        public void CanAddItemsOnSameBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 11, "b" }
            };
            Assert.Equal("a", dictionary[1]);
            Assert.Equal("b", dictionary[11]);
        }

        [Fact]

        public void CanSetValueWithKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10) { { 1, "a" } };
            dictionary[1] = "b";
            Assert.Equal("b", dictionary[1]);
        }

        [Fact]

        public void CanSetValueWithKeyHavingMultipleElementsOnBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 11, "b" }
            };
            dictionary[1] = "c";
            Assert.Equal("c", dictionary[1]);
        }

        [Fact]

        public void CanAddNewElementWhenTryToSetNotExistentKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10);
            dictionary[1] = "b";
            Assert.Contains(new KeyValuePair<int, object>(1, "b"), dictionary);
        }

        [Fact]

        public void CanAddItemWithKeyValuePair()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.Equal("a", dictionary[1]);
        }

        [Fact]

        public void CanClearDictionary()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            dictionary.Clear();
            Assert.Equal(new int[0], dictionary.Keys);
        }

        [Fact]

        public void CanAddAdfterClearingDictionary()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            dictionary.Clear();
            dictionary.Add(2, "b");
            Assert.Equal("b", dictionary[2]);
        }

        [Fact]

        public void ContainsKeyReturnsTrueWithExistentKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.True(dictionary.ContainsKey(1));
        }

        [Fact]

        public void ContainsKeyReturnsFalseWithNonExistentKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.False(dictionary.ContainsKey(2));
        }

        [Fact]

        public void ContainsValueReturnsTrueWithExistentValue()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.True(dictionary.ContainsValue("a"));
        }

        [Fact]

        public void ContainsValueReturnsFalseWithNonExistentValue()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.False(dictionary.ContainsValue("b"));
        }

        [Fact]

        public void ContainsKeyReturnsFalseWhenDictionaryIsEmpty()
        {
            var dictionary = new MyDictionary<int, object>(5, 10);
            Assert.False(dictionary.ContainsKey(1));
        }

        [Fact]

        public void ContainsReturnsTrueWithValidKeyValuePair()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.True(dictionary.Contains(new KeyValuePair<int, object>(1, "a")));
        }

        [Fact]

        public void ContainsReturnsFalseWithInvalidKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.False(dictionary.Contains(new KeyValuePair<int, object>(2, "a")));
        }

        [Fact]

        public void ContainsReturnsFalseWithInvalidValue()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a")
            };
            Assert.False(dictionary.Contains(new KeyValuePair<int, object>(1, "b")));
        }

        [Fact]
        public void CanLoopThroughDictionaryWithEnumerator()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 2, "b" }
            }; 
            IEnumerator<KeyValuePair<int, object>> enumerator = dictionary.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(new KeyValuePair<int, object>(1, "a"), enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(new KeyValuePair<int, object>(2, "b"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void CanCopyDictionaryItemsToArray()
        {
            var expectedArray = new KeyValuePair<int, object>[]
            {
                new KeyValuePair<int, object>(1, "a"),
                new KeyValuePair<int, object>(2, "b")
            };
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 2, "b" }
            };
            var copiedArray = new KeyValuePair<int, object>[2];
            dictionary.CopyTo(copiedArray, 0);
            Assert.Equal(expectedArray, copiedArray);
        }

        [Fact]

        public void CanRemoveElementByKeyWhenIsFirstAndLastInTheBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                new KeyValuePair<int, object>(1, "a"),
            };
            Assert.True(dictionary.Remove(1));
            Assert.False(dictionary.ContainsKey(1));
        }

        [Fact]

        public void CanRemoveElementByKeyWhenIsLastInTheBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 6, "b" }
            };
            Assert.True(dictionary.Remove(1));
            Assert.False(dictionary.ContainsKey(1));
        }

        [Fact]

        public void CanRemoveElementByKeyWhenIsFirstInTheBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 6, "b" }
            };
            Assert.True(dictionary.Remove(6));
            Assert.False(dictionary.ContainsKey(6));
        }

        [Fact]

        public void CanNotRemoveElementByKeyWhenIsNotInDictionary()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };
            Assert.False(dictionary.Remove(6));
            Assert.False(dictionary.ContainsKey(6));
        }

        [Fact]

        public void CanRemoveKeyValuePairWhenIsSingleInTheBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };
            Assert.True(dictionary.Remove(new KeyValuePair<int, object>(1, "a")));
            Assert.False(dictionary.Contains(new KeyValuePair<int, object>(1, "a")));
        }

        [Fact]

        public void CanRemoveKeyValuePairWhenIsLastInTheBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 6, "b" }
            };
            Assert.True(dictionary.Remove(new KeyValuePair<int, object>(1, "a")));
            Assert.False(dictionary.Contains(new KeyValuePair<int, object>(1, "a")));
        }

        [Fact]

        public void CanRemoveKeyValuePairWhenIsFirstInTheBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" },
                { 6, "b" }
            };
            Assert.True(dictionary.Remove(new KeyValuePair<int, object>(6, "b")));
            Assert.False(dictionary.Contains(new KeyValuePair<int, object>(6, "b")));
        }

        [Fact]

        public void CanNotRemoveKeyValuePairWhenIsNotInTheBucket()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };
            Assert.False(dictionary.Remove(new KeyValuePair<int, object>(6, "b")));
            Assert.False(dictionary.Contains(new KeyValuePair<int, object>(6, "b")));
        }

        [Fact]

        public void CanNotRemoveKeyValuePairWithInvalidValue()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };
            Assert.False(dictionary.Remove(new KeyValuePair<int, object>(1, "b")));
            Assert.True(dictionary.Contains(new KeyValuePair<int, object>(1, "a")));
        }

        [Fact]

        public void CanTryGetValueWithValidKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };

            Assert.True(dictionary.TryGetValue(1, out var value));
            Assert.Equal("a", value);
        }

        [Fact]

        public void CanTryGetValueWithInvalidKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };

            Assert.False(dictionary.TryGetValue(2, out var value));
            Assert.Null(value);
        }

        [Fact]

        public void CanTryAddValidKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10);
            Assert.True(dictionary.TryAdd(1, "a"));
            Assert.Contains(new KeyValuePair<int, object>(1, "a"), dictionary);
        }

        [Fact]

        public void CanTryAddInvalidKey()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };
            Assert.False(dictionary.TryAdd(1, "a"));
            Assert.Equal(new MyDictionary<int, object>(5, 10) { { 1, "a" } }, dictionary);
        }

        [Fact]

        public void TryAddWithInvalidKeyDoesNotOverrideExistentElement()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "a" }
            };
            Assert.False(dictionary.TryAdd(1, "b"));
            Assert.Equal(new MyDictionary<int, object>(5, 10) { { 1, "a" } }, dictionary);
        }

        [Fact]

        public void CanGetKeyCollection()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 2, "b" },
                { 1, "a" },
                { 3, "c" }
            };
            Assert.Equal(new int[] {1, 2, 3}, dictionary.Keys);
        }

        [Fact]

        public void CanGetValuesCollection()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 2, "b" },
                { 1, "a" },
                { 3, "c" }
            };
            Assert.Equal(new object[] { "a", "b", "c" }, dictionary.Values);
        }

        [Fact]

        public void CanGetCorrectKeysAndValuesAfterRemovingElements()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 1, "b" },
                { 2, "a" },
                { 3, "c" },
                { 4, "a" },
                { 5, "a" }
            };
            dictionary.Remove(2);
            dictionary.Remove(4);
            Assert.Equal(new int[] { 5, 1, 3 }, dictionary.Keys);
            Assert.Equal(new object[] { "a", "b", "c" }, dictionary.Values);
        }

        [Fact]
        public void CanLoopThroughDictionaryWithEnumeratorAfterRemovingElements()
        {
            var dictionary = new MyDictionary<int, object>(5, 10)
            {
                { 3, "c" },
                { 1, "a" },
                { 2, "b" }
            };
            dictionary.Remove(3);
            IEnumerator<KeyValuePair<int, object>> enumerator = dictionary.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(new KeyValuePair<int, object>(1, "a"), enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(new KeyValuePair<int, object>(2, "b"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenGetNullKey()
        {
            var dictionary = new MyDictionary<object, object>(5, 10);
            Assert.Throws<ArgumentNullException>(() => dictionary[null]);
        }

        [Fact]
        public void ThrowsKeyNotFoundExceptionWhenGetKeyIsNotInDictionary()
        {
            var dictionary = new MyDictionary<int, object>(5, 10);
            Assert.Throws<KeyNotFoundException>(() => dictionary[0]);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenAddNullKey()
        {
            var dictionary = new MyDictionary<object, object>(5, 10);
            Assert.Throws<ArgumentNullException>(() => dictionary.Add(null, null));
        }

        [Fact]
        public void ThrowsArgumentExceptionnWhenAddElementWithKeyThatAlreadyExists()
        {
            var dictionary = new MyDictionary<int, object>(5, 10) { { 1, "a"} };
            Assert.Throws<ArgumentException>(() => dictionary.Add(1, "b"));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenUseContainsKeyWithNullKey()
        {
            var dictionary = new MyDictionary<object, object>(5, 10);
            Assert.Throws<ArgumentNullException>(() => dictionary.ContainsKey(null));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenRemoveNullKey()
        {
            var dictionary = new MyDictionary<object, object>(5, 10);
            Assert.Throws<ArgumentNullException>(() => dictionary.Remove(null));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenCopyToNullArray()
        {
            var dictionary = new MyDictionary<int, object>(5, 10);
            Assert.Throws<ArgumentNullException>(() => dictionary.CopyTo(null ,0));
        }

        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenCopyToIndexIsLessThanZero()
        {
            var dictionary = new MyDictionary<int, object>(5, 10);
            Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.CopyTo(new KeyValuePair<int, object>[0], -1));
        }

         [Fact]
        public void ThrowsArgumentExceptionWhenIsntEnoughSpaceAvailableInCopyToArray()
        {
            var dictionary = new MyDictionary<int, object>(5, 10) { { 1, "a"} };
            Assert.Throws<ArgumentException>(() => dictionary.CopyTo(new KeyValuePair<int, object>[10], 10));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenTryGetValueWithNullKey()
        {
            var dictionary = new MyDictionary<object, object>(5, 10);
            Assert.Throws<ArgumentNullException>(() => dictionary.TryGetValue(null, out var value));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenTryAddNullKey()
        {
            var dictionary = new MyDictionary<object, object>(5, 10);
            Assert.Throws<ArgumentNullException>(() => dictionary.TryAdd(null, true));
        }
    }
}
