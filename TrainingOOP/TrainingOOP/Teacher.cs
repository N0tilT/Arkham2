using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOOP
{/// <summary>
/// Класс, задающий общую информацию о преподавателе Вуза
/// </summary>
    public class Teacher
    {
        #region enums
        public enum AcademicTitle //Ученые звания
        {
            Без_ученого_звания,
            Доцент,
            Профессор
        }
        #endregion

        #region fields
        //Поля класса
        string _name; //ФИО преподователя
        int _experience; //опыт работы/стаж
        string _phone; //номер телефона
        string _degree; //учёная степень
        AcademicTitle _title; //ученое звание, зависящее от ученой степени
        string _position; //должность
        string _workplace; //место работы

        List<int> _idstud = new List<int> (); //номер принадлежащего студента

        static Student std0 = new Student
        {
            Name = "Вадим",
            University = "ТвГТУ",
            Faculty = "ФИТ",
            StudingYears = 1,
            SumDebt = 6
        };
        static List<Student> _students = new List<Student>()
        {
             std0
        };
        //Методы-свойства класса
        /// <summary>
        /// Чтение ученого звания преподавателя
        /// </summary>
        public AcademicTitle GetAcademicTitle
        {
            get { return _title; }
        }
        /// <summary>
        /// Чтение-запись должности преподавателя
        /// </summary>
        public string Positions 
        {
            get { return _position; }
            set { _position = value; }
        }
        /// <summary>
        /// Чтение-запись ФИО преподователя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Чтение-запись опыта работы преподователя
        /// </summary>
        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }
        /// <summary>
        /// Чтение-запись контактного номера преподователя
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// Чтение-запись ученой степени преподователя
        /// </summary>
        public string Degree
        {
            get { return _degree; }
            set
            {
                _degree = value;
                _title = AcademicTitle.Без_ученого_звания;
                if (_degree.Split(' ')[0] == "Доктор") _title = AcademicTitle.Профессор;
                else if (_degree.Split(' ')[0] == "Кандидат") _title = AcademicTitle.Доцент;
            }

        }
        /// <summary>
        /// Чтение-запись места работы преподователя
        /// </summary>
        public string Workplace
        {
            get { return _workplace; }
            set { _workplace = value; }
        }
        /// <summary>
        /// Чтение-запись номера студента
        /// </summary>
        public List<int> Idstud
        {
            get { return _idstud; }
            set { _idstud = value; }
        }
        /// <summary>
        /// Чтение списка студентов
        /// </summary>
        public static List<Student> StudList
        {
            get { return _students; }
        }
        #endregion

        #region functions
        /// <summary>
        /// Добавление студента в список
        /// </summary>
        static public void AddStud(Student stud)
        {
            _students.Add(stud);
        }
        #endregion
    }

}
