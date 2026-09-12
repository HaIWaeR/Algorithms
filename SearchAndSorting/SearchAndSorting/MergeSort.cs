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

            while(i < leftPart.Length)
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