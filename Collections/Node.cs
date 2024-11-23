using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Node<T>
    {
        public T? Value { get; set; }

        public Node<T>? Previous {  get; internal set; }

        public Node<T>? Next { get; internal set; }

        public LinkedList<T> List { get; internal set; }

        public Node(T value = default)
        {
            Value = value;
        }
    }
}
