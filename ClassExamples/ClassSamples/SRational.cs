using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassSamples
{
     /// <summary>
    /// Структура SRational.
    /// определяет новый тип данных - рациональные числа и основные
    /// операции над ними - сложение, умножение, вычитание и деление.
    /// Рациональное число задается парой целых чисел
    /// (numerator,denominator) и изображается
    /// обычно в виде дроби numerator/denominator. 
    /// Число numerator называется числителем,
    /// denominator - знаменателем. Для каждого рационального числа существует
    /// множество его представлений, например, 1/2, 2/4, 3/6, 6/12.
    /// Среди всех представлений
    /// можно выделить то, в котором числитель и знаменатель взаимно
    /// несократимы. Такой представитель будет храниться в полях класса.
    /// </summary>
    public struct SRational
    {
        const string NONE_EXIST =
                "Не существует рационального  числа " +
                "со знаменателем, равным нулю!";
        //Поля класса. Числитель и знаменатель рационального числа.
        int numerator, denominator;       
        /// <summary>
        /// Конструктор класса. Создает рациональное число
        /// эквивалентное numerator/denominator, 
        /// но со взаимно несократимыми числителем и знаменателем. 
        /// Если denominator = 0, то выбрасывается исключение, 
        /// сообщающее о невозможности создать
        /// рациональное число со знаменателем 0
        /// </summary>
        /// <param name="numerator">числитель</param>
        /// <param name="denominator">знаменатель</param>
        public SRational(int numerator, int denominator)
        {
            if (denominator == 0) 
                throw new SRationalException(NONE_EXIST);
            if (numerator == 0) 
            { 
                this.numerator = 0; 
                this.denominator = 1; 
                return; 
            } 
            
            //приведение знака
            if (denominator < 0) 
            { 
                denominator = -denominator; 
                numerator = -numerator; 
            }
            //приведение к несократимой дроби
            int m = numerator, n = denominator;
            {
                int p = 0;
                if (n > m) { p = m; m = n; n = p; }
                do
                {
                    p = m % n; m = n; n = p;
                } while (n != 0);
            }//Nod
            this.numerator = numerator / m; 
            this.denominator = denominator / m;            
        }       

        /// <summary>
        /// Представление рационального числа 
        /// в виде строки
        /// </summary>
        /// <returns>строка в формате numerator/denominator
        /// </returns>
        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
        public SRational Plus(SRational a)
        {
            int u, v;
            u = numerator * a.denominator + denominator * a.numerator;
            v = denominator * a.denominator;
            return (new SRational(u, v));
        }//Plus
        public static SRational operator +(SRational r1, SRational r2)
        {
            return (r1.Plus(r2));
        }
        public SRational Minus(SRational a)
        {
            int u, v;
            u = numerator * a.denominator - denominator * a.numerator; 
            v = denominator * a.denominator;
            return (new SRational(u, v));
        }//Minus
        public static SRational operator -(SRational r1, SRational r2)
        {
            return (r1.Minus(r2));
        }
        public SRational Mult(SRational a)
        {
            int u, v;
            u = numerator * a.numerator; 
            v = denominator * a.denominator;
            return (new SRational(u, v));
        }//Mult
        public static SRational operator *(SRational r1, SRational r2)
        {
            return (r1.Mult(r2));
        }
        public SRational Divide(SRational a)
        {
            int u, v;
            u = numerator * a.denominator; 
            v = denominator * a.numerator;
            return (new SRational(u, v));
        }//Divide
        public static SRational operator /(SRational r1, SRational r2)
        {
            return (r1.Divide(r2));
        }

        //Константы класса 0 и 1 - ZERO и ONE
        public static readonly SRational ZERO, ONE;
        SRational(int num, int den, string t)
        {
            numerator = num; denominator = den;
        }//Закрытый конструктор
        static SRational()
        {
            ZERO = new SRational(0, 1, "");
            ONE = new SRational(1, 1, "");
        }//Статический конструктор

        //Операции отношения
        public static bool operator ==(SRational r1, SRational r2)
        {
            return ((r1.numerator == r2.numerator) && 
                (r1.denominator == r2.denominator));
        }
        public static bool operator !=(SRational r1, SRational r2)
        {
            return ((r1.numerator != r2.numerator) || 
                (r1.denominator != r2.denominator));
        }
        
        public static bool operator <(SRational r1, SRational r2)
        {
            return (r1.numerator * r2.denominator < 
                r2.numerator * r1.denominator);
        }
        public static bool operator >(SRational r1, SRational r2)
        {
            return (r1.numerator * r2.denominator > 
                r2.numerator * r1.denominator);
        }
        public static bool operator <(SRational r1, double r2)
        {
            return ((double)r1.numerator / r1.denominator < r2);
        }
        public static bool operator >(SRational r1, double r2)
        {
            return ((double)r1.numerator / r1.denominator > r2);
        }
        public override bool Equals(object obj)
        {
            return this == (SRational)obj;
        }
        public override int GetHashCode()
        {
            return numerator + denominator;
        }



    }
    /// <summary>
    /// Класс, задающий исключения при работе
    /// с рациональными числами.
    /// </summary>
    public class SRationalException : Exception
    {

        public SRationalException() { }
        public SRationalException(string message) :
            base(message) { }
        public SRationalException(string message,
            Exception e)
            : base(message, e) { }
    }
}

