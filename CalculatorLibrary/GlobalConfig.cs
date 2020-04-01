using CalculatorLibrary.OperatorsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Setup of the global instance of the calculator object
        /// </summary>
        public static IOperatorsRepository Iinstance { get; private set; }

        public static void AddIinstance()
        {
            OperatorsRepository op = new OperatorsRepository();
            Iinstance = op;
        }

        public static void RemoveIinstance()
        {
            Iinstance = null;
        }
    }
}
