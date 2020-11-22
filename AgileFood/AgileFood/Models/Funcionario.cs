using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileFood.Models
{
    public class Funcionario : Pessoa
    {
        public int FinciuonarioID { get; set; }
        public Pedido Pedidos { get; set; }
    }
}