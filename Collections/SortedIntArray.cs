using System;
using System.ComponentModel;
using System.Reflection;
namespace Collections
{
    public class SortedIntArray : IntArray
    {
        public override void Add(int element)
        {
            for (int additionIndex = 0; additionIndex <= Count; additionIndex++)
            {
                if (IsSortedElement(additionIndex, element, true))
                {
                    base.Insert(additionIndex, element);
                    return;
                }
            }
        }

        public override int this[int index]
        {
            set => base[index] = index < Count && IsSortedElement(index, value, false) ? value : base[index];
        }
  
        public override void Insert(int index, int element)
        {
            if (!IsSortedElement(index, element, true))
            {
                return;
            }
            base.Insert(index, element);
        }

        private bool IsSortedElement(int index, int value, bool insertion)
        {
            if (Count == 0)
            {
                return true;
            }

            int nextElementIndex = insertion ? index : index + 1;
            if (index == (insertion ? Count : Count - 1))
            {
                return value >= this[index - 1];
            }

            if (index == 0)
            {
                return value <= this[nextElementIndex];
            }

            return value >= this[index - 1] && value <= this[nextElementIndex];
        }
    }
}
