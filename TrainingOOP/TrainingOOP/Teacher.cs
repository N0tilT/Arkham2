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
        public enum AcademicTitle //Ученые звания
        {
            Без_ученого_звания,
            Доцент,
            Профессор
        }


        //Поля класса
        string name; //ФИО преподователя
        int experience; //опыт работы/стаж
        string phone; //номер телефона
        string degree; //учёная степень
        AcademicTitle title; //ученое звание, зависящее от ученой степени
        string position; //должность
        string workplace; //место работы

        //Методы-свойства класса
        /// <summary>
        /// Чтение ученого звания преподавателя
        /// </summary>
        public AcademicTitle GetAcademicTitle
        {
            get { return title; }
        }
        /// <summary>
        /// Чтение-запись должности преподавателя
        /// </summary>
        public string Positions 
        {
            get { return position; }
            set { position = value; }
        }
        /// <summary>
        /// Чтение-запись ФИО преподователя
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Чтение-запись опыта работы преподователя
        /// </summary>
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        /// <summary>
        /// Чтение-запись контактного номера преподователя
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// Чтение-запись ученой степени преподователя
        /// </summary>
        public string Degree
        {
            get { return degree; }
            set
            {
                degree = value;
                title = AcademicTitle.Без_ученого_звания;
                if (degree.Split(' ')[0] == "Доктор") title = AcademicTitle.Профессор;
                else if (degree.Split(' ')[0] == "Кандидат") title = AcademicTitle.Доцент;
            }

        }
        /// <summary>
        /// Чтение-запись места работы преподователя
        /// </summary>
        public string Workplace
        {
            get { return workplace; }
            set { workplace = value; }
        }
    }

}
