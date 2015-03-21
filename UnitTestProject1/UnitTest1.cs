using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortMatrix;
using InterfaceCompare;
using System.Linq;
using CompareLogic;
using DelegateCompare;


namespace UnitTestProject1
{
    [TestClass]
    public class SortArrayUnitTest
    {
        [TestMethod]
        public void InterfaceSortBySumStringTestMethod1()
        {
            int[][] array = new int[4][];
            array[0] = new int[] { 12, 8, 5 };
            array[1] = new int[] { 5, 2, 7, 2 };
            array[2] = new int[] { 1, 9 };
            array[3] = new int[] { 6, 3 };
            Matrix.Sort(array, new CompareBySumString());
            CollectionAssert.AreEqual(new int[] {6,3 }, array[0]);
        }

        [TestMethod]
        public void DelegateSortBySumStringTestMethod2()
        {
            int[][] array = new int[4][];
            array[0] = new int[] { 12, 8, 5 };
            array[1] = new int[] { 5, 2, 7, 2 };
            array[2] = new int[] { 1, 9 };
            array[3] = new int[] { 6, 3 };
            Matrix.SortDelegat(array, DelegatCompareLogic.CompareBySumString);
            CollectionAssert.AreEqual(new int[] { 6, 3 }, array[0]);
        }

        [TestMethod]
        public void InterfaceSortByMaxValueTestMethod1()
        {
            int[][] array = new int[4][];
            array[0] = new int[] { 12, 8, 5 };
            array[1] = new int[] { 5, 2, 7, 2 };
            array[2] = new int[] { 1, 9 };
            array[3] = new int[] { 6, 3 };
            Matrix.Sort(array, new CompareByMaxValue());
            CollectionAssert.AreEqual(new int[] { 6,3 }, array[0]);
        }

        [TestMethod]
        public void DelegateSortByMaxValueTestMethod2()
        {
            int[][] array = new int[4][];
            array[0] = new int[] { 12, 8, 5 };
            array[1] = new int[] { 5, 2, 7, 2 };
            array[2] = new int[] { 1, 9 };
            array[3] = new int[] { 6, 3 };
            Matrix.SortDelegat(array, DelegatCompareLogic.CompareByMaxNumber);
            CollectionAssert.AreEqual(new int[] { 6, 3 }, array[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExeptionTestMethod()
        {
            int[][] array = null;
            Matrix.Sort(array, new CompareByMaxValue());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExeptionTestMethod2()
        {
            int[][] array = new int[4][];
            array[0] = new int[] { 12, 8, 5 };
            array[1] = new int[] { 5, 2, 7, 2 };
            array[2] = null;
            array[3] = new int[] { 6, 3 };
            Matrix.Sort(array, new CompareByMaxValue());
        }
    }
}
