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
        //global variables 
        private readonly IOperatorsRepository Calc;
        Button btn = null;
        string operatorCLicked = null;
        bool isOperatorCLicked = false;
        string finalResult = "0";
        string valueEntered = "0";

        // the calculator library injected into this UI form constructor
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
            btn = (Button)sender;

            // only one dot can be added to the new entry
            if (txtEntryNResult.Text.Contains("."))
            {
                if (btn.Text != ".")
                    txtEntryNResult.Text += btn.Text;
            }
            else
                txtEntryNResult.Text += btn.Text;

            // get the lastest value entered
            valueEntered = txtEntryNResult.Text;

            // reset btn to null
            btn = null;

        }

        private void operator_click(object sender, EventArgs e)
        {
            // get the sign of the button clicked
            btn = (Button)sender;
            operatorCLicked = btn.Text;

            // on click of an operator copy the new entry to the entry status box
            if(finalResult == "0")
            {
                finalResult = valueEntered;
                txtEntryStatus.Text = finalResult;
            }
            else
            {
                // pass collected values and operator to the calculator library to 
                // return result based on the operation perfomed
                finalResult = Calc.Calculate(finalResult, valueEntered, operatorCLicked);
            }
            
            
            txtEntryStatus.Text = finalResult + " " + operatorCLicked;
            
            // reset the entry box to zero
            txtEntryNResult.Text = "0";
            valueEntered = "0";

            // reset btn to null
            btn = null;
        }
    }
}
