using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileFood.Models
{
    public class Cardapio
    {
        public int CardapioId { get; set; }
        public virtual List<Mercadoria> Mercadorias { get; set; }

        public int FornecedorID { get; set; }
        public virtual Fornecedor Fornecedor  { get; set; }
    }
}