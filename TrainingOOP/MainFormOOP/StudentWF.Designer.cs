
namespace MainFormOOP
{
    partial class StudentWF
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
            this.buttonStudents = new System.Windows.Forms.Button();
            this.StudentInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStudents
            // 
            this.buttonStudents.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStudents.Location = new System.Drawing.Point(12, 23);
            this.buttonStudents.Name = "buttonStudents";
            this.buttonStudents.Size = new System.Drawing.Size(274, 70);
            this.buttonStudents.TabIndex = 0;
            this.buttonStudents.Text = "Список студентов";
            this.buttonStudents.UseVisualStyleBackColor = true;
            this.buttonStudents.Click += new System.EventHandler(this.buttonStudents_Click);
            // 
            // StudentInfo
            // 
            this.StudentInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StudentInfo.Location = new System.Drawing.Point(12, 109);
            this.StudentInfo.Multiline = true;
            this.StudentInfo.Name = "StudentInfo";
            this.StudentInfo.ReadOnly = true;
            this.StudentInfo.Size = new System.Drawing.Size(643, 296);
            this.StudentInfo.TabIndex = 1;
            // 
            // StudentWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 417);
            this.Controls.Add(this.StudentInfo);
            this.Controls.Add(this.buttonStudents);
            this.Name = "StudentWF";
            this.Text = "Студенты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStudents;
        private System.Windows.Forms.TextBox StudentInfo;
    }
}