using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> myList = new CustomList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);

            myList.PrintArray();

            myList.RemoveAt(3);

            myList.PrintArray();

            Console.Write($"\n\nНайденый элемент: {myList.Get(2)}");
        }
    }
    class CustomList<T>
    {
        private T[] _items;
        public int count;

        public CustomList()
        {
            _items = new T[1];
            count = 0;
        }
        public void PrintArray()
        {
            Console.WriteLine();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{_items[i]} ");
            }
        }
        public void Add(T item)
        {
            if (count == _items.Length)
            {
                int newSize = _items.Length + (_items.Length / 2);
                if (newSize == _items.Length)
                    newSize++;

                T[] newArray = new T[newSize];

                for (int i = 0; i < count; i++)
                {
                    newArray[i] = _items[i];
                }

                _items = newArray;

                Console.WriteLine($"\nМассив расширен до: {newSize} размера");
            }
            _items[count] = item;
            count++;
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < count)
            {
                for (int i = index; i < count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }

                _items[count - 1] = default(T);
                count--;
            }
        }
        public T Get(int index)
        {
            if (index >= 0 && index < count)
            {
                return _items[index];
            }
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона");
        }
    }
}