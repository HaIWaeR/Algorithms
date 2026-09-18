# Часть 1. Односвязный список
```csharp
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
```

### Main
```csharp
static void ShowList<T>(SinglyLinkedList<T> list)
{
    if (list.Count == 0)
    {
        Console.WriteLine("Список пуст");
        return;
    }

    foreach (T item in list)
    {
        Console.Write(item + ", ");
    }

    Console.WriteLine("null");
}
```

```csharp
SinglyLinkedList<string> link = new SinglyLinkedList<string>();
Console.WriteLine($"Список создан. Count: {link.Count}");
Console.WriteLine(new string('_', 50));

// AddFirst 
link.AddFirst("Первый");
link.AddFirst("Второй");
link.AddFirst("Третий");
ShowList(link);
Console.WriteLine($"Count: {link.Count}");
Console.WriteLine(new string('_', 50));

// AddLast 
link.AddLast("1");
link.AddLast("2");
link.AddLast("3");
ShowList(link);
Console.WriteLine(new string('_', 50));

// Contains 
Console.WriteLine($"Поиск 'Первый': {link.Contains("Первый")}");
Console.WriteLine($"Поиск 'Второй': {link.Contains("Второй")}");
Console.WriteLine($"Поиск 'Шестой': {link.Contains("Шестой")}");
Console.WriteLine($"Поиск 'null': {link.Contains(null!)}");
Console.WriteLine(new string('_', 50));

// First
Console.WriteLine($"First (голова без удаления): {link.First}");
ShowList(link);
Console.WriteLine(new string('_', 50));

// RemoveFirst 
Console.WriteLine("Текущий список:");
ShowList(link);
string removed = link.RemoveFirst();
Console.WriteLine($"Удален элемент: '{removed}'");
Console.WriteLine("Список после удаления:");
ShowList(link);
```

### Вывод
```
Список создан. Count: 0
__________________________________________________
Третий, Второй, Первый, null
Count: 3
__________________________________________________
Третий, Второй, Первый, 1, 2, 3, null
__________________________________________________
Поиск 'Первый': True
Поиск 'Второй': True
Поиск 'Шестой': False
Поиск 'null': False
__________________________________________________
First (голова без удаления): Третий
Третий, Второй, Первый, 1, 2, 3, null
__________________________________________________
Текущий список:
Третий, Второй, Первый, 1, 2, 3, null
Удален элемент: 'Третий'
Список после удаления:
Второй, Первый, 1, 2, 3, null
```

# Часть 2. Стек на основе связного списка
```csharp
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
```
### Main

```csharp
static void ShowStack<T>(MyStack<T> stack)
{
    if (stack.IsEmpty)
    {
        Console.WriteLine("Stack is empty");
        return;
    }

    Console.WriteLine("Stack contents (сверху вниз):");
    foreach (T item in stack)
    {
        Console.WriteLine(item);
    }
}
```
```csharp
MyStack<int> myStack = new MyStack<int>();
Console.WriteLine($"Count: {myStack.Count}");
ShowStack(myStack);
Console.WriteLine(new string('_', 50));

myStack.Push(7);
myStack.Push(2);
myStack.Push(5);
Console.WriteLine($"Count: {myStack.Count}");
ShowStack(myStack);
Console.WriteLine(new string('_', 50));

myStack.Push(5);
myStack.Push(5);
Console.WriteLine($"Count: {myStack.Count}");
Console.WriteLine($"Peek: {myStack.Peek()}");
ShowStack(myStack);
Console.WriteLine(new string('_', 50));

Console.WriteLine(myStack.Pop());
Console.WriteLine(myStack.Pop());
Console.WriteLine($"Count: {myStack.Count}");
ShowStack(myStack);

Console.WriteLine(new string('_', 50));

Console.WriteLine($"Count: {myStack.Count}");
Console.WriteLine($"IsEmpty: {myStack.IsEmpty}");

Console.WriteLine(new string('_', 50));

while (!myStack.IsEmpty)
{
    myStack.Pop();
}

Console.WriteLine($"Стек опустошён. IsEmpty: {myStack.IsEmpty}");

try
{
    myStack.Pop();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Pop на пустом: {ex.Message}");
}

try
{
    myStack.Peek();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Peek на пустом: {ex.Message}");
}
```

### Вывод
```
Count: 0
Stack is empty
__________________________________________________
Count: 3
Stack contents (сверху вниз):
5
2
7
__________________________________________________
Count: 5
Peek: 5
Stack contents (сверху вниз):
5
5
5
2
7
__________________________________________________
5
5
Count: 3
Stack contents (сверху вниз):
5
2
7
__________________________________________________
Count: 3
IsEmpty: False
__________________________________________________
Стек опустошён. IsEmpty: True
Pop на пустом: Список пуст, невозможно удалить элемент
Peek на пустом: Список пуст
```

# Часть 3. Проверка сбалансированности скобок
```csharp
namespace LinkedListAndStack
{
    class Balanced
    {
        private Dictionary<char, char> Pairs = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}'}
        };

        public bool IsBalanced(string input)
        {
            MyStack<char> stack = new MyStack<char>();

            foreach (char c in input)
            {
                if (Pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (Pairs.ContainsValue(c))
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    if (Pairs[top] != c) return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
```

### Main
```csharp
Balanced balanced = new Balanced();
Console.WriteLine(balanced.IsBalanced("(a + b) * [c - d]"));  // true
Console.WriteLine(balanced.IsBalanced("{[()()]}"));           // true
Console.WriteLine(balanced.IsBalanced("([)]"));               // false
Console.WriteLine(balanced.IsBalanced("((a + b)"));           // false
Console.WriteLine(balanced.IsBalanced(""));                   // true
Console.WriteLine(balanced.IsBalanced(")("));                 // false
Console.WriteLine(balanced.IsBalanced("abc"));                // true
```

### Вывод
```
True
True
False
False
True
False
True
```