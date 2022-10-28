using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace UnitTestBoolean
{
    [TestClass]
    public class TruthTableUnitTest
    {
        [TestMethod]
        public void TestTruthTableBools()
        {
            TruthTable table = new TruthTable(2);

            Assert.AreEqual("0 0 \n" +
                            "0 1 \n" +
                            "1 0 \n" +
                            "1 1", table.ToString());

            table = new TruthTable(4);
            Assert.AreEqual("0 0 0 0\n" +
                            "0 0 0 1\n" +
                            "0 0 1 0\n" +
                            "0 0 1 1\n" +
                            "0 1 0 0\n" +
                            "0 1 0 1\n" +
                            "0 1 1 0\n" +
                            "0 1 1 1\n" +
                            "1 0 0 0\n" +
                            "1 0 0 1\n" +
                            "1 0 1 0\n" +
                            "1 0 1 1\n" +
                            "1 1 0 0\n" +
                            "1 1 0 1\n" +
                            "1 1 1 0\n" +
                            "1 1 1 1", table.ToString());

            table = new TruthTable(1);
            Assert.AreEqual("0\n" +
                            "1", table.ToString());


        }
        /*
        [TestMethod]
        public void TestTruthTable_Negate()
        {
            
            TruthTable table = new TruthTable(1).Negate();
            Assert.AreEqual("0\n" +
                            "1", table.Negate().ToString()); // 0 1 | 0 1 | 0 0 | 0 1 0 0 | 0 1 0 1 |0 1 1 0 | 0 1 1 1 |1 0 0 0 |1 0 0 1 |1 0 1 0 |1 0 1 1 |1 1 0 0 |1 1 0 1 |1 1 1 0 |1 1 1 1
            
            table = new TruthTable(2);
            Assert.AreEqual("1 1\n" +
                            "1 0\n" +
                            "0 1\n" +
                            "0 0", table.Negate().ToString()); // 1 1 |1 0 |0 1 |0 0 |0 1 0 0 |0 1 0 1 |0 1 1 0 |0 1 1 1 |1 0 0 0 |1 0 0 1 |1 0 1 0 |1 0 1 1 |1 1 0 0 |1 1 0 1 |1 1 1 0 |1 1 1 1 
        }

        [TestMethod]
        public void TestTruthTable_AndOr()
        {
            TruthTable table = new TruthTable(2);
            Assert.AreEqual("0 0 0 0", table.And().ToString());
            Assert.AreEqual("0 0 0 0", table.Or().ToString());
            table = new TruthTable(1);
            Assert.AreEqual("0 0", table.And().ToString());
            Assert.AreEqual("0 0", table.Or().ToString());
            table = new TruthTable(4);
            Assert.AreEqual("0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0", table.And().ToString()); //?
        }
        */
    }
}

