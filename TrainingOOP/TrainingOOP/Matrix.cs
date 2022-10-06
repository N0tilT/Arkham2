using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingOOP
{
    class Matrix    //Вадим
    {
        private int n;
        private double[,] mas;
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
        public Matrix(int n)
        {
            this.n = n;
            mas = new double[this.n, this.n];
        }
        public double this[int i, int j]
        {
            get
            { return mas[i, j]; }
            set
            { mas[i, j] = value; }
        }
        //Ввод матрицы
        //Перенести в класс тестов
        public void MakeMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"Введите элемент матрицы {i + 1}:{j + 1}");
                    mas[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        //Ввод случайной матрицы
        //min max, проверки
        public void MakeRandMatrix(int min, int max)
        {
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = rand.Next(min, max);
                }
            }
            Thread.Sleep(11);
        }
        //Вывод матрицы
        //перенести в класс тестов
        public void PrintMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        //Сложение матриц
        private static Matrix SummMatrix(Matrix a, Matrix b)
        {
            Matrix answ = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    answ[i, j] = a[i, j] + b[i, j];
                }
            }
            return answ;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return SummMatrix(a, b);
        }
        //Вычитание матриц
        private static Matrix SubtMatrix(Matrix a, Matrix b)
        {
            Matrix answ = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    answ[i, j] = a[i, j] - b[i, j];
                }
            }
            return answ;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return SubtMatrix(a, b);
        }
        //Умножение матрицы на число
        //int b -> double b
        private static Matrix MultIntMatrix(Matrix a, int b)
        {
            Matrix answ = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    answ[i, j] = a[i, j] * b;
                }
            }
            return answ;
        }
        public static Matrix operator *(Matrix a, int b)
        {
            return MultIntMatrix(a, b);
        }
        //Умножение матриц
        private static Matrix MultMatrix(Matrix a, Matrix b)
        {
            Matrix answ = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    for (int k = 0; k < b.N; k++)
                    {
                        answ[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return answ;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return MultMatrix(a, b);
        }
        //Возведение матрицы в степень
        private static Matrix PowMatrix(Matrix a, int b)
        {
            int size = a.N;
            Matrix answ = a;
            for (int l = 1; l < b; l++)
            {
                Matrix tmp = new Matrix(a.N);
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < size; k++)
                            sum += Convert.ToInt32(answ[i, k] * a[k, j]);
                        tmp[i, j] = sum;
                    }
                answ = tmp;
            }
            return answ;
        }
        public static Matrix operator ^(Matrix a, int b)
        {
            return PowMatrix(a, b);
        }
        //Вычислить определитель
        // убрать большую часть комментариев
        private static double DefMatrix(Matrix a)
        {
            const double EPS = 1E-9;
            double answ = 1;
            Matrix tmp = new Matrix(a.N);
            //проходим по строкам
            for (int i = 0; i < a.N; i++)
            {
                //присваиваем k номер строки
                int k = i;
                //идем по строке от i+1 до конца
                for (int j = i + 1; j < a.N; ++j)
                    //проверяем
                    if (Math.Abs(a[j, i]) > Math.Abs(a[k, i]))
                        //если равенство выполняется то k присваиваем j
                        k = j;
                //если равенство выполняется то определитель приравниваем 0 и выходим из программы
                if (Math.Abs(a[k, i]) < EPS)
                {
                    return answ = 0;
                }
                for (int g = 0; g < a.N; ++g)
                {
                    tmp[0, g] = a[i, g];
                    a[i, g] = a[k, g];
                    a[k, g] = tmp[0, g];
                }
                //если i не равно k
                if (i != k)
                    //то меняем знак определителя
                    answ = -answ;
                //умножаем det на элемент a[i][i]
                answ *= a[i, i];
                //идем по строке от i+1 до конца
                for (int j = i + 1; j < a.N; ++j)
                    //каждый элемент делим на a[i][i]
                    a[i, j] /= a[i, i];
                //идем по столбцам
                for (int j = 0; j < a.N; ++j)
                    //проверяем
                    if ((j != i) && (Math.Abs(a[j, i]) > EPS))
                        //если да, то идем по k от i+1
                        for (k = i + 1; k < a.N; ++k)
                            a[j, k] -= a[i, k] * a[j, i];
            }
            return answ;
        }
        //не в инт
        public static int operator !(Matrix a)
        {
            return Convert.ToInt32(DefMatrix(a));
        }
        //Транспонирование матрицы
        private static Matrix TranMatrix(Matrix a)
        {
            Matrix tmp = a;
            Matrix answ = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    answ[i, j] = a[j, i];
                }
            }
            return answ;
        }
        public static Matrix operator ~(Matrix a)
        {
            return TranMatrix(a);
        }
    }
}
