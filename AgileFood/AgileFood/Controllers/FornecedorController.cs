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
using System.Security.Cryptography.X509Certificates;

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
        public ActionResult Alterar(string cod, string nome, string telefone,string endereco,string ativo)
        {
            MontarTitulo(2);

            @ViewBag.cod = cod;
            @ViewBag.nome = nome;
            @ViewBag.telefone = telefone;
            @ViewBag.endereco = endereco;
            @ViewBag.ativo = ativo;
            return View();
        }

        public ActionResult ConsultarFornecedor()
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

        public ActionResult Atualizar(string cod, string nome, string tel, string end,string ativo)
        {

            tb_fornecedor objFornAtualizado = new tb_fornecedor();

            objFornAtualizado.id_fornecedor = Convert.ToInt32(cod);
            objFornAtualizado.nome_fornecedor = nome;
            objFornAtualizado.telefone_fornecedor = tel;
            objFornAtualizado.endereco_fornecedor = end;
            objFornAtualizado.status_fornecedor = Convert.ToInt32(ativo);

            if (cod == null )
            {
                MontarTitulo(3);
                ViewBag.Ret = -1;
                ViewBag.Msg = Mensagens.Msg.MensagemCampoObg;
            }
            else
            {
                if (objFornAtualizado.nome_fornecedor.Trim() == "" || objFornAtualizado.telefone_fornecedor.Trim() == "" || objFornAtualizado.endereco_fornecedor.Trim() == "")
                {
                    ViewBag.Rwilet = 0;
                    ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
                }


                AgileFoodEntities objBanco = new AgileFoodEntities();

                tb_fornecedor objResgate = objBanco.tb_fornecedor.Where(forn => forn.id_fornecedor == objFornAtualizado.id_fornecedor).FirstOrDefault();

                objBanco.SaveChanges();

                ViewBag.Ret = 1;
                ViewBag.Msg = Mensagens.Msg.MsgSucesso;

            }

            return View("ConsultarFornecedor");
        }
    }
}