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
            // before proceeding, cancel operation if an error occur
            try
            {
                // get the value on the button and assign it the the entry textbox
                btn = (Button)sender;

                // remove the leading zero in the entry textbox
                if (txtEntryNResult.Text == "0" && btn.Text != ".")
                    txtEntryNResult.Clear();


                // if operation is already selected then execute operation else add value to new entry
                if (operatorIsCLicked)
                {
                    var Temp = btn.Text;
                    // prefix a dot with zero if lastValue = 0 and the new value clicked is dot
                    if (lastValue == "0" && Temp == ".")
                        Temp = "0.";

                    // 
                    if (lastValue.Contains(".") && Temp.Contains("."))
                    { }
                    else
                    {
                        txtEntryStatus.Text += Temp;
                        lastValue += Temp;
                        var tempResult = Calc.Calculate(firstValue, lastValue, operatorCLicked);
                        txtEntryNResult.Text = $"{Math.Round(Double.Parse(tempResult), 6)}";
                    }

                }
                else
                {
                    if (result != "0")
                    {
                        txtEntryStatus.Clear();
                        txtEntryStatus.Text += result;
                        result = "0";
                    }

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
                        if (txtEntryNResult.Text == "0" && Temp == ".")
                            Temp = "0.";

                        txtEntryNResult.Text += btn.Text;
                        txtEntryStatus.Text += Temp;
                        firstValue = txtEntryNResult.Text;
                    }
                }

                // reset button to null
                btn = null;
            }catch(Exception ex)
            {
                ResetForm();
            }

        }

        private void operator_click(object sender, EventArgs e)
        {
            // before proceeding, cancel operation if an error occur
            try
            {
                // get the sign of the button clicked
                btn = (Button)sender;
                operatorCLicked = btn.Text;
                operatorIsCLicked = true;

                // display zero before an operator if the status box is empty
                if (txtEntryStatus.Text == "")
                    txtEntryStatus.Text = "0";

                // add the sign of the button clicked to the status entry box
                if (result != "0")
                {
                    txtEntryStatus.Clear();
                    txtEntryStatus.Text += result +  operatorCLicked ;
                    result = "0";
                }
                else
                    txtEntryStatus.Text += operatorCLicked;

                // reset the last value entered
                lastValue = "0";
                firstValue = txtEntryNResult.Text;

                // reset button to null
                btn = null;
            }
            catch (Exception ex)
            {
                ResetForm();
            }
        }

        // Display final result and reset screen
        private void btnEqualTo_Click(object sender, EventArgs e)
        {
            txtEntryStatus.Text = "";
            operatorIsCLicked = false;
            result = txtEntryNResult.Text;
        }

        // reset operations
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        // undo last entry
        private void btnCancelEntry_Click(object sender, EventArgs e)
        {
            if(result == "0")
            {
                var currentExp = txtEntryStatus.Text;
                txtEntryStatus.Text = currentExp.Substring(0, currentExp.Length-1);

                result = (Double.Parse(Calc.Addition(firstValue,lastValue)) - Double.Parse(lastValue)).ToString();
                txtEntryNResult.Text = result;
                lastValue = "0";
            }
            
        }

        // helper function
        private void ResetForm()
        {
            btn = null;
            operatorCLicked = null;
            operatorIsCLicked = false;
            firstValue = "0";
            lastValue = "0";
            result = "0";

            txtEntryStatus.Text = "";
            txtEntryNResult.Text = "0";
        }
    }
}
