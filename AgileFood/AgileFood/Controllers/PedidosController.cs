using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileFood.Models;
using DAO;

namespace AgileFood.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult ConsultarFuncionario()
        {
            
            CarregarFuncionarios();
            return View();
        }
        public ActionResult CarregarFornecedores()
        {
            MostrarFornecedores();

            return View();
        }
        public ActionResult Pedidos(string fornecedor,string funcionario, string id_pedido, string nomePord,string  precoProd, string qtdPedido)
        {
            ConsultarProdutos(fornecedor);

            if (qtdPedido !="0")
            {
                CadastrarPedido( fornecedor,  funcionario,  id_pedido,  nomePord,   precoProd,  qtdPedido);
            }

            return View();
        }

      

        public ActionResult AdicionarItens(string quantidade)
        {
            if (quantidade != "0")
            {
                
            }

            return View("CarregarFornecedores");
        }

        public void MostrarFornecedores()
        {
            FornecedorDAO objDao = new FornecedorDAO();
            List<tb_fornecedor> lst = objDao.ConsultarFornecedores().Where(forn =>forn.status_fornecedor == 1).ToList();


            ViewBag.LstFornecedores = lst;
        }
        public void ConsultarProdutos(string fornecedor)
        {
            if (fornecedor == null )
            {

            }
            else
            {
                int idFornecedor = Convert.ToInt32(fornecedor);

                ProdutoDAO objDao = new ProdutoDAO();


                List<tb_produto> lst = objDao.ConsultarProduto().Where(prod => prod.id_fornecedor == idFornecedor && prod.status_produto == 1 ).ToList();


                ViewBag.LstProdutos = lst;
            }
            

        }
        public void CarregarFuncionarios()
        {
            FuncionarioDAO objDao = new FuncionarioDAO();
            List<tb_funcionario> lst = objDao.ConsultarFuncionario();


            ViewBag.LstFuncionario = lst;
        }
        public void CadastrarPedido(string fornecedor, string funcionario, string idPedido, string nomePord, string precoProd, string qtdPedido)
        {
            //if (fornecedor.Trim() == "" || funcionario.Trim() == "" || qtdPedido.Trim() == "")
            //{
            //    ViewBag.ret = 0;
            //    ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
            //}
            //else
            //{

                tb_pedidos objPedido = new tb_pedidos();
                PedidoDAO ObjDao = new PedidoDAO();

                objPedido.id_funcionario = Convert.ToInt32(fornecedor);
                objPedido.id_fornecedor = Convert.ToInt32(fornecedor);
                objPedido.id_produto = Convert.ToInt32(idPedido);
                objPedido.qtProdu_pedidos = Convert.ToInt32(qtdPedido);
                objPedido.valorTotal_pedido = (Convert.ToInt32(qtdPedido) * Convert.ToDecimal(precoProd));

               

                try
                {
                    ObjDao.InserirPedido(objPedido);
                    ViewBag.Ret = 1;
                    ViewBag.Msg = Mensagens.Msg.MsgSucesso;
                }
                catch (Exception)
                {

                    ViewBag.Ret = -1;
                    ViewBag.Msg = Mensagens.Msg.MsgErro;
                }
            //}
            
        }
    }
}