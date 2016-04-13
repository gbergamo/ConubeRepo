using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Conube.Business;
using Conube.Business.Interfaces;
using Conube.Model;

namespace Conube.API.Controllers
{
    public class ConubeController : ApiController
    {
        private ICalculator _calculator;
        public ConubeController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public string teste(string id)
        {
            return "funcionou - " + id;
        }

        [HttpPost]
        public NFe CalculateWithhold([FromBody]dynamic obj)
        {
            string receivedValue = obj.invoiceValue;
            decimal invoiceValue;
            if (decimal.TryParse(receivedValue, out invoiceValue))
                return _calculator.CalculateWithhold(invoiceValue);

            return null;
        }

        [HttpPost]
        public NFe CalculateWithholdWithCustomTaxValues([FromBody]dynamic obj)
        {
            decimal invoiceValue, ir, pis, cofins, csll;

            string invoiceValueStr = obj.invoiceValue;
            string irStr = obj.ir;
            string pisStr = obj.pis;
            string cofinsStr = obj.cofins;
            string csllStr = obj.csll;

            if (!decimal.TryParse(invoiceValueStr, out invoiceValue))
                return null;
            if (!decimal.TryParse(irStr, out ir))
                return null;
            if (!decimal.TryParse(pisStr, out pis))
                return null;
            if (!decimal.TryParse(cofinsStr, out cofins))
                return null;
            if (!decimal.TryParse(csllStr, out csll))
                return null;
            
            return _calculator.CalculateWithhold(invoiceValue, ir / 100, pis / 100, cofins / 100, csll / 100);
        }
    }
}
