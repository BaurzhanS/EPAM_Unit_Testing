using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAMUnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAMUnitTests.Tests
{
    [TestClass()]
    public class BasicCodingTests
    {
        [TestMethod]
        public void InsertNumberTest1()
        {
            Assert.AreEqual(BasicCoding.InsertNumber(15, 15, 0, 0), 15);
        }

        [TestMethod]
        public void InsertNumberTest2()
        {
            Assert.AreEqual(BasicCoding.InsertNumber(8, 15, 0, 0), 9);
        }

        [TestMethod]
        public void InsertNumberTest3()
        {
            Assert.AreEqual(BasicCoding.InsertNumber(8, 15, 3, 8), 120);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberTestArgumentExceptionTest()
        {
            BasicCoding.InsertNumber(8, 15, 8, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberTestArgumentOutOfRangeExceptionTest1()
        {
            BasicCoding.InsertNumber(8, 15, 32, 33);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberTestArgumentOutOfRangeExceptionTest2()
        {
            BasicCoding.InsertNumber(8, 15, 3, 32);
        }

        [TestMethod]
        public void getMaxTest()
        {
            int[] arr = {12,23,45,32,31,55,7,33,14 };
            Assert.AreEqual(BasicCoding.getMax(arr, 0),55);
        }

        [TestMethod]
        public void findElementTest()
        {
            int[] arr = { 1,2,3,6,4,2 };
            Assert.AreEqual(BasicCoding.findElement(arr), 3);
        }

        [TestMethod]
        public void getLatinLettersTest()
        {
            Assert.AreEqual(BasicCoding.getLatinLetters("AAAAaaaaBBBbbbУУУУУкккк", "AAAAaaaaBBBbbbУУУУУкккк"), "AaBb");
        }


        [TestMethod]
        public void FindingNumbersTest()
        {
            long delay = 0;
            Assert.AreEqual(BasicCoding.FindNextBiggerNumber(12,out delay),21);
        }

        [TestMethod]
        public void FilterDigitTest()
        {
            int[] list = { 7, 1, 2, 3, 4, 5, 6, 8, 68, 70, 15, 17 };
            list = BasicCoding.FilterDigit(list,7);
            int[] resultList = { 7, 70, 17 };
            for (int i = 0; i < list.Length; i++)
            {
                Assert.AreEqual(list[i], resultList[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterDigitTestArgumentExceptionTest()
        {
            int[] list = new int[0];
            BasicCoding.FilterDigit(list,8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigitTestArgumentOutOfRangeExceptionTest2()
        {
            int[] list = { 7, 1, 2, 3, 4, 5, 6, 8, 68, 70, 15, 17 };
            BasicCoding.FilterDigit(list,12);
        }
    }
}