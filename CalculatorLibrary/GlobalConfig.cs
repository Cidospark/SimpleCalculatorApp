using CalculatorLibrary.OperationsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public static class GlobalConfig
    {
        public static IOperationsRepository Iinstance { get; private set; }

        public static void AddIinstance()
        {
            OperationsRepository op = new OperationsRepository();
            Iinstance = op;
        }
    }
}
