using DAO;
using System;
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
                    ViewBag.Subtitulo = "Aqui poderá consultar os fornecedores cadastrados e cadastrar os Produto";
                    break;
            }
        }

        // GET: Fornecedor
        public ActionResult Cadastrar()
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
            CarregarFornecedores();
            return View();
        }

        public ActionResult Gravar(string Nome, string telefone, string endereco)
        {
            if (Nome.Trim() == "" || telefone.Trim() == "" || endereco.Trim() == "")
            {
                ViewBag.ret = 0;
                ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
            }
            else
            {

                tb_produto objProduto = new tb_produto();
                FornecedorDAO ObjDao = new FornecedorDAO();

                objFornecedor.nome_fornecedor = Nome;
                objFornecedor.telefone_fornecedor = telefone;
                objFornecedor.endereco_fornecedor = endereco;
                objFornecedor.status_fornecedor = 1;

                try
                {
                    ObjDao.InserirFornecedor(objFornecedor);
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
            return View("Cadastrar");
        }
        public void CarregarFornecedores()
        {
            FornecedorDAO objDao = new FornecedorDAO();
            List<tb_fornecedor> lst = objDao.ConsultarFornecedores();


            ViewBag.LstFornecedores = lst;
        }

        public ActionResult Alterar(tb_fornecedor objFornAtualizado)
        {
            if (objFornAtualizado.nome_fornecedor.Trim() == "" || objFornAtualizado.telefone_fornecedor.Trim() == "" || objFornAtualizado.endereco_fornecedor.Trim() == "")
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

            tb_fornecedor objResgate = objBanco.tb_fornecedor.Where(forn => forn.id_fornecedor == objFornAtualizado.id_fornecedor).FirstOrDefault();

            objBanco.SaveChanges();

            return View("Alterar");
        }
    }
}
      
    }
}