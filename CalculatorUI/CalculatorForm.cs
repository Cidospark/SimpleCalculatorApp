using CalculatorLibrary;
using CalculatorLibrary.OperatorsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorUI
{
    public partial class frmCalculator : Form
    {
        private readonly IOperatorsRepository Calc;
        public frmCalculator(IOperatorsRepository calc)
        {
            InitializeComponent();
            this.Calc = calc;
        }

       
    }
}
