using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCompare
{
        public static class DelegatCompareLogic
        {
            public static int CompareBySumString(int[] first, int[] second)
            {
                return first.Sum() - second.Sum();
            }
            public static int CompareByLengthString(int[] first, int[] second)
            {
                return first.Length - second.Length;
            }
            public static int CompareByMaxNumber(int[] first, int[] second)
            {
                return first.Max() - second.Max();
            }
        }
}
