using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conube.Model;

namespace Conube.Business.Interfaces
{
    public interface ITaxesServices
    {
        Invoice CalculateTaxes(decimal invoiceValue);
    }
}
