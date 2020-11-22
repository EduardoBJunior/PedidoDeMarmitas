using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileFood.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public List<Mercadoria> Mercadorias { get; set; }
        public List<Fornecedor> Fornecedores { get; set; }

        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario {get; set;}
    }
}