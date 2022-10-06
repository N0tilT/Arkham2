using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassSamples
{
    /// <summary>
    /// Класс Rational.
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
    public class Rational
    {
        const string NONE_EXIST =
                "Не существует рационального  числа " +
                "со знаменателем, равным нулю!";
        //Поля класса. Числитель и знаменатель рационального числа.
        int numerator, denominator;

        //Констукторы класса
        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает рациональный нуль - пару (0/1)
        /// </summary>
        public Rational()
        {
            numerator = 0; denominator = 1;
        }
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
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0) 
                throw new RationalException(NONE_EXIST);
            if (numerator == 0) 
            { 
                this.numerator = 0; this.denominator = 1; 
                return; 
            } 
            //приведение знака
            if (denominator < 0) 
            { 
                denominator = -denominator;
                numerator = -numerator;
            }
            //приведение к несократимой дроби
            int d = Nod(numerator, denominator);
            this.numerator = numerator / d; 
            this.denominator = denominator / d;            
        }

        /// <summary>
        /// Закрытый метод класса.
        /// Возвращает наибольший общий делитель чисел m,n
        /// </summary>
        /// <param name="m">первое число</param>
        /// <param name="n">второе число, положительное</param>
        /// <returns>НОД(m,n)</returns>
        int Nod(int m, int n)
        {
            int p = 0;
            m = Math.Abs(m); n = Math.Abs(n);
            do
            {
                p = m % n; m = n; n = p;
            } while (n != 0);
            return (m);
        }//Nod

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
        public Rational Plus(Rational a)
        {
            int u, v;
            u = numerator * a.denominator + denominator * a.numerator;
            v = denominator * a.denominator;
            return (new Rational(u, v));
        }//Plus
        public static Rational operator +(Rational r1, Rational r2)
        {
            return (r1.Plus(r2));
        }
        public Rational Minus(Rational a)
        {
            int u, v;
            u = numerator * a.denominator - denominator * a.numerator; 
            v = denominator * a.denominator;
            return (new Rational(u, v));
        }//Minus
        public static Rational operator -(Rational r1, Rational r2)
        {
            return (r1.Minus(r2));
        }
        public Rational Mult(Rational a)
        {
            int u, v;
            u = numerator * a.numerator; 
            v = denominator * a.denominator;
            return (new Rational(u, v));
        }//Mult
        public static Rational operator *(Rational r1, Rational r2)
        {
            return (r1.Mult(r2));
        }
        public Rational Divide(Rational a)
        {
            int u, v;
            u = numerator * a.denominator; 
            v = denominator * a.numerator;
            return (new Rational(u, v));
        }//Divide
        public static Rational operator /(Rational r1, Rational r2)
        {
            return (r1.Divide(r2));
        }

        //Константы класса 0 и 1 - ZERO и ONE
        public static readonly Rational ZERO, ONE;
        Rational(int num, int den, string t)
        {
            numerator = num; denominator = den;
        }//Закрытый конструктор
        static Rational()
        {
            ZERO = new Rational(0, 1, "");
            ONE = new Rational(1, 1, "");
        }//Статический конструктор

        //Операции отношения
        public static bool operator ==(Rational r1, Rational r2)
        {
            return ((r1.numerator == r2.numerator) && 
                (r1.denominator == r2.denominator));
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            return ((r1.numerator != r2.numerator) || 
                (r1.denominator != r2.denominator));
        }
        
        public static bool operator <(Rational r1, Rational r2)
        {
            return (r1.numerator * r2.denominator < 
                r2.numerator * r1.denominator);
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            return (r1.numerator * r2.denominator > 
                r2.numerator * r1.denominator);
        }
        public static bool operator <(Rational r1, double r2)
        {
            return ((double)r1.numerator / r1.denominator < r2);
        }
        public static bool operator >(Rational r1, double r2)
        {
            return ((double)r1.numerator / r1.denominator > r2);
        }
        public override bool Equals(object obj)
        {
            return this == (Rational)obj;
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
    public class RationalException : Exception
    {

        public RationalException() { }
        public RationalException(string message) :
            base(message) { }
        public RationalException(string message,
            Exception e)
            : base(message, e) { }
    }
}
