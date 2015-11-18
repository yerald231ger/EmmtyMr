namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aceptadores_Monedas
    {
        public Aceptadores_Monedas()
        {
            Cajeros = new HashSet<Cajero>();
        }

        [Key]
        public int IdAceptador_Monedas { get; set; }

        [StringLength(50)]
        public string ModeloAceptador_Monedas { get; set; }

        [StringLength(50)]
        public string NombreAceptador_Monedas { get; set; }

        [StringLength(50)]
        public string NSAceptador_Monedas { get; set; }

        [StringLength(50)]
        public string StatusAceptador_Monedas { get; set; }

        [StringLength(50)]
        public string ErrorAceptador_Monedas { get; set; }

        [StringLength(50)]
        public string MarcaAceptador_Monedas { get; set; }

        public virtual ICollection<Cajero> Cajeros { get; set; }
    }
}
