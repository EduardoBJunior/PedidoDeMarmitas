using DAO;
using AgileFood.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.Expressions;

namespace AgiliFood.Controllers
{
    public class FornecedorController : Controller
    {
        private void MontarTitulo(int tipoPag)
        {
            switch (tipoPag)
            {
                case 1:
                    ViewBag.Titulo = "Novo Fornecedor";
                    ViewBag.Subtitulo = "Cadastre os Fornecedores aqui";

                    break;
                case 2:
                    ViewBag.Titulo = "Alterar ou Inativar Fornecedor";
                    ViewBag.Subtitulo = "Altere os dados do fornecedor ou inative-o";
                    break;
                case 3:
                    ViewBag.Titulo = "Consultar Fornecedor";
                    ViewBag.Subtitulo = "Aqui poderá consultar os fornecedores cadastrados e cadastrar os Cardapios";
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
            if (Nome.Trim() == "" || telefone.Trim() =="" || endereco.Trim() =="" )
            {
                ViewBag.ret = 0;
                ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
            }
            else
            {

                tb_fornecedor objFornecedor = new tb_fornecedor();
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