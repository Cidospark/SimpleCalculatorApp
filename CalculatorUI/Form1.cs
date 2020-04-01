using CalculatorLibrary;
using CalculatorLibrary.OperationsModel;
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
    public partial class Form1 : Form
    {
        private readonly IOperationsRepository Calc;
        public Form1()
        {
            InitializeComponent();
            Calc = GlobalConfig.Iinstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ans = Calc.Addition(textBox1.Text, textBox2.Text);
            label1.Text = ans;
        }
    }
}
