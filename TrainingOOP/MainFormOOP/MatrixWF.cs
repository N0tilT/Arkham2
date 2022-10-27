﻿using System;
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
        }

        private void bCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                Matrix mass1 = new Matrix(int.Parse(Size.Text));
                mass1.MakeRandMatrix(int.Parse(Min.Text), int.Parse(Max.Text));
                Rezult.Text = Rezult.Text + "Матрица A:" + Environment.NewLine;
                PrintMatrix(mass1);

                Matrix mass2 = new Matrix(int.Parse(Size.Text));
                mass2.MakeRandMatrix(int.Parse(Min.Text), int.Parse(Max.Text));
                Rezult.Text = Rezult.Text + "Матрица B:" + Environment.NewLine;
                PrintMatrix(mass2);

                Matrix mass3 = new Matrix(int.Parse(Size.Text));
                Rezult.Text = Rezult.Text + "Сумма матриц A и В:" + Environment.NewLine;
                mass3 = mass1 + mass2;
                PrintMatrix(mass3);

                Matrix mass4 = new Matrix(int.Parse(Size.Text));
                Rezult.Text = Rezult.Text + "Разность матриц А и В:" + Environment.NewLine;
                mass4 = mass1 - mass2;
                PrintMatrix(mass4);

                Matrix mass5 = new Matrix(int.Parse(Size.Text));
                Rezult.Text = Rezult.Text + "Умножение матрицы А на число:" + Environment.NewLine;
                mass5 = mass1 * int.Parse(Mult.Text);
                PrintMatrix(mass5);

                Matrix mass6 = new Matrix(int.Parse(Size.Text));
                Rezult.Text = Rezult.Text + "Произведение матриц А и В:" + Environment.NewLine;
                mass6 = mass1 * mass2;
                PrintMatrix(mass6);

                Matrix mass7 = new Matrix(int.Parse(Size.Text));
                Rezult.Text = Rezult.Text + "Возведение матрицы B в степень" + Environment.NewLine;
                mass7 = mass2 ^ int.Parse(Pow.Text);
                PrintMatrix(mass7);

                Rezult.Text = Rezult.Text + "Определитель матрицы А:" + Environment.NewLine;
                double def1 = !mass1;
                Rezult.Text +=  def1 + Environment.NewLine+Environment.NewLine;

                Matrix mass8 = new Matrix(int.Parse(Size.Text));
                Rezult.Text += "Транспонирование матрицы B" + Environment.NewLine;
                mass8 = ~mass2;
                PrintMatrix(mass8);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректное заполнение полей/Не все поля заполнены");
            }
        }
        public void PrintMatrix(Matrix mas)
        {
            string s;
            for (int i = 0; i < mas.N; i++)
            {
                for (int j = 0; j < mas.N; j++)
                {
                    s=(mas[i, j] + " ");
                    Rezult.Text += s;
                }
                Rezult.Text += Environment.NewLine;
            }
            Rezult.Text += Environment.NewLine;  
        }
    }
}
