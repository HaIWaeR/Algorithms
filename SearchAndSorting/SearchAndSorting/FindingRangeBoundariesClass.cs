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
                    right = mid ;
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
                    right = mid ;
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