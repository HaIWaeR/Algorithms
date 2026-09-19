namespace BinarySearchTreeTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = new int[] { 50, 30, 70, 20, 40, 60, 80 };

            //Вставка
            BinarySearchTree tree1 = new BinarySearchTree();
            foreach (int value in values)
            {
                tree1.Insert(value);
            }

            Console.WriteLine("Вставлено: " + string.Join(", ", values));
            Console.WriteLine("Дерево по возрастанию: " + string.Join(", ", tree1.InOrderTraversal()));
            Console.WriteLine("Количество узлов: " + tree1.InOrderTraversal().Count);

            tree1.Insert(30);
            Console.WriteLine("Повторная вставка 30");
            Console.WriteLine("Дерево по возрастанию: " + string.Join(", ", tree1.InOrderTraversal()));
            Console.WriteLine("Количество узлов: " + tree1.InOrderTraversal().Count);
            Console.WriteLine();

            //Поиск
            BinarySearchTree tree2 = new BinarySearchTree();
            foreach (int value in values)
            {
                tree2.Insert(value);
            }

            Console.WriteLine("Дерево: " + string.Join(", ", tree2.InOrderTraversal()));
            Console.WriteLine("Contains(50) = " + tree2.Contains(50));
            Console.WriteLine("Contains(20) = " + tree2.Contains(20));
            Console.WriteLine("Contains(40) = " + tree2.Contains(40));
            Console.WriteLine("Contains(45) = " + tree2.Contains(45));
            Console.WriteLine("Contains(10) = " + tree2.Contains(10));
            Console.WriteLine("Contains(100) = " + tree2.Contains(100));
            Console.WriteLine();

            //Удаление
            BinarySearchTree tree3 = new BinarySearchTree();
            foreach (int value in values)
            {
                tree3.Insert(value);
            }

            Console.WriteLine("Исходное дерево: " + string.Join(", ", tree3.InOrderTraversal()));

            tree3.Remove(20);
            Console.WriteLine("Remove(20) - лист");
            Console.WriteLine("Дерево: " + string.Join(", ", tree3.InOrderTraversal()));
            Console.WriteLine("Contains(20) = " + tree3.Contains(20));

            tree3.Remove(30);
            Console.WriteLine("Remove(30) - один потомок");
            Console.WriteLine("Дерево: " + string.Join(", ", tree3.InOrderTraversal()));
            Console.WriteLine("Contains(30) = " + tree3.Contains(30));
            Console.WriteLine("Contains(40) = " + tree3.Contains(40));

            tree3.Remove(50);
            Console.WriteLine("Remove(50) - два потомка, корень");
            Console.WriteLine("Дерево: " + string.Join(", ", tree3.InOrderTraversal()));
            Console.WriteLine("Contains(50) = " + tree3.Contains(50));
            Console.WriteLine("Contains(60) = " + tree3.Contains(60));

            tree3.Remove(999);
            Console.WriteLine("Remove(999) - значения нет");
            Console.WriteLine("Дерево: " + string.Join(", ", tree3.InOrderTraversal()));
            Console.WriteLine();

            //Обходы
            BinarySearchTree tree4 = new BinarySearchTree();
            foreach (int value in values)
            {
                tree4.Insert(value);
            }

            List<int> inOrder = tree4.InOrderTraversal();
            List<int> preOrder = tree4.PreOrderTraversal();
            List<int> postOrder = tree4.PostOrderTraversal();

            Console.WriteLine("Порядок вставки: " + string.Join(", ", values));
            Console.WriteLine("InOrder:   " + string.Join(", ", inOrder));
            Console.WriteLine("PreOrder:  " + string.Join(", ", preOrder));
            Console.WriteLine("PostOrder: " + string.Join(", ", postOrder));
            Console.WriteLine("InOrder строго возрастает: " + IsSorted(inOrder));
        }
        static bool IsSorted(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] >= list[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}