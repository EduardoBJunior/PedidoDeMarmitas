using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class ProdutoDAO
    {

        public void InserirProduto(tb_produto ObjProd)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            objBanco.tb_produto.Add(ObjProd);

            objBanco.SaveChanges();
        }

        public void AlterarFornecedor(tb_produto objForneAtualizado)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            tb_produto objResgate = objBanco.tb_produto.Where(forn => forn.id_fornecedor == objForneAtualizado.id_fornecedor).FirstOrDefault();

            objResgate.nome_produto = objForneAtualizado.nome_fornecedor;
            objResgate.codigo_produto = objForneAtualizado.telefone_fornecedor;
            objResgate.preco_produto = objForneAtualizado.endereco_fornecedor;
            objResgate.status_produto = objForneAtualizado.status_fornecedor;
        }

        public List<tb_produto> ConsultarFornecedores()
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();
            List<tb_produto> LstRetorno = objBanco.tb_produto.ToList();

            return LstRetorno;
        }
    }
}
