using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conube.Business.Interfaces;
using Conube.Model;

namespace Conube.Business
{
    public class Calculator : ICalculator
    {
        private readonly decimal ValueToCalculateIR = Decimal.Parse(ConfigurationManager.AppSettings["DefaultValueToCalculateIR"]);
        private readonly decimal ValueToCalculateOthersTaxes = Decimal.Parse(ConfigurationManager.AppSettings["DefaultValueToCalculateOthersTaxes"]);

        public NFe CalculateWithhold(decimal invoiceValue)
        {
            var csll = new CSLLService();
            var cofins = new COFINSService();
            var ir = new IRService();
            var pis = new PISService();

            NFe nfe = new NFe(cofins, csll, ir, pis);
            nfe.invoiceValue = invoiceValue;

            return InternalCalculate(nfe);                 
        }

        public NFe CalculateWithhold(decimal invoiceValue, decimal IR, decimal PIS, decimal COFINS, decimal CSLL)
        {
            var csll = new CSLLService(CSLL);
            var cofins = new COFINSService(COFINS);
            var ir = new IRService(IR);
            var pis = new PISService(PIS);

            NFe nfe = new NFe(cofins, csll, ir, pis);
            nfe.invoiceValue = invoiceValue;

            return InternalCalculate(nfe);
        }

        private NFe InternalCalculate(NFe nfe)
        {
            nfe.CalculateTaxes();

            if (nfe.IRValue >= 10)
                nfe.CalculateIRWithhold();
            else
                nfe.CleanNFeIR();

            if (nfe.invoiceValue >= 5000)
                nfe.CalculateTaxesWithhold();
            else
                nfe.CleanNFeTaxes();

            return nfe;
        }
    }
}
