using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PowerOfTwoApp.Models
{
    /// <summary>
    /// Класс для проведения экспериментов с алгоритмами
    /// </summary>
    public class ExperimentRunner
    {
        private DivisionAlgorithm _divisionAlgo;
        private BitAlgorithm _bitAlgo;

        public ExperimentRunner(DivisionAlgorithm divisionAlgo, BitAlgorithm bitAlgo)
        {
            _divisionAlgo = divisionAlgo;
            _bitAlgo = bitAlgo;
        }

        /// <summary>
        /// Результат одного замера
        /// </summary>
        public class ExperimentResult
        {
            public int Power { get; set; }
            public long Number { get; set; }
            public double DivisionTime { get; set; }
            public double BitTime { get; set; }   
            public int DivisionOps { get; set; }
            public int BitOps { get; set; }
        }

        /// <summary>
        /// Запускает эксперимент на разных размерах данных
        /// </summary>
        /// <param name="powers">Степени двойки для теста</param>
        /// <param name="iterations">Количество запусков для усреднения</param>
        /// <returns>Список результатов</returns>
        public List<ExperimentResult> RunExperiment(int[] powers, int iterations = 1000)
        {
            var results = new List<ExperimentResult>();

            foreach (int power in powers)
            {
                long testNumber = (long)Math.Pow(2, power);

                // Замер для метода деления
                var divTime = MeasureTime(_divisionAlgo, testNumber, iterations);
                int divOps = _divisionAlgo.OperationCount;

                // Замер для битового метода
                var bitTime = MeasureTime(_bitAlgo, testNumber, iterations);
                int bitOps = _bitAlgo.OperationCount;

                results.Add(new ExperimentResult
                {
                    Power = power,
                    Number = testNumber,
                    DivisionTime = divTime,
                    BitTime = bitTime,
                    DivisionOps = divOps,
                    BitOps = bitOps
                });
            }

            return results;
        }

        /// <summary>
        /// Замеряет время выполнения алгоритма (среднее по iterations запусков)
        /// </summary>
        private double MeasureTime(dynamic algo, long number, int iterations)
        {
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                algo.Check(number);
            }

            stopwatch.Stop();

            // Возвращаем среднее время в миллисекундах
            return (stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency) / iterations;
        }
    }
}