using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileFood.Models
{
    public class Fornecedor : Pessoa
    {
        public int FornecedorId { get; set; }
        public List<Cardapio> Cardapios{ get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}