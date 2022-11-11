using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingOOP
{
    public class Matrix    //Вадим
    {

        #region fields
        private int n;
        private double[,] mas;
        #endregion

        #region propirties
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
        #endregion

        #region constructors
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
        #endregion

        #region methods
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

        //Возведение матрицы в степень?
        private static Matrix FastPowMatrix(Matrix a, int b)
        {
            Matrix answ = a;
            int s = b;
            int c = 1;
            while (s > 1)
            {
                if (s % 2 == 1)
                {
                    s--;
                }
                while (s % 2 == 0)
                {
                    answ = answ * answ;
                    s = s / 2;
                    c = c * 2;
                }
            }

            for (int l = 1; l < b-c+1; l++)
            {
                answ = answ * a;
            }
            return answ;
        }

        public static Matrix operator &(Matrix a, int b)
        {
            return FastPowMatrix(a, b);
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
        private static Matrix CopyMatrix(Matrix a)
        {
            Matrix b = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < a.N; j++)
                {
                    b[i, j] = a[i, j];
                }
                    return b;
        }
        //Вычисление определителя методом Гаусса
        public static double Gauss(Matrix c)
        {
            Matrix A = CopyMatrix(c);
            double[][] B = new double[1][];
            B[0] = new double[A.n];
            double det = 1;
            const double EPS = 1E-9;
            for (int i = 0; i < A.n; ++i)
            {
                int k = i;
                for (int j = i + 1; j < A.n; ++j)
                    if (Math.Abs(A[j,i]) > Math.Abs(A[k,i]))
                        k = j;
                if (Math.Abs(A[k,i]) < EPS)
                {
                    det = 0;
                    break;
                }
                for (int z = 0; z < A.n; z++)
                {
                    B[0][z] = A[i,z];
                    A[i,z] = A[k,z];
                    A[k,z] = B[0][z];
                }
                if (i != k)
                    det = -det;
                det *= A[i,i];
                for (int j = i + 1; j < A.n; ++j)
                    A[i,j] /= A[i,i];
                for (int j = 0; j < A.n; ++j)
                    if ((j != i) && (Math.Abs(A[j,i]) > EPS))
                        for (k = i + 1; k < A.n; ++k)
                            A[j,k] -= A[i,k] * A[j,i];
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
        #endregion
    }
}
