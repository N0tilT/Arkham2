using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrimeadesCL
{

    /// <summary>
    /// Класс обработки массива.
    /// Содержит функции заполнения массива и нахождения максимальных десятков 
    /// с максимальным и минимальным количеством простых чисел
    /// </summary>
    public class ArrayHandler
    {
        /// <summary>
        /// Функция заполнения списка целыми числами от 1 до N
        /// </summary>
        /// <param name="N">Входное число, последнее в списке</param>
        /// <returns>Список целых чисел от 1 до N</returns>
        public static List<int> ArrayFiller(int N)
        {
            List<int> array = new List<int>();

            //Формирование массива целых чисел 1..N
            for (int i = 1; i <= N; i++)
            {
                array.Add(i);
            }
            array[0] = 0;
            return array;
        }
        
        /// <summary>
        /// Функция подсчёта простых чисел на сегменте
        /// </summary>
        /// <param name="Primes">Список целых чисел, в котором непростые заменены на ноль</param>
        /// <param name="Segment">рассматриваемый сегмент чисел</param>
        /// <returns>Список, индексы которого обозначают номер сегмента,
        /// а значение - количество простых чисел на нём.</returns>
        public static List<int> CountPrimesOnSegment(List<int> Primes,int Segment)
        {
            List<int> Answer = new List<int>() {0}; //Индекс - номер сегмента, значение - количество простых на сегменте
            int index = 0;
            for (int i = 0; i < Primes.Count; i++)
            {
                if (Primes[i] != 0)
                    Answer[index]++;

                if ((i+1) % Segment == 0)
                {
                    index++;
                    Answer.Add(0);
                }
                
            }


            return Answer;
        }

        /// <summary>
        /// Функция определения отрезка максимальной длины, в котором нет простых чисел
        /// </summary>
        /// <param name="NewArray"> Список целых чисел, в котором непростые числа заменены на ноль</param>
        /// <returns>Список, содержащий информацию об отрезке
        /// [0 Первое число отрезка
        /// 1 Последнее число отрезка
        /// 2 Количество чисел между первым и последним числом отрезка]
        /// </returns>
        public static List<int> Segment(List<int> NewArray)
        {
            //sigma[первое простое число, второе простое число, длина отрезка]
            List<int> sigma = new List<int> { 0, 0, 0 };
            int CurLen, FirstNumIndex=0;
            //Считаем расстояние между ненулевыми элементами списка простых чисел
            for (int i = 0; i < NewArray.Count; i++)
                if (NewArray[i] != 0)
                {
                    CurLen = i - FirstNumIndex;
                    if (CurLen > sigma[2]) { sigma[2] = CurLen-1; sigma[0]= FirstNumIndex + 1; sigma[1] = i+1; }
                    FirstNumIndex = i;
                }
            return sigma;
        }

        /// <summary>
        /// Функция нахождения максимальных отрезков чисел
        /// с максимальным и минимальным количеством простых чисел
        /// </summary>
        /// 
        /// <param name="array">Список простых чисел, 
        /// в котором все непростые числа заменены на 0</param>
        /// <param name="segment">рассматриваемый отрезок чисел</param>
        /// 
        /// <returns>
        /// Список, содержащий информацию о максимальных 
        /// отрезках с максимальным и минимальным количеством простых чисел 
        /// 
        /// [0 максимальный сегмент с минимальным количеством простых чисел,
        /// 1 минимальное количество простых чисел,
        /// 2 минимальный сегмент с максимальным количеством простых чисел,
        /// 3 максимальное количество простых чисел] 
        /// </returns>
        public static List<int> SplitPrimes(List<int> array, int segment)
        {
            //Решение проблемы работы с некратным количеством сегментов, умещающихся в N
            if (array.Count() % segment == segment - 1 && segment!=1) array.Add(array.Count() + 1);

            //minmax[segment с минимумом, минимум, segment с максимумом,максимум]
            List<int> minmax = new List<int> { 0, segment, 0, 0 }; 

            int counter = 0; //Счётчик простых чисел в segment

            //Проходим по массиву, и каждые segment шагов
            //сравниваем counter c максимумом и минимумом
            for (int i = 0; i < array.Count; i++)
            {
                if ((i + 1) % segment == 0)
                {
                    //Проверка на максимум
                    if (counter >= minmax[3])
                    {
                        minmax[2] = i / segment;
                        minmax[3] = counter;
                    }

                    //Проверка на минимум
                    if (counter <= minmax[1])
                    {
                        minmax[0] = i / segment;
                        minmax[1] = counter;
                    }

                    //Обнуление счётчика для нового segment
                    counter = 0;
                }
                //Подсчёт простого числа
                if (array[i] != 0) counter++;

            }
            return minmax;
        }
    }
    
    /// <summary>
    /// Класс работы с простыми числами. 
    /// Содержит функцию поиска простых чисел в списке методом решета Эратосфена
    /// </summary>
    public class Primes
    {
        //Список для хранения простых чисел
        static List<int> PrimeArray = new List<int>();

        /// <summary>
        /// Функция определения всех делителей числа N
        /// </summary>
        /// <param name="N">исходной число</param>
        /// <returns>список всех делителей числа N</returns>
        public static List<int> GetDividers(int N)
        {
            List<int> Dividers = new List<int>();

            //Ищем делители до квадратного корня
            for (int i = 1; i < Math.Sqrt(N); i++)
                if (N % i == 0) Dividers.Add(i);

            //Если N-квадрат целого числа, добавляем это число к делителям
            bool flag = true;
            if (Math.Sqrt(N) == (int)Math.Sqrt(N))
            {
                flag = false;
                Dividers.Add((int)Math.Sqrt(N));
            }

            //Добавляем "зеркальные" относительно корня делители
            //В случае, если N-квадрат целого числа, не берём последнее число в Dividers
            for (int i = flag?Dividers.Count-1: Dividers.Count-2; i >= 0; i--)
                Dividers.Add(N / Dividers[i]);

            return Dividers;
        }

        /// <summary>
        /// Функция поиска простых чисел в списке методом решета Эратосфена
        /// </summary>
        /// 
        /// <param name="InputArray">Список целых чисел от 1 до N</param>
        /// 
        /// <returns>
        /// Список целых чисел от 1 до N, 
        /// в котором все непростые числа заменены на 0
        /// </returns>
        public static List<int> doEratosfen(List<int> InputArray)
        {
            //Перенос входного списка в объект класса
            PrimeArray = InputArray;

            //Поиск простых чисел решетом Эратосфена
            EratosfenHandleArray();
            return PrimeArray;
        }
        /// <summary>
        /// Функция обработки списка целых чисел решетом Эратосфена
        /// </summary>
        private static void EratosfenHandleArray()
        {
            int i = 1;
            //Для каждого ненулевого элемента списка
            //выполняем "выкалывание" по алгоритму решета Эратосфена
            while (i < PrimeArray.Count())
            {
                if (PrimeArray[i] != 0) Step(PrimeArray[i], i);
                i++;
            }
        }

        /// <summary>
        /// Функция, реализующая "выкалывание" чисел по алгоритму решета Эратосфена
        /// </summary>
        /// <param name="prime">Стартовое простое число</param>
        /// <param name="start">индекс стартового числа в списке</param>
        private static void Step(int prime, int start)
        {
            //Зануляем элементы списка с шагом в значение текущего стартового простого числа
            for (int i = start + prime; i < PrimeArray.Count(); i += prime) PrimeArray[i] = 0;
        }
    }
    public class ForTest
    {
        /// <summary>
        /// Функция для проверки работы программы
        /// </summary>
        /// <param name="num">Входное число, последнее в списке</param>
        /// <returns>Список, содержащий информацию о максимальных 
        /// десятках с максимальным и минимальным количеством простых чисел 
        /// [0 максимальный десяток с минимальным количеством простых чисел,
        /// 1 минимальное количество простых чисел,
        /// 2 минимальный десяток с максимальным количеством простых чисел,
        /// 3 максимальное количество простых чисел] </returns>
        public static string WorkPrimes(int N)
        {
            //Создаем массив с целыми числами от 1 до N
            List<int> NewArray = ArrayHandler.ArrayFiller(N);

            //Применяем алгоритм решета Эратосфена
            //для поиска простых чисел
            NewArray = Primes.doEratosfen(NewArray);
            //PrintArray(NewArray);

            //Находим максимальные десятки
            //с минимальным и максимальным количеством простых чисел
            List<int> Answer = ArrayHandler.SplitPrimes(NewArray,10);
            Console.WriteLine(PrintArray(Answer)); 
            return PrintArray(Answer);
            
        }
        /// <summary>
        /// Функция вывода списка 
        /// </summary>
        /// <param name="answer">Входной список</param>
        private static string PrintArray(List<int> answer)
        {
            string StrArray = "";
            foreach (int element in answer) StrArray += element + " ";
            return StrArray;
        }
    }
}
