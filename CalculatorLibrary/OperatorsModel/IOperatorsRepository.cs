using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.OperatorsModel
{
    /// <summary>
    /// This interface provides a contract on the applications operations
    /// </summary>
    public interface IOperatorsRepository
    {
        /// <summary>
        /// This method handles the addition operation of the calculator
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        string Addition(string firstNumber, string secondNumber);
    }
}
