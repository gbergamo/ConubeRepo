using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conube.Model;

namespace Conube.Business.Interfaces
{
    public interface ICalculator
    {
        NFe CalculateWithhold(decimal invoiceValue);
        NFe CalculateWithhold(decimal invoiceValue, decimal IR, decimal PIS, decimal COFINS, decimal CSLL);
    }
}
