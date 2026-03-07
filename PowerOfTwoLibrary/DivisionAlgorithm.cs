using System;
using System.Collections.Generic;
using System.Text;

namespace PowerOfTwoApp.Models
{
    /// <summary>
    /// Алгоритм проверки: метод последовательного деления. Делим число на 2, пока не получим 1 или остаток
    /// </summary>
    public class DivisionAlgorithm
    {
        public int OperationCount { get; private set; }

        /// <summary>
        /// Проверяет, является ли число степенью двойки
        /// </summary>
        /// <param name="number">Число от 1 до 2^30</param>
        /// <returns>True, если степень двойки</returns>
        public bool Check(long number)
        {
            OperationCount = 0;

            OperationCount++;
            if (number < 1)
            {
                return false;
            }

            while (number % 2 == 0)
            {
                OperationCount += 2;
                number = number / 2;
            }

            OperationCount++;
            return number == 1;
        }

        public string GetName()
        {
            return "Метод деления";
        }
    }
}
