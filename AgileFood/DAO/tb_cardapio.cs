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
    
    public partial class tb_cardapio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_cardapio()
        {
            this.tb_pedidos = new HashSet<tb_pedidos>();
        }
    
        public int id_cardapio { get; set; }
        public Nullable<int> id_fornecedor { get; set; }
        public Nullable<int> id_Produto { get; set; }
    
        public virtual tb_produto tb_produto { get; set; }
        public virtual tb_fornecedor tb_fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_pedidos> tb_pedidos { get; set; }
    }
}
