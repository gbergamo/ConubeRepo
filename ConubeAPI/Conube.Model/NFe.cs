using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conube.Model.Interfaces;

namespace Conube.Model
{
    public class NFe
    {
        private readonly ICOFINSService _cofinsService;
        private readonly ICSLLService _csllService;
        private readonly IIRService _irService;
        private readonly IPISService _pisService;

        public NFe(ICOFINSService cofinsService,
            ICSLLService csllService,
            IIRService irService,
            IPISService pisService)
        {
            _cofinsService = cofinsService;
            _csllService = csllService;
            _irService = irService;
            _pisService = pisService;
        }

        public decimal invoiceValue { get; set; }
        public decimal Withhold { get; set; }
        public decimal IRValue { get; set; }
        public decimal COFINSValue { get; set; }
        public decimal CSLLValue { get; set; }
        public decimal PISValue { get; set; }

        public void CalculateTaxes()
        {
            this.IRValue = _irService.CalculateTax(this.invoiceValue);
            this.COFINSValue = _cofinsService.CalculateTax(this.invoiceValue);
            this.CSLLValue = _csllService.CalculateTax(this.invoiceValue);
            this.PISValue = _pisService.CalculateTax(this.invoiceValue);
        }

        public void CalculateIRWithhold()
        {
            this.Withhold += this.IRValue;
        }

        public void CalculateTaxesWithhold()
        {
            this.Withhold += this.COFINSValue;
            this.Withhold += this.CSLLValue;
            this.Withhold += this.PISValue;
        }

        public void CleanNFeTaxes()
        {
            this.COFINSValue = default(decimal);
            this.CSLLValue = default(decimal);
            this.PISValue = default(decimal);
        }

        public void CleanNFeIR()
        {
            this.IRValue = default(decimal);
        }

    }
}
