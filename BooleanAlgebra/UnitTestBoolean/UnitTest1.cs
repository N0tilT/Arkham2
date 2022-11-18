using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

            Assert.AreEqual("0 0\r\n" +
                            "0 1\r\n" +
                            "1 0\r\n" +
                            "1 1", table.ToString());

            table = new TruthTable(4);
            Assert.AreEqual("0 0 0 0\r\n" +
                            "0 0 0 1\r\n" +
                            "0 0 1 0\r\n" +
                            "0 0 1 1\r\n" +
                            "0 1 0 0\r\n" +
                            "0 1 0 1\r\n" +
                            "0 1 1 0\r\n" +
                            "0 1 1 1\r\n" +
                            "1 0 0 0\r\n" +
                            "1 0 0 1\r\n" +
                            "1 0 1 0\r\n" +
                            "1 0 1 1\r\n" +
                            "1 1 0 0\r\n" +
                            "1 1 0 1\r\n" +
                            "1 1 1 0\r\n" +
                            "1 1 1 1", table.ToString());

            table = new TruthTable(1);
            Assert.AreEqual("0\r\n" +
                            "1", table.ToString());


        }

        [TestMethod]
        public void TestTruthTable_Negate()
        {

            TruthTable table = new TruthTable(1);
            Assert.AreEqual("1 0", table.Negate(0).ToString());

            table = new TruthTable(2);
            Assert.AreEqual("1 1 0 0 | 1 0 1 0", (table.Negate(0).ToString() + " | " + table.Negate(1).ToString()));
        }

        //[TestMethod]
        public void TestTruthTableTime()
        {
            TruthTable table = new TruthTable(26); //3,6 мин
        }

        public string PrintD(List<string> d)
        {
            string str = "";
            for (int i = 0; i < d.Count; i++)
            {
                str += d[i] + " ";
            }

            return str;
        }
        public string PrintD(string d)
        {
            string str = "";
            for (int i = 0; i < d.Length; i++)
            {
                str += d[i];
            }

            return str;
        }

        [TestMethod]
        public void TestParser()
        {
            LogicalParser parser = new LogicalParser();
            Assert.AreEqual("A B + ", PrintD(parser.Parse("A + B")));
            Assert.AreEqual("A B -> ", PrintD(parser.Parse("A -> B")));
            Assert.AreEqual("A - B - + ", PrintD(parser.Parse("- A + - B")));
            Assert.AreEqual("A C + ", PrintD(parser.Parse("A + C")));
            Assert.AreEqual("A B + С + ", PrintD(parser.Parse("A + B + С")));
            Assert.AreEqual("A B C - * A + C * + ", PrintD(parser.Parse("A + ( B * - C + A ) * C")));
            Assert.AreEqual("X Y Z + - F * ", PrintD(parser.Parse("X - ( Y + Z ) * F")));
            Assert.AreEqual("- A - ", PrintD(parser.Parse("- - A")));
            Assert.AreEqual("A - - ", PrintD(parser.Parse("- ( - A )")));
            Assert.AreEqual("X Y Z + <-> ", PrintD(parser.Parse("X <-> Y + Z")));
            Assert.AreEqual("A B <-> ", PrintD(parser.Parse("A <-> B")));
            Assert.AreEqual("A B + C D + E - * ", PrintD(parser.Parse("( A + B ) * ( C + D ) - E"))); //A B + C D + * E - * \ A B + C D + * E -
        }

        [TestMethod]
        public void TestNF()
        {
            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();
            string f1 = "A + B";
            string f2 = "A + ( B * - C + A ) * C";
            string f3 = "- ( - A )";

            Assert.AreEqual("( - A * B ) + ( A * - B ) + ( A * B )", 
                PrintD(LogicalNormalForm.SDNF(
                new TruthTable(2),
                Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(2), parser.Parse(f1)).List), 
                parser.Parse(f1))));
            Assert.AreEqual("( A + B )", 
                PrintD(LogicalNormalForm.SKNF(
                new TruthTable(2),
                Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(2), parser.Parse(f1)).List), 
                parser.Parse(f1))));

            Assert.AreEqual("( A * - B * - C ) + ( A * - B * C ) + ( A * B * - C ) + ( A * B * C )", 
                PrintD(LogicalNormalForm.SDNF(
                new TruthTable(3),
                Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(3), parser.Parse(f2)).List), 
                parser.Parse(f2))));
            Assert.AreEqual("( A + B + C ) * ( A + B + - C ) * ( A + - B + C ) * ( A + - B + - C )", 
                PrintD(LogicalNormalForm.SKNF(
                new TruthTable(3),
                Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(3), parser.Parse(f2)).List), 
                parser.Parse(f2))));

            Assert.AreEqual("( A )",
                PrintD(LogicalNormalForm.SDNF(
                new TruthTable(1),
                Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(1), parser.Parse(f3)).List),
                parser.Parse(f3))));
            Assert.AreEqual("( A )",
                PrintD(LogicalNormalForm.SKNF(
                new TruthTable(1),
                Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(1), parser.Parse(f3)).List),
                parser.Parse(f3))));
        }

    }
}

