﻿using System;
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

        public void AlterarProduto(tb_produto objForneAtualizado)
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();

            tb_produto objResgate = objBanco.tb_produto.Where(forn => forn.id_produto == objForneAtualizado.id_produto).FirstOrDefault();

            objResgate.nome_produto = objForneAtualizado.nome_produto;
            objResgate.codigo_produto = objForneAtualizado.codigo_produto;
            objResgate.preco_produto = objForneAtualizado.preco_produto;
            objResgate.status_produto = objForneAtualizado.status_produto;
        }

        public List<tb_produto> ConsultarProduto()
        {
            AgileFoodEntities objBanco = new AgileFoodEntities();
            List<tb_produto> LstRetorno = objBanco.tb_produto.ToList();

            return LstRetorno;
        }
    }
}
