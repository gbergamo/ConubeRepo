using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conube.Model.Interfaces
{
    public interface IPISService
    {
        decimal CalculateTax(decimal invoiceValue);
    }
}
