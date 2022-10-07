using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingOOP;

namespace TestingClassesCA
{
    /// <summary>
    /// Класс с тестами методов
    /// классов DLL TrainingOOPCL
    /// </summary>
    class Test
    {
        //Ошибка set { if (brand == "") brand = value; }
        //Ошибка if (numberOfOwners == 1) used = Used.новый;

        /// <summary>
        /// Тестирование свойств объектов
        /// класса Vehicle
        /// </summary>
        public void TestVehicleProps()
        {
            Vehicle vehicle1 = new Vehicle();

            vehicle1.Setcolor = Color.Black;
            vehicle1.VIN = "WAUYP64B01N141245";
            vehicle1.GosID = "х677кн";
            vehicle1.Brand = "BMW";
            vehicle1.Model = "X6 40d III(GO6)";
            vehicle1.ReleaseYear = 2022;
            vehicle1.SetBody = Vehicle.Body.внедорожник;
            vehicle1.NumberOfDoors = 5;
            vehicle1.NumberOfOwners = 1;
            vehicle1.SetCondition = Vehicle.Condition.Не_требует_ремонта;
            vehicle1.SetEngineType = Vehicle.EngineType.дизель;
            vehicle1.SetDriveType = Vehicle.DriveType.полный;
            vehicle1.SetTransmissionType = Vehicle.Transmission.автоматическая;
            vehicle1.SetSteeringWheelPosition = Vehicle.SteeringWheelPosition.левый;
            vehicle1.Mileage = 9620;

            Console.WriteLine("TestVehicleProps()");
            PrintVehicleInfo(vehicle1);
        }
        /// <summary>
        /// Печать "карточки автомобиля"
        /// в консоль
        /// </summary>
        /// <param name="vehicle1"></param>
        private void PrintVehicleInfo(Vehicle vehicle1)
        {
            Console.WriteLine("КАРТОЧКА АВТОМОБИЛЯ:\n" +
                              "{0} {1} , {2}\n" +
                              "Год выпуска: {3}\n" +
                              "Пробег: {4}\n" +
                              "Кузов:  {5},{6}-дв.\n" +
                              "Цвет: {7}\n" +
                              "Двигатель: {8}\n" +
                              "КПП: {9}\n" +
                              "Привод: {10}\n" +
                              "Руль: {11}\n" +
                              "Состояние: {12}\n" +
                              "Владельцы: {13} владелец\n" +
                              "ПТС: {14}\n" +
                              "VIN: {15}\n" +
                              "Гос.номер: {16}\n",
                vehicle1.Brand,vehicle1.Model,vehicle1.GetUsed,
                vehicle1.ReleaseYear,
                vehicle1.Mileage,
                vehicle1.GetBody, vehicle1.NumberOfDoors,
                vehicle1.Getcolor,
                vehicle1.GetEngineType,
                vehicle1.GetTransmissionType,
                vehicle1.GetDriveType,
                vehicle1.GetSteeringWheelPosition,
                vehicle1.GetCondition,
                vehicle1.NumberOfOwners,
                vehicle1.GetPTS,
                vehicle1.VIN,
                vehicle1.GosID
                );
        }

        /// <summary>
        /// Тестирование свойства used 
        /// класса Vehicle
        /// </summary>
        public void TestVehicleUsed()
        {
            Vehicle vehicleUsed = new Vehicle(),
                    vehicleUsed2 = new Vehicle(),
                    vehicleUsed3 = new Vehicle(),
                    vehicleNew = new Vehicle(),
                    vehicleNew2 = new Vehicle(),
                    vehicleNew3 = new Vehicle();

            vehicleUsed.Mileage = 1000;
            vehicleUsed2.NumberOfOwners = 2;
            vehicleUsed3.SetCondition = Vehicle.Condition.Битый_или_не_на_ходу;
            vehicleNew.Mileage = 0;
            vehicleNew2.NumberOfOwners = 0;
            vehicleNew3.SetCondition = Vehicle.Condition.Не_требует_ремонта;

            Console.WriteLine("TestVehicleUsed()");
            PrintUsedPropVehicle(vehicleUsed);
            PrintUsedPropVehicle(vehicleUsed2);
            PrintUsedPropVehicle(vehicleUsed3);
            PrintUsedPropVehicle(vehicleNew);
            PrintUsedPropVehicle(vehicleNew2);
            PrintUsedPropVehicle(vehicleNew3);

        }

        private void PrintUsedPropVehicle(Vehicle vehicleUsed)
        {
            Console.WriteLine("Состояние автомобиля: {0}",vehicleUsed.GetUsed);
        }

        /// <summary>
        /// Тестирование свойств объектов
        /// класса Student
        /// </summary>
        public void TestStudentProps()
        {
            Student std1 = new Student
            {
                Name = "Марина",
                University = "ТвГТУ",
                Faculty = "ФИТ",
                StudingYears = 6,
                SumDebt = 2
            };
            PrintStudentProps(std1);
            Student std2 = new Student
            {
                Name = "Матвей",
                University = "ТвГТУ",
                Faculty = "ФПИЭ",
                StudingYears = 2,
                SumDebt = 0
            };
            PrintStudentProps(std2);
            Student std3 = new Student
            {
                Name = "Вадим",
                University = "ТвГТУ",
                Faculty = "ФИТ",
                StudingYears = 1,
                SumDebt = 6
            };
            PrintStudentProps(std3);
        }

        private void PrintStudentProps(Student std)
        {
            Console.WriteLine("Имя: {0}, Университет: {1}, Факультет: {2},\n" +
                "Форма обучения: {3}, Курс: {4}, Статус: {5}",
                std.Name, std.University, std.Faculty, std.GetStage,
                std.GetCourse, std.GetStatus);
            Console.WriteLine();
        }
        public void TeacherTest()
        {
            Teacher teach1 = new Teacher
            {
                Name = "Чернигова Марина Ивановна",
                Degree = "Кандидат филологических наук",
                Positions = "Доцент",
                Workplace = "ТвГУ",
                Experience = 6,
                Phone = "89607183375"
            };
            PrintTeacher(teach1);
            Teacher teach2 = new Teacher
            {
                Name = "Увалов Александр Леонидович",
                Degree = "Доктор математических наук",
                Positions = "Декан",
                Workplace = "ТвГTУ",
                Experience = 16,
                Phone = "89607186375"
            };
            PrintTeacher(teach2);
            Teacher teach3 = new Teacher
            {
                Name = "Смирнова Елена Дмитриевна",
                Degree = "Кандидат педогогических наук",
                Positions = "Старший преподаватель",
                Workplace = "ТвГУ",
                Experience = 14,
                Phone = "89677193375"
            };
            PrintTeacher(teach3);
            Teacher teach4 = new Teacher
            {
                Name = "Дятлов Иван Олегович",
                Degree = "Без ученой степень",
                Positions = "Старший преподаватель",
                Workplace = "ТвГТУ",
                Experience = 2,
                Phone = "89578193475"
            };
            PrintTeacher(teach4);
            Teacher teach5 = new Teacher
            {
                Name = "Печорин Роман Валерьевич",
                Degree = "Доктор физико-математических наук",
                Positions = "Ректор",
                Workplace = "ТвГТУ",
                Experience = 24,
                Phone = "89558193476"
            };
            PrintTeacher(teach5);
        }
        static void PrintTeacher(Teacher teach)
        {
            Console.WriteLine("ФИО преподавателя: {0}, Ученая степень: {1}, Место работы: {2},\n" +
                "Опыт работы: {3}, Ученая степень: {4}, Занимаемая должность: {5}, Контактный номер: {6}",
                teach.Name, teach.Degree, teach.Workplace, teach.Experience,
                teach.GetAcademicTitle, teach.Positions, teach.Phone);
            Console.WriteLine();
        }

        /// <summary>
        /// Тестирование класса Complex
        /// </summary>
        public void TestComplex()
        {
            Complex z1, z2, z3;

            Console.WriteLine();

            // Инициализация
            z1 = new Complex(1.0, -2.0);
            z2 = new Complex(-3.0, 5.0);
            z3 = new Complex(0.292342, -0.394875);

            Console.WriteLine("Инициализированные комплексные числа:");
            Console.WriteLine(string.Format("z1 = {0}", z1));
            Console.WriteLine(string.Format("z2 = {0}", z2));
            Console.WriteLine(string.Format("z3 = {0}", z3));
            Console.WriteLine();

            Console.WriteLine("Основные поля:");
            Console.WriteLine(string.Format("z1.real = {0}\nz1.imaginary = {1}", z1.Real, z1.Imaginary));
            Console.WriteLine(string.Format("z2.real = {0}\nz2.imaginary = {1}", z2.Real, z2.Imaginary));
            Console.WriteLine(string.Format("z3.real = {0}\nz3.imaginary = {1}", z3.Real, z3.Imaginary));
            Console.WriteLine();

            Console.WriteLine("Операции:");
            z3 = z1 + z2; Console.WriteLine(string.Format("z1 + z2 = {0}", z3));
            z3 = z1 - z2; Console.WriteLine(string.Format("z1 - z2 = {0}", z3));
            z3 = z1 * z2; Console.WriteLine(string.Format("z1 * z2 = {0}", z3));
            z3 = z1 * 4.0; Console.WriteLine(string.Format("z1 * 4 = {0}", z3));
            z3 = z1 / z2; Console.WriteLine(string.Format("z1 / z2 = {0}", z3));
            z3 = z1 / 4.0; Console.WriteLine(string.Format("z1 / 4 = {0}", z3));
            Console.WriteLine();

            // Случайные комплексные числа
            z1 = Complex.Random();
            z2 = Complex.Random(-10.0, 10.0);
            z3 = Complex.Random(-100.0, 100.0);

            Console.WriteLine("Случайные комплексные числа:");
            Console.WriteLine(string.Format("z1 = {0}", z1));
            Console.WriteLine(string.Format("z2 = {0}", z2));
            Console.WriteLine(string.Format("z3 = {0}", z3));
            Console.WriteLine();
        }

        /// <summary>
        /// Тестирование класса Matrix
        /// </summary>
        public void TestMatrix()
        {
            //Ввод размерности квадратной матрицы
            int nn = 3;

            //Указание диапазона из которого будут выбираться случайные числа
            int min = 1;
            int max = 11;

            //Число на которое умножаем матрицу
            double b = 5;

            //Число в какую степень возводим матрицу
            int c = 2;


            Matrix mass1 = new Matrix(nn);
            mass1.MakeRandMatrix(min,max);
            Console.WriteLine("Матрица A:");
            PrintMatrix(mass1);
            Console.WriteLine();

            Matrix mass2 = new Matrix(nn);
            mass2.MakeRandMatrix(min, max);
            Console.WriteLine("Матрица B:");
            PrintMatrix(mass2);
            Console.WriteLine();

            Matrix mass3 = new Matrix(nn);
            Console.WriteLine("Сумма матриц A и B");
            mass3 = mass1+mass2;
            PrintMatrix(mass3);
            Console.WriteLine();

            Matrix mass4 = new Matrix(nn);
            Console.WriteLine("Разность матриц A и B");
            mass4 = mass1 - mass2;
            PrintMatrix(mass4);
            Console.WriteLine();

            Matrix mass5 = new Matrix(nn);
            Console.WriteLine($"Умножение матрицы A на число {b}");
            mass5 = mass1 * b;
            PrintMatrix(mass5);
            Console.WriteLine();

            Matrix mass6 = new Matrix(nn);
            Console.WriteLine("Произведение матриц A и B");
            mass6 = mass1 * mass2;
            PrintMatrix(mass6);
            Console.WriteLine();

            Matrix mass7 = new Matrix(nn);
            Console.WriteLine($"Возведение матрицы B в степень {c}");
            mass7 = mass2 ^ c;
            PrintMatrix(mass7);
            Console.WriteLine();


            Console.WriteLine("Определитель матрицы A");
            double def1 = !mass1;
            Console.WriteLine(def1);
            Console.WriteLine();

            Matrix mass8 = new Matrix(nn);
            Console.WriteLine("Транспонирование матрицы B");
            mass8 = ~mass2;
            PrintMatrix(mass8);
            Console.WriteLine();
        }
        /// <summary>
        /// Вывод объекта класса Matrix
        /// </summary>
        public void PrintMatrix(Matrix mas)
        {
            for (int i = 0; i < mas.N; i++)
            {
                for (int j = 0; j < mas.N; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
