using System.Collections;

namespace LinkedListAndStack
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? _head;
        private int _count;

        public int Count => _count;

        public T First
        {
            get
            {
                if (_head == null)
                    throw new InvalidOperationException("Список пуст");

                return _head.Value;
            }
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);
            newNode.Next = _head;
            _head = newNode;
            _count++;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            _count++;
        }

        public T RemoveFirst()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Список пуст, невозможно удалить элемент");
            }

            T value = _head.Value;
            _head = _head.Next;
            _count--;

            return value;
        }

        public bool Contains(T value)
        {
            Node? current = _head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}