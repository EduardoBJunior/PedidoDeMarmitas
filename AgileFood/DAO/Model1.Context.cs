﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AgileFoodEntities : DbContext
    {
        public AgileFoodEntities()
            : base("name=AgileFoodEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_cardapio> tb_cardapio { get; set; }
        public virtual DbSet<tb_funcionario> tb_funcionario { get; set; }
        public virtual DbSet<tb_pessoa> tb_pessoa { get; set; }
        public virtual DbSet<tb_produto> tb_produto { get; set; }
        public virtual DbSet<tb_fornecedor> tb_fornecedor { get; set; }
        public virtual DbSet<tb_pedidos> tb_pedidos { get; set; }
    }
}
