//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tienda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class tipo_telefono
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_telefono()
        {
            this.telefono = new HashSet<telefono>();
        }
    
        public int ID_TIPO_TELEFONO { get; set; }
        [Display(Name = "Tipo Telefono")]
        public string TIPO_TELEFONO1 { get; set; }
        [Display(Name = "Descripcion")]
        public string DESCRIPCION_TIPO_TELEFONO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefono> telefono { get; set; }
    }
}
