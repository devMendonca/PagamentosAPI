using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagamentos.Models
{
    public enum StatusPagamento
    {
        SALDO_INDISPONIVEL,
        PEDIDO_JA_PAGO,
        CARTAO_INEXISTENTE,
        PAGAMENTO_OK
    }
}