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
            double[] values = Utility.convertToDouble(firstNumber, secondNumber);
            return (values[0] + values[1]).ToString();
        }

        // Perform minus operation
        public string Minus(string firstNumber, string secondNumber)
        {
            double[] values = Utility.convertToDouble(firstNumber, secondNumber);
            return (values[0] - values[1]).ToString();
        }

        // Perform multiplication operation
        public string Times(string firstNumber, string secondNumber)
        {
            double[] values = Utility.convertToDouble(firstNumber, secondNumber);
            return (values[0] * values[1]).ToString();
        }

        // Perform division operation
        public string Divide(string firstNumber, string secondNumber)
        {
            double[] values = Utility.convertToDouble(firstNumber, secondNumber);
            if (values[1] == 0)
                return "Can't divide by zero!"; 

            return (values[0] / values[1]).ToString();
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
                case "*":
                    calcResult = this.Times(fNum, sNum);
                break;
                case "/":
                    calcResult = this.Divide(fNum, sNum);
                break;
            }
            return calcResult;
        }

    }
}
