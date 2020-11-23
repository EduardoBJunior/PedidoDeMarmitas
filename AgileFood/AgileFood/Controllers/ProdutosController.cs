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
        public ActionResult Alterar()
        {
            MontarTitulo(2);
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

        public ActionResult AlterarProduto(tb_produto objProdAtualizado)
        {
            if (objProdAtualizado.codigo_produto.Trim() == "" || objProdAtualizado.nome_produto.Trim() == "" || objProdAtualizado.preco_produto == 0)
            {
                ViewBag.ret = 0;
                ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
            }
            //if (objFornAtualizado.status_fornecedor != HtmlInputCheckBox)
            //{
            //    ViewBag.ret = 0;
            //    ViewBag.msg = Mensagens.Msg.MsgInativarFornecedor;
            //    objFornAtualizado.status_fornecedor = 0;
            //}
            AgileFoodEntities objBanco = new AgileFoodEntities();

            tb_produto objResgate = objBanco.tb_produto.Where(prod => prod.id_produto == objProdAtualizado.id_produto).FirstOrDefault();


            try
            {
              
                objBanco.SaveChanges();
                ViewBag.Ret = 1;
                ViewBag.Msg = Mensagens.Msg.MsgSucesso;
            }
            catch (Exception)
            {
                ViewBag.Ret = -1;
                ViewBag.Msg = Mensagens.Msg.MsgErro;
            }
         

            objBanco.SaveChanges();

            return View("Alterar");
        }
    }
}
      
