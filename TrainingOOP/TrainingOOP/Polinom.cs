using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingOOP
{
    public class Polinom
    {
        #region fields
        private int _n; //степень
        private double[] _cf; //коэффициенты
        private static Random rnd = new Random(); // генератор случайных чисел
        #endregion

        #region propirties
        // Свойство для доступа к степени полинома
        /// <summary>
        /// степень полинома
        /// </summary>
        public int N
        {
            get { return _n; }
            set { if (value > 0) _n = value; }
        }
        // Свойство для доступа к коэффициентам полинома
        /// <summary>
        /// коэффициенты полинома
        /// </summary>
        public double[] Coef
        {
            get { return _cf; }
            set { _cf = value; }
        }       

        #endregion

        #region constructors
        /// <summary>
        /// Создаёт полином с данными коэффициентами
        /// </summary>
        /// <param name="cf"></param>
        public Polinom(double[] cf)
        {
            _cf = cf;
            _n = _cf.Length - 1;
        }        
       
        /// <summary>
        /// Конструктор по умолчанию
        /// Создает полином 6x^2 - 5x + 1.
        /// </summary>
        public Polinom()
        {
            _n = 2;
            _cf = new double[] { 6, -5, 1 };
        }

        /// <summary>
        /// Создаёт полином n-й степени со случайными коэффициентами целого типа 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// /// <param name="max"> верхняя граница </param>
        public Polinom(int n, int max)
        {
            _n = n;
            _cf = new double[N + 1];
            for (int i = 0; i <= n; i++)
            {
                _cf[i] = rnd.Next(max);
            }
        }

        /// <summary>
        /// Создаёт полином n-й степени со случайными коэффициентами целого типа из диапазона [min, max)
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        public Polinom(int n, int min, int max)
        {
            _n = n;
            _cf = new double[N + 1];
            for (int i = 0; i <= n; i++)
            {
                _cf[i] = rnd.Next(min, max);
            }
        }

        /// <summary>
        /// Создаёт полином n-й степени со случайными коэффициентами дробного типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        /// <param name="round"> количество знаков после запятой </param>
        public Polinom(int n, double min, double max, int round)
        {
            _n = n;
            _cf = new double[N + 1];
            for (int i = 0; i <= n; i++)
            {
                _cf[i] = Math.Round(rnd.NextDouble() * (max - min) + min, round);
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Сложение полиномов
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> сумма полиномов </returns>
        private static Polinom Sum(Polinom p1, Polinom p2)
        {
            int n = Math.Max(p1.N, p2.N);
            int m = Math.Min(p1.N, p2.N);
            double[] sumcf = new double[n + 1];
            Polinom ans = new Polinom(sumcf);
            for (int i = 0; i <= m; i++)
                sumcf[i] = p1.Coef[i] + p2.Coef[i];
            for (int k = m+1; k <= n; k++)
            {
                if (p1.N == n)
                    ans.Coef[k] = p1.Coef[k];
                else
                    ans.Coef[k] = p2.Coef[k];
            }
            return ans;
        }
        public static Polinom operator +(Polinom p1, Polinom p2)
        {
            return (Polinom.Sum(p1, p2));
        }
        /// <summary>
        /// Вычитание полиномов
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> разность полиномов </returns>
        private static Polinom Sub(Polinom p1, Polinom p2)
        {
            int n = Math.Max(p1.N, p2.N);
            int m = Math.Min(p1.N, p2.N);
            double[] subcf = new double[n + 1];
            Polinom ans = new Polinom(subcf);
            for (int i = 0; i <= m; i++)
                subcf[i] = p1.Coef[i] - p2.Coef[i];
            for (int k = m+1; k <= n; k++)
            {
                if (p1.N == n)
                    ans.Coef[k] = p1.Coef[k];
                else
                    ans.Coef[k] = p2.Coef[k];
            }
            return ans;
        }
        public static Polinom operator -(Polinom p1, Polinom p2)
        {
            return (Polinom.Sub(p1, p2));
        }
        /// <summary>
        /// Умножение полиномов
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> произведение полиномов </returns>
        private static Polinom Mult(Polinom p1, Polinom p2)
        {
            int n = p1.N;
            int m = p2.N;
            double[] multcf = new double[n + m + 1];
            Polinom ans = new Polinom(multcf);
            for (int i = 0; i <= n + m; i++)  
                for (int k = 0; k <= Math.Min(i, n); k++)  
                {
                    int j = i - k;  
                    if (j <= m)  
                        multcf[i] += p1.Coef[k] * p2.Coef[j];
                }
            return ans;
        }
        public static Polinom operator *(Polinom p1, Polinom p2)
        {
            return (Polinom.Mult(p1, p2));
        }
        /// <summary>
        /// Умножение полинома на число
        /// </summary>
        /// <param name="p"> полином для умножения </param>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <returns> полином - результат умножения </returns>
       private static Polinom MultNum(Polinom p, double num)
        {
            int n = p.N;
            double[] multcf = new double[n + 1];
            Polinom ans = new Polinom(multcf);
            for (int i = 0; i <= n; i++)
                multcf[i] = p.Coef[i];  
            for (int i = 0; i <= n; i++)
                multcf[i] *= num;  
            return ans;
        }
        public static Polinom operator *(Polinom p, double n)
        {
            return (Polinom.MultNum(p, n));
        }
        /// <summary>
        /// Деление полиномов нацело
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - результат деления нацело </returns>
        private static Polinom Div(Polinom p1, Polinom p2)
        {            
            int n = p1.N;
            int m = p2.N;
            if (n < m)  // если степень первого полинома меньше степени второго, то результат деления нацело - 0
                return new Polinom(new double[] { 0 });
            double[] anscf = new double[n - m + 1];  // коэффициенты итогового полинома 
            double[] delcf = new double[n + 1];  // коэффициенты делимого
            for (int i = 0; i <= n; i++)
                delcf[i] = p1.Coef[i];
            for (int i = 0; i <= n - m; i++)
            {
                double d = delcf[n - i] / p2.Coef[m];  // коэффициент итогового полинома
                anscf[n - m - i] = d;
                delcf[n - i] = 0;  // старший коэффициент делимого зануляется
                for (int k = 1; k <= m; k++)
                    delcf[n - i - k] -= d * p2.Coef[m - k];  // вычитание из делимого результата умножения d на p2
            }
            Polinom ans = new Polinom(anscf);
            return ans;
        }
        public static Polinom operator /(Polinom p1, Polinom p2)
        {
            return (Polinom.Div(p1, p2));
        }


        /// <summary>
        /// Деление полиномов на число
        /// </summary>
        /// <param name="p"> первый полином </param>
        /// <param name="num"> число </param>
        /// <returns> полином - результат деления нацело </returns>
        private static Polinom DivNum(Polinom p, double num)
        {
            int n = p.N;
            double[] multcf = new double[n + 1];
            Polinom ans = new Polinom(multcf);
            for (int i = 0; i <= n; i++)
                multcf[i] = p.Coef[i];
            for (int i = 0; i <= n; i++)
                multcf[i] = Math.Round(multcf[i] / num,3);
            return ans;
        }
        public static Polinom operator /(Polinom p, double n)
        {
            return (Polinom.DivNum(p, n));
        }
        /// <summary>
        /// Возведение полинома в целую неотрицательную степень
        /// </summary>
        /// <param name="n"> степень </param>
        /// <returns> полином - результат возведения в степень </returns>
        public Polinom Pow(int n)
        {
            if (n == 0)
                return new Polinom(new double[] { 1 });
            Polinom pol1 = new Polinom(_cf);
            Polinom pol2 = new Polinom(new double[] { 1 });
            while (n > 1)
                if (n % 2 == 0)
                {
                    pol1 *= pol1;
                    n /= 2;
                }
                else
                {
                    pol2 *= pol1;
                    n--;
                }
            Polinom ans = pol1 * pol2;
            return ans;
        }
        public static Polinom operator ^(Polinom p, int n)
        {
            return (p.Pow(n));
        }
        /// <summary>
        /// Производная полинома
        /// </summary>
        /// <returns> производная полинома</returns>
        public Polinom GetDx()
        {
            double[] anscf = new double[_n];
            for (int i = _n; i > 0; i--)
                anscf[i - 1] = i * _cf[i];
            return new Polinom(anscf);
        }
        /// <summary>
        /// Первообразная полинома
        /// </summary>
        /// <returns> первообразная полинома </returns>
        public Polinom GetFx()
        {
            double[] ansc = new double[_n + 2];
            for (int i = _n + 1; i > 0; i--)
                ansc[i] = _cf[i - 1] / i;
            return new Polinom(ansc);
        }

        #endregion

        #region ToString() modify
        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> строка, представляющая полином </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetFirstNotNullMember(out int position));
            for (int i = position - 1; i >= 0; i--)
            {
                if (_cf[i] == 0) continue;
                if (Math.Abs(_cf[i]) == 1)
                {
                    if (i == 0)
                    {
                        sb.Append(SetGign(_cf[i]));
                        sb.Append('1');
                    }
                    else if (i == 1)
                    {
                        sb.Append(SetGign(_cf[i]));
                        sb.Append('x');
                    }
                    else
                    {
                        sb.Append(SetGign(_cf[i]));
                        sb.Append("x^");
                        sb.Append(i);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        sb.Append(SetGign(_cf[i]));
                        sb.Append(Math.Abs(_cf[i]));
                    }
                    else if (i == 1)
                    {
                        sb.Append(SetGign(_cf[i]));
                        sb.Append(Math.Abs(_cf[i]));
                        sb.Append('x');
                    }
                    else
                    {
                        sb.Append(SetGign(_cf[i]));
                        sb.Append(Math.Abs(_cf[i]));
                        sb.Append("x^");
                        sb.Append(i);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Получение первого ненулевого элемента в полиноме.
        /// </summary>
        /// <param name="position"> позиция ненулевого элемента </param>
        /// <returns> первый ненулевой элемент в полиноме </returns>
        private string GetFirstNotNullMember(out int position)
        {
            string temp = "";
            int i;
            for (i = _n; i >= 0; i--)
            {
                if (_cf[i] == 0) continue;
                if (Math.Abs(_cf[i]) == 1)
                {
                    if (i == 0)
                        temp += _cf[i];
                    else if (i == 1)
                        temp += _cf[i] == 1 ? "x" : "-x";
                    else
                        temp += (_cf[i] == 1 ? "x^" : "-x^") + i;
                }
                else
                {
                    if (i == 0)
                        temp += _cf[i];
                    else if (i == 1)
                        temp += _cf[i] + "x";
                    else
                        temp += _cf[i] + "x^" + i;
                }
                break;
            }
            if (temp == "")
                temp = "0";
            position = i;
            return temp;
        }

        /// <summary>
        /// Получает знак числа.
        /// </summary>
        /// <param name="n"> число, знак которого нужно получить </param>
        /// <returns> знак числа (+ или -) </returns>
        private string SetGign(double n)
        {
            if (n >= 0)
                return " + ";
            return " - ";
        }
        #endregion
    }
}
