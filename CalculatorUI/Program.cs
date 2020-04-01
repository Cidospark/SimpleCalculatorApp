using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorLibrary;

namespace CalculatorUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalConfig.AddIinstance();
            CalculatorLibrary.OperatorsModel.IOperatorsRepository Calc = GlobalConfig.Iinstance;
            Application.Run(new frmCalculator(Calc));

            GlobalConfig.RemoveIinstance();
        }
    }
}
