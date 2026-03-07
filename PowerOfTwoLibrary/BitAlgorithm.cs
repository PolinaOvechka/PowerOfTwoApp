using System;
using System.Collections.Generic;
using System.Text;

namespace PowerOfTwoApp.Models
{
    /// <summary>
    /// Алгоритм проверки: битовые операции. Используем свойство: n & (n-1) == 0 для степеней двойки
    /// </summary>
    public class BitAlgorithm
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

            OperationCount += 3;
            return (number & (number - 1)) == 0;
        }

        public string GetName()
        {
            return "Битовые операции";
        }
    }
}
