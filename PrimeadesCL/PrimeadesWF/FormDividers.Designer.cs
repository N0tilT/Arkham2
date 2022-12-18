
namespace PrimeadesWF
{
    partial class FormDividers
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
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.textBoxDividers = new System.Windows.Forms.TextBox();
            this.labelAnswers = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelNumberInput = new System.Windows.Forms.Label();
            this.panelMainContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.BackColor = System.Drawing.Color.Lavender;
            this.panelMainContainer.Controls.Add(this.textBoxDividers);
            this.panelMainContainer.Controls.Add(this.labelAnswers);
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(0, 210);
            this.panelMainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelMainContainer.Size = new System.Drawing.Size(465, 480);
            this.panelMainContainer.TabIndex = 0;
            // 
            // textBoxDividers
            // 
            this.textBoxDividers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDividers.Font = new System.Drawing.Font("Franklin Gothic Medium", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDividers.Location = new System.Drawing.Point(13, 49);
            this.textBoxDividers.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDividers.Multiline = true;
            this.textBoxDividers.Name = "textBoxDividers";
            this.textBoxDividers.ReadOnly = true;
            this.textBoxDividers.Size = new System.Drawing.Size(439, 419);
            this.textBoxDividers.TabIndex = 2;
            // 
            // labelAnswers
            // 
            this.labelAnswers.AutoSize = true;
            this.labelAnswers.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAnswers.Font = new System.Drawing.Font("Franklin Gothic Medium", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAnswers.Location = new System.Drawing.Point(13, 12);
            this.labelAnswers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAnswers.Name = "labelAnswers";
            this.labelAnswers.Size = new System.Drawing.Size(140, 37);
            this.labelAnswers.TabIndex = 2;
            this.labelAnswers.Text = "Делители:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.panelButtons);
            this.panel2.Controls.Add(this.panelInput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 210);
            this.panel2.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Plum;
            this.panelButtons.Controls.Add(this.buttonCalculate);
            this.panelButtons.Controls.Add(this.buttonHelp);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 113);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelButtons.Size = new System.Drawing.Size(465, 97);
            this.panelButtons.TabIndex = 0;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCalculate.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalculate.Location = new System.Drawing.Point(13, 12);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(286, 73);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Узнать делители";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonHelp.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHelp.Location = new System.Drawing.Point(299, 12);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(153, 73);
            this.buttonHelp.TabIndex = 2;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelInput.Controls.Add(this.textBoxInput);
            this.panelInput.Controls.Add(this.labelNumberInput);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Margin = new System.Windows.Forms.Padding(4);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelInput.Size = new System.Drawing.Size(465, 210);
            this.panelInput.TabIndex = 1;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxInput.Font = new System.Drawing.Font("Franklin Gothic Medium", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInput.Location = new System.Drawing.Point(13, 49);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(439, 40);
            this.textBoxInput.TabIndex = 0;
            // 
            // labelNumberInput
            // 
            this.labelNumberInput.AutoSize = true;
            this.labelNumberInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNumberInput.Font = new System.Drawing.Font("Franklin Gothic Medium", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumberInput.Location = new System.Drawing.Point(13, 12);
            this.labelNumberInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumberInput.Name = "labelNumberInput";
            this.labelNumberInput.Size = new System.Drawing.Size(201, 37);
            this.labelNumberInput.TabIndex = 1;
            this.labelNumberInput.Text = "Введите число";
            // 
            // FormDividers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 690);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(421, 728);
            this.Name = "FormDividers";
            this.Text = "Узнать делители числа";
            this.panelMainContainer.ResumeLayout(false);
            this.panelMainContainer.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelNumberInput;
        private System.Windows.Forms.Label labelAnswers;
        private System.Windows.Forms.TextBox textBoxDividers;
    }
}