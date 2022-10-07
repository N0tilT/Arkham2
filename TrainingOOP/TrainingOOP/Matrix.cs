using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingOOP
{
    public class Matrix    //Вадим
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

        //Ручной ввод матрицы
        /*
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
        */

        //Ввод случайной матрицы
        public void MakeRandMatrix(int min, int max)
        {
            if (min >= max) throw new Exception("Неверный ввод диапазона для заполнения случайными числами");
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
        private static Matrix MultIntMatrix(Matrix a, double b)
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
        public static Matrix operator *(Matrix a, double b)
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
                        double sum = 0;
                        for (int k = 0; k < size; k++)
                            sum += answ[i, k] * a[k, j];
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

        //Функция расчета алгебаического дополнения элемента матрицы
        private static double AlgComplementA(Matrix A, int k, int m)
        {
            double minor;
            Matrix B = new Matrix(A.N - 1);
            for (int i = 0; i < B.N; i++)
            {
                for (int j = 0; j < B.N; j++)
                {
                    int ii = (i >= k) ? i + 1 : i;
                    int jj = (j >= m) ? j + 1 : j;
                    B[i, j] = A[ii, jj];
                }
            }
            minor = Determinant(B);
            return (int)Math.Pow(-1, k) * minor;
        }

        //Вычислить определитель
        public static double Determinant(Matrix A)
        {
            double det = 0;
            int lenA = A.N;
            if (lenA == 1)  //Базовый случай. Определитель матрицы 1x1 равен её единственному элементу
            {
                det = A[0, 0];
            }
            else    //Для матриц 2х2 и большего размера применяем разложение по первому столбцу
            {
                for (int i = 0; i < A.N; i++)
                {
                    det += A[i, 0] * AlgComplementA(A, i, 0);
                }
            }
            return det;
        }

        public static double operator !(Matrix a)
        {
            return Determinant(a);
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
