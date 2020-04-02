﻿using CalculatorLibrary;
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
        bool operatorIsCLicked = false;
        string firstValue = "0";
        string lastValue = "0";
        string result = "0";

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
            
            // if operation is already selected then execute operation else add value to new entry
            if (operatorIsCLicked)
            {
                var Temp = btn.Text;
                // prefix a dot with zero if lastValue = 0 and the new value clicked is dot
                if (lastValue == "0"  && Temp == ".")
                    Temp = "0.";

                // 
                if (lastValue.Contains(".") && Temp.Contains("."))
                { }
                else { 
                    txtEntryStatus.Text += Temp;
                    lastValue += Temp;
                    result = Calc.Calculate(firstValue, lastValue, operatorCLicked);
                    txtEntryNResult.Text = result;
                }
                
            }
            else
            {
                // only one dot can be added to the new entry
                if (txtEntryNResult.Text.Contains("."))
                {
                    if (btn.Text != ".")
                    {
                        txtEntryNResult.Text += btn.Text;
                        txtEntryStatus.Text += btn.Text;
                        firstValue = txtEntryNResult.Text;
                    }

                }
                else
                {
                    var Temp = btn.Text;
                    // prefix a dot with 0 if it is the initial value entered
                    if (Temp == ".")
                        Temp = "0.";

                    txtEntryNResult.Text += Temp;
                    txtEntryStatus.Text += Temp;
                    firstValue = txtEntryNResult.Text;
                }
            }

            // reset button to null
            btn = null;

        }

        private void operator_click(object sender, EventArgs e)
        {
            // get the sign of the button clicked
            btn = (Button)sender;
            operatorCLicked = btn.Text;
            operatorIsCLicked = true;

            // add the sign of the button clicked to the status entry box
            if (txtEntryStatus.Text == "")
                txtEntryStatus.Text = "0";
            txtEntryStatus.Text +=  operatorCLicked;
            
            // reset the last value entered
            lastValue = "0";
            firstValue = txtEntryNResult.Text;

            // reset button to null
            btn = null;
        }

        private void btnEqualTo_Click(object sender, EventArgs e)
        {

        }
    }
}
