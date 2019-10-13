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
    public class MethodsInDetails
    {
        [TestMethod]
        public void ToByteStringTest()
        {
            Assert.AreEqual(DoubleExtensions.ToByteString(-255.255), "1100000001101111111010000010100011110101110000101000111101011100");
        }

        [TestMethod]
        public void SearchByEuclidTest1()
        {
            Assert.AreEqual(GCDSearch.SearchByEuclid(18,12), 6);
        }

        [TestMethod]
        public void SearchByEuclidTest2()
        {
            Assert.AreEqual(GCDSearch.SearchByEuclid(1000, 975, 250), 25);
        }

        [TestMethod]
        public void SearchByEuclidTest3()
        {
            Assert.AreEqual(GCDSearch.SearchByEuclid(18, -12, 24, 36), 6);
        }

        [TestMethod]
        public void getNullReferenceTest1()
        {
            int? number = null;
            Assert.AreEqual(NullExtensions.getNullReference(number), true);
        }

        [TestMethod]
        public void getNullReferenceTest2()
        {
            int number = 10;
            Assert.AreEqual(NullExtensions.getNullReference(number), false);
        }

        [TestMethod]
        public void getNullReferenceTest3()
        {
            string word = "Welcome to EPAM";
            Assert.AreEqual(NullExtensions.getNullReference(word), false);
        }
    }

}