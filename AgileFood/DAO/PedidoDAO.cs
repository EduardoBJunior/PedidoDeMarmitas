using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PedidoDAO
    {

        public void InserirPedido(tb_pedidos ObjPed)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            objBanco.tb_pedidos.Add(ObjPed);

            objBanco.SaveChanges();
        }

        public void AlterarProduto(tb_pedidos objPedAtualizado)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            tb_pedidos objResgate = objBanco.tb_pedidos.Where(ped => ped.id_pedido == objPedAtualizado.id_produto).FirstOrDefault();

            objResgate.id_produto = objPedAtualizado.id_produto;
            objResgate.id_funcionario = objPedAtualizado.id_funcionario;
            objResgate.id_fornecedor = objPedAtualizado.id_fornecedor;
            objResgate.qtProdu_pedidos = objPedAtualizado.qtProdu_pedidos;
            objResgate.valorTotal_pedido = objPedAtualizado.valorTotal_pedido;

            objBanco.SaveChanges();
        }

        public List<tb_pedidos> ConsultarPedidos()
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();
            List<tb_pedidos> LstRetorno = objBanco.tb_pedidos.ToList();

            return LstRetorno;
        }
    }
}
