using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conube.Model
{
    public class Invoice : Taxes
    {
        public decimal InvoiceAmount { get; set; }
        public decimal WithheldAmount { get; set; }

        public void CalculateWitheldAmount()
        {
            this.WithheldAmount = base.IR + base.PIS + base.COFINS + base.CSLL;
        }
    }
}
