
namespace MainFormOOP
{
    partial class ComplexWF
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
            this.Calculate = new System.Windows.Forms.Button();
            this.Rezult = new System.Windows.Forms.TextBox();
            this.Real1 = new System.Windows.Forms.TextBox();
            this.Imaginary1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Real2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Imaginary2 = new System.Windows.Forms.TextBox();
            this.Random = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Calculate
            // 
            this.Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.Location = new System.Drawing.Point(709, 28);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(321, 60);
            this.Calculate.TabIndex = 0;
            this.Calculate.Text = "Операции с заданными числами";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // Rezult
            // 
            this.Rezult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rezult.Location = new System.Drawing.Point(12, 179);
            this.Rezult.Multiline = true;
            this.Rezult.Name = "Rezult";
            this.Rezult.ReadOnly = true;
            this.Rezult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Rezult.Size = new System.Drawing.Size(1018, 356);
            this.Rezult.TabIndex = 1;
            // 
            // Real1
            // 
            this.Real1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Real1.Location = new System.Drawing.Point(17, 44);
            this.Real1.Name = "Real1";
            this.Real1.Size = new System.Drawing.Size(347, 34);
            this.Real1.TabIndex = 2;
            // 
            // Imaginary1
            // 
            this.Imaginary1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Imaginary1.Location = new System.Drawing.Point(387, 44);
            this.Imaginary1.Name = "Imaginary1";
            this.Imaginary1.Size = new System.Drawing.Size(276, 34);
            this.Imaginary1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Действительная часть первого числа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(382, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Мнимая часть первого числа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Действительная чать второго числа";
            // 
            // Real2
            // 
            this.Real2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Real2.Location = new System.Drawing.Point(17, 121);
            this.Real2.Name = "Real2";
            this.Real2.Size = new System.Drawing.Size(347, 34);
            this.Real2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(381, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Мнимая чать второго числа";
            // 
            // Imaginary2
            // 
            this.Imaginary2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Imaginary2.Location = new System.Drawing.Point(386, 121);
            this.Imaginary2.Name = "Imaginary2";
            this.Imaginary2.Size = new System.Drawing.Size(277, 34);
            this.Imaginary2.TabIndex = 9;
            // 
            // Random
            // 
            this.Random.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Random.Location = new System.Drawing.Point(709, 105);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(321, 60);
            this.Random.TabIndex = 10;
            this.Random.Text = "Операции со случайными числами";
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // ComplexWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 554);
            this.Controls.Add(this.Random);
            this.Controls.Add(this.Imaginary2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Real2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Imaginary1);
            this.Controls.Add(this.Real1);
            this.Controls.Add(this.Rezult);
            this.Controls.Add(this.Calculate);
            this.Name = "ComplexWF";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.TextBox Rezult;
        private System.Windows.Forms.TextBox Real1;
        private System.Windows.Forms.TextBox Imaginary1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Real2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Imaginary2;
        private System.Windows.Forms.Button Random;
    }
}