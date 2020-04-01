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

        private void btn_clicked(object sender, EventArgs e)
        {
            // remove the leading zero in the entry textbox
            if (txtEntryNResult.Text == "0")
                txtEntryNResult.Clear();

            // get the value on the button and assign it the the entry textbox
            Button btn = (Button)sender;

            // only one dot can be added to the new entry
            if (txtEntryNResult.Text.Contains(".")) 
            {
                if(btn.Text != ".")
                    txtEntryNResult.Text += btn.Text;
            }
            else
                txtEntryNResult.Text += btn.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
        }
    }
}
