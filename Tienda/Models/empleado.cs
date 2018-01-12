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
    public partial class empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleado()
        {
            this.factura = new HashSet<factura>();
        }
    
        public int ID_EMPLEADO { get; set; }
        [Display(Name = "Fecha Contratacion")]
        public Nullable<System.DateTime> FECHA_CONTRATACION_EMPLEADO { get; set; }
        [Display(Name = "Horas laborales")]
        public Nullable<int> HORAS_LABORALES_MENSUALES_EMPLEADO { get; set; }
        [Display(Name = "Cargo")]
        public Nullable<int> ID_CARGO_LABORAL_EMPLEADO { get; set; }
        [Display(Name = "Sucursal")]
        public Nullable<int> ID_SUCURSAL_EMPLEADO { get; set; }
        [Display(Name = "Persona")]
        public int PERSONA_ID_PERSONA { get; set; }
    
        public virtual cargo_laboral cargo_laboral { get; set; }
        public virtual persona persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
        public virtual sucursal sucursal { get; set; }
    }
}