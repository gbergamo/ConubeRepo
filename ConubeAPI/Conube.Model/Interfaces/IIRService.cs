using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conube.Model.Interfaces
{
    public interface IIRService
    {
        decimal CalculateTax(decimal invoiceValue);
    }
}
