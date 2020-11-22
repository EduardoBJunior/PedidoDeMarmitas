using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class ProdutosController : Controller
    {
        private void MontarTitulo(int TipoLanca)
        {
            switch (TipoLanca)
            {
                case 1 :
                  ViewBag.Titulo = "Novo Produto";
                    ViewBag.Subtitulo = "Cadastre os Fornecedores aqui";
                break;
            }
        }
        // GET: Produtos
        public ActionResult Cadastro()
        {
            MontarTitulo(1);
            return View();
        }

      
    }
}