using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Conube.Model.Interfaces;

namespace Conube.Model
{
    public class IRService : IIRService
    {
        private decimal taxValue = Decimal.Parse(ConfigurationManager.AppSettings["DefaultValueForCOFINS"]);

        public IRService() { }

        public IRService(decimal customValue) { taxValue = customValue; }

        public decimal CalculateTax(decimal invoiceValue)
        {
            return invoiceValue * taxValue;
        }
    }
}
