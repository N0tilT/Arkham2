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
        #region enums
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
        #endregion

        #region fields
        //поля 
        string _name; //Имя 
        string _univer; //Университет
        string _facult = ""; //Факультет(закрытое поле)
        int _years; //Суммарные годы обучения
        int _course; //Курс
        int _sumdebt; //Число долгов
        Stage _stage;
        Status _status;
        #endregion

        #region propirties
        //методы - свойства

        /// <summary>
        /// информация о статусе студента
        /// </summary>
        public Status GetStatus
        {
            get { return _status; }
        }
        /// <summary>
        /// информация о форме обучения студента
        /// </summary>
        public Stage GetStage
        {
            get { return _stage; }
        }
        /// <summary>
        /// информация о имени студента
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// информация о названии университета
        /// </summary>
        public string University
        {
            get { return _univer; }
            set { _univer = value; }
        }
        /// <summary>
        /// информация о названии факультета
        /// </summary>
        public string Faculty
        {
            get { return _facult; }
            set { if (_facult == "") _facult = value; }
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
            get { return _years; }
            set
            {
                if (value > 0 && value <= maxyears) _years = value;

                if (_years <= maxbac)
                {
                    _stage = Stage.бакалавриат;
                    _course = _years;
                }
                else if (_years <= maxmag)
                {
                    _stage = Stage.магистратура;
                    _course = _years - maxbac;
                }
                else
                {
                    _stage = Stage.аспирантура;
                    _course = _years - maxmag;
                }
            }
        }
        /// <summary>
        /// Read-Only
        /// информация о курсе студента
        /// </summary>
        public int GetCourse
        {
            get { return _course; }
        }
        const int maxdebt = 3; // максимальное число долгов, при котором не происходит отчисление
        public int SumDebt
        {
            get { return _sumdebt; }
            set
            {
                if (value >= 0) _sumdebt = value;
                {
                    if (_sumdebt == 0) _status = (Status)0; //Статус 'аттестован' в другой форме записи
                    else if (_sumdebt <= maxdebt) _status = Status.имеет_задолженности;
                    else _status = Status.отчислен;
                }
            }
        }
        #endregion
    }
}
