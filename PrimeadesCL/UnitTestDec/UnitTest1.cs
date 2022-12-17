using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PrimeadesCL;

namespace UnitTestDec
{
    [TestClass]
    public class UnitTest
    {


        [TestMethod]
        public void TestArrayFiller()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }

        [TestMethod]
        public void TestCountPrimesOnSegment()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }

        [TestMethod]
        public void TestSegment()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }

        [TestMethod]
        public void TestSplitPrimes()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }

        [TestMethod]
        public void TestSGetDividers()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }


        [TestMethod]
        public void TestdoEratosfen()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }

        [TestMethod]
        public void TestEratosfenHandleArray()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }

        [TestMethod]
        public void TestStep()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));

        }        
        
        [TestMethod]
        public void TestProggram()
        {
            Assert.AreEqual("9 1 1 4 ", ForTest.WorkPrimes(100));
            //Assert.AreEqual("89 0 0 5 ", ForTest.WorkPrimes(1000));
            //Assert.AreEqual("12338 0 0 5 ", ForTest.WorkPrimes(123456));
            //Assert.AreEqual("999998 0 0 5 ", ForTest.WorkPrimes(10000000));
            //Assert.AreEqual("9995 0 0 5 ", ForTest.WorkPrimes(99998));
            //Assert.AreEqual("0 5 0 5 ", ForTest.WorkPrimes(12));
            //Assert.AreEqual("8 2 0 5 ", ForTest.WorkPrimes(97));
            //Assert.AreEqual("8 2 0 5 ", ForTest.WorkPrimes(90));
            //Assert.AreEqual("18 1 0 5 ", ForTest.WorkPrimes(200));
            //Assert.AreEqual("114 0 0 5 ", ForTest.WorkPrimes(1234));

        }
    }
}
