namespace PerfomanceTestingToolsWF
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbClearCache = new System.Windows.Forms.CheckBox();
            this.nudThread = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nudGraphWidth = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThread)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudGraphWidth);
            this.panel1.Controls.Add(this.cbClearCache);
            this.panel1.Controls.Add(this.nudThread);
            this.panel1.Controls.Add(this.lblMax);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(563, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 396);
            this.panel1.TabIndex = 0;
            // 
            // cbClearCache
            // 
            this.cbClearCache.AutoSize = true;
            this.cbClearCache.Location = new System.Drawing.Point(9, 211);
            this.cbClearCache.Name = "cbClearCache";
            this.cbClearCache.Size = new System.Drawing.Size(73, 17);
            this.cbClearCache.TabIndex = 5;
            this.cbClearCache.Text = "No cache";
            this.cbClearCache.UseVisualStyleBackColor = true;
            // 
            // nudThread
            // 
            this.nudThread.Location = new System.Drawing.Point(12, 185);
            this.nudThread.Name = "nudThread";
            this.nudThread.Size = new System.Drawing.Size(120, 20);
            this.nudThread.TabIndex = 4;
            this.nudThread.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(9, 27);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(13, 13);
            this.lblMax.TabIndex = 3;
            this.lblMax.Text = "0";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(9, 71);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 396);
            this.panel2.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ca";
            chartArea2.Name = "cb";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(563, 396);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // nudGraphWidth
            // 
            this.nudGraphWidth.Location = new System.Drawing.Point(12, 45);
            this.nudGraphWidth.Name = "nudGraphWidth";
            this.nudGraphWidth.Size = new System.Drawing.Size(120, 20);
            this.nudGraphWidth.TabIndex = 6;
            this.nudGraphWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 396);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThread)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.NumericUpDown nudThread;
        private System.Windows.Forms.CheckBox cbClearCache;
        private System.Windows.Forms.NumericUpDown nudGraphWidth;
    }
}

