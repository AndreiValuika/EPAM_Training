﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Valuika._01_Console
{
    public class Sort
   {
        /// <summary>
        /// Sort an array of integers using the "quicksort" algorithm.
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        /// <summary>
        /// Sort an array of integers using the "mergesort" algorithm.
        /// </summary>
        /// <param name="array"></param>
        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private static int Partition(int[] array, int left, int right)
        {
            {
                var pivot = left - 1;
                for (var i = left; i < right; i++)
                {
                    if (array[i] < array[right])
                    {
                        pivot++;
                        int temp1 = array[pivot];
                        array[pivot] = array[i];
                        array[i] = temp1;
                    }
                }

                pivot++;
                int temp = array[pivot];
                array[pivot] = array[right];
                array[right] = temp;

                return pivot;
            }
        }

        private static int[] QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return array;
            }

            int pivotIndex = Partition(array, left, right);
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);

            return array;
        }

        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            int left = lowIndex;
            int right = middleIndex + 1;
            int[] tempArray = new int[highIndex - lowIndex + 1];
            int index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (int i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (int i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (int i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        private static void MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }
        }
    }

    class Program
    {
        static int[] GetRandomArray(int lenght) 
        {
            int[] testArray = new int[lenght];
            Random random = new Random();

            for (int i = 0; i < lenght; i++)
            {
                testArray[i] = random.Next(100);
            }
            return testArray;
        }

        static void ShowArray(int[] array) 
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }

        static void Main(string[] args)
        {
            int[] testArray_quick = GetRandomArray(10);
            Console.WriteLine("Random Array: ");
            ShowArray(testArray_quick);
            Console.WriteLine();
            Sort.QuickSort(testArray_quick);
            Console.WriteLine("Quick Sort Array: ");
            ShowArray(testArray_quick) ;
            
            Console.WriteLine();
            Console.WriteLine();

            int[] testArray_merge = GetRandomArray(15);
            Console.WriteLine("Random Array: ");
            ShowArray(testArray_merge);
            Console.WriteLine();
            Sort.MergeSort(testArray_merge);
            Console.WriteLine("Merge Sort Array: ");
            ShowArray(testArray_merge);

            Console.ReadKey();
        }
    }
}

