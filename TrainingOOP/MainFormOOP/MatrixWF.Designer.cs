
namespace MainFormOOP
{
    partial class MatrixWF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Size = new System.Windows.Forms.TextBox();
            this.Max = new System.Windows.Forms.TextBox();
            this.Min = new System.Windows.Forms.TextBox();
            this.Mult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Pow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bCalculate = new System.Windows.Forms.Button();
            this.Rezult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Size
            // 
            this.Size.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Size.Location = new System.Drawing.Point(348, 18);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(228, 34);
            this.Size.TabIndex = 0;
            // 
            // Max
            // 
            this.Max.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Max.Location = new System.Drawing.Point(349, 98);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(228, 34);
            this.Max.TabIndex = 1;
            // 
            // Min
            // 
            this.Min.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Min.Location = new System.Drawing.Point(348, 58);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(228, 34);
            this.Min.TabIndex = 2;
            // 
            // Mult
            // 
            this.Mult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mult.Location = new System.Drawing.Point(349, 138);
            this.Mult.Name = "Mult";
            this.Mult.Size = new System.Drawing.Size(228, 34);
            this.Mult.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Размер квадратной матрицы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Максимальный элемент матрицы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Минимальный элемент матрицы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Умножить матрицу на число";
            // 
            // Pow
            // 
            this.Pow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pow.Location = new System.Drawing.Point(348, 178);
            this.Pow.Name = "Pow";
            this.Pow.Size = new System.Drawing.Size(229, 34);
            this.Pow.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(12, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Возвести матрицу в степень";
            // 
            // bCalculate
            // 
            this.bCalculate.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCalculate.Location = new System.Drawing.Point(597, 18);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(175, 74);
            this.bCalculate.TabIndex = 10;
            this.bCalculate.Text = "Вычислить";
            this.bCalculate.UseVisualStyleBackColor = true;
            this.bCalculate.Click += new System.EventHandler(this.bCalculate_Click);
            // 
            // Rezult
            // 
            this.Rezult.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rezult.Location = new System.Drawing.Point(12, 231);
            this.Rezult.Multiline = true;
            this.Rezult.Name = "Rezult";
            this.Rezult.ReadOnly = true;
            this.Rezult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Rezult.Size = new System.Drawing.Size(760, 384);
            this.Rezult.TabIndex = 11;
            // 
            // MatrixWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 627);
            this.Controls.Add(this.Rezult);
            this.Controls.Add(this.bCalculate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Pow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mult);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.Size);
            this.Name = "MatrixWF";
            this.Text = "Операции с квадратными матрицами";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Size;
        private System.Windows.Forms.TextBox Max;
        private System.Windows.Forms.TextBox Min;
        private System.Windows.Forms.TextBox Mult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Pow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bCalculate;
        private System.Windows.Forms.TextBox Rezult;
    }
}