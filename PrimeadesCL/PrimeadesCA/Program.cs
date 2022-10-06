using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeadesCL;

namespace PrimeadesCA
{
    class Program
    {
        static List<int> NumsArray = new List<int>();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число N и segment");
            int N = int.Parse(Console.ReadLine());
            int segment = int.Parse(Console.ReadLine());

            TestArrayFiller(N);

            TestEratosfen(NumsArray);

            TestCountPrimesOnSegment(NumsArray,segment);

            TestSplitPrimes(NumsArray, segment);

            TestSegment(NumsArray);


            Console.WriteLine("Введите число N для определения делителей");
            int Q = int.Parse(Console.ReadLine());

            TestDividers(Q);


            Console.ReadKey();
        }

        private static void TestCountPrimesOnSegment(List<int> numsArray,int Segment)
        {
            Console.WriteLine("CountPrimesOnSegment()");
            Console.WriteLine(PrintArray(ArrayHandler.CountPrimesOnSegment(numsArray, Segment)));
        }

        private static void TestDividers(int q)
        {
            Console.WriteLine("GetDividers()");
            Console.WriteLine(PrintArray(Primes.GetDividers(q)));
        }

        private static void TestSegment(List<int> numsArray)
        {
            Console.WriteLine("Segment()");
            Console.WriteLine(PrintArray(ArrayHandler.Segment(numsArray)));
        }

        private static void TestSplitPrimes(List<int> numsArray, int segment)
        {
            Console.WriteLine("SplitPrimes()");
            Console.WriteLine(PrintArray(ArrayHandler.SplitPrimes(numsArray, segment)));
        }

        private static void TestEratosfen(List<int> numsArray)
        {
            Console.WriteLine("doEratosfen()");
            Console.WriteLine(PrintArray(Primes.doEratosfen(numsArray)));
        }

        private static void TestArrayFiller(int N)
        {
            NumsArray = ArrayHandler.ArrayFiller(N);
        }

        /// <summary>
        /// Функция преобразования списка в строку чисел через пробел
        /// </summary>
        /// <param name="array">преобразуемый список</param>
        /// <returns>Строку - список целых чисел через пробел</returns>
        private static string PrintArray(List<int> array)
        {
            string StrArray = "";
            foreach (int element in array) StrArray += element + " ";
            return StrArray;
        }
    }
}
