using System;
using System.Collections;

namespace Collections
{
    public class LinkedList<T> : ICollection<T>
    {
        private Node<T>? santinel;

        public LinkedList()
        {
            santinel = new Node<T>();
            santinel.List = this;
            Clear();
        }

        public Node<T>? First { get => Count == 0 ? null : santinel.Next; }

        public Node<T>? Last { get => Count == 0 ? null : santinel.Previous; }

        public int Count { get; private set; }

        bool ICollection<T>.IsReadOnly { get => false; }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        public void AddLast(Node<T> newNode)
        {
            AddBefore(santinel, newNode);
        }

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        public void AddFirst(Node<T> newNode)
        {
            AddBefore(santinel.Next, newNode);
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            AddBefore(node?.Next, newNode);
        }

        public void AddAfter(Node<T> node, T value)
        {
            AddAfter(node, new Node<T>(value));
        }

        public void AddBefore(Node<T> node, T value)
        {
            AddBefore(node, new Node<T>(value));
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            ValidateNode(node);
            ValidateNewNode(newNode);
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            newNode.List = this;
            Count++;
        }

        public void Clear()
        {
            santinel.Next = santinel.Previous = santinel;
            Count = 0;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ValidateArrayArguments(array, arrayIndex);
            foreach(var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public Node<T> Find(T value)
        {
            for (Node<T> current = santinel.Next; current != santinel; current = current.Next)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
            }

            return null;
        }

        public Node<T> FindLast(T value)
        {
            for (Node<T> current = santinel.Previous; current != santinel; current = current.Previous)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> current = santinel.Next; current != santinel; current = current.Next)
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Remove(T value)
        {
            Node<T> removeNode = Find(value);
            if (removeNode == null)
            {
                return false;
            }

            RemoveNode(removeNode);
            return true;
        }

        public void Remove(Node<T> node)
        {
            ValidateNode(node);
            RemoveNode(node);
        }

        public void RemoveFirst()
        {
            ValidateList();
            RemoveNode(santinel.Next);
        }

        public void RemoveLast()
        {
            ValidateList();
            RemoveNode(santinel.Previous);
        }

        private void RemoveNode(Node<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        private void ValidateNode(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException("node is null");
            if (node.List != this) throw new InvalidOperationException("node is not in this list");
        }

        private void ValidateNewNode(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException("newNode is null");
            if (node.List != null) throw new InvalidOperationException("newNode belongs to another list");
        }

        private void ValidateArrayArguments(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("index is less than zero");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("the number of elements in the list is greater than the available space from index to the end of the given array");
        }

        private void ValidateList()
        {
            if (Count == 0) throw new InvalidOperationException("the list is empty");
        }
    }
}
