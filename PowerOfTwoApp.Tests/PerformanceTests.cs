using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerOfTwoApp.Models;
using System.Diagnostics;

namespace PowerOfTwoApp.Tests
{
    /// <summary>
    /// Тесты производительности алгоритмов
    /// </summary>
    [TestClass]
    public class PerformanceTests
    {
        private DivisionAlgorithm _divisionAlgo = null!;
        private BitAlgorithm _bitAlgo = null!;

        [TestInitialize]
        public void SetUp()
        {
            _divisionAlgo = new DivisionAlgorithm();
            _bitAlgo = new BitAlgorithm();
        }

        // ТЕСТ 1: Битовый алгоритм должен быть быстрее метода деления на больших числах
        [TestMethod]
        public void ComparePerformance_LargeNumber_BitAlgorithmIsFaster()
        {
            long testNumber = 1073741824; // 2^30
            int iterations = 10000;

            // Замер времени для алгоритма деления
            var swDivision = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                var algo = new DivisionAlgorithm();
                algo.Check(testNumber);
            }
            swDivision.Stop();

            // Замер времени для битового алгоритма
            var swBit = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                var algo = new BitAlgorithm();
                algo.Check(testNumber);
            }
            swBit.Stop();

            Assert.IsTrue(swBit.ElapsedTicks < swDivision.ElapsedTicks,
                "Битовый алгоритм должен быть быстрее метода деления");
        }

        // ТЕСТ 2: Проверка количества операций для различных степеней двойки
        [TestMethod]
        [DataRow(1, 1)]      // 2^0
        [DataRow(2, 2)]      // 2^1
        [DataRow(4, 3)]      // 2^2
        [DataRow(8, 4)]      // 2^3
        [DataRow(16, 5)]     // 2^4
        [DataRow(1024, 11)]  // 2^10
        public void Check_DivisionAlgorithm_OperationCountMatchesLogarithm(long number, int expectedMaxOps)
        {
            var algo = new DivisionAlgorithm();
            algo.Check(number);

            Assert.IsTrue(algo.OperationCount > 0, "Количество операций должно быть больше 0");
            Assert.IsTrue(algo.OperationCount <= expectedMaxOps,
                $"Количество операций ({algo.OperationCount}) не должно превышать {expectedMaxOps}");
        }

        // ТЕСТ 3: Битовый алгоритм всегда выполняет константное количество операций
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(1024)]
        [DataRow(1073741824)]
        public void Check_BitAlgorithm_ConstantOperationCount(long number)
        {
            var algo = new BitAlgorithm();
            algo.Check(number);

            Assert.AreEqual(4, algo.OperationCount,
                "Битовый алгоритм должен выполнять ровно 4 операции");
        }

        // ТЕСТ 4: Производительность на серии чисел
        [TestMethod]
        public void RunExperiment_MultipleNumbers_CompletesInReasonableTime()
        {
            var runner = new ExperimentRunner(_divisionAlgo, _bitAlgo);
            int[] powers = { 1, 5, 10, 15, 20, 25, 30 };

            var sw = Stopwatch.StartNew();
            var results = runner.RunExperiment(powers, 100);
            sw.Stop();

            Assert.AreEqual(7, results.Count);
            Assert.IsTrue(sw.ElapsedMilliseconds < 5000,
                $"Эксперимент должен завершиться менее чем за 5 секунд (фактически: {sw.ElapsedMilliseconds} мс)");
        }
    }
}
