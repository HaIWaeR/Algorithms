namespace LinkedListAndStack
{
    class Program
    {
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

        static void Main(string[] args)
        {
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

            // -----------------------------------------------------------------
            Console.WriteLine($"\n{new string('#', 50)}\n");

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

            // -----------------------------------------------------------------
            Console.WriteLine($"\n{new string('#', 50)}\n");

            Balanced balanced = new Balanced();
            Console.WriteLine(balanced.IsBalanced("(a + b) * [c - d]"));  // true
            Console.WriteLine(balanced.IsBalanced("{[()()]}"));           // true
            Console.WriteLine(balanced.IsBalanced("([)]"));               // false
            Console.WriteLine(balanced.IsBalanced("((a + b)"));           // false
            Console.WriteLine(balanced.IsBalanced(""));                   // true
            Console.WriteLine(balanced.IsBalanced(")("));                 // false
            Console.WriteLine(balanced.IsBalanced("abc"));                // true
        }
    }
}