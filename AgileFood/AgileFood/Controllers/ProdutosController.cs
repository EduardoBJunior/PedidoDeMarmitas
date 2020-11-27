using DAO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class ProdutosController : Controller
    {
        private void MontarTitulo(int tipoPag)
        {
            switch (tipoPag)
            {
                case 1:
                    ViewBag.Titulo = "Novo Produto";
                    ViewBag.Subtitulo = "Cadastre os Produto aqui";

                    break;
                case 2:
                    ViewBag.Titulo = "Alterar ou Inativar Produto";
                    ViewBag.Subtitulo = "Altere os dados do Produto ou inative-o";
                    break;
                case 3:
                    ViewBag.Titulo = "Consultar Produto";
                    ViewBag.Subtitulo = "Aqui poderá consultar os Produtos cadastrados e cadastrar os Produto";
                    break;
            }
        }

        // GET: Produtos
        public ActionResult Cadastro()
        {
            MontarTitulo(1);
            return View();
        }
        public ActionResult Alterar(string cod, string nome, string codigo,string preco, string status)
        {
            MontarTitulo(2);

            @ViewBag.cod = cod;
            @ViewBag.nome = nome;
            @ViewBag.codigo = codigo;
            @ViewBag.preco = preco;
            @ViewBag.status = status;

            return View();
        }

        public ActionResult Consultar()
        {
            MontarTitulo(3);
            CarregarProdutos();
            return View();
        }

        public ActionResult Gravar(string codigo, string nome, string preco)
        {
            if (codigo.Trim() == "" || nome.Trim() == "" || preco == "" || preco =="0")
            {
                ViewBag.ret = 0;
                ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
            }
            else
            {

                tb_produto objProduto = new tb_produto();
                ProdutoDAO objDao = new ProdutoDAO();

                objProduto.codigo_produto= codigo;
                objProduto.nome_produto = nome ;
                objProduto.preco_produto = Convert.ToDecimal(preco);
                objProduto.status_produto = 1;

                try
                {
                    objDao.InserirProduto(objProduto);
                    ViewBag.Ret = 1;
                    ViewBag.Msg = Mensagens.Msg.MsgSucesso;
                }
                catch (Exception ex)
                {

                    ViewBag.Ret = -1;
                    ViewBag.Msg = Mensagens.Msg.MsgErro;
                }
            }
            MontarTitulo(1);
            return View("Cadastro");
        }
        public void CarregarProdutos()
        {
            ProdutoDAO objDao = new ProdutoDAO();
            List<tb_produto> lst = objDao.ConsultarProduto();


            ViewBag.LstProdutos = lst;
        }

        public ActionResult AlterarProduto(string cod,string codigo, string nome, string preco, string status)
        {

            ProdutoDAO ObjDao = new ProdutoDAO();
            tb_produto objProdAtualizado = new tb_produto();

            objProdAtualizado.id_produto = Convert.ToInt32(cod);
            objProdAtualizado.nome_produto = nome;
            objProdAtualizado.codigo_produto = codigo;
            objProdAtualizado.preco_produto = Convert.ToDecimal(preco);
            objProdAtualizado.status_produto = Convert.ToInt32(status);

            if (cod == null)
            {
                MontarTitulo(3);
                ViewBag.Ret = -1;
                ViewBag.Msg = Mensagens.Msg.MensagemCampoObg;
            }
            else
            {
                try
                {

                    ObjDao.AlterarProduto(objProdAtualizado);

                    MontarTitulo(3);
                    CarregarProdutos();

                    ViewBag.Ret = 1;
                    ViewBag.Msg = Mensagens.Msg.MsgSucesso;
                }
                catch (Exception)
                {

                    ViewBag.Ret = -1;
                    ViewBag.Msg = Mensagens.Msg.MsgErro;
                }

                ViewBag.Ret = 2;
                ViewBag.Msg = Mensagens.Msg.MensagemCampoObg;
            }



            return View("Consultar");

        }

            
    
    }
}
      
