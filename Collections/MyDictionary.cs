using System.Collections;

namespace Collections
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private struct Element
        {
            internal TKey Key { get; set; }

            internal TValue Value { get; set; }

            internal int Next { get; set; }

            internal Element(TKey key, TValue value, int next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        int[] buckets;

        Element[] elements;

        int freeIndex;

        public MyDictionary(int bucketsSize, int elementsSize)
        {
            buckets = new int[bucketsSize];
            elements = new Element[elementsSize];
            Clear();
        }

        public TValue this[TKey key]
        {
            get
            {
                ValidateKey(key);
                int elementIndex = FindKey(key);
                if (elementIndex == -1) throw new KeyNotFoundException();
                return elements[elementIndex].Value;
            }
            set
            {
                int elementIndex = FindKey(key);
                if (elementIndex != -1)
                {
                    elements[elementIndex].Value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] keys = new TKey[Count];
                int index = 0;
                foreach (var element in this)
                {
                    keys[index] = element.Key;
                    index++;
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] values = new TValue[Count];
                int index = 0;
                foreach (var element in this)
                {
                    values[index] = element.Value;
                    index++;
                }

                return values;
            }
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key)) throw new ArgumentException("An element with the same key already exists in the dictionary");
            int additionIndex = GetAdditionIndex();
            int bucketNumber = GetBucket(key);
            elements[additionIndex] = new Element(key, value, buckets[bucketNumber]);
            buckets[bucketNumber] = additionIndex;
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill(buckets, -1);
            elements = new Element[elements.Length];
            Count = 0;
            freeIndex = -1;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int elementIndex = FindKey(item.Key);
            return elementIndex != -1 && elements[elementIndex].Value.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            ValidateKey(key);
            return FindKey(key) != -1;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (TValue currentValue in Values)
            {
                if (currentValue.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ValidateArrayArguments(array, arrayIndex);
            foreach (KeyValuePair<TKey, TValue> item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = buckets[i];  j != -1; j = elements[j].Next)
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[j].Key, elements[j].Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            ValidateKey(key);
            int elementIndex = FindKey(key, out int prev);
            if (elementIndex == -1)
            {
                return false;
            }

            RemoveElement(elementIndex, GetBucket(key), prev);
            return true;
        }

       
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            ValidateKey(item.Key);
            int elementIndex = FindKey(item.Key, out int prev);
            if (elementIndex == -1 || !elements[elementIndex].Value.Equals(item.Value))
            {
                return false;
            }

            RemoveElement(elementIndex, GetBucket(item.Key), prev);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            ValidateKey(key);
            int elementIndex = FindKey(key);
            if (elementIndex != -1)
            {
                value = elements[elementIndex].Value;
                return true;
            }

            value = default;
            return false;
        }

        public bool TryAdd(TKey key, TValue value)
        {
            ValidateKey(key);
            if (ContainsKey(key))
            {
                return false;
            }

            Add(key, value);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void RemoveElement(int elementIndex, int bucketNumber, int prev)
        {
            if (buckets[bucketNumber] == elementIndex)
            {
                buckets[bucketNumber] = elements[elementIndex].Next;
            }
            else
            {
                elements[prev].Next = elements[elementIndex].Next;
            }

            elements[elementIndex].Next = freeIndex;
            freeIndex = elementIndex;
            Count--;
        }

        private int GetBucket(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        private int FindKey(TKey key)
        {
            return FindKey(key, out _);
        }

        private int FindKey(TKey key, out int prev)
        {
            for (int i = prev = buckets[GetBucket(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return i;
                }
                prev = i;
            }

            return -1;
        }

        private static void ValidateKey(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key is null");
        }

        private void ValidateArrayArguments(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("index is less than zero");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("the number of elements in the dictionary is greater than the available space from index to the end of the given array");
        }

        private int GetAdditionIndex()
        {
            if (freeIndex != -1)
            {
                int index = freeIndex;
                freeIndex = elements[freeIndex].Next;
                return index;
            }

            return Count;
        }
    }
}
