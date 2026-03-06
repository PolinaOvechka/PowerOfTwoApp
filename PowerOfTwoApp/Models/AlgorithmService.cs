using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PowerOfTwoApp.Models
{
    /// <summary>
    /// Сервис для запуска алгоритмов и форматирования результатов
    /// </summary>
    public class AlgorithmService
    {
        private DivisionAlgorithm _divisionAlgo;
        private BitAlgorithm _bitAlgo;

        public AlgorithmService(DivisionAlgorithm divisionAlgo, BitAlgorithm bitAlgo)
        {
            _divisionAlgo = divisionAlgo;
            _bitAlgo = bitAlgo;
        }

        /// <summary>
        /// Результат проверки одного алгоритма
        /// </summary>
        public class AlgorithmResult
        {
            public string AlgorithmName { get; set; } = string.Empty;
            public string IsPowerOfTwo { get; set; } = string.Empty;
            public int OperationCount { get; set; }
            public string TimeMs { get; set; } = string.Empty;
        }

        /// <summary>
        /// Замеряет время выполнения алгоритма
        /// </summary>
        private (bool result, double timeMs) MeasureAlgorithm(Func<long, bool> algorithm, long number, int iterations = 100)
        {
            var stopwatch = Stopwatch.StartNew();

            bool result = false;
            for (int i = 0; i < iterations; i++)
            {
                result = algorithm(number);
            }

            stopwatch.Stop();
            double averageTime = (stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency) / iterations;

            return (result, averageTime);
        }

        /// <summary>
        /// Запускает оба алгоритма и возвращает результаты, готовые для таблицы
        /// </summary>
        public List<AlgorithmResult> CheckNumber(long number)
        {
            var results = new List<AlgorithmResult>();

            // Первый алгоритм (деление)
            var (result1, time1) = MeasureAlgorithm(_divisionAlgo.Check, number);
            results.Add(new AlgorithmResult
            {
                AlgorithmName = _divisionAlgo.GetName(),
                IsPowerOfTwo = result1 ? "Да" : "Нет",
                OperationCount = _divisionAlgo.OperationCount,
                TimeMs = time1.ToString("F4")
            });

            // Второй алгоритм (битовый)
            var (result2, time2) = MeasureAlgorithm(_bitAlgo.Check, number);
            results.Add(new AlgorithmResult
            {
                AlgorithmName = _bitAlgo.GetName(),
                IsPowerOfTwo = result2 ? "Да" : "Нет",
                OperationCount = _bitAlgo.OperationCount,
                TimeMs = time2.ToString("F4")
            });

            return results;
        }

        /// <summary>
        /// Форматирует информацию о степени двойки для отображения
        /// </summary>
        public static string FormatPowerInfo(long number, bool isPowerOfTwo)
        {
            if (!isPowerOfTwo)
                return $"Число {number} НЕ является степенью двойки";

            // Считаем степень
            int power = 0;
            long temp = number;
            while (temp > 1)
            {
                temp /= 2;
                power++;
            }
            return $"Число {number} = 2^{power} (степень двойки)";
        }
    }
}