using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCompare;
using DelegateCompare;

namespace SortMatrix
{
    public static  class Matrix
    {

        #region Interface Sort
        public static void Sort(int[][] array, ICompare compare)
        {
            if (array == null || compare == null)
            {
                throw new ArgumentNullException();
            }
            bool swaped;
            for (int i = 0; i < array.Length; i++)
            {
                swaped = false;
                for (int y = 0; y < array.Length - 1; y++)
                {
                    if (compare.Compare(array[y], array[y + 1]) > 0)
                    {
                        Swap(array, y, y + 1);
                        swaped = true;
                    }
                }
                if (!swaped) break;
            }
        } 
        #endregion

        #region Delegate Sort
        public static void SortDelegat(int[][] array, Func<int[], int[], int> compare)
        {
             Sort(array, new CompareAdapter(compare));
        } 
        #endregion


        private class CompareAdapter : ICompare
        {
            private Func<int[], int[], int> compare = null;

            public CompareAdapter(Func<int[], int[], int> compare)
            {
                this.compare = compare;
            }

            public int Compare(int[] firstNumber, int[] secondNumber)
            {
                return Compare(firstNumber, secondNumber, compare);
            }
            private int Compare(int[] firstNumber, int[] secondNumber, Func<int[], int[], int> compare)
            {
                return compare(firstNumber, secondNumber);
            }
        }

        /// <summary>
        /// Swaps the elements of the array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void Swap(int[][] array, int left, int right)
        {
            int[] temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

    }

}
