using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOOP
{
    //Полина

    /// <summary>
    /// Класс, задающий
    /// основные данные о студенте
    /// </summary>
    public class Student
    {

        public enum Stage //список перечислений форм обучения
        {
            бакалавриат,
            магистратура,
            аспирантура
        }
        public enum Status //список перечислений статуса студента
        {
            аттестован,
            имеет_задолженности,
            отчислен
        }
        //поля 
        string name; //Имя 
        string univer; //Университет
        string facult = ""; //Факультет(закрытое поле)
        int years; //Суммарные годы обучения
        int course; //Курс
        int sumdebt; //Число долгов
        Stage stage;
        Status status;

        //методы - свойства

        /// <summary>
        /// информация о статусе студента
        /// </summary>
        public Status GetStatus
        {
            get { return status; }
        }
        /// <summary>
        /// информация о форме обучения студента
        /// </summary>
        public Stage GetStage
        {
            get { return stage; }
        }
        /// <summary>
        /// информация о имени студента
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// информация о названии университета
        /// </summary>
        public string University
        {
            get { return univer; }
            set { univer = value; }
        }
        /// <summary>
        /// информация о названии факультета
        /// </summary>
        public string Faculty
        {
            get { return facult; }
            set { if (facult == "") facult = value; }
        }

        const int maxbac = 4; //максимальные года обучения на бакалавриат
        const int maxmag = 6; //максимальные года обучения на магистратуру
        const int maxyears = 8; //максимальные года обучения на аспирантуру
        /// <summary>
        /// информация о годах обучения
        /// рассчёт формы обучения и курса студента
        /// </summary>
        public int StudingYears
        {
            get { return years; }
            set
            {
                if (value > 0 && value <= maxyears) years = value;

                if (years <= maxbac)
                {
                    stage = Stage.бакалавриат;
                    course = years;
                }
                else if (years <= maxmag)
                {
                    stage = Stage.магистратура;
                    course = years - maxbac;
                }
                else
                {
                    stage = Stage.аспирантура;
                    course = years - maxmag;
                }
            }
        }
        /// <summary>
        /// Read-Only
        /// информация о курсе студента
        /// </summary>
        public int GetCourse
        {
            get { return course; }
        }
        const int maxdebt = 3; // максимальное число долгов, при котором не происходит отчисление
        public int SumDebt
        {
            get { return sumdebt; }
            set
            {
                if (value >= 0) sumdebt = value;
                {
                    if (sumdebt == 0) status = (Status)0; //Статус 'аттестован' в другой форме записи
                    else if (sumdebt <= maxdebt) status = Status.имеет_задолженности;
                    else status = Status.отчислен;
                }
            }
        }
    }
}
