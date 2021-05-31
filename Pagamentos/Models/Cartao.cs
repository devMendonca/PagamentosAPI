using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagamentos.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public int NumeroCartao { get; set; }
        public double Limite { get; set; }
    }
}