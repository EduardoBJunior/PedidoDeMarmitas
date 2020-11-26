using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime;

namespace DAO
{
    public class FornecedorDAO
    {

        public void InserirFornecedor(tb_fornecedor ObjForne)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            objBanco.tb_fornecedor.Add(ObjForne);

            objBanco.SaveChanges();
        }

        public void AlterarFornecedor(tb_fornecedor objForneAtualizado)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            tb_fornecedor objResgate = objBanco.tb_fornecedor.Where(forn => forn.id_fornecedor == objForneAtualizado.id_fornecedor).FirstOrDefault();

            
            objResgate.nome_fornecedor = objForneAtualizado.nome_fornecedor;
            objResgate.telefone_fornecedor = objForneAtualizado.telefone_fornecedor;
            objResgate.endereco_fornecedor = objForneAtualizado.endereco_fornecedor;
            objResgate.status_fornecedor = objForneAtualizado.status_fornecedor;

            objBanco.SaveChanges();
        }

        public List<tb_fornecedor> ConsultarFornecedores()
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();
            List <tb_fornecedor> LstRetorno = objBanco.tb_fornecedor.ToList();

            return LstRetorno;
        }
    }
}
