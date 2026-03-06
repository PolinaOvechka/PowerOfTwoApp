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
        private AlgorithmService _algorithmService;

        public MainForm()
        {
            InitializeComponent();

            _divisionAlgo = new DivisionAlgorithm();
            _bitAlgo = new BitAlgorithm();
            _experimentRunner = new ExperimentRunner(_divisionAlgo, _bitAlgo);
            _algorithmService = new AlgorithmService(_divisionAlgo, _bitAlgo);
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

            var results = _algorithmService.CheckNumber(number);

            dataGridViewResults.Rows.Clear();
            foreach (var result in results)
            {
                dataGridViewResults.Rows.Add(
                    result.AlgorithmName,
                    result.IsPowerOfTwo,
                    result.OperationCount,
                    result.TimeMs
                );
            }

            bool isPower = results[0].IsPowerOfTwo == "Да";
            labelResult.Text = AlgorithmService.FormatPowerInfo(number, isPower);

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

            MessageBox.Show($"Эксперимент завершён! Проведено {powers.Length} замеров.", "Готово");


        }
    }
}
