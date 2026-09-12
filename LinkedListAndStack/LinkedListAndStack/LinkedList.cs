using System.Collections;
using System.Collections.Generic;

namespace LinkedListAndStack
{
    public class LinkedMain()
    {
        public void Main()
        {
            // Создание пустого сиска
            LinkedList<string> link = new LinkedList<string>();
            Console.WriteLine($"Список создан. Count: {link.Count}");

            Console.WriteLine(new string('_', 50));

            // AddFirst 
            link.AddFirst("Первый");
            link.AddFirst("Второй");
            link.AddFirst("Третий");
            link.ShowList();
            Console.WriteLine($"Count: {link.Count}");

            Console.WriteLine(new string('_', 50));

            // AddLast 
            link.AddLast("1");
            link.AddLast("2");
            link.AddLast("3");
            link.ShowList();

            Console.WriteLine(new string('_', 50));
            
            // Contains 
            Console.WriteLine($"Поиск 'Первый': {link.Contains("Первый")}");
            Console.WriteLine($"Поиск 'Второй': {link.Contains("Второй")}");
            Console.WriteLine($"Поиск 'Шестой': {link.Contains("Шестой")}");
            Console.WriteLine($"Поиск 'null': {link.Contains(null!)}");

            Console.WriteLine(new string('_', 50));

            // RemoveFirst 
            Console.WriteLine("Текущий список:");
            link.ShowList();
            string removed = link.RemoveFirst();
            Console.WriteLine($"Удален элемент: '{removed}'");
            Console.WriteLine("Список после удаления:");
            link.ShowList();

            // 

        }

    }


    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T>? _head;
        private int _count;
        public int Count => _count;

        public LinkedList()
        {
            _head = null;
            _count = 0;
        }

        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = _head;
            _head = newNode;
            _count++;
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node<T> current = _head;
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
            Node<T>? current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }


        public void ShowList()
        {
            if (_head == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Node<T>? current = _head;

            while (current != null)
            {
                Console.Write(current.Value + ", ");
                current = current.Next;
            }

            Console.WriteLine("null");
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
