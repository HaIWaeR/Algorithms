# 1. Сортировка слиянием

```csharp
namespace SearchAndSorting
{
    public class MergeSortClass
    {
        public void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Marge(arr, left, mid, right);
        }

        public void Marge(int[] arr, int left, int mid, int right)
        {
            int[] leftPart = arr[left..(mid + 1)];
            int[] rightPart = arr[(mid + 1)..(right + 1)];

            int i = 0, j = 0, k = left;

            while (i < leftPart.Length && j < rightPart.Length)
            {
                if (leftPart[i] <= rightPart[j])
                {
                    arr[k] = leftPart[i];
                    i++;
                }
                else
                {
                    arr[k] = rightPart[j];
                    j++;
                }
                k++;
            }

            while (i < leftPart.Length)
            {
                arr[k] = leftPart[i];
                i++;
                k++;
            }

            while (j < rightPart.Length)
            {
                arr[k] = rightPart[j];
                j++;
                k++;
            }
        }
    }
}
```

## Вызов

```csharp
MergeSortClass mergeSort = new MergeSortClass();
int[] array1 = { 3, 6, 8, 1, 2, 5 };
int[] check1 = (int[])array1.Clone();

mergeSort.MergeSort(array1, 0, array1.Length - 1);
Array.Sort(check1);

Console.WriteLine(string.Join(" ", array1));
Console.WriteLine($"Совпадает с Array.Sort: {array1.SequenceEqual(check1)}");
```

## Вывод

```
1 2 3 5 6 8
Совпадает с Array.Sort: True
```

---

# 2. Быстрая сортировка

```csharp
namespace SearchAndSorting
{
    public class QuickSortClass
    {
        public void QuickSort(int[] arr, int low, int high)
        {
            if (low >= high) return;

            int pivontIndex = Partition(arr, low, high);

            QuickSort(arr, low, pivontIndex - 1);
            QuickSort(arr, pivontIndex + 1, high);
        }

        public int Partition(int[] arr, int low, int high)
        {
            int randomIndex = Random.Shared.Next(low, high + 1);
            (arr[randomIndex], arr[high]) = (arr[high], arr[randomIndex]);

            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
    }
}
```

## Вызов

```csharp
QuickSortClass quickSort = new QuickSortClass();
int[] array2 = { 3, 6, 8, 1, 2, 5 };
int[] check2 = (int[])array2.Clone();

quickSort.QuickSort(array2, 0, array2.Length - 1);
Array.Sort(check2);

Console.WriteLine(string.Join(" ", array2));
Console.WriteLine($"Совпадает с Array.Sort: {array2.SequenceEqual(check2)}");
```

## Вывод

```
1 2 3 5 6 8
Совпадает с Array.Sort: True
```

---

# 3. Бинарный поиск

```csharp
namespace SearchAndSorting
{
    public class BinarySearchClass
    {
        public int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target) return mid;

                if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
```

## Вызов

```csharp
int[] array3 = new int[20];
Random random = new Random();

for (int i = 0; i < array3.Length; i++)
{
    array3[i] = random.Next(1, 21);
}

Console.WriteLine($"До: {string.Join(" ", array3)}");
quickSort.QuickSort(array3, 0, array3.Length - 1);
Console.WriteLine($"После: {string.Join(" ", array3)}");

int target = array3[array3.Length / 2];
BinarySearchClass binarySearch = new BinarySearchClass();

int myIndex = binarySearch.BinarySearch(array3, target);
int refIndex = Array.BinarySearch(array3, target);

Console.WriteLine($"Ищем {target}");
Console.WriteLine($"Мой индекс: {myIndex}, Array.BinarySearch: {refIndex}");
```

## Вывод

```
До: 9 16 13 5 1 5 19 14 13 17 20 2 12 2 19 15 2 14 9 20
После: 1 2 2 2 5 5 9 9 12 13 13 14 14 15 16 17 19 19 20 20
Ищем 13
Мой индекс: 9, Array.BinarySearch: 9
```

---

# 4. Поиск границ диапазона

```csharp
namespace SearchAndSorting
{
    public class FindingRangeBoundariesClass
    {
        public int LowerBound(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        public int UpperBound(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] <= target)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        public int NaiveCount(int[] arr, int x)
        {
            int count = 0;

            foreach (int value in arr)
                if (value == x)
                    count++;

            return count;
        }
    }
}
```

## Вызов

```csharp
int[] array4 = { 10, 20, 20, 20, 20, 30 };
FindingRangeBoundariesClass findingRangeBoundaries = new FindingRangeBoundariesClass();

Console.WriteLine($"LowerBound(20) = {findingRangeBoundaries.LowerBound(array4, 20)} (ожидается 1)");
Console.WriteLine($"UpperBound(20) = {findingRangeBoundaries.UpperBound(array4, 20)} (ожидается 5)");
Console.WriteLine($"LowerBound(25) = {findingRangeBoundaries.LowerBound(array4, 25)} (ожидается 5)");
Console.WriteLine($"LowerBound(5)  = {findingRangeBoundaries.LowerBound(array4, 5)} (ожидается 0)");
Console.WriteLine($"UpperBound(100) = {findingRangeBoundaries.UpperBound(array4, 100)} (ожидается 6)");

for (int x = 5; x <= 35; x += 5)
{
    int fast = findingRangeBoundaries.UpperBound(array4, x) - findingRangeBoundaries.LowerBound(array4, x);
    int slow = findingRangeBoundaries.NaiveCount(array4, x);

    Console.WriteLine($"x = {x}: границы {fast}, вручную {slow}, совпало: {fast == slow}");
}
```

## Вывод

```
LowerBound(20) = 1 (ожидается 1)
UpperBound(20) = 5 (ожидается 5)
LowerBound(25) = 5 (ожидается 5)
LowerBound(5)  = 0 (ожидается 0)
UpperBound(100) = 6 (ожидается 6)
x = 5: границы 0, вручную 0, совпало: True
x = 10: границы 1, вручную 1, совпало: True
x = 15: границы 0, вручную 0, совпало: True
x = 20: границы 4, вручную 4, совпало: True
x = 25: границы 0, вручную 0, совпало: True
x = 30: границы 1, вручную 1, совпало: True
x = 35: границы 0, вручную 0, совпало: True
```