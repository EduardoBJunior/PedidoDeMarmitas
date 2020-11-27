using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime;

namespace DAO
{
    public class FuncionarioDAO
    {

        public void InserirFuncionario(tb_funcionario ObjFunc)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            objBanco.tb_funcionario.Add(ObjFunc);

            objBanco.SaveChanges();
        }

        public void AlterarFuncionario(tb_funcionario objFuncAtualizado)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            tb_funcionario objResgate = objBanco.tb_funcionario.Where(forn => forn.id_funcionario == objFuncAtualizado.id_funcionario).FirstOrDefault();

            objResgate.id_funcionario = objFuncAtualizado.id_funcionario;
            objResgate.nome_funcionario = objFuncAtualizado.nome_funcionario;
            objResgate.telefone_funcionario = objFuncAtualizado.telefone_funcionario;
            objResgate.endereco_funcionario = objFuncAtualizado.endereco_funcionario;
            

            objBanco.SaveChanges();
        }

        public List<tb_funcionario> ConsultarFuncionario()
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();
            List <tb_funcionario> LstRetorno = objBanco.tb_funcionario.ToList();

            return LstRetorno;
        }
    }
}
