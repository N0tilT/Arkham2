using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Test
{
    internal class ConsoleTest
    {
        private static void Main(string[] args)
        {
            //Console.Write("Введите количество булевых переменных [{0}...{1}]: ", MainLibrary.COUNT_MIN, MainLibrary.COUNT_MAX);

            //if (!int.TryParse(Console.ReadLine(), out int count))
            //{
            //    Console.WriteLine("Некорректный ввод");
            //    return;
            //}

            //TestTruthTable(count);
            TestParser("A * ( B -> C ) + C <-> - A");
            //TestEvaluationTruthTable(3);
            //TestEvaluationInputFunction();
        }

        private static void TestTruthTable(int count)
        {
            Console.WriteLine("TestTruthTable({0}):", count);

            TruthTable table = new TruthTable(count);

            Console.WriteLine(table);
            Console.ReadLine();
        }

        private static void TestParser(string equation)
        {
            Console.WriteLine("TestParser({0}):", equation);

            LogicalParser parser = new LogicalParser();

            List<string> parsed = parser.Parse(equation);
            foreach (string item in parsed) Console.Write(item + " ");

            Console.ReadLine();

        }

        private static void TestEvaluationTruthTable(int n)
        {
            Console.WriteLine("TestEvaluationTruthTable({0}):", n);
            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();

            Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n),parser.Parse("A * ( B -> C ) + C <-> - A")).List);
            foreach (bool item in result.List) Console.Write(item + " ");

            Console.ReadLine();
        }

        private static void TestEvaluationInputFunction()
        {
            Console.WriteLine("TestEvaluationInputFunction():");
            Console.WriteLine("Введите количество переменных:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите функцию:");
            string function = Console.ReadLine();

            TruthTable table = new TruthTable(n);
            Console.WriteLine("Таблица истинности:");
            foreach (Sensor row in table.Table) { foreach (bool item in row.List) 
                    Console.Write(item==true?"1" + " ":"0" + " "); Console.WriteLine(); }

            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();

            Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);

            Console.WriteLine("Значение функции:");
            foreach (bool item in result.List) Console.Write(item == true ? "1" + " ": "0" + " ");

            Console.ReadLine();
        }

    }
}
