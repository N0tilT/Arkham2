
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bCalculate = new System.Windows.Forms.Button();
            this.A = new System.Windows.Forms.TextBox();
            this.B = new System.Windows.Forms.TextBox();
            this.combo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.TextBox();
            this.Inter = new System.Windows.Forms.TextBox();
            this.Matx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Size
            // 
            this.Size.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Size.Location = new System.Drawing.Point(261, 15);
            this.Size.Margin = new System.Windows.Forms.Padding(2);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(172, 29);
            this.Size.TabIndex = 0;
            // 
            // Max
            // 
            this.Max.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Max.Location = new System.Drawing.Point(261, 80);
            this.Max.Margin = new System.Windows.Forms.Padding(2);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(172, 29);
            this.Max.TabIndex = 1;
            // 
            // Min
            // 
            this.Min.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Min.Location = new System.Drawing.Point(261, 47);
            this.Min.Margin = new System.Windows.Forms.Padding(2);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(172, 29);
            this.Min.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Размер квадратной матрицы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Максимальный элемент матрицы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Минимальный элемент матрицы";
            // 
            // bCalculate
            // 
            this.bCalculate.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.bCalculate.Location = new System.Drawing.Point(447, 15);
            this.bCalculate.Margin = new System.Windows.Forms.Padding(2);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(220, 94);
            this.bCalculate.TabIndex = 10;
            this.bCalculate.Text = "Создать матрицы";
            this.bCalculate.UseVisualStyleBackColor = true;
            this.bCalculate.Click += new System.EventHandler(this.bCalculate_Click);
            // 
            // A
            // 
            this.A.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.A.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.A.Location = new System.Drawing.Point(13, 125);
            this.A.Margin = new System.Windows.Forms.Padding(2);
            this.A.Multiline = true;
            this.A.Name = "A";
            this.A.ReadOnly = true;
            this.A.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.A.Size = new System.Drawing.Size(320, 204);
            this.A.TabIndex = 11;
            // 
            // B
            // 
            this.B.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.B.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.B.Location = new System.Drawing.Point(347, 125);
            this.B.Margin = new System.Windows.Forms.Padding(2);
            this.B.Multiline = true;
            this.B.Name = "B";
            this.B.ReadOnly = true;
            this.B.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.B.Size = new System.Drawing.Size(320, 204);
            this.B.TabIndex = 12;
            // 
            // combo
            // 
            this.combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.combo.FormattingEnabled = true;
            this.combo.Items.AddRange(new object[] {
            "Сумма матриц",
            "Разность матриц",
            "Умножение матрицы на число i",
            "Произведение матриц",
            "Возведение в степень i матрицы X",
            "Определитель матрицы X",
            "Транспонирование матрицы X"});
            this.combo.Location = new System.Drawing.Point(13, 354);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(420, 33);
            this.combo.TabIndex = 13;
            this.combo.SelectedIndexChanged += new System.EventHandler(this.combo_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.button1.Location = new System.Drawing.Point(447, 333);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 94);
            this.button1.TabIndex = 14;
            this.button1.Text = "Выполнить действие";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // C
            // 
            this.C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.C.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.C.Location = new System.Drawing.Point(11, 437);
            this.C.Margin = new System.Windows.Forms.Padding(2);
            this.C.Multiline = true;
            this.C.Name = "C";
            this.C.ReadOnly = true;
            this.C.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.C.Size = new System.Drawing.Size(656, 204);
            this.C.TabIndex = 15;
            // 
            // Inter
            // 
            this.Inter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Inter.Enabled = false;
            this.Inter.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Inter.Location = new System.Drawing.Point(397, 397);
            this.Inter.Margin = new System.Windows.Forms.Padding(2);
            this.Inter.Name = "Inter";
            this.Inter.Size = new System.Drawing.Size(45, 34);
            this.Inter.TabIndex = 17;
            // 
            // Matx
            // 
            this.Matx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Matx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Matx.Enabled = false;
            this.Matx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Matx.FormattingEnabled = true;
            this.Matx.Items.AddRange(new object[] {
            "A",
            "B"});
            this.Matx.Location = new System.Drawing.Point(318, 397);
            this.Matx.Name = "Matx";
            this.Matx.Size = new System.Drawing.Size(45, 33);
            this.Matx.TabIndex = 18;
            this.Matx.SelectedIndexChanged += new System.EventHandler(this.Matx_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(279, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 26);
            this.label4.TabIndex = 19;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(369, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "i:";
            // 
            // MatrixWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 641);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Matx);
            this.Controls.Add(this.Inter);
            this.Controls.Add(this.C);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.B);
            this.Controls.Add(this.A);
            this.Controls.Add(this.bCalculate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.Size);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MatrixWF";
            this.Text = "Операции с квадратными матрицами";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Size;
        private System.Windows.Forms.TextBox Max;
        private System.Windows.Forms.TextBox Min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bCalculate;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox C;
        private System.Windows.Forms.TextBox Inter;
        private System.Windows.Forms.ComboBox Matx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}