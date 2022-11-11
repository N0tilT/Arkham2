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
    public partial class MatrixWF : Form
    {
        public MatrixWF()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        int l;
        int k;
        Matrix mass1;
        Matrix mass2;
        private void bCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                A.Clear();
                B.Clear();
                Matrix a = new Matrix(int.Parse(Size.Text));
                a.MakeRandMatrix(int.Parse(Min.Text), int.Parse(Max.Text));
                A.Text = A.Text + "Матрица A:" + "\r\n";
                PrintMatrix(a,A);

                Matrix b = new Matrix(int.Parse(Size.Text));
                b.MakeRandMatrix(int.Parse(Min.Text), int.Parse(Max.Text));
                B.Text = B.Text + "Матрица B:" + "\r\n";
                PrintMatrix(b,B);
                mass1 = a;
                mass2 = b;
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректное заполнение полей/Не все поля заполнены");
            }
        }
        public void PrintMatrix(Matrix mas, TextBox X)
        {
            string s;
            for (int i = 0; i < mas.N; i++)
            {
                for (int j = 0; j < mas.N; j++)
                {
                    s=(mas[i, j] + " ");
                    X.Text += s;
                }
                X.Text += "\r\n";
            }
            X.Text += "\r\n";  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                C.Clear();
                if (l == 0)
                {
                    Matrix mass3 = new Matrix(int.Parse(Size.Text));
                    C.Text = C.Text + "Сумма матриц A и В:" + "\r\n";
                    mass3 = mass1 + mass2;
                    PrintMatrix(mass3, C);
                }
                if (l == 1)
                {
                    Matrix mass3 = new Matrix(int.Parse(Size.Text));
                    C.Text = C.Text + "Разность матриц А и В:" + "\r\n";
                    mass3 = mass1 - mass2;
                    PrintMatrix(mass3, C);
                }
                if (l == 2)
                {
                    Matrix mass3 = new Matrix(int.Parse(Size.Text));
                    C.Text = C.Text + "Умножение матрицы на число:" + "\r\n";
                    if (k == 0)
                    { 
                        mass3 = mass1 * int.Parse(Inter.Text);
                    }
                    else
                    {
                        mass3 = mass2 * int.Parse(Inter.Text);
                    }
                    PrintMatrix(mass3, C);
                }
                if (l == 3)
                {
                    Matrix mass3 = new Matrix(int.Parse(Size.Text));
                    C.Text = C.Text + "Произведение матриц А и В:" + "\r\n";
                    mass3 = mass1 * mass2;
                    PrintMatrix(mass3, C);
                }
                if (l == 4)
                {
                    Matrix mass3 = new Matrix(int.Parse(Size.Text));
                    C.Text = C.Text + "Возведение матрицы в степень" + "\r\n";
                    if (k == 0)
                    {
                        mass3 = mass1 & int.Parse(Inter.Text);
                    }
                    else
                    {
                        mass3 = mass2 & int.Parse(Inter.Text);
                    }
                    PrintMatrix(mass3, C);
                }
                if (l == 5)
                {
                    Matrix mass3 = new Matrix(int.Parse(Size.Text));
                    double qq;
                    C.Text = C.Text + "Определитель матрицы:" + "\r\n";
                    if (k == 0)
                    {
                        mass3 = mass1;
                         qq = Matrix.Gauss(mass3);
                    }
                    else
                    {
                        mass3 = mass2;
                         qq = Matrix.Gauss(mass3);
                    }
                    C.Text += qq + "\r\n";
                }
                if (l == 6)
                {
                    Matrix mass3 = new Matrix(int.Parse(Size.Text));
                    C.Text += "Транспонирование матрицы B" + "\r\n";
                    if (k == 0)
                    {
                        mass3 = ~mass1;
                    }
                    else
                    {
                        mass3 = ~mass2;
                    }
                    PrintMatrix(mass3,C);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректное заполнение полей/Не все поля заполнены");
            }
        }
        
        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            Matx.Enabled = false;
            Inter.Enabled = false;
            l = combo.SelectedIndex;
            if (l == 2)
            {
                Matx.Enabled = true;
                Inter.Enabled = true;
            }
            if (l == 4)
            {
                Matx.Enabled = true;
                Inter.Enabled = true;
            }
            if (l == 5)
            {
                Matx.Enabled = true;
            }
            if (l == 6)
            {
                Matx.Enabled = true;
            }
        }

        private void Matx_SelectedIndexChanged(object sender, EventArgs e)
        {
            k = Matx.SelectedIndex;
        }
    }
}
