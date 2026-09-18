using System.Collections;

namespace LinkedListAndStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly SinglyLinkedList<T> _list = new SinglyLinkedList<T>();
        public int Count => _list.Count;
        public bool IsEmpty => _list.Count == 0;
        public void Push(T value) => _list.AddFirst(value);
        public T Pop() => _list.RemoveFirst();
        public T Peek() => _list.First;
        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}