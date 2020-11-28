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
using AgileFood.Models;
using System.Security.Policy;

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
        public ActionResult Alterar(string cod, string nome, string telefone, string endereco, string ativo)
        {
            MontarTitulo(2);

            @ViewBag.cod = cod;
            @ViewBag.nome = nome;
            @ViewBag.telefone = telefone;
            @ViewBag.endereco = endereco;
            @ViewBag.ativo = ativo;
            return View();
        }
        public ActionResult ConsultarFornecedor(string fornecedor)
        {
            MontarTitulo(3);
            ViewBag.fornecedor = fornecedor;
            CarregarFornecedores();
            
            return View();
        }

        //GET: Cardapio
        public ActionResult CadastrarCardapio(string cod, string nome, string codigo, string preco, string status,string fornecedor)
        {
            ViewBag.fonecedor = fornecedor;

            GravarProduto(codigo, nome,preco,fornecedor);

            return View("Cardapio");
        }
        public ActionResult Cardapio(string fornecedor)
        {
            CarregarProdutos(fornecedor);

            
            return View();
        }

       
        //===========================================================================================================
        //Dadaos do Fornecedor
        public ActionResult Gravar(string Nome, string telefone, string endereco)
        {
            if (Nome.Trim() == "" || telefone.Trim() == "" || endereco.Trim() == "")
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
                catch (Exception )
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

        public ActionResult Atualizar(string cod, string nome, string telelefone, string endereco, string ativo)
        {
           
            FornecedorDAO objdao = new FornecedorDAO();
            tb_fornecedor objFornAtualizado = new tb_fornecedor();

            objFornAtualizado.id_fornecedor = Convert.ToInt32(cod);
            objFornAtualizado.nome_fornecedor = nome;
            objFornAtualizado.telefone_fornecedor = telelefone;
            objFornAtualizado.endereco_fornecedor = endereco;
            objFornAtualizado.status_fornecedor = Convert.ToInt32(ativo);

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

                        objdao.AlterarFornecedor(objFornAtualizado);

                        MontarTitulo(3);
                        CarregarFornecedores();

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

            return View("ConsultarFornecedor");
        }
        //======================================================
        //Dados Cardapio
        public void GravarProduto(string codigo, string nome, string preco, string fornecedor)
        {
            if (codigo.Trim() == "" || nome.Trim() == "" || preco == "" || preco == "0")
            {
                ViewBag.ret = 0;
                ViewBag.msg = Mensagens.Msg.MensagemCampoObg;
            }
            else
            {

                tb_produto objProduto = new tb_produto();
                ProdutoDAO objDao = new ProdutoDAO();

                objProduto.codigo_produto = codigo;
                objProduto.nome_produto = nome;
                objProduto.preco_produto = Convert.ToDecimal(preco);
                objProduto.status_produto = 1;
                objProduto.id_fornecedor = Convert.ToInt32(fornecedor);

                try
                {
                    objDao.InserirProduto(objProduto);
                    ViewBag.Ret = 1;
                    ViewBag.Msg = Mensagens.Msg.MsgSucesso;
                }
                catch (Exception)
                {

                    ViewBag.Ret = -1;
                    ViewBag.Msg = Mensagens.Msg.MsgErro;
                }
            }
            CarregarProdutos(fornecedor);
           
        }
        public void CarregarProdutos(string fornecedor)
        {
            int idFornecedor = Convert.ToInt32(fornecedor);

            ProdutoDAO objDao = new ProdutoDAO();
           

            List<tb_produto> lst = objDao.ConsultarProduto().Where(prod => prod.id_fornecedor == idFornecedor).ToList();


            ViewBag.LstProdutos = lst;
        }

        public ActionResult AlterarProduto(string cod, string codigo, string nome, string preco, string status,string fornecedor)
        {

            ProdutoDAO ObjDao = new ProdutoDAO();
            tb_produto objProdAtualizado = new tb_produto();

            objProdAtualizado.id_produto = Convert.ToInt32(cod);
            objProdAtualizado.nome_produto = nome;
            objProdAtualizado.codigo_produto = codigo;
            objProdAtualizado.preco_produto = Convert.ToDecimal(preco);
            objProdAtualizado.status_produto = Convert.ToInt32(status);
            objProdAtualizado.id_fornecedor = Convert.ToInt32(fornecedor);

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
                    CarregarProdutos(fornecedor);

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



            return View("Cardapio");

        }
    }
}