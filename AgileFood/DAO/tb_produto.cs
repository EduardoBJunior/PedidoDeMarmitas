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
    
    public partial class tb_produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_produto()
        {
            this.tb_cardapio = new HashSet<tb_cardapio>();
        }
    
        public int id_produto { get; set; }
        public string codigo_produto { get; set; }
        public string nome_produto { get; set; }
        public Nullable<decimal> preco_produto { get; set; }
        public Nullable<int> status_produto { get; set; }
        public Nullable<int> id_fornecedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_cardapio> tb_cardapio { get; set; }
    }
}
