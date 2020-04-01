using CalculatorLibrary.Helpers;
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
        // perform addition operation
        public string Addition(string firstNumber, string secondNumber)
        {
            string result = null;
            double[] values = Utility.convertToDouble(firstNumber, secondNumber);
            result = (values[0] + values[1]).ToString();
            return result;
        }

        // Perform minus operation
        public string Minus(string firstNumber, string secondNumber)
        {
            string result = null;
            double[] values = Utility.convertToDouble(firstNumber, secondNumber);
            result = (values[0] - values[1]).ToString();
            return result;
        }


        // get result based on the operator sign
        public string Calculate(string fNum, string sNum, string operation)
        {
            string calcResult = null; 

            switch (operation)
            {
                case "+":
                    calcResult = this.Addition(fNum, sNum);
                break;
                case "-":
                    calcResult = this.Minus(fNum, sNum);
                break;
            }
            return calcResult;
        }

    }
}
