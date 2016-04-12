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
        [HttpGet]
        public Invoice CalculateWithhold(decimal id)
        {
            ITaxesServices taxesServices = new TaxesServices();
            return taxesServices.CalculateTaxes(id);
        }
    }
}
