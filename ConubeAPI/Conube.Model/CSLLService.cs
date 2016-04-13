using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Conube.Model.Interfaces;

namespace Conube.Model
{
    public class CSLLService : ICSLLService
    {
        private decimal taxValue = Decimal.Parse(ConfigurationManager.AppSettings["DefaultValueForCSLL"]);

        public CSLLService() { }

        public CSLLService(decimal customValue) { taxValue = customValue; }

        public decimal CalculateTax(decimal invoiceValue)
        {
            return invoiceValue * taxValue;
        }
    }
}
