using DAO;
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
    public class FuncionarioController : Controller
    {
        private void MontarTitulo(int tipoPag)
        {
            switch (tipoPag)
            {
                case 1:
                    ViewBag.Titulo = "Novo Funcionario";
                    ViewBag.Subtitulo = "Cadastre os Funcionarioes aqui";

                    break;
                case 2:
                    ViewBag.Titulo = "Alterar ou Inativar Funcionario";
                    ViewBag.Subtitulo = "Altere os dados do Funcionario ou inative-o";
                    break;
                case 3:
                    ViewBag.Titulo = "Consultar Funcionario";
                    ViewBag.Subtitulo = "Aqui poderá consultar os funcionarioes cadastrados e cadastrar os Cardapios";
                    break;
            }
        }

        // GET: Funcionario
        public ActionResult Cadastrar()
        {
            MontarTitulo(1);
            return View();
        }
        public ActionResult Alterar(string cod, string nome, string telefone, string endereco)
        {
            MontarTitulo(2);

            @ViewBag.cod = cod;
            @ViewBag.nome = nome;
            @ViewBag.telefone = telefone;
            @ViewBag.endereco = endereco;
           
            return View();
        }

        public ActionResult ConsultarFuncionario()
        {
            MontarTitulo(3);
            CarregarFuncionarios();
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

                tb_funcionario objFuncionario = new tb_funcionario();
                FuncionarioDAO ObjDao = new FuncionarioDAO();

                objFuncionario.nome_funcionario = Nome;
                objFuncionario.telefone_funcionario = telefone;
                objFuncionario.endereco_funcionario = endereco;
                

                try
                {
                    ObjDao.InserirFuncionario(objFuncionario);
                    ViewBag.Ret = 1;
                    ViewBag.Msg = Mensagens.Msg.MsgSucesso;
                }
                catch (Exception )
                {

                    ViewBag.Ret = -1;
                    ViewBag.Msg = Mensagens.Msg.MsgErro;
                }
            }
            MontarTitulo(1);
            return View("Cadastrar");
        }
        public void CarregarFuncionarios()
        {
            FuncionarioDAO objDao = new FuncionarioDAO();
            List<tb_funcionario> lst = objDao.ConsultarFuncionario();


            ViewBag.LstFuncionario = lst;
        }

        public ActionResult Atualizar(string cod, string nome, string telelefone, string endereco)
        {
           
            FuncionarioDAO objdao = new FuncionarioDAO();
            tb_funcionario objFornAtualizado = new tb_funcionario();

            objFornAtualizado.id_funcionario = Convert.ToInt32(cod);
            objFornAtualizado.nome_funcionario = nome;
            objFornAtualizado.telefone_funcionario = telelefone;
            objFornAtualizado.endereco_funcionario = endereco;
            

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

                        objdao.AlterarFuncionario(objFornAtualizado);

                        MontarTitulo(3);
                        CarregarFuncionarios();

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

            return View("ConsultarFuncionario");
        }
    }
}