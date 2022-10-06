using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassSamples;
using Geometrical_Figures;

namespace ConsoleWithClasses
{
    /// <summary>
    /// Класс с тестами методов
    /// классов DLL ClassSamples
    /// </summary>
    class Testing
    {
        /// <summary>
        /// Тестирование свойств объектов
        /// класса Person
        /// </summary>
        public void TestPersonProps()
        {           
            Person pers1 = new Person(), 
                   pers2 = new Person();
            pers1.Fam = "Хохлова";
            pers1.Age = 21;
            ConsolePrintPerson(pers1);
           
            pers2.Fam = "Петров"; 
            pers2.Age = pers1.Age + 1;
            ConsolePrintPerson(pers2);

            pers1.Fam = "Петрова";
            ConsolePrintPerson(pers1);

        }//TestPersonProps
        /// <summary>
        /// Вывод на консоль полей, открытых для чтения
        /// </summary>
        void ConsolePrintPerson(Person pers)
        {
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}",
                pers.Fam, pers.Age, pers.GetStatus);
        }
        /// <summary>
        /// Тест индексатора 
        /// </summary>
        public void TestPersonChildren()
        {
            Person pers1, pers2, pers3, pers4;
            pers1 = new Person();
            pers1.Fam = "Петров"; pers1.Age = 42;            

            pers2 = new Person();
            pers2.Fam = pers1.Fam; pers2.Age = 7;
            pers1[pers1.Count_children] = pers2;

            pers3 = new Person();
            pers3.Fam = pers1.Fam + "а"; pers3.Age = 4;
            pers1[pers1.Count_children] = pers3;

            pers4 = new Person();
            pers4.Fam = pers1.Fam; pers4.Age = 2;
            pers1[pers1.Count_children] = pers4;

            ConsolePrintPerson(pers1);
            ConsolePrintPerson(pers1[0]);
            ConsolePrintPerson(pers1[1]);
            ConsolePrintPerson(pers1[2]);
        }
        public void TestCreateRational()
        {
            try
            {                 
                 Rational r1 = new Rational(-5, -25);
                 Console.WriteLine("r1 = " + r1.ToString());
                 Rational r2 = new Rational();
                 Console.WriteLine("r2 = " + r2.ToString());
                 Rational r3 = new Rational(4, -8);
                 Console.WriteLine("r3 = " + r3.ToString());  
                 Rational r4 = new Rational(8, 18); 
                 Console.WriteLine("r4 = " + r4.ToString()); 
                 Rational r5 = new Rational(0, 0);
                 Console.WriteLine("r5 = " + r5.ToString());
            }
            catch (RationalException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void TestOperRational()
        {
            Rational r1 = new Rational(1, 2), 
                r2 = new Rational(1, 3);
            Rational r3, r4, r5, r6;
            r3 = r1 - r2; r4 = r1 * r2; r5 = r1 / r2; 
            r6 = (r3 + r4) * (r5 - r3)/r4;
            Console.WriteLine("r1 = " + r1.ToString());
            Console.WriteLine("r2 = " + r2.ToString());
            Console.WriteLine("r3 = " + r3.ToString());
            Console.WriteLine("r4 = " + r4.ToString());
            Console.WriteLine("r5 = " + r5.ToString());
            Console.WriteLine("r6 = " + r6.ToString());
        }
        public void TestRationalConst()
        {
            Rational r1 = new Rational(0, 8), r2 = new Rational(2, 5);
            Rational r3 = new Rational(4, 10), r4 = new Rational(3, 7);
            Rational r5 = Rational.ZERO, r6, r7;
            if ((r1 != Rational.ZERO) && (r2 == r3)) 
                r6 = (r3 + Rational.ONE) * r4;
            else r6 = Rational.ONE + Rational.ONE;
            if ((r6 > r3) && (r4 > 0.5)) r7 = r1; 
            else r7 = r2;
            Console.WriteLine("r1 = " + r1.ToString());
            Console.WriteLine("r2 = " + r2.ToString());
            Console.WriteLine("r3 = " + r3.ToString());
            Console.WriteLine("r4 = " + r4.ToString());
            Console.WriteLine("r5 = " + r5.ToString());
            Console.WriteLine("r6 = " + r6.ToString());
            Console.WriteLine("r7 = " + r7.ToString());
        }
        public void TestTriangle()
        {
            const string CONTAINS =
                "Треугольник содержит точку!";
            const string NOT_CONTAINS =
                "Треугольник не содержит точку!";
            Triangle tr1;
            CPoint p1, p2, p3, p4;
            p1 = new CPoint(1, 1);
            p2 = new CPoint(2, 2);
            p3 = new CPoint(3, 1);
            p4 = new CPoint(2, 2);
            tr1 = new Triangle(p1, p2, p3);
            Console.WriteLine("Треугольник tr1 \n\r" + tr1.ToString());
            Console.WriteLine("Точка \n\r" + p4.ToString());
            if (tr1.Contains(p4))
                Console.WriteLine(CONTAINS);
            else Console.WriteLine(NOT_CONTAINS);
            
        }
        public void TestEnum()
        {
            Color color1 = Color.два;
            Color color2 = Color.три;
            color2 = color1;
            color1 = Color.один;
            Console.WriteLine("color1 = " + color1 +
                "color2 = " + color2);

        }

        enum Color { один, два, три }

    }
}
