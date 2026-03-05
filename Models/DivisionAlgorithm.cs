using System;
using System.Collections.Generic;
using System.Text;

namespace PowerOfTwoApp.Models
{
    // Метод последовательного деления
    public class DivisionAlgorithm
    {
        // Счетчик выполненных операций
        public int OperationCount { get; private set; }

        public bool Check(long number)
        {
            OperationCount = 0;
            
            OperationCount++;
            if (number < 1) ;
            {
                return false;
            }

            while (number%2==0)
            {
                OperationCount += 2;
                number = number/2;
            }

            OperationCount++;
            return number == 1;
        }
    }
}
