namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sucursale
    {
        public Sucursale()
        {
            Cajeros = new HashSet<Cajero>();
        }

        [Key]
        public int IdSucursal { get; set; }

        [StringLength(50)]
        public string SupervisorCajero { get; set; }

        [StringLength(50)]
        public string EmpresaSucursal { get; set; }

        public int? TelefonoSucursal { get; set; }

        [StringLength(50)]
        public string GerenteSucursal { get; set; }

        [StringLength(50)]
        public string DireccionSucursal { get; set; }

        [StringLength(50)]
        public string NombreSucursal { get; set; }

        public virtual ICollection<Cajero> Cajeros { get; set; }
    }
}
