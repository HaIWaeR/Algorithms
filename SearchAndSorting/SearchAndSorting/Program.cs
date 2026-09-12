namespace SearchAndSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            // MarginSort
            MergeSortClass mergeSort = new MergeSortClass();
            int[] array1 = { 3, 6, 8, 1, 2, 5 };
            int[] check1 = (int[])array1.Clone();
            mergeSort.MergeSort(array1, 0, array1.Length -1);
            Console.WriteLine(string.Join(" ", array1));
            Console.WriteLine($"Совпадает с Array.Sort: {array1.SequenceEqual(check1)}");

            // --------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 11)}\n");
            
            // QuickSort

            QuickSortClass quickSort = new QuickSortClass();
            int[] array2 = { 3, 6, 8, 1, 2, 5 };
            int[] check2 = (int[])array1.Clone();

            quickSort.QuickSort(array2, 0, array2.Length - 1);
            Console.WriteLine(string.Join(" ", array2));
            Console.WriteLine($"Совпадает с Array.Sort: {array2.SequenceEqual(check2)}");

            // --------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 11)}\n");

            // BinarySearch
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

            // --------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 11)}\n");

            // FindingRangeBoundaries
            int[] array4 = { 10, 20, 20, 20, 20, 30};

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
        }
    }
}