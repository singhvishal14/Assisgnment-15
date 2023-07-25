using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppAssisgnment15
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);

        }
        private static void QuickSort(int[] array1, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array1, left, right);
                QuickSort(array1, left, pivotIndex - 1);
                QuickSort(array1, pivotIndex + 1, right);

            }
        }
        private static int Partition(int[] array1, int left, int right)
        {
            int pivot = array1[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array1[j] < pivot)
                {
                    i++;
                    Swap(array1, i, j);
                }
            }
            Swap(array1, i + 1, right);
            return i + 1;


        }
        private static void Swap(int[] array1, int i, int j)
        {
            int temp = array1[i];
            array1[i] = array1[j];
            array1[j] = temp;
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
    
        public static void MergeSort(int[] arr2)
        {
            MergeSort(arr2, 0, arr2.Length - 1);
        }
        private static void MergeSort(int[] arr2, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr2, left, mid);
                MergeSort(arr2, mid + 1, right);
                Merge(arr2, left, mid, right);
            }
        }

        private static void Merge(int[] arr2, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr2, left, leftArray, 0, n1);
            Array.Copy(arr2, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr2[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr2[k] = rightArray[j];
                    j++;

                }
                k++;

            }
            while (i < n1)
            {
                arr2[k] = leftArray[i];
                i++;
                k++;

            }
            while (j < n2)
            {
                arr2[k] = rightArray[j];
                j++; k++;
            }
        }
        static void Main(string[] args)
        {
            int[] arr2 = { 38, 37, 27, 43, 3, 9, 82, 10 };
            Console.WriteLine("Original Array For MergeSort: " );
            Print(arr2);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MergeSort(arr2);
            stopwatch.Stop();
            Console.WriteLine("After MergeSort");
            Print(arr2);
            Console.WriteLine($"ArraySize {arr2.Length} Time Taken {stopwatch.Elapsed.Milliseconds} miliseconds");
            Console.WriteLine("==========================================================================================");


            
            int[] array = { -64, -34, -25, -12, -22, -11, -90 };
            Console.WriteLine("Original Array For QuickSort: ");
            Print(array);
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            QuickSort(array);
            stopwatch.Stop();
            Console.WriteLine("After QuickSort");
            Print(array);
            Console.WriteLine($"ArraySize {array.Length} Time Taken  {stopwatch.Elapsed.Milliseconds} miliseconds");
            Console.ReadKey();
        }
    }
}
