using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Conube.Model.Interfaces;

namespace Conube.Model
{
    public class COFINSService : ICOFINSService
    {
        private decimal taxValue = Decimal.Parse(ConfigurationManager.AppSettings["DefaultValueForCOFINS"]);

        public COFINSService() { }

        public COFINSService(decimal customValue) { taxValue = customValue; }


        public decimal CalculateTax(decimal invoiceValue)
        {
            return invoiceValue * taxValue;
        }
    }
}
