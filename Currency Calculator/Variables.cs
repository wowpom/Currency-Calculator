using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator
{
    public class Variables
    {
        public Currency[] Valuta = new Currency[2];
        public Currency[] AllValuta = new Currency[0];
        public int numb;
        public String NewValuta = "Доллар США";

        public double Сalculation(int inputnumbertext, double volume, Variables variables)
        {
            int outputnumbertext;
            if (inputnumbertext == 2)
            {
                inputnumbertext = 1;
                outputnumbertext = 0;
            }
            else
            {
                inputnumbertext = 0;
                outputnumbertext = 1;
            }
            return volume * variables.Valuta[outputnumbertext].Nominal / variables.Valuta[outputnumbertext].Value * variables.Valuta[inputnumbertext].Value / variables.Valuta[inputnumbertext].Nominal;
        }
    }
}
