using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCompare;

namespace CompareLogic
{
    public class CompareBySumString : ICompare
    {
        public int Compare(int[] firstNumber, int[] secondNumber)
        {
            if (firstNumber == null || secondNumber == null) throw new ArgumentNullException();
            return firstNumber.Sum() - secondNumber.Sum();
        }
    }

    public class CompareByMaxValue : ICompare
    {
        public int Compare(int[] firstNumber, int[] secondNumber)
        {
            if (firstNumber == null || secondNumber == null) throw new ArgumentNullException();
            return firstNumber.Max() - secondNumber.Max();
        }
    }

    public class CompareByMinValue : ICompare
    {
        public int Compare(int[] firstNumber, int[] secondNumber)
        {
            if (firstNumber == null || secondNumber == null) throw new ArgumentNullException();
            return firstNumber.Min() - secondNumber.Min();
        }
    }
}
