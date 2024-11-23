using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Collections
{
    public class List<T> : IEnumerable<T>, IList<T>
    {
        T[] list;

        public List()
        {
            list = new T[4];
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool IsReadOnly { get; private set; } = false;

        public IList<T> AsReadOnly() => new ReadOnlyList<T>(this);

        public void CopyTo(T[] array, int index)
        {
            if (array == null) throw new ArgumentNullException("array can not be null");
            if (index < 0) throw new ArgumentOutOfRangeException("index should be positive");
            if (Count + index > array.Length) throw new ArgumentException("can not copy elements to array, it is to small");
            for (int i = 0; i < Count; i++)
            {
                array[index] = this.list[i];
                index++;
            }
        }

        public int Count { get; protected set; }

        public void Add(T element)
        {
            if (IsReadOnly) throw new NotSupportedException();
            Insert(Count, element);
        }

        public virtual T this[int index]
        {
            get
            {
                IsIndexValid(index, Count - 1);
                return list[index];
            }
            set
            {
                if (IsReadOnly) throw new NotSupportedException();
                IsIndexValid(index, Count - 1);
                this.list[index] = value;
            }
        }

        public bool Contains(T element) => IndexOf(element) != -1;

        public int IndexOf(T item) => Array.IndexOf(list, item, 0, Count);

        public virtual void Insert(int index, T element)
        {
            if (IsReadOnly) throw new NotSupportedException();
            IsIndexValid(index, Count);
            EnsureCapacity();
            ShiftRight(index);
            list[index] = element;
            Count++;
        }

        public void Clear()
        {
            if (IsReadOnly) throw new NotSupportedException();
            Count = 0;
        }

        public bool Remove(T element)
        {
            if (IsReadOnly) throw new NotSupportedException();
            int elementIndex = IndexOf(element);
            if (elementIndex == -1)
            {
                return false;
            }

            RemoveAt(elementIndex);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (index > Count - 1 || index < 0) throw new ArgumentOutOfRangeException("index is not a valid index in the List<T>");
            IsIndexValid(index, Count - 1);
            ShiftLeft(index);
            Count--;
        }

        private void ShiftLeft(int index)
        {
            for (int arrayIndex = index; arrayIndex < Count - 1; arrayIndex++)
            {
                list[arrayIndex] = list[arrayIndex + 1];
            }
        }

        protected void ShiftRight(int index)
        {
            for (int arrayIndex = Count; arrayIndex > index; arrayIndex--)
            {
                list[arrayIndex] = list[arrayIndex - 1];
            }
        }

        protected void EnsureCapacity()
        {
            if (Count == list.Length)
            {
                Array.Resize(ref list, Count * 2);
            }
        }

        private void IsIndexValid(int index, int maxValue)
        {
            if (index > maxValue || index < 0) throw new ArgumentOutOfRangeException("index is not a valid in the List<T>");
        }
    }
}
