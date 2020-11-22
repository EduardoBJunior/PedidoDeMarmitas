using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileFood.Models
{
    public class Mercadoria
    {
        public int MercadoriaId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public int CardapioId { get; set; }
        public virtual Cardapio Cardapio { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}