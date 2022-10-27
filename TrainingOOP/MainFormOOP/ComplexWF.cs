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
    public partial class ComplexWF : Form
    {
        public ComplexWF()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Complex z1, z2;
            try
            {
                z1 = new Complex(int.Parse(Real1.Text), int.Parse(Imaginary1.Text));
                z2 = new Complex(int.Parse(Real2.Text), int.Parse(Imaginary2.Text));

                Rezult.Text = ("Инициализированные комплексные числа:") + "\r\n";
                Rezult.Text += string.Format("z1 = {0}", z1) + "\r\n";
                Rezult.Text += string.Format("z2 = {0}", z2) + "\r\n";
                ComplexOperations(z1, z2);
            }
            catch (Exception)
            {
                MessageBox.Show("Поля заполнены некорректно или не заполнены вовсе");
            }
        }
        public void ComplexOperations(Complex z1,Complex z2)
        {
            Complex z3;
            Rezult.Text += "Операции:" + "\r\n";
            z3 = z1 + z2; Rezult.Text += string.Format("z1 + z2 = {0}", z3) + "\r\n";
            z3 = z1 - z2; Rezult.Text += (string.Format("z1 - z2 = {0}", z3)) + "\r\n";
            z3 = z1 * z2; Rezult.Text += (string.Format("z1 * z2 = {0}", z3)) + "\r\n";
            z3 = z1 * 4.0; Rezult.Text += (string.Format("z1 * 4 = {0}", z3)) + "\r\n";
            z3 = z1 / z2; Rezult.Text += (string.Format("z1 / z2 = {0}", z3)) + "\r\n";
            z3 = z1 / 4.0; Rezult.Text += (string.Format("z1 / 4 = {0}", z3)) + "\r\n";
            z3 = z1 * (z2 * 2) + z2 / (z1 - z2) / 2;
            Rezult.Text += string.Format("z1 * (z2 * 2) + z2 / (z1 - z2) / 2 = {0}", z3) + "\r\n";
        }

        private void Random_Click(object sender, EventArgs e)
        {
            Complex z1, z2;
            z1 = Complex.Random(-100.0,100.0);
            z2 = Complex.Random(-100.0, 100.0);
            Rezult.Text = "Случайные комплексные числа:" + "\r\n";
            Rezult.Text += string.Format("z1 = {0}", z1) + "\r\n";
            Rezult.Text += string.Format("z2 = {0}", z2) + "\r\n";
            ComplexOperations(z1, z2);

        }
    }
}
