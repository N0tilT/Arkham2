
namespace MainFormOOP
{
    partial class TeacherWF
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
            this.buttonTeacher = new System.Windows.Forms.Button();
            this.TeacherText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonTeacher
            // 
            this.buttonTeacher.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTeacher.Location = new System.Drawing.Point(25, 21);
            this.buttonTeacher.Name = "buttonTeacher";
            this.buttonTeacher.Size = new System.Drawing.Size(223, 71);
            this.buttonTeacher.TabIndex = 0;
            this.buttonTeacher.Text = "Преподаватели";
            this.buttonTeacher.UseVisualStyleBackColor = true;
            this.buttonTeacher.Click += new System.EventHandler(this.buttonTeacher_Click);
            // 
            // TeacherText
            // 
            this.TeacherText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeacherText.Location = new System.Drawing.Point(24, 115);
            this.TeacherText.Multiline = true;
            this.TeacherText.Name = "TeacherText";
            this.TeacherText.ReadOnly = true;
            this.TeacherText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TeacherText.Size = new System.Drawing.Size(746, 516);
            this.TeacherText.TabIndex = 1;
            // 
            // TeacherWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 653);
            this.Controls.Add(this.TeacherText);
            this.Controls.Add(this.buttonTeacher);
            this.Name = "TeacherWF";
            this.Text = "Teacher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTeacher;
        private System.Windows.Forms.TextBox TeacherText;
    }
}