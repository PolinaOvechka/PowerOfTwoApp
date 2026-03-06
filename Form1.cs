using PowerOfTwoApp.Models;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace PowerOfTwoApp
 
{
    public partial class MainForm : Form
    {
        private DivisionAlgorithm _divisionAlgo;
        private BitAlgorithm _bitAlgo;
        private ExperimentRunner _experimentRunner;

        public MainForm()
        {
            InitializeComponent();

            _divisionAlgo = new DivisionAlgorithm();
            _bitAlgo = new BitAlgorithm();
            _experimentRunner = new ExperimentRunner(_divisionAlgo, _bitAlgo);
        }

        /// <summary>
        /// Запускает алгоритм и замеряет время
        /// </summary>
        private (bool result, double timeMs) RunAlgorithm(dynamic algo, long number)
        {
            var stopwatch = Stopwatch.StartNew();
            bool result = algo.Check(number);
            stopwatch.Stop();

            double timeMs = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
            return (result, timeMs);
        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            dataGridViewResults.Rows.Clear();

            // Проверяем ввод
            if (!long.TryParse(textNumber.Text, out long number))
            {
                MessageBox.Show("Введите корректное число!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем диапазон
            if (number < 1 || number > 1073741824)
            {
                MessageBox.Show("Число должно быть от 1 до 2^30!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Первый алгоритм
            var (result1, time1) = RunAlgorithm(_divisionAlgo, number);
            dataGridViewResults.Rows.Add(
                _divisionAlgo.GetName(),
                result1 ? "Да" : "Нет",
                _divisionAlgo.OperationCount,
                time1.ToString("F4")
            );

            // Второй алгоритм
            var (result2, time2) = RunAlgorithm(_bitAlgo, number);
            dataGridViewResults.Rows.Add(
                _bitAlgo.GetName(),
                result2 ? "Да" : "Нет",
                _bitAlgo.OperationCount,
                time2.ToString("F4")
            );

            labelResult.Text = $"Число {number} {(result1 ? "является" : "НЕ является")} степенью двойки";
        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            // Очищаем график перед экспериментом
            chartComparison.Series[0].Points.Clear();
            chartComparison.Series[1].Points.Clear();


            int[] powers = { 1, 5, 10, 15, 20, 25, 27, 28, 29, 30 };
            var results = _experimentRunner.RunExperiment(powers, 100);

            // Заполняем график результатами
            foreach (var result in results)
            {
                chartComparison.Series[0].Points.AddXY(result.Power, result.DivisionTime);
                chartComparison.Series[1].Points.AddXY(result.Power, result.BitTime);
            }

            await Task.Delay(100);  // Небольшая задержка
            chartComparison.Update();
            chartComparison.Refresh();

            MessageBox.Show($"Эксперимент завершён! Проведено {powers.Length} замеров.", "Готово");


        }
    }
}
