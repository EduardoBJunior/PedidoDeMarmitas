using AgileFood.Models; //perguntar nanno
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgileFood.Context
{
    public class FornecedorContext : DbContext
    {
        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}