
namespace MainFormOOP
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bComplex = new System.Windows.Forms.Button();
            this.bMatrix = new System.Windows.Forms.Button();
            this.bStudent = new System.Windows.Forms.Button();
            this.bTeacher = new System.Windows.Forms.Button();
            this.bVehicle = new System.Windows.Forms.Button();
            this.bPolinom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bComplex
            // 
            this.bComplex.Location = new System.Drawing.Point(173, 72);
            this.bComplex.Name = "bComplex";
            this.bComplex.Size = new System.Drawing.Size(279, 61);
            this.bComplex.TabIndex = 0;
            this.bComplex.Text = "Комплексыне числа";
            this.bComplex.UseVisualStyleBackColor = true;
            this.bComplex.Click += new System.EventHandler(this.bComplex_Click);
            // 
            // bMatrix
            // 
            this.bMatrix.Location = new System.Drawing.Point(173, 139);
            this.bMatrix.Name = "bMatrix";
            this.bMatrix.Size = new System.Drawing.Size(279, 61);
            this.bMatrix.TabIndex = 1;
            this.bMatrix.Text = "Матрицы";
            this.bMatrix.UseVisualStyleBackColor = true;
            this.bMatrix.Click += new System.EventHandler(this.bMatrix_Click);
            // 
            // bStudent
            // 
            this.bStudent.Location = new System.Drawing.Point(173, 206);
            this.bStudent.Name = "bStudent";
            this.bStudent.Size = new System.Drawing.Size(279, 61);
            this.bStudent.TabIndex = 2;
            this.bStudent.Text = "Студенты";
            this.bStudent.UseVisualStyleBackColor = true;
            this.bStudent.Click += new System.EventHandler(this.bStudent_Click);
            // 
            // bTeacher
            // 
            this.bTeacher.Location = new System.Drawing.Point(173, 273);
            this.bTeacher.Name = "bTeacher";
            this.bTeacher.Size = new System.Drawing.Size(279, 61);
            this.bTeacher.TabIndex = 3;
            this.bTeacher.Text = "Преподаватели";
            this.bTeacher.UseVisualStyleBackColor = true;
            this.bTeacher.Click += new System.EventHandler(this.bTeacher_Click);
            // 
            // bVehicle
            // 
            this.bVehicle.Location = new System.Drawing.Point(173, 340);
            this.bVehicle.Name = "bVehicle";
            this.bVehicle.Size = new System.Drawing.Size(279, 61);
            this.bVehicle.TabIndex = 4;
            this.bVehicle.Text = "Автомобили";
            this.bVehicle.UseVisualStyleBackColor = true;
            this.bVehicle.Click += new System.EventHandler(this.bVehicle_Click);
            // 
            // bPolinom
            // 
            this.bPolinom.Location = new System.Drawing.Point(173, 407);
            this.bPolinom.Name = "bPolinom";
            this.bPolinom.Size = new System.Drawing.Size(279, 61);
            this.bPolinom.TabIndex = 5;
            this.bPolinom.Text = "Полиномы?";
            this.bPolinom.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 601);
            this.Controls.Add(this.bPolinom);
            this.Controls.Add(this.bVehicle);
            this.Controls.Add(this.bTeacher);
            this.Controls.Add(this.bStudent);
            this.Controls.Add(this.bMatrix);
            this.Controls.Add(this.bComplex);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bComplex;
        private System.Windows.Forms.Button bMatrix;
        private System.Windows.Forms.Button bStudent;
        private System.Windows.Forms.Button bTeacher;
        private System.Windows.Forms.Button bVehicle;
        private System.Windows.Forms.Button bPolinom;
    }
}

