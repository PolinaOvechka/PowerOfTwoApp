namespace PowerOfTwoApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            labelInput = new Label();
            textNumber = new TextBox();
            buttonCheck = new Button();
            buttonExp = new Button();
            labelResult = new Label();
            dataGridViewResults = new DataGridView();
            colAlgo = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            colOps = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            chartComparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartComparison).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(20, 25);
            label1.Name = "label1";
            label1.Size = new Size(431, 32);
            label1.TabIndex = 0;
            label1.Text = "Является ли число степенью двойки?";
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelInput.Location = new Point(20, 81);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(207, 21);
            labelInput.TabIndex = 1;
            labelInput.Text = "Введите число (от 1 до 2³⁰):";
            // 
            // textNumber
            // 
            textNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textNumber.Location = new Point(243, 77);
            textNumber.Name = "textNumber";
            textNumber.Size = new Size(397, 29);
            textNumber.TabIndex = 2;
            // 
            // buttonCheck
            // 
            buttonCheck.BackColor = Color.LightGreen;
            buttonCheck.FlatAppearance.BorderSize = 0;
            buttonCheck.FlatStyle = FlatStyle.Flat;
            buttonCheck.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonCheck.ForeColor = Color.DarkGreen;
            buttonCheck.Location = new Point(672, 74);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(200, 35);
            buttonCheck.TabIndex = 3;
            buttonCheck.Text = "Проверить число";
            buttonCheck.UseVisualStyleBackColor = false;
            buttonCheck.Click += buttonCheck_Click;
            // 
            // buttonExp
            // 
            buttonExp.BackColor = Color.DarkGreen;
            buttonExp.FlatAppearance.BorderSize = 0;
            buttonExp.FlatStyle = FlatStyle.Flat;
            buttonExp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonExp.ForeColor = Color.LightGreen;
            buttonExp.Location = new Point(672, 299);
            buttonExp.Name = "buttonExp";
            buttonExp.Size = new Size(198, 35);
            buttonExp.TabIndex = 4;
            buttonExp.Text = "Построить график";
            buttonExp.UseVisualStyleBackColor = false;
            buttonExp.Click += buttonExp_Click;
            // 
            // labelResult
            // 
            labelResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelResult.Location = new Point(20, 132);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(850, 21);
            labelResult.TabIndex = 5;
            labelResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { colAlgo, colResult, colOps, colTime });
            dataGridViewResults.Location = new Point(20, 178);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.RowHeadersVisible = false;
            dataGridViewResults.Size = new Size(850, 76);
            dataGridViewResults.TabIndex = 6;
            // 
            // colAlgo
            // 
            colAlgo.HeaderText = "Алгоритм";
            colAlgo.Name = "colAlgo";
            // 
            // colResult
            // 
            colResult.HeaderText = "Результат";
            colResult.Name = "colResult";
            // 
            // colOps
            // 
            colOps.HeaderText = "Кол-во операций";
            colOps.Name = "colOps";
            // 
            // colTime
            // 
            colTime.HeaderText = "Время (мс)";
            colTime.Name = "colTime";
            // 
            // chartComparison
            // 
            chartArea1.AxisX.Title = "Степень (2^n)";
            chartArea1.AxisY.Title = "Время (мс)";
            chartArea1.Name = "MainArea";
            chartComparison.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartComparison.Legends.Add(legend1);
            chartComparison.Location = new Point(22, 395);
            chartComparison.Name = "chartComparison";
            series1.BorderWidth = 2;
            series1.ChartArea = "MainArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = Color.Red;
            series1.Legend = "Legend1";
            series1.LegendText = "Метод деления";
            series1.MarkerSize = 6;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "divisionSeries";
            series2.BorderWidth = 2;
            series2.ChartArea = "MainArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.Blue;
            series2.Legend = "Legend1";
            series2.LegendText = "Битовые операции";
            series2.MarkerSize = 6;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "bitSeries";
            chartComparison.Series.Add(series1);
            chartComparison.Series.Add(series2);
            chartComparison.Size = new Size(850, 224);
            chartComparison.TabIndex = 7;
            chartComparison.Text = "Сравнение алгоритмов";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(20, 299);
            label2.Name = "label2";
            label2.Size = new Size(332, 32);
            label2.TabIndex = 8;
            label2.Text = "Экспериментальные данные";
            // 
            // label3
            // 
            label3.Location = new Point(20, 346);
            label3.Name = "label3";
            label3.Size = new Size(848, 33);
            label3.TabIndex = 9;
            label3.Text = "Эксперимент проводится на 10 различных степенях двойки. Каждый алгоритм запускается 100 раз для каждого числа, вычисляется среднее время выполнения для каждого метода.";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 631);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(chartComparison);
            Controls.Add(dataGridViewResults);
            Controls.Add(labelResult);
            Controls.Add(buttonExp);
            Controls.Add(buttonCheck);
            Controls.Add(textNumber);
            Controls.Add(labelInput);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Проверка степени двойки";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartComparison).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelInput;
        private TextBox textNumber;
        private Button buttonCheck;
        private Button buttonExp;
        private Label labelResult;
        private DataGridView dataGridViewResults;
        private DataGridViewTextBoxColumn colAlgo;
        private DataGridViewTextBoxColumn colResult;
        private DataGridViewTextBoxColumn colOps;
        private DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartComparison;
        private Label label2;
        private Label label3;
    }
}
