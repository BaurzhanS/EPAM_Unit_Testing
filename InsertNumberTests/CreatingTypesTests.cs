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
    public class CreatingTypesTests
    {
        [TestMethod]
        public void FindNthRootTest1()
        {
            Assert.AreEqual(CreatingTypes.FindNthRoot(1, 5, 0.0001), 1);
        }

        [TestMethod]
        public void FindNthRootTest2()
        {
            Assert.AreEqual(CreatingTypes.FindNthRoot(-0.008, 3, 0.1), -0.2);
        }

        [TestMethod]
        public void SortBySumOfTheElementsTest()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 4, 2, 5, 6, 120 };
            numbers[1] = new int[] { 5, 3, 1, 7, 12, 4, 2, 5 };
            numbers[2] = new int[] { 12, 1, 4, 23, 5, 8 };

            int[][] sorted = new int[3][];
            sorted[0] = new int[] { 4, 2, 5, 6, 120 };
            sorted[1] = new int[] { 5, 3, 1, 7, 12, 4, 2, 5 };
            sorted[2] = new int[] { 12, 1, 4, 23, 5, 8 };

            int[][] result = new int[3][];
            result[0] = new int[] { 4, 2, 5, 6, 120 };
            result[1] = new int[] { 12, 1, 4, 23, 5, 8 };
            result[2] = new int[] { 5, 3, 1, 7, 12, 4, 2, 5 };


            CreatingTypes.SortBySumOfTheElements(sorted);

            for (int i = 0; i < sorted.Length; i++)
            {
                for (int j = 0; j < sorted[i].Length; j++)
                {
                    Assert.AreEqual(sorted[i][j], result[i][j]);
                }
            }
        }

        [TestMethod]
        public void SortByMaximumOfTheElementsTest()
        {
            int[][] numbers = new int[3][];
            numbers[0] = new int[] { 4, 2, 5, 6, 120 };
            numbers[1] = new int[] { 5, 3, 1, 7, 12, 4, 2, 5 };
            numbers[2] = new int[] { 12, 1, 4, 23, 5, 8 };

            int[][] sorted = new int[3][];
            sorted[0] = new int[] { 4, 2, 5, 6, 120 };
            sorted[1] = new int[] { 5, 3, 1, 7, 12, 4, 2, 5 };
            sorted[2] = new int[] { 12, 1, 4, 23, 5, 8 };

            int[][] result = new int[3][];
            result[0] = new int[] { 4, 2, 5, 6, 120 };
            result[1] = new int[] { 12, 1, 4, 23, 5, 8 };
            result[2] = new int[] { 5, 3, 1, 7, 12, 4, 2, 5 };


            CreatingTypes.SortByMaximumOfTheElements(sorted);

            for (int i = 0; i < sorted.Length; i++)
            {
                for (int j = 0; j < sorted[i].Length; j++)
                {
                    Assert.AreEqual(sorted[i][j], result[i][j]);
                }
            }
        }
    }
}