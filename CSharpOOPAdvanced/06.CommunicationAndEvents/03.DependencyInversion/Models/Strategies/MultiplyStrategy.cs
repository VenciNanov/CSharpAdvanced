using System;
using System.Collections.Generic;
using System.Text;

public class MultiplyStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }
}
