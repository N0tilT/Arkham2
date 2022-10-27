
namespace MainFormOOP
{
    partial class VehicleWF
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
            this.ShowInfo = new System.Windows.Forms.Button();
            this.VehicleInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ShowInfo
            // 
            this.ShowInfo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowInfo.Location = new System.Drawing.Point(12, 21);
            this.ShowInfo.Name = "ShowInfo";
            this.ShowInfo.Size = new System.Drawing.Size(368, 71);
            this.ShowInfo.TabIndex = 0;
            this.ShowInfo.Text = "Информация об автомобиле";
            this.ShowInfo.UseVisualStyleBackColor = true;
            this.ShowInfo.Click += new System.EventHandler(this.ShowInfo_Click);
            // 
            // VehicleInfo
            // 
            this.VehicleInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VehicleInfo.Location = new System.Drawing.Point(12, 112);
            this.VehicleInfo.Multiline = true;
            this.VehicleInfo.Name = "VehicleInfo";
            this.VehicleInfo.Size = new System.Drawing.Size(742, 467);
            this.VehicleInfo.TabIndex = 1;
            // 
            // VehicleWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 597);
            this.Controls.Add(this.VehicleInfo);
            this.Controls.Add(this.ShowInfo);
            this.Name = "VehicleWF";
            this.Text = "Автомобили";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowInfo;
        private System.Windows.Forms.TextBox VehicleInfo;
    }
}