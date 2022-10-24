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
    public partial class StudentWF : Form
    {
        public StudentWF()
        {
            InitializeComponent();
        }

        private void buttonStudents_Click(object sender, EventArgs e)
        {
            Student std1 = new Student
            {
                Name = "Марина",
                University = "ТвГТУ",
                Faculty = "ФИТ",
                StudingYears = 6,
                SumDebt = 2
            };
            StudentInfo.Text=PrintStudentProps(std1) + Environment.NewLine;
            Student std2 = new Student
            {
                Name = "Матвей",
                University = "ТвГТУ",
                Faculty = "ФПИЭ",
                StudingYears = 2,
                SumDebt = 0
            };
            StudentInfo.Text+=PrintStudentProps(std2) + Environment.NewLine;
            Student std3 = new Student
            {
                Name = "Вадим",
                University = "ТвГТУ",
                Faculty = "ФИТ",
                StudingYears = 1,
                SumDebt = 6
            };
            StudentInfo.Text+=PrintStudentProps(std3)+Environment.NewLine;
        }
        private string PrintStudentProps(Student std)
        {
            return "Имя: " + std.Name +", Университет: " + std.University + ", Факультет: " + std.Faculty + Environment.NewLine +
                "Форма обучения: " + std.GetStage + ", Курс: " + std.GetCourse + ", Статус: " + std.GetStatus+Environment.NewLine;
        }
    }
}
