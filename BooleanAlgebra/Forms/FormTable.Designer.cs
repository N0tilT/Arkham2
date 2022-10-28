
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
            this.Rezult.Size = new System.Drawing.Size(923, 429);
            this.Rezult.TabIndex = 0;
            // 
            // BoolN
            // 
            this.BoolN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoolN.Location = new System.Drawing.Point(15, 54);
            this.BoolN.Name = "BoolN";
            this.BoolN.Size = new System.Drawing.Size(428, 38);
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
            this.buttonTable.Location = new System.Drawing.Point(480, 12);
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
            this.buttonHelp.Location = new System.Drawing.Point(722, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(216, 80);
            this.buttonHelp.TabIndex = 4;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 552);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoolN);
            this.Controls.Add(this.Rezult);
            this.Name = "Form1";
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
    }
}

