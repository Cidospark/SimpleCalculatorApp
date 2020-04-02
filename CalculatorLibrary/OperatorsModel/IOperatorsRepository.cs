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
        /// <returns> A string </returns>
        string Addition(string firstNumber, string secondNumber);

        /// <summary>
        /// This method handles the subtraction operation of the calculator
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns> A string </returns>
        string Minus(string firstNumber, string secondNumber);

        /// <summary>
        /// This method handles the multiplication operation of the calculator
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns> A string </returns>
        string Times(string firstNumber, string secondNumber);


        /// <summary>
        /// This method handles the division operation of the calculator
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns> A string </returns>
        string Divide(string firstNumber, string secondNumber);


        /// <summary>
        /// Takes in the values to be calculated and find there result based on 
        /// the operation performed
        /// </summary>
        /// <param name="fNum"></param>
        /// <param name="sNum"></param>
        /// <param name="operation"></param>
        /// <returns> A string </returns>
        string Calculate(string fNum, string sNum, string operation);
    }
}
