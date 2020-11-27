using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProdutoDAO
    {

         public void InserirProduto(tb_produto ObjProd)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            objBanco.tb_produto.Add(ObjProd);

            objBanco.SaveChanges();
        }

        public void AlterarProduto(tb_produto objProdAtualizado)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            tb_produto objResgate = objBanco.tb_produto.Where(prod => prod.id_produto == objProdAtualizado.id_produto).FirstOrDefault();

            objResgate.id_produto = objProdAtualizado.id_produto;
            objResgate.nome_produto = objProdAtualizado.nome_produto;
            objResgate.codigo_produto = objProdAtualizado.codigo_produto;
            objResgate.preco_produto = objProdAtualizado.preco_produto;
            objResgate.status_produto = objProdAtualizado.status_produto;

            objBanco.SaveChanges();
        }

        public List<tb_produto> ConsultarProduto()
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();
            List <tb_produto> LstRetorno = objBanco.tb_produto.ToList();

            return LstRetorno;
        }
    }
}
