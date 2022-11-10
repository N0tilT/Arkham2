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
            Console.Write("Введите количество булевых переменных [{0}...{1}]: ", MainLibrary.COUNT_MIN, MainLibrary.COUNT_MAX);

            if (!int.TryParse(Console.ReadLine(), out int count))
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }

            TestTruthTable(count);
            Console.ReadLine();
        }

        private static void TestTruthTable(int count)
        {
            Console.WriteLine("TestTruthTable({0}):", count);

            TruthTable table = new TruthTable(count);

            Console.WriteLine(table);

            Console.WriteLine("Negate:");
            Console.WriteLine(table.Negate());

            Console.WriteLine("Negate(0):");
            Console.WriteLine(table.Negate(0));

            Console.WriteLine("ROW(0):");
            Console.WriteLine(table.Row(0));

            Console.WriteLine("GRID(0):");
            Console.WriteLine(table.Grid(0));

            Console.WriteLine("OR:");
            Console.WriteLine(table.Or());
            Console.WriteLine("OR(0, 1):");
            Console.WriteLine(table.Or(0, 1));

            Console.WriteLine("AND:");
            Console.WriteLine(table.And());

            Console.WriteLine("AND(0, 1):");
            Console.WriteLine(table.And(0, 1));
        }
    }
}
