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