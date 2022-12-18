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
        /// <summary>
        /// Создание списка чисел, используемого в тестах
        /// </summary>
        static List<int> NumsArray = new List<int>();
        /// <summary>
        /// Основыной метод, из которого вызваются функции, отвечающие за тестирования
        /// отдельных элементов программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество рассматриваемых чисел N и отрезок segment");
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
        /// <summary>
        /// Тестирование функции подсчета простых чисел на отрезке
        /// </summary>
        /// <param name="numsArray">Список чисел</param>
        /// <param name="Segment">Длина рассматриваемых отрезков</param>
        private static void TestCountPrimesOnSegment(List<int> numsArray,int Segment)
        {
            Console.WriteLine("Количество простых чисел на отрезке");
            Console.WriteLine(PrintArray(ArrayHandler.CountPrimesOnSegment(numsArray, Segment)));
        }
        /// <summary>
        /// Тестирование функции поиска делителей числа
        /// </summary>
        /// <param name="q">число</param>
        private static void TestDividers(int q)
        {
            Console.WriteLine("Делители числа");
            Console.WriteLine(PrintArray(Primes.GetDividers(q)));
        }
        /// <summary>
        /// Тестирования функции определения отрезка максимальной длины бех простых чисел
        /// </summary>
        /// <param name="numsArray"></param>
        private static void TestSegment(List<int> numsArray)
        {
            Console.WriteLine("Рассматриваемы отрезок:");
            Console.WriteLine(PrintArray(ArrayHandler.Segment(numsArray)));
        }
        /// <summary>
        /// Тестрование функции нахождения максимальных отрезков чисел
        /// с максимальным и минимальным количеством простых чисел
        /// </summary>
        /// <param name="numsArray">Список чисел</param>
        /// <param name="segment">Длина рассматриваемых отрезков</param>
        private static void TestSplitPrimes(List<int> numsArray, int segment)
        {
            Console.WriteLine("Минимальный отрезок - кол. элементов, максимальный отрезок - кол. элементов");
            Console.WriteLine(PrintArray(ArrayHandler.SplitPrimes(numsArray, segment)));
        }
        /// <summary>
        /// Тестирование метода решета Эратосфена
        /// </summary>
        /// <param name="numsArray">Список чисел</param>
        private static void TestEratosfen(List<int> numsArray)
        {
            Console.WriteLine("результат применения метода Решето Эратосфена");
            Console.WriteLine(PrintArray(Primes.doEratosfen(numsArray)));
        }
        /// <summary>
        /// Тестирование функции заполнения массива
        /// </summary>
        /// <param name="N">Количество элементов массива</param>
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
