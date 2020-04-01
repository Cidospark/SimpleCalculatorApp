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
        public static IOperatorsRepository Iinstance { get; private set; }

        public static void AddIinstance()
        {
            OperatorsRepository op = new OperatorsRepository();
            Iinstance = op;
        }
    }
}
