using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormOOP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void bComplex_Click(object sender, EventArgs e)
        {
            ComplexWF f = new ComplexWF();
            f.Show();

        }

        private void bMatrix_Click(object sender, EventArgs e)
        {
            MatrixWF f = new MatrixWF();
            f.Show();
        }

        private void bStudent_Click(object sender, EventArgs e)
        {
            StudentWF f = new StudentWF();
            f.Show();

        }

        private void bTeacher_Click(object sender, EventArgs e)
        {
            TeacherWF f = new TeacherWF();
            f.Show();
        }

        private void bVehicle_Click(object sender, EventArgs e)
        {
            VehicleWF f = new VehicleWF();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PolynomWF f = new PolynomWF();
            f.Show();
        }
    }
}
