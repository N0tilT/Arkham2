
namespace PrimeadesWF
{
    partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.textBoxMaxSegment = new System.Windows.Forms.TextBox();
            this.labelMaxSegment = new System.Windows.Forms.Label();
            this.textBoxMinSeg = new System.Windows.Forms.TextBox();
            this.labelMinPrimes = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panelN = new System.Windows.Forms.Panel();
            this.textBoxInputN = new System.Windows.Forms.TextBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.panelSegment = new System.Windows.Forms.Panel();
            this.textBoxSegmentInput = new System.Windows.Forms.TextBox();
            this.labelSegment = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonDividers = new System.Windows.Forms.Button();
            this.textBoxMaxSeg = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelMaxPrimes = new System.Windows.Forms.Label();
            this.chartPrimes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInput.SuspendLayout();
            this.panelN.SuspendLayout();
            this.panelSegment.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrimes)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonCalculate.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCalculate.Font = new System.Drawing.Font("Franklin Gothic Medium", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalculate.Location = new System.Drawing.Point(16, 40);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCalculate.Size = new System.Drawing.Size(161, 69);
            this.buttonCalculate.TabIndex = 11;
            this.buttonCalculate.Text = "Вычислить";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonHelp.Font = new System.Drawing.Font("Franklin Gothic Medium", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHelp.Location = new System.Drawing.Point(319, 40);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(119, 69);
            this.buttonHelp.TabIndex = 12;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // textBoxMaxSegment
            // 
            this.textBoxMaxSegment.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxMaxSegment.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMaxSegment.Location = new System.Drawing.Point(5, 480);
            this.textBoxMaxSegment.Multiline = true;
            this.textBoxMaxSegment.Name = "textBoxMaxSegment";
            this.textBoxMaxSegment.ReadOnly = true;
            this.textBoxMaxSegment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMaxSegment.Size = new System.Drawing.Size(214, 149);
            this.textBoxMaxSegment.TabIndex = 10;
            // 
            // labelMaxSegment
            // 
            this.labelMaxSegment.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMaxSegment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxSegment.Location = new System.Drawing.Point(5, 421);
            this.labelMaxSegment.Name = "labelMaxSegment";
            this.labelMaxSegment.Size = new System.Drawing.Size(214, 59);
            this.labelMaxSegment.TabIndex = 14;
            this.labelMaxSegment.Text = "Максимальный отрезок без простых чисел";
            this.labelMaxSegment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMinSeg
            // 
            this.textBoxMinSeg.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxMinSeg.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMinSeg.Location = new System.Drawing.Point(5, 272);
            this.textBoxMinSeg.Multiline = true;
            this.textBoxMinSeg.Name = "textBoxMinSeg";
            this.textBoxMinSeg.ReadOnly = true;
            this.textBoxMinSeg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMinSeg.Size = new System.Drawing.Size(214, 149);
            this.textBoxMinSeg.TabIndex = 9;
            // 
            // labelMinPrimes
            // 
            this.labelMinPrimes.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMinPrimes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinPrimes.Location = new System.Drawing.Point(5, 213);
            this.labelMinPrimes.Name = "labelMinPrimes";
            this.labelMinPrimes.Size = new System.Drawing.Size(214, 59);
            this.labelMinPrimes.TabIndex = 13;
            this.labelMinPrimes.Text = "Отрезок с минимальным количеством простых чисел";
            this.labelMinPrimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelInput.Controls.Add(this.panelN);
            this.panelInput.Controls.Add(this.panelSegment);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(0, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelInput.Size = new System.Drawing.Size(796, 149);
            this.panelInput.TabIndex = 12;
            // 
            // panelN
            // 
            this.panelN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.panelN.Controls.Add(this.textBoxInputN);
            this.panelN.Controls.Add(this.labelInput);
            this.panelN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelN.Location = new System.Drawing.Point(10, 0);
            this.panelN.Name = "panelN";
            this.panelN.Padding = new System.Windows.Forms.Padding(20);
            this.panelN.Size = new System.Drawing.Size(319, 149);
            this.panelN.TabIndex = 9;
            // 
            // textBoxInputN
            // 
            this.textBoxInputN.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxInputN.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInputN.Location = new System.Drawing.Point(20, 111);
            this.textBoxInputN.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxInputN.Name = "textBoxInputN";
            this.textBoxInputN.Size = new System.Drawing.Size(279, 29);
            this.textBoxInputN.TabIndex = 6;
            // 
            // labelInput
            // 
            this.labelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelInput.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInput.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelInput.Location = new System.Drawing.Point(20, 20);
            this.labelInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInput.Name = "labelInput";
            this.labelInput.Padding = new System.Windows.Forms.Padding(0, 10, 0, 15);
            this.labelInput.Size = new System.Drawing.Size(279, 91);
            this.labelInput.TabIndex = 7;
            this.labelInput.Text = "Введите количество чисел";
            this.labelInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSegment
            // 
            this.panelSegment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.panelSegment.Controls.Add(this.textBoxSegmentInput);
            this.panelSegment.Controls.Add(this.labelSegment);
            this.panelSegment.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSegment.Location = new System.Drawing.Point(329, 0);
            this.panelSegment.Name = "panelSegment";
            this.panelSegment.Padding = new System.Windows.Forms.Padding(20);
            this.panelSegment.Size = new System.Drawing.Size(457, 149);
            this.panelSegment.TabIndex = 8;
            // 
            // textBoxSegmentInput
            // 
            this.textBoxSegmentInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSegmentInput.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSegmentInput.Location = new System.Drawing.Point(20, 111);
            this.textBoxSegmentInput.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSegmentInput.Name = "textBoxSegmentInput";
            this.textBoxSegmentInput.Size = new System.Drawing.Size(417, 29);
            this.textBoxSegmentInput.TabIndex = 8;
            // 
            // labelSegment
            // 
            this.labelSegment.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSegment.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSegment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelSegment.Location = new System.Drawing.Point(20, 20);
            this.labelSegment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSegment.Name = "labelSegment";
            this.labelSegment.Padding = new System.Windows.Forms.Padding(0, 10, 0, 15);
            this.labelSegment.Size = new System.Drawing.Size(417, 91);
            this.labelSegment.TabIndex = 9;
            this.labelSegment.Text = "Введите размер рассматриваемого отрезка чисел";
            this.labelSegment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.Ivory;
            this.panelControls.Controls.Add(this.panelInput);
            this.panelControls.Controls.Add(this.panelButtons);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1274, 149);
            this.panelControls.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Plum;
            this.panelButtons.Controls.Add(this.buttonCalculate);
            this.panelButtons.Controls.Add(this.buttonDividers);
            this.panelButtons.Controls.Add(this.buttonHelp);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(796, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(40);
            this.panelButtons.Size = new System.Drawing.Size(478, 149);
            this.panelButtons.TabIndex = 2;
            // 
            // buttonDividers
            // 
            this.buttonDividers.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonDividers.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDividers.Font = new System.Drawing.Font("Franklin Gothic Medium", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDividers.Location = new System.Drawing.Point(177, 40);
            this.buttonDividers.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDividers.Name = "buttonDividers";
            this.buttonDividers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonDividers.Size = new System.Drawing.Size(142, 69);
            this.buttonDividers.TabIndex = 13;
            this.buttonDividers.Text = "Узнать делители";
            this.buttonDividers.UseVisualStyleBackColor = false;
            this.buttonDividers.Click += new System.EventHandler(this.buttonDividers_Click);
            // 
            // textBoxMaxSeg
            // 
            this.textBoxMaxSeg.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxMaxSeg.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMaxSeg.Location = new System.Drawing.Point(5, 64);
            this.textBoxMaxSeg.Multiline = true;
            this.textBoxMaxSeg.Name = "textBoxMaxSeg";
            this.textBoxMaxSeg.ReadOnly = true;
            this.textBoxMaxSeg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMaxSeg.Size = new System.Drawing.Size(214, 149);
            this.textBoxMaxSeg.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.textBoxMaxSegment);
            this.panel4.Controls.Add(this.labelMaxSegment);
            this.panel4.Controls.Add(this.textBoxMinSeg);
            this.panel4.Controls.Add(this.labelMinPrimes);
            this.panel4.Controls.Add(this.textBoxMaxSeg);
            this.panel4.Controls.Add(this.labelMaxPrimes);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(224, 637);
            this.panel4.TabIndex = 9;
            // 
            // labelMaxPrimes
            // 
            this.labelMaxPrimes.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMaxPrimes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxPrimes.Location = new System.Drawing.Point(5, 5);
            this.labelMaxPrimes.Name = "labelMaxPrimes";
            this.labelMaxPrimes.Size = new System.Drawing.Size(214, 59);
            this.labelMaxPrimes.TabIndex = 12;
            this.labelMaxPrimes.Text = "Отрезок с максимальным количеством простых чисел";
            this.labelMaxPrimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartPrimes
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPrimes.ChartAreas.Add(chartArea4);
            this.chartPrimes.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartPrimes.Legends.Add(legend4);
            this.chartPrimes.Location = new System.Drawing.Point(20, 20);
            this.chartPrimes.Name = "chartPrimes";
            series4.ChartArea = "ChartArea1";
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series4.YValuesPerPoint = 2;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartPrimes.Series.Add(series4);
            this.chartPrimes.Size = new System.Drawing.Size(1010, 637);
            this.chartPrimes.TabIndex = 0;
            this.chartPrimes.Text = "chart1";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.SkyBlue;
            this.panelInfo.Controls.Add(this.panel4);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInfo.Location = new System.Drawing.Point(1030, 20);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(224, 637);
            this.panelInfo.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Lavender;
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.textBoxT);
            this.panelContent.Controls.Add(this.chartPrimes);
            this.panelContent.Controls.Add(this.panelInfo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 149);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.panelContent.Size = new System.Drawing.Size(1274, 662);
            this.panelContent.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.YellowGreen;
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelControls);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1274, 811);
            this.panelMain.TabIndex = 1;
            // 
            // textBoxT
            // 
            this.textBoxT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxT.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBoxT.Location = new System.Drawing.Point(936, 632);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.ReadOnly = true;
            this.textBoxT.Size = new System.Drawing.Size(88, 25);
            this.textBoxT.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(647, 636);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Время выполнения программы в секундах:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 811);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1290, 850);
            this.Name = "FormMain";
            this.Text = "Простые числа";
            this.panelInput.ResumeLayout(false);
            this.panelN.ResumeLayout(false);
            this.panelN.PerformLayout();
            this.panelSegment.ResumeLayout(false);
            this.panelSegment.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrimes)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.TextBox textBoxMaxSegment;
        private System.Windows.Forms.Label labelMaxSegment;
        private System.Windows.Forms.TextBox textBoxMinSeg;
        private System.Windows.Forms.Label labelMinPrimes;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonDividers;
        private System.Windows.Forms.TextBox textBoxMaxSeg;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelMaxPrimes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrimes;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelN;
        private System.Windows.Forms.TextBox textBoxInputN;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Panel panelSegment;
        private System.Windows.Forms.TextBox textBoxSegmentInput;
        private System.Windows.Forms.Label labelSegment;
        private System.Windows.Forms.TextBox textBoxT;
        private System.Windows.Forms.Label label1;
    }
}

