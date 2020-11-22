using DAO;
using AgileFood.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Alterar(tb_fornecedor objFornAtualizado)
        {
            
        }
    }
}