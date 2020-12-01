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
        public ActionResult Pedidos(string fornecedor)
        {
            ConsultarProdutos(fornecedor);

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
        //public void RegistrarPedido()
        //{
        //    if (Nome.Trim() == "" || telefone.Trim() == "" || endereco.Trim() == "")
        //    {
        //        ViewBag.ret = 0;
        //        ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
        //    }
        //    else
        //    {

        //        tb_pedidos objPrdido = new tb_pedidos();
        //        FornecedorDAO ObjDao = new FornecedorDAO();

        //        objFornecedor.nome_fornecedor = Nome;
        //        objFornecedor.telefone_fornecedor = telefone;
        //        objFornecedor.endereco_fornecedor = endereco;
        //        objFornecedor.status_fornecedor = 1;

        //        try
        //        {
        //            ObjDao.InserirFornecedor(objFornecedor);
        //            ViewBag.Ret = 1;
        //            ViewBag.Msg = Mensagens.Msg.MsgSucesso;
        //        }
        //        catch (Exception)
        //        {

        //            ViewBag.Ret = -1;
        //            ViewBag.Msg = Mensagens.Msg.MsgErro;
        //        }
        //    }
        //    MontarTitulo(1);
        //}
    }
}