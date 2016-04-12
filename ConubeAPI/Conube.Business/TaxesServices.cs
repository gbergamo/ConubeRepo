using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Conube.Business.Interfaces;
using Conube.Model;

namespace Conube.Business
{
    public class TaxesServices : ITaxesServices
    {
        private readonly decimal ValueToCalculateIR = Decimal.Parse(ConfigurationManager.AppSettings["DefaultValueToCalculateIR"]);
        private readonly decimal ValueToCalculateOthersTaxes = Decimal.Parse(ConfigurationManager.AppSettings["DefaultValueToCalculateOthersTaxes"]);
        public Invoice CalculateTaxes(decimal invoiceValue)
        {
            Taxes taxes = new Taxes(true);
            var invoice = new Invoice() { InvoiceAmount = invoiceValue };

            if (invoiceValue * taxes.IR > ValueToCalculateIR)
            {
                invoice.IR = invoiceValue * taxes.IR;
            }
            
            if (invoiceValue > ValueToCalculateOthersTaxes)
            {
                invoice.IR = invoiceValue * taxes.IR;
                invoice.PIS = invoiceValue * taxes.PIS;
                invoice.COFINS = invoiceValue * taxes.COFINS;
                invoice.CSLL = invoiceValue * taxes.CSLL;
            }

            invoice.CalculateWitheldAmount();
            return invoice;
        }
    }
}
