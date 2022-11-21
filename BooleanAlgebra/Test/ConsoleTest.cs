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
            //TestParser("A * ( B -> C ) + C <-> - A");
            //TestEvaluationTruthTable(3);
            //TestEvaluationInputFunction();
            //TestNormalForms();
            //TestSDNF();
            //TestSKNF();
            TestComparison();
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

        private static void TestNormalForms()
        {
            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();
            string function = "A + B";
            Console.WriteLine("TestNormalForms():");
            int n = parser.Counter(function);
            Console.WriteLine("Введите количество переменных: " + n);
            
            
            
            Console.WriteLine("Введите функцию: " + function);
            TruthTable table = new TruthTable(n);
            Console.WriteLine("Таблица истинности:");
            foreach (Sensor row in table.Table)
            {
                foreach (bool item in row.List)
                Console.Write(item == true ? "1" + " " : "0" + " "); Console.WriteLine();
            }

            Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);

            Console.WriteLine("Значение функции:");
            foreach (bool item in result.List) Console.Write(item == true ? "1" + " " : "0" + " ");
            Console.WriteLine();
            Console.WriteLine("СДНФ");
            Console.WriteLine(LogicalNormalForm.SDNF(table, result, parser.Parse(function)));
            Console.WriteLine("СКНФ");
            Console.WriteLine(LogicalNormalForm.SKNF(table, result, parser.Parse(function)));
            Console.ReadLine();
        }

        private static void TestSKNF()
        {
            Console.WriteLine("TestSKNF():");
            int n = 2;
            Console.WriteLine("Введите количество переменных: " + n);
            string function = "A -> B";
            Console.WriteLine("Введите функцию: " + function);
            TruthTable table = new TruthTable(n);
            Console.WriteLine("Таблица истинности:");
            foreach (Sensor row in table.Table)
            {
                foreach (bool item in row.List)
                    Console.Write(item == true ? "1" + " " : "0" + " "); Console.WriteLine();
            }

            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();

            Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);

            Console.WriteLine("Значение функции:");
            foreach (bool item in result.List) Console.Write(item == true ? "1" + " " : "0" + " ");
            Console.WriteLine();
            Console.WriteLine("СДНФ");
            Console.WriteLine(LogicalNormalForm.SDNF(table, result, parser.Parse(function)));
            Console.ReadLine();
        }

        private static void TestSDNF()
        {
            Console.WriteLine("TestSDNF():");
            int n = 2;
            Console.WriteLine("Введите количество переменных: " + n);
            string function = "A -> B";
            Console.WriteLine("Введите функцию: " + function);
            TruthTable table = new TruthTable(n);
            Console.WriteLine("Таблица истинности:");
            foreach (Sensor row in table.Table)
            {
                foreach (bool item in row.List)
                    Console.Write(item == true ? "1" + " " : "0" + " "); Console.WriteLine();
            }

            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();

            Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);

            Console.WriteLine("Значение функции:");
            foreach (bool item in result.List) Console.Write(item == true ? "1" + " " : "0" + " ");
            Console.WriteLine();
            Console.WriteLine("СКНФ");
            Console.WriteLine(LogicalNormalForm.SKNF(table, result, parser.Parse(function)));
            Console.ReadLine();
        }
        private static void TestComparison()
        {
            Console.WriteLine("TestComparison():");
            Console.WriteLine("Первое логическое выражение");
            LogicalParser parser = new LogicalParser();
            LogicalEvaluate eval = new LogicalEvaluate();
            string function = "A <-> B";
            int n = parser.Counter(function);
            Console.WriteLine("Введите количество переменных: " + n);

            Console.WriteLine("Введите функцию: " + function);
            TruthTable table = new TruthTable(n);
            Console.WriteLine("Таблица истинности:");
            foreach (Sensor row in table.Table)
            {
                foreach (bool item in row.List)
                    Console.Write(item == true ? "1" + " " : "0" + " "); Console.WriteLine();
            }

            Sensor result = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n), parser.Parse(function)).List);

            Console.WriteLine("Значение функции:");
            foreach (bool item in result.List) Console.Write(item == true ? "1" + " " : "0" + " ");
            Console.WriteLine();
            Console.WriteLine("СДНФ");
            Console.WriteLine(LogicalNormalForm.SDNF(table, result, parser.Parse(function)));
            Console.WriteLine("СКНФ");
            Console.WriteLine(LogicalNormalForm.SKNF(table, result, parser.Parse(function)));

            Console.WriteLine();
            Console.WriteLine("Второе логическое выражение");

            LogicalParser parser2 = new LogicalParser();
            LogicalEvaluate eval2 = new LogicalEvaluate();
            string function2 = "( A * B ) + ( - A * - B )";
            int n2 = parser.Counter(function2);
            Console.WriteLine("Введите количество переменных: " + n2);

            Console.WriteLine("Введите функцию: " + function2);
            TruthTable table2 = new TruthTable(n2);
            Console.WriteLine("Таблица истинности:");
            foreach (Sensor row2 in table2.Table)
            {
                foreach (bool item2 in row2.List)
                    Console.Write(item2 == true ? "1" + " " : "0" + " "); Console.WriteLine();
            }

            Sensor result2 = Sensor.Custom(eval.EvaluateTrurhTable(new TruthTable(n2), parser2.Parse(function2)).List);

            Console.WriteLine("Значение функции:");
            foreach (bool item2 in result2.List) Console.Write(item2 == true ? "1" + " " : "0" + " ");
            Console.WriteLine();
            Console.WriteLine("СДНФ");
            Console.WriteLine(LogicalNormalForm.SDNF(table2, result2, parser2.Parse(function2)));
            Console.WriteLine("СКНФ");
            Console.WriteLine(LogicalNormalForm.SKNF(table2, result2, parser2.Parse(function2)));
            Console.WriteLine("Сравнение: ");
            if (LogicalNormalForm.SDNF(table, result, parser.Parse(function))==LogicalNormalForm.SDNF(table2, result2, parser2.Parse(function2)) && LogicalNormalForm.SKNF(table, result, parser.Parse(function))==LogicalNormalForm.SKNF(table2, result2, parser2.Parse(function2)))
            {
                Console.WriteLine("Равны");
            }
            else
            {
                Console.WriteLine("Не равны");
            }
            Console.ReadLine();
        }
    }
}
