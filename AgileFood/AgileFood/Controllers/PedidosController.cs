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
        public ActionResult Pedidos(string fornecedor)
        {

           
            CarregarFornecedores();



            return View();
        }

        public ActionResult Produtos(string fornecedor)
        {
            ConsultarProdutos(fornecedor);

            return View("Pedidos");
        }

        public void CarregarFornecedores()
        {
            FornecedorDAO objDao = new FornecedorDAO();
            List<tb_fornecedor> lst = objDao.ConsultarFornecedores();


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


                List<tb_produto> lst = objDao.ConsultarProduto().Where(prod => prod.id_fornecedor == idFornecedor).ToList();


                ViewBag.LstProdutos = lst;
            }
            

        }
    }
}