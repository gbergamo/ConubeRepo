using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Conube.Model
{
    public class Taxes
    {
        public Taxes()
        {
        }
        public Taxes(bool LoadDefaultValues)
        {
            if (LoadDefaultValues)
                SetDefaultValuesForTaxes();
        }

        public decimal IR { get; set; }
        public decimal PIS { get; set; }
        public decimal COFINS { get; set; }
        public decimal CSLL { get; set; }

        private void SetDefaultValuesForTaxes()
        {
            this.IR = decimal.Parse(ConfigurationManager.AppSettings["DefaultValueForIR"]);
            this.PIS = decimal.Parse(ConfigurationManager.AppSettings["DefaultValueForPIS"]);
            this.COFINS = decimal.Parse(ConfigurationManager.AppSettings["DefaultValueForCOFINS"]);
            this.CSLL = decimal.Parse(ConfigurationManager.AppSettings["DefaultValueForCSLL"]);
        }
    }
}
