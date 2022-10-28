using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingOOP;

namespace MainFormOOP
{
    public partial class TeacherWF : Form
    {
        public TeacherWF()
        {
            InitializeComponent();
        }

        private void buttonTeacher_Click(object sender, EventArgs e)
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
        private void PrintTeacher(Teacher teach)
        {
            TeacherText.Text += "ФИО преподавателя: " + teach.Name + ", Ученая степень: " + teach.Degree + ", Место работы: " + teach.Workplace +
                Environment.NewLine + "Опыт работы: " + teach.Experience + " г."+", Ученая степень: " + teach.GetAcademicTitle +
                ", Занимаемая должность: " + teach.Positions + ", Контактный номер: " + teach.Phone + Environment.NewLine+ "\r\n";
        }
    }
}
