//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tb_fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_fornecedor()
        {
            this.tb_cardapio = new HashSet<tb_cardapio>();
            this.tb_pedidos = new HashSet<tb_pedidos>();
            this.tb_produto = new HashSet<tb_produto>();
        }
    
        public int id_fornecedor { get; set; }
        public string nome_fornecedor { get; set; }
        public string telefone_fornecedor { get; set; }
        public string endereco_fornecedor { get; set; }
        public Nullable<int> id_pessoa { get; set; }
        public Nullable<int> status_fornecedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_cardapio> tb_cardapio { get; set; }
        public virtual tb_pessoa tb_pessoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_pedidos> tb_pedidos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_produto> tb_produto { get; set; }
    }
}
