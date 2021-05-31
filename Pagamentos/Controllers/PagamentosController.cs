using Pagamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pagamentos.Data;

namespace Pagamentos.Controllers
{
    public class PagamentosController : ApiController
    {
        [HttpGet]
        public IEnumerable<Fatura> GetFaturas()
        {
            return PagamentosDAO.ListarFaturas();
        }
    }
}
