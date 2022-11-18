
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.N = new System.Windows.Forms.TextBox();
            this.Function = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonNF = new System.Windows.Forms.Button();
            this.RezultNF = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Rezult
            // 
            this.Rezult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Rezult.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rezult.Location = new System.Drawing.Point(11, 110);
            this.Rezult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Rezult.Multiline = true;
            this.Rezult.Name = "Rezult";
            this.Rezult.ReadOnly = true;
            this.Rezult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Rezult.Size = new System.Drawing.Size(367, 317);
            this.Rezult.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество логических переменных";
            // 
            // buttonTable
            // 
            this.buttonTable.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.buttonTable.Location = new System.Drawing.Point(389, 28);
            this.buttonTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(176, 65);
            this.buttonTable.TabIndex = 3;
            this.buttonTable.Text = "Построить таблицу истинности";
            this.buttonTable.UseVisualStyleBackColor = true;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHelp.Location = new System.Drawing.Point(751, 28);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(176, 65);
            this.buttonHelp.TabIndex = 4;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // N
            // 
            this.N.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.N.Location = new System.Drawing.Point(180, 37);
            this.N.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.N.Name = "N";
            this.N.Size = new System.Drawing.Size(198, 26);
            this.N.TabIndex = 8;
            // 
            // Function
            // 
            this.Function.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Function.Location = new System.Drawing.Point(180, 67);
            this.Function.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Function.Name = "Function";
            this.Function.Size = new System.Drawing.Size(198, 26);
            this.Function.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Количество переменных";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(8, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Функция";
            // 
            // buttonNF
            // 
            this.buttonNF.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.buttonNF.Location = new System.Drawing.Point(570, 28);
            this.buttonNF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNF.Name = "buttonNF";
            this.buttonNF.Size = new System.Drawing.Size(176, 65);
            this.buttonNF.TabIndex = 12;
            this.buttonNF.Text = "СДНФ и СКНФ";
            this.buttonNF.UseVisualStyleBackColor = true;
            this.buttonNF.Click += new System.EventHandler(this.buttonNF_Click);
            // 
            // RezultNF
            // 
            this.RezultNF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RezultNF.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.RezultNF.Location = new System.Drawing.Point(389, 111);
            this.RezultNF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RezultNF.Multiline = true;
            this.RezultNF.Name = "RezultNF";
            this.RezultNF.ReadOnly = true;
            this.RezultNF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RezultNF.Size = new System.Drawing.Size(523, 316);
            this.RezultNF.TabIndex = 13;
            // 
            // FormTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(933, 475);
            this.Controls.Add(this.RezultNF);
            this.Controls.Add(this.buttonNF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Function);
            this.Controls.Add(this.N);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rezult);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(949, 514);
            this.Name = "FormTable";
            this.Text = "Таблица истинности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Rezult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTable;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.TextBox N;
        private System.Windows.Forms.TextBox Function;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonNF;
        private System.Windows.Forms.TextBox RezultNF;
    }
}

