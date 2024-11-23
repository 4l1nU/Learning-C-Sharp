using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class SortedList<T> where T : IComparable<T>
    {
        T[] array;

        public SortedList()
        {
            array = new T[4];
            Count = 0;
        }

        public int Count { get; protected set; }

        public void Add(T element)
        {
            for (int additionIndex = 0; additionIndex <= Count; additionIndex++)
            {
                if (IsSortedElement(additionIndex, element, true))
                {
                    Insert(additionIndex, element);
                    return;
                }
            }
        }

        public virtual T this[int index]
        {
            get => index < Count ? array[index] : default;
            set => array[index] = index < Count && IsSortedElement(index, value, false) ? value : array[index];
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;

        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(array, element, 0, Count);

        }

        public virtual void Insert(int index, T element)
        {
            if (!IsSortedElement(index, element, true))
            {
                return;
            }

            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(T element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        private void ShiftLeft(int index)
        {
            for (int arrayIndex = index; arrayIndex < Count - 1; arrayIndex++)
            {
                array[arrayIndex] = array[arrayIndex + 1];
            }
        }

        private bool IsSortedElement(int index, T value, bool insertion)
        {
            if (Count == 0)
            {
                return true;
            }

            int nextElementIndex = insertion ? index : index + 1;
            if (index == (insertion ? Count : Count - 1))
            {
                return value.CompareTo(array[index - 1]) != -1;
            }

            if (index == 0)
            {
                return value.CompareTo(array[nextElementIndex]) != 1;
            }

            return value.CompareTo(array[index - 1]) != -1 && value.CompareTo(array[nextElementIndex]) != 1;
        }

        protected void ShiftRight(int index)
        {
            for (int arrayIndex = Count; arrayIndex > index; arrayIndex--)
            {
                array[arrayIndex] = array[arrayIndex - 1];
            }
        }

        protected void EnsureCapacity()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, Count * 2);
            }
        }
    }
}
