using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Helpers
{
    public static class Utility
    {
        public static double[] convertToDouble(string fn, string sn)
        {
            double[] results = {Double.Parse(fn), Double.Parse(sn) };
            return results;
        }
    }
}
