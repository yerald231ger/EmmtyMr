//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.ComponentModel.DataAnnotations;

namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReportesXCajero
    {
        public Nullable<int> IdReporte { get; set; }
        public Nullable<int> IdCajero { get; set; }
        
        [Key]
        public int IdReporteXCajero { get; set; }
    
        public virtual Cajero Cajeros { get; set; }
        public virtual Reporte Reportes { get; set; }
    }
}
