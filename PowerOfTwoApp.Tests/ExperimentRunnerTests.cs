using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerOfTwoApp.Models;
using System.Linq;

namespace PowerOfTwoApp.Tests
{
    [TestClass]
    public class ExperimentRunnerTests
    {
        private ExperimentRunner _runner = null!;
        private DivisionAlgorithm _divisionAlgo = null!;
        private BitAlgorithm _bitAlgo = null!;

        [TestInitialize]
        public void SetUp()
        {
            _divisionAlgo = new DivisionAlgorithm();
            _bitAlgo = new BitAlgorithm();
            _runner = new ExperimentRunner(_divisionAlgo, _bitAlgo);
        }

        // ТЕСТ 1: Типичные данные — возвращает правильное количество результатов
        [TestMethod]
        public void RunExperiment_TypicalData_ReturnsCorrectNumberOfResults()
        {
            int[] powers = { 5, 10, 15 };
            var results = _runner.RunExperiment(powers, 10);

            Assert.AreEqual(3, results.Count);
        }

        // ТЕСТ 2: Граничные случаи — минимальная и максимальная степени
        [TestMethod]
        public void RunExperiment_BoundaryCases_MinAndMaxPowers_ReturnsValidResults()
        {
            int[] powers = { 0, 30 }; // 2^0 = 1, 2^30 = 1073741824
            var results = _runner.RunExperiment(powers, 10);

            Assert.AreEqual(2, results.Count);

            // Проверяем минимальную степень
            Assert.AreEqual(0, results[0].Power);
            Assert.AreEqual(1, results[0].Number);
            Assert.IsTrue(results[0].DivisionTime >= 0);
            Assert.IsTrue(results[0].BitTime >= 0);

            // Проверяем максимальную степень
            Assert.AreEqual(30, results[1].Power);
            Assert.AreEqual(1073741824, results[1].Number);
            Assert.IsTrue(results[1].DivisionTime >= 0);
            Assert.IsTrue(results[1].BitTime >= 0);
        }

        // ТЕСТ 3: Некорректные входные данные — отрицательные степени
        [TestMethod]
        public void RunExperiment_InvalidInput_NegativePowers_ReturnsResultsWithZero()
        {
            int[] powers = { -5, -10 };
            var results = _runner.RunExperiment(powers, 10);

            Assert.AreEqual(2, results.Count);

            // Для отрицательных степеней Math.Pow вернёт дробное число < 1,
            // которое при приведении к long станет 0
            Assert.AreEqual(0, results[0].Number);
            Assert.AreEqual(0, results[1].Number);
        }

        // ТЕСТ 4: Пустые данные — пустой массив степеней
        [TestMethod]
        public void RunExperiment_EmptyData_EmptyArray_ReturnsEmptyList()
        {
            int[] powers = { };
            var results = _runner.RunExperiment(powers, 10);

            Assert.AreEqual(0, results.Count);
        }

        // ТЕСТ 5: Большие объёмы данных — 10 степеней с большим количеством итераций
        [TestMethod]
        public void RunExperiment_LargeData_TenPowersWithManyIterations_ReturnsValidResults()
        {
            int[] powers = { 1, 5, 10, 15, 20, 25, 27, 28, 29, 30 };
            var results = _runner.RunExperiment(powers, 1000);

            Assert.AreEqual(10, results.Count);

            // Проверяем, что все времена неотрицательные
            foreach (var result in results)
            {
                Assert.IsTrue(result.DivisionTime >= 0);
                Assert.IsTrue(result.BitTime >= 0);
                Assert.IsTrue(result.DivisionOps >= 0);
                Assert.AreEqual(4, result.BitOps); // Битовый алгоритм всегда 4 операции
            }

            // Проверяем, что время битового метода не превышает время деления более чем в 2 раза
            // (битовый метод должен быть быстрее или примерно равен)
            foreach (var result in results)
            {
                Assert.IsTrue(result.BitTime <= result.DivisionTime * 2 ||
                              result.DivisionTime < 0.001, // Для очень малых времён допускаем погрешность
                              $"Битовый метод должен быть быстрее для 2^{result.Power}");
            }
        }
    }
}