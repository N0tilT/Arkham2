using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingClassesCA
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();

            Console.WriteLine("_____\nТестирование класса Student\n_____");
            test.TestStudentProps();

            Console.WriteLine("_____\nТестирование класса Teacher\n_____");
            test.TeacherTest();

            Console.WriteLine("_____\nТестирование класса Vehicle\n_____");
            test.TestVehicleProps();
            test.TestVehicleUsed();

            Console.WriteLine("_____\nТестирование класса Complex\n_____");
            test.TestComplex();

            Console.ReadKey();
        }
    }
}
