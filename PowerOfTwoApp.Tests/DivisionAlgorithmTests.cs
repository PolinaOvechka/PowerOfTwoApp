using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerOfTwoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerOfTwoApp.Tests
{
    /// <summary>
    /// Тесты для алгоритма деления
    /// </summary>
    [TestClass]
    public class DivisionAlgorithmTests
    {
        private DivisionAlgorithm _algo = null!;

        [TestInitialize]
        public void SetUp()
        {
            _algo = new DivisionAlgorithm();
        }

        // ТЕСТ 1: Типичные данные — степени двойки (должны вернуть true)
        [TestMethod]
        [DataRow(2)]
        [DataRow(8)]
        [DataRow(1024)]
        public void Check_TypicalData_PowersOfTwo_ReturnsTrue(long number)
        {
            bool result = _algo.Check(number);
            Assert.IsTrue(result);
        }

        // ТЕСТ 2: Типичные данные — не степени двойки (должны вернуть false)
        [TestMethod]
        [DataRow(3)]
        [DataRow(100)]
        [DataRow(999)]
        public void Check_TypicalData_NotPowersOfTwo_ReturnsFalse(long number)
        {
            bool result = _algo.Check(number);
            Assert.IsFalse(result);
        }

        // ТЕСТ 3: Граничные случаи
        [TestMethod]
        [DataRow(1)]
        [DataRow(1073741824)]
        public void Check_BoundaryCases_MinAndMax_ReturnsTrue(long number)
        {
            bool result = _algo.Check(number);
            Assert.IsTrue(result);
        }

        // ТЕСТ 4: Некорректные входные данные
        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        public void Check_InvalidInput_ReturnsFalse(long number)
        {
            bool result = _algo.Check(number);
            Assert.IsFalse(result);
        }

        // ТЕСТ 5: Большие объёмы данных + проверка подсчёта операций
        [TestMethod]
        public void Check_LargeData_MaxPower_CountsOperations()
        {
            long largeNumber = 1073741824;
            bool result = _algo.Check(largeNumber);

            Assert.IsTrue(result);
            Assert.IsTrue(_algo.OperationCount > 0);
            Assert.IsTrue(_algo.OperationCount <= 70);
        }
    }
}
