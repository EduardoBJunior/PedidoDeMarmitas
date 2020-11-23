using DAO;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;

namespace AgileFood.Models
{
    public class Fornecedor : Pessoa
    {
        public int FornecedorId { get; set; }


        public List<Fornecedor> lstFornecedor()
        {
            FornecedorDAO objDao = new FornecedorDAO();
            List<tb_fornecedor> objFornecedor = new List<tb_fornecedor>();

            List<Fornecedor> listRet = new List<Fornecedor>();

            
            
            return listRet;
        }
        public List<Cardapio> Cardapios{ get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}