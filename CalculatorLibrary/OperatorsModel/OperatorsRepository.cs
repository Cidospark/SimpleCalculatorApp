using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.OperatorsModel
{
    /// <summary>
    /// This class implements the operations interface thereby binding to the contract
    /// </summary>
    public class OperatorsRepository : IOperatorsRepository
    {
        public string Addition(string firstNumber, string secondNumber)
        {
            string result = null;
            if (firstNumber.Contains(".") || secondNumber.Contains("."))
            {
                double num1 = Double.Parse(firstNumber);
                double num2 = Double.Parse(secondNumber);
                result = (num1 + num2).ToString();
            }
            else
            {
                int num1 = int.Parse(firstNumber);
                int num2 = int.Parse(secondNumber);
                result = (num1 + num2).ToString();
            }
            return result;
        }
    }
}
