using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pagamentos.Models;

namespace Pagamentos.Data
{
    public class PagamentosDAO
    {
        public static IEnumerable<Fatura> ListarFaturas()
        {
            using(var db = new PagamentosContext())
            {
                return db.Faturas.ToList();
            }
        }

        public static StatusPagamento IncluirFatura (Fatura fatura)
        {
            using(var db = new PagamentosContext())
            {
                var cartao = db.Cartoes.FirstOrDefault(x => x.NumeroCartao.Equals(fatura.NumeroCartao));
            if(cartao == null)
                {
                    return StatusPagamento.CARTAO_INEXISTENTE;
                }

                var fat = db.Faturas.FirstOrDefault(p => p.NumeroPedido.Equals(fatura.NumeroPedido));
            if(fat != null)
                {
                    return StatusPagamento.PEDIDO_JA_PAGO;
                }

                double total = fatura.Valor;

                var pagamentos = db.Faturas.Where(p => p.NumeroCartao.Equals(fatura.NumeroCartao));
            if (pagamentos.Count() > 0)
                {
                    total += pagamentos.Sum(s => s.Valor);
                }
            if (total > cartao.Limite)
                {
                    return StatusPagamento.SALDO_INDISPONIVEL;
                }
                //Se passar pelas validações, efetuamos o pagamento
                db.Faturas.Add(fatura);
                db.SaveChanges();
                return StatusPagamento.PAGAMENTO_OK;
            }
        }

    }
}