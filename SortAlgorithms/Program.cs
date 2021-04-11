using System;

namespace SortAlgorithms
{
    class Program
    {
        //Best	Average	Worst: Ω(n^2)	Θ(n^2)	O(n^2)
        public static int[] SelectionSort(int[] A, int n)
        {
            for (int i = 0; i < n - 2; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (A[j] < A[iMin])
                    {
                        iMin = j;
                    }
                }
                Swap(ref A[i], ref A[iMin]);
            }

            return A;
        }

        //Best	Average	Worst: Ω(n)	Θ(n^2)	O(n^2)
        public static int[] BubbleSort(int[] A, int n)
        {
            for (int k = 1; k < n - 1; k++)
            {
                int flag = 0;
                for (int i = 0; i <= n - k - 1; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        Swap(ref A[i], ref A[i + 1]);
                        flag = 1;
                    }
                }
                if (flag == 0) break;
            }
            return A;
        }
        //Best	Average	Worst: Ω(n)	Θ(n^2)	O(n^2)
        public static int[] InsertSort(int[] A, int n)
        {
            for (int i = 1; i < n - 1; i++)
            {
                var value = A[i];
                var hole = i;
                while (hole > 0 && (A[hole - 1] > value))
                {
                    A[i] = A[hole - 1];
                    hole = hole - 1;
                }
                A[hole] = value;
            }
            return A;
        }
        //Best	Average	Worst: Ω(n log(n))	Θ(n log(n))	O(n log(n))
        public static void Merge(int[] A, int[] L, int leftCount, int[] R, int rightCount)
        {
            int i, j, k;
            i = 0; j = 0; k = 0;
            while (i < leftCount && j < rightCount)
            {
                if (L[i] < R[j])
                {
                    A[k++] = L[i++];
                }
                else
                {
                    A[k++] = R[j++];
                }
            }
            while (i < leftCount) A[k++] = L[i++];
            while (j < rightCount) A[k++] = R[j++];
        }
        //Best	Average	Worst: Ω(n^2)	Θ(n^2)	O(n^2)
        public static int[] MergeSort(int[] A, int n)
        {
            int mid, i;
            if (n < 2) return A;
            mid = n / 2;
            int[] L = new int[mid];
            int[] R = new int[n - mid];
            for (i = 0; i < mid; i++) L[i] = A[i];
            for (i = mid; i < n; i++) R[i - mid] = A[i];

            MergeSort(L, mid);
            MergeSort(R, n - mid);
            Merge(A, L, mid, R, n - mid);

            return A;
        }

        //Best	Average	Worst: Ω(n log(n)) Θ(n log(n)) O(n^2)
        public static int[] QuickSort(int[] A, int start, int end)
        {
            if(start < end)
            {
                var pIndex = Partition(A, start, end);
                QuickSort(A, start, pIndex - 1);
                QuickSort(A, pIndex + 1, end);
            }
           
            return A;
        }
        public static int Partition(int[] A, int start, int end)
        {
            var pivot = A[end];
            var pIndex = start;
            for (int i = start; i < end-1; i++)
            {
                if (A[i] <= pivot)
                {
                    Swap(ref A[i], ref A[pIndex]);
                    pIndex++;
                }
            }
            Swap(ref A[pIndex], ref A[end]);
            return pIndex;
        }

        static void Main(string[] args)
        {
            int[] inputArr = MakeArray();
            var watch = new System.Diagnostics.Stopwatch();
            Console.WriteLine();

            Console.WriteLine("----Selection: ");
            watch.Start();
            int[] sortedBySelection = SelectionSort(inputArr, inputArr.Length);
            watch.Stop();
            Console.WriteLine($"Time to sorted: {watch.ElapsedMilliseconds}ms. <================");
            Console.WriteLine();

            Console.WriteLine("----Bubble: ");
            watch.Start();
            int[] sortedByBubble = BubbleSort(inputArr, inputArr.Length);
            watch.Stop();
            Console.WriteLine($"Time to sorted: {watch.ElapsedMilliseconds}ms. <================");
            Console.WriteLine();

            Console.WriteLine("----Insert Sort: ");
            watch.Start();
            int[] sortedByInsert = InsertSort(inputArr, inputArr.Length);
            watch.Stop();
            Console.WriteLine($"Time to sorted: {watch.ElapsedMilliseconds}ms. <================");
            Console.WriteLine();

            Console.WriteLine("----Merge Sort: ");
            watch.Start();
            int[] sortedByMerge = MergeSort(inputArr, inputArr.Length);
            watch.Stop();
            Console.WriteLine($"Time to sorted: {watch.ElapsedMilliseconds}ms. <================");
            Console.WriteLine();

            Console.WriteLine("----Quick Sort: ");
            watch.Start();
            int[] sortedByQuick = QuickSort(inputArr, 0, inputArr.Length-1);
            watch.Stop();
            Console.WriteLine($"Time to sorted: {watch.ElapsedMilliseconds}ms. <================");

            Console.ReadKey();
        }

        public static void PrintResult(int[] A)
        {
            string resultStr = string.Join(" ", A);
            Console.WriteLine("Array is: {0}", resultStr);
        }
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static int[] MakeArray()
        {
            Console.WriteLine("Please length of the original array: ");
            int n = Int32.Parse(Console.ReadLine());
            int[] arrOutput = new int[n];
            for (int i = 0; i < n; i++)
            {
                Random random = new Random();
                int numberRandom = random.Next(0, 1000000);
                arrOutput[i] = numberRandom;
            }

            return arrOutput;
        }
    }
}
