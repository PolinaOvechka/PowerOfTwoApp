using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerOfTwoApp.Models;
using System.Linq;

namespace PowerOfTwoApp.Tests
{
    [TestClass]
    public class AlgorithmServiceTests
    {
        private AlgorithmService _service = null!;
        private DivisionAlgorithm _divisionAlgo = null!;
        private BitAlgorithm _bitAlgo = null!;

        [TestInitialize]
        public void SetUp()
        {
            _divisionAlgo = new DivisionAlgorithm();
            _bitAlgo = new BitAlgorithm();
            _service = new AlgorithmService(_divisionAlgo, _bitAlgo);
        }

        // ТЕСТ 1: Типичные данные — степень двойки возвращает 2 результата с правильными именами
        [TestMethod]
        public void CheckNumber_ForPowerOfTwo_ReturnsTwoResultsWithCorrectNames()
        {
            var results = _service.CheckNumber(8);

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Метод деления", results[0].AlgorithmName);
            Assert.AreEqual("Битовые операции", results[1].AlgorithmName);
        }

        // ТЕСТ 2: Типичные данные — не степень двойки возвращает "Нет" для обоих алгоритмов
        [TestMethod]
        public void CheckNumber_ForNotPowerOfTwo_ReturnsNoForBothAlgorithms()
        {
            var results = _service.CheckNumber(100);

            Assert.AreEqual("Нет", results[0].IsPowerOfTwo);
            Assert.AreEqual("Нет", results[1].IsPowerOfTwo);
        }

        // ТЕСТ 3: Граничные случаи — минимальное (1) и максимальное (2^30) значения
        [TestMethod]
        [DataRow(1)]
        [DataRow(1073741824)]
        public void CheckNumber_BoundaryCases_MinAndMax_ReturnsYes(long number)
        {
            var results = _service.CheckNumber(number);

            Assert.AreEqual("Да", results[0].IsPowerOfTwo);
            Assert.AreEqual("Да", results[1].IsPowerOfTwo);
        }

        // ТЕСТ 4: Некорректные входные данные — 0 и отрицательные числа
        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        public void CheckNumber_InvalidInput_ReturnsNoForBothAlgorithms(long number)
        {
            var results = _service.CheckNumber(number);

            Assert.AreEqual("Нет", results[0].IsPowerOfTwo);
            Assert.AreEqual("Нет", results[1].IsPowerOfTwo);
        }

        // ТЕСТ 5: Большие объёмы данных + форматирование результата
        [TestMethod]
        public void FormatPowerInfo_ForLargeNumber_ReturnsFormattedStringWithCorrectPower()
        {
            // Проверяем форматирование для 2^10 = 1024
            string info = AlgorithmService.FormatPowerInfo(1024, true);

            Assert.IsTrue(info.Contains("1024"));
            Assert.IsTrue(info.Contains("2^10"));
            Assert.IsTrue(info.Contains("степень двойки"));

            // Проверяем форматирование для не-степени
            string notPowerInfo = AlgorithmService.FormatPowerInfo(1000, false);
            Assert.IsTrue(notPowerInfo.Contains("1000"));
            Assert.IsTrue(notPowerInfo.Contains("НЕ является степенью двойки"));
        }
    }
}