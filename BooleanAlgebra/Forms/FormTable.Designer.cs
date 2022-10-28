
namespace Forms
{
    partial class FormTable
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
            this.Rezult = new System.Windows.Forms.TextBox();
            this.BoolN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.Rezult2 = new System.Windows.Forms.TextBox();
            this.BoolN2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Rezult
            // 
            this.Rezult.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rezult.Location = new System.Drawing.Point(15, 107);
            this.Rezult.Multiline = true;
            this.Rezult.Name = "Rezult";
            this.Rezult.ReadOnly = true;
            this.Rezult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Rezult.Size = new System.Drawing.Size(613, 429);
            this.Rezult.TabIndex = 0;
            // 
            // BoolN
            // 
            this.BoolN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoolN.Location = new System.Drawing.Point(104, 54);
            this.BoolN.Name = "BoolN";
            this.BoolN.Size = new System.Drawing.Size(256, 38);
            this.BoolN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество логических переменных";
            // 
            // buttonTable
            // 
            this.buttonTable.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.buttonTable.Location = new System.Drawing.Point(763, 9);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(236, 80);
            this.buttonTable.TabIndex = 3;
            this.buttonTable.Text = "Построить таблицу истинности";
            this.buttonTable.UseVisualStyleBackColor = true;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHelp.Location = new System.Drawing.Point(1005, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(216, 80);
            this.buttonHelp.TabIndex = 4;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // Rezult2
            // 
            this.Rezult2.Location = new System.Drawing.Point(634, 108);
            this.Rezult2.Multiline = true;
            this.Rezult2.Name = "Rezult2";
            this.Rezult2.ReadOnly = true;
            this.Rezult2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Rezult2.Size = new System.Drawing.Size(592, 428);
            this.Rezult2.TabIndex = 5;
            // 
            // BoolN2
            // 
            this.BoolN2.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.BoolN2.Location = new System.Drawing.Point(480, 54);
            this.BoolN2.Name = "BoolN2";
            this.BoolN2.Size = new System.Drawing.Size(263, 38);
            this.BoolN2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "1 функция";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(383, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "2 функция";
            // 
            // FormTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 552);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoolN2);
            this.Controls.Add(this.Rezult2);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoolN);
            this.Controls.Add(this.Rezult);
            this.Name = "FormTable";
            this.Text = "Таблица истинности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Rezult;
        private System.Windows.Forms.TextBox BoolN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTable;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.TextBox Rezult2;
        private System.Windows.Forms.TextBox BoolN2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

