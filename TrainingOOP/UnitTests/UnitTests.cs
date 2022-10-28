using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TrainingOOP;

namespace UnitTests
{
    [TestClass]
    public class VehicleUnitTest
    {
        [TestMethod]
        public void Test_Used()
        {
            Vehicle vhl = new Vehicle
            {
                Mileage = 9620
            };

            Assert.AreEqual("с_пробегом", vhl.GetUsed.ToString());
            vhl.Mileage = 0;
            Assert.AreEqual("новый", vhl.GetUsed.ToString());
        }
    }

    [TestClass]
    public class StudentUnitTest
    {
        Student std = new Student
        {
            StudingYears = 6,
            SumDebt = 2
        };

        [TestMethod]
        public void Test_Stage()
        {
            Assert.AreEqual("магистратура", std.GetStage.ToString());
            std.StudingYears = 2;
            Assert.AreEqual("бакалавриат", std.GetStage.ToString());
            std.StudingYears = 7;
            Assert.AreEqual("аспирантура", std.GetStage.ToString());
        }
        [TestMethod]
        public void Test_Course()
        {
            Assert.AreEqual( 2, std.GetCourse);
            std.StudingYears = 2;
            Assert.AreEqual(2, std.GetCourse);
            std.StudingYears = 5;
            Assert.AreEqual(1, std.GetCourse);
            std.StudingYears = 7;
            Assert.AreEqual(1, std.GetCourse);
        }
        [TestMethod]
        public void Test_Status()
        {
            Assert.AreEqual("имеет_задолженности", std.GetStatus.ToString());
            std.SumDebt = 0;
            Assert.AreEqual("аттестован", std.GetStatus.ToString());
            std.SumDebt = 6;
            Assert.AreEqual("отчислен", std.GetStatus.ToString());
        }

    }

    [TestClass]
    public class TeacherUnitTest
    {
        Teacher teach = new Teacher
        {
            Degree = "Кандидат филологических наук",
            Idstud = { 0, 1, 2, 3 }
        };
       
        [TestMethod]
        public void Test_AcademicTitle()
        {
            Assert.AreEqual("Доцент", teach.GetAcademicTitle.ToString());
            teach.Degree = "Доктор наук";
            Assert.AreEqual("Профессор", teach.GetAcademicTitle.ToString());
            teach.Degree = "Учитель";
            Assert.AreEqual("Без_ученого_звания", teach.GetAcademicTitle.ToString());
            teach.Degree = " ";
            Assert.AreEqual("Без_ученого_звания", teach.GetAcademicTitle.ToString());
            teach.Degree = "124531256";
            Assert.AreEqual("Без_ученого_звания", teach.GetAcademicTitle.ToString());
        }
  
        private string ArrayToString(List<Student> list)
        {
            string stdlist = "";
            foreach (Student std in list)
            {
                stdlist += std.Name + " ";
            }

            return stdlist;
        }

        [TestMethod]
        public void Test_StudList()
        {
            Assert.AreEqual("Вадим ", ArrayToString(teach.StudList)); // "Вадим Марина Матвей Вадим "
        }
    }

    [TestClass]
    public class MatrixUnitTest
    {
        string strmat = "";            
        const int n = 4;
        static private Matrix FillMatrix(Matrix a, double shift)
        {
            Matrix tmp = a;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmp[i, j] = j - i + shift; 
                }
            }
            return tmp;
        }        
        Matrix A = FillMatrix(new Matrix(n), 2); // 2 3 4 5 | 1 2 3 4 | 0 1 2 3 | -1 0 1 2
        Matrix B = FillMatrix(new Matrix(n), 4); // 4 5 6 7 | 3 4 5 6 | 2 3 4 5 |  1 2 3 4
        Matrix C = FillMatrix(new Matrix(n), 3.5); // 3.5 4.5 5.5 6.5 | 2.5 3.5 4.5 5.5 | 1.5 2.5 3.5 4.5 | -0.5 1.5 2.5 3.5
        Matrix D = FillMatrix(new Matrix(n), 0); // 0 1 2 3 | -1 0 1 2 | -2 -1 0 1 | -3 -2 -1 0
        public string PrintMatrix(Matrix mas)
        {
            strmat = "";
            for (int i = 0; i < mas.N; i++)
            {
                for (int j = 0; j < mas.N; j++)
                {
                    strmat += mas[i, j] + " ";
                }
                strmat += "| ";
            }
            return strmat;
        }

        [TestMethod]
        public void Test_SumMatrix()
        {
            Assert.AreEqual("6 8 10 12 | 4 6 8 10 | 2 4 6 8 | 0 2 4 6 | ", PrintMatrix(A + B));
            Assert.AreEqual("3,5 5,5 7,5 9,5 | 1,5 3,5 5,5 7,5 | -0,5 1,5 3,5 5,5 | -2,5 -0,5 1,5 3,5 | ", PrintMatrix(C + D));
        }

        [TestMethod]
        public void Test_SubtMatrix()
        {
            Assert.AreEqual("-2 -2 -2 -2 | -2 -2 -2 -2 | -2 -2 -2 -2 | -2 -2 -2 -2 | ", PrintMatrix(A - B));
        }

        [TestMethod]
        public void Test_MultIntMatrix()
        {
            Assert.AreEqual("12 18 24 30 | 6 12 18 24 | 0 6 12 18 | -6 0 6 12 | ", PrintMatrix(A * 6));
            Assert.AreEqual("16 20 24 28 | 12 16 20 24 | 8 12 16 20 | 4 8 12 16 | ", PrintMatrix(B * 4));
            Assert.AreEqual("12 18 24 30 | 6 12 18 24 | 0 6 12 18 | -6 0 6 12 | ", PrintMatrix(A * 6));
        }

        [TestMethod]
        public void Test_MultMatrix()
        {
            Assert.AreEqual("30 44 58 72 | 20 30 40 50 | 10 16 22 28 | 0 2 4 6 | ", PrintMatrix(A * B));
        }

        [TestMethod]
        public void Test_PowMatrix()
        {
            Assert.AreEqual("2 16 30 44 | 0 10 20 30 | -2 4 10 16 | -4 -2 0 2 | ", PrintMatrix(A ^ 2));
        }

        [TestMethod]
        public void Test_DeterminantMatrix()
        {
            Assert.AreEqual(0, !A);
            Assert.AreEqual(0, !D);
            Assert.AreEqual(0, !B);
          
        }

        [TestMethod]
        public void Test_TranMatrix()
        {
            Assert.AreEqual("2 1 0 -1 | 3 2 1 0 | 4 3 2 1 | 5 4 3 2 | ", PrintMatrix(~A));
        }

        [TestMethod]
        public void Test_AllMatrix()
        {
            Assert.AreEqual(0, !(A + B));
            Assert.AreEqual("4 4 4 4 | 4 4 4 4 | 4 4 4 4 | 4 4 4 4 | ", PrintMatrix(~(B-D)));
        }
    }

    [TestClass]
    public class ComplexUnitTest
    {
        [TestMethod]
        public void Test_ComplexPlus()
        {
            Complex z1 = new Complex(3, -2.5);
            Complex z2 = new Complex(0, 3);
            Assert.AreEqual("3 + 0,5i", (z1 + z2).ToString());
            z1 = new Complex(6.5345, 0);
            z2 = new Complex(-342, 34);
            Assert.AreEqual("-335,4655 + 34i", (z1 + z2).ToString());
            z1 = new Complex(0, 0);
            z2 = new Complex(-2, 0);
            Assert.AreEqual("-2 + 0i", (z1 + z2).ToString()); //0i = 0?
        }

        [TestMethod]
        public void Test_ComplexMinus()
        {
            Complex z1 = new Complex(3, -2.5);
            Complex z2 = new Complex(2, 3);
            Assert.AreEqual("1 - 5,5i", (z1 - z2).ToString());
            z1 = new Complex(-83734, +4);
            z2 = new Complex(-2, 0);
            Assert.AreEqual("-83732 + 4i", (z1 - z2).ToString());
            z1 = new Complex(-99, 5.44);
            z2 = new Complex(-1, 4.551);
            Assert.AreEqual("-98 + 0,889i", (z1 - z2).ToString());
        }

        [TestMethod]
        public void Test_ComplexMultiply()
        {
            Complex z1 = new Complex(3, -2);
            Complex z2 = new Complex(0, 3);
            Assert.AreEqual("6 + 9i", (z1 * z2).ToString());
            Assert.AreEqual("6 - 4i", (z1 * 2).ToString());
            z1 = new Complex(137, 1);
            z2 = new Complex(-1, 137);
            Assert.AreEqual("-274 + 18768i", (z1 * z2).ToString());
            Assert.AreEqual("959 + 7i", (z1 * 7).ToString());
            Assert.AreEqual("-37 + 5069i", (z2 * 37).ToString());
            z1 = new Complex(13.7, -2.32);
            z2 = new Complex(2, 6);
            Assert.AreEqual("41,32 + 77,56i", (z1 * z2).ToString());
            z1 = new Complex(0, 0);
            z2 = new Complex(-2, 0);
            Assert.AreEqual("0 + 0i", (z1 * z2).ToString());
        }

        [TestMethod]
        public void Test_ComplexDivide()
        {
            Complex z1 = new Complex(3, -3);
            Complex z2 = new Complex(1, 3);
            Assert.AreEqual("-0,6 - 1,2i", (z1/z2).ToString());
            Assert.AreEqual("1 - 1i", (z1/3).ToString());
            z1 = new Complex(137, 1);
            z2 = new Complex(-1, 137);
            Assert.AreEqual("0 - 1i", (z1 / z2).ToString());
            Assert.AreEqual("1 + 0,0072992700729927i", (z1 / 137).ToString()); //1+0.0073i
            z1 = new Complex(13.7, -2.32);
            z2 = new Complex(2, 6);
            Assert.AreEqual("0,337 - 2,171i", (z1 / z2).ToString());
            z1 = new Complex(3, -4/5);
            z2 = new Complex(0, 1);
            Assert.AreEqual("0 - 3i", (z1 / z2).ToString());
            z1 = new Complex(0, 9);
            z2 = new Complex(-2, 0);
            Assert.AreEqual("0 - 4,5i", (z1 / z2).ToString());

        }
        
        [TestMethod]
        public void Test_ComplexIsIdentical()
        {
            Complex z1 = new Complex(3, -3);
            Complex z2 = new Complex(3, -3);
            Complex z3 = new Complex(0, -1);
            Assert.AreEqual("True", (z1 == z2).ToString());
            Assert.AreEqual("False", (z1 != z2).ToString());
            Assert.AreEqual("False", (z3 == z2).ToString());
        }


        [TestMethod]
        public void Test_AllComplex()
        {
            Complex z1 = new Complex(1, 3);
            Complex z2 = new Complex(3, -3.5);
            Complex z3 = new Complex(5, 9.0809);
            Assert.AreEqual("1,5733908555839 - 2,65756100409436i", (((z1*z2 + z2) * 2 - z1)/z3).ToString());
            z1 = new Complex(13.7, -2.32);
            z2 = new Complex(2, 6);
            z3 = new Complex(5, 9.0);
            Assert.AreEqual("45,38 + 159,7i", ((z1 + z2) * z3).ToString());
            z1 = new Complex(2.5, -6);
            z2 = new Complex(5, 9.0);
            Assert.AreEqual("132,681081081081 - 14,8864864864865i", (z1 * (z2 * 2) + z2 / (z1 - z2) / 2).ToString());
        }
    }

    [TestClass]
    public class PolinomUnitTest
    {  
        static double[] k = { 6, -5, 2 };
        Polinom pol = new Polinom(k);

        [TestMethod]
        public void Test_Polinom()
        {
            Assert.AreEqual(k, pol.Koef);
            Assert.AreEqual(2, pol.N);
        }

    }


}
