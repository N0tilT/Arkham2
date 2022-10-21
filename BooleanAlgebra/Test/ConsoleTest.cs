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
        }

        private static void TestTruthTable(int count)
        {
            Console.WriteLine("TestTruthTable({0}):", count);

            TruthTable table = new TruthTable(count);

            Console.WriteLine(table);
            Console.ReadLine();
        }
    }
}
