## Часть 1. Структура узла и вставка
```csharp
class TreeNode
{
    public int Value;
    public TreeNode? Left = null;
    public TreeNode? Right = null;
    public TreeNode(int value) => Value = value;
}

private TreeNode? root = null;

private TreeNode Insert(TreeNode? node, int value)
{
    if (node == null)
        return new TreeNode(value);

    if (value < node.Value)
    {
        node.Left = Insert(node.Left, value);
    }
    else if (value > node.Value)
    {
        node.Right = Insert(node.Right, value);
    }

    return node;
}

public void Insert(int value)
{
    root = Insert(root, value);
}
```

### Main

```csharp
int[] values = new int[] { 50, 30, 70, 20, 40, 60, 80 };

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
```

### Вывод

```
Вставлено: 50, 30, 70, 20, 40, 60, 80
Дерево по возрастанию: 20, 30, 40, 50, 60, 70, 80
Количество узлов: 7
Повторная вставка 30
Дерево по возрастанию: 20, 30, 40, 50, 60, 70, 80
Количество узлов: 7
```


## Часть 2. Поиск элемента
```csharp
private bool Contains(TreeNode? node, int value)
{
    if (node == null) return false;
    if (value == node.Value) return true;

    return value < node.Value ? Contains(node.Left, value) : Contains(node.Right, value);
}

public bool Contains(int value)
{
    return Contains(root, value);
}
```

### Main

```csharp
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
```

### Вывод

```
Дерево: 20, 30, 40, 50, 60, 70, 80
Contains(50) = True
Contains(20) = True
Contains(40) = True
Contains(45) = False
Contains(10) = False
Contains(100) = False
```

## Часть 3. Удаление элемента
```csharp
private int FindMin(TreeNode node)
{
    while (node.Left != null)
    {
        node = node.Left;
    }

    return node.Value;
}

private TreeNode? Remove(TreeNode? node, int value)
{
    if (node == null) return null;

    if (value < node.Value)
    {
        node.Left = Remove(node.Left, value);
        return node;
    }

    if (value > node.Value)
    {
        node.Right = Remove(node.Right, value);
        return node;
    }

    if (node.Left == null) return node.Right;
    if (node.Right == null) return node.Left;

    int successor = FindMin(node.Right);
    node.Value = successor;
    node.Right = Remove(node.Right, successor);
    return node;
}

public void Remove(int value)
{
    root = Remove(root, value);
}
```

### Main
```csharp
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
```

### Вывод
```
Исходное дерево: 20, 30, 40, 50, 60, 70, 80
Remove(20) - лист
Дерево: 30, 40, 50, 60, 70, 80
Contains(20) = False
Remove(30) - один потомок
Дерево: 40, 50, 60, 70, 80
Contains(30) = False
Contains(40) = True
Remove(50) - два потомка, корень
Дерево: 40, 60, 70, 80
Contains(50) = False
Contains(60) = True
Remove(999) - значения нет
Дерево: 40, 60, 70, 80
```

## Часть 4. Обходы дерева
```csharp
private void InOrder(TreeNode? node, List<int> result)
{
    if (node == null) return;

    InOrder(node.Left, result);
    result.Add(node.Value);
    InOrder(node.Right, result);
}

public List<int> InOrderTraversal()
{
    List<int> result = new List<int>();
    InOrder(root, result);
    return result;
}

private void PreOrder(TreeNode? node, List<int> result)
{
    if (node == null) return;

    result.Add(node.Value);
    PreOrder(node.Left, result);
    PreOrder(node.Right, result);
}

public List<int> PreOrderTraversal()
{
    List<int> result = new List<int>();
    PreOrder(root, result);
    return result;
}

private void PostOrder(TreeNode? node, List<int> result)
{
    if (node == null) return;

    PostOrder(node.Left, result);
    PostOrder(node.Right, result);
    result.Add(node.Value);
}

public List<int> PostOrderTraversal()
{
    List<int> result = new List<int>();
    PostOrder(root, result);
    return result;
}
```

### Main
```csharp
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
```

```csharp
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
```

### Вывод

```
Порядок вставки: 50, 30, 70, 20, 40, 60, 80
InOrder:   20, 30, 40, 50, 60, 70, 80
PreOrder:  50, 30, 20, 40, 70, 60, 80
PostOrder: 20, 40, 30, 60, 80, 70, 50
InOrder строго возрастает: True
```