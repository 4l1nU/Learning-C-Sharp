using System;
using System.Reflection;

namespace Collections
{
    public class IntArray
    {
        int[] array;
       
        public IntArray()
        {
            array = new int[4];
            Count = 0;
        }

        public int Count { get; protected set; }
        
        public virtual void Add(int element)
        {
            Insert(Count, element);
        }

        public virtual int this[int index]
        {
            get => index < Count ? array[index] : 0;
            set => array[index] = index < Count ? value : 0;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;

        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element, 0, Count);

        }

        public virtual void Insert(int index, int element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
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