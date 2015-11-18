namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aceptadores_Billetes
    {
        public Aceptadores_Billetes()
        {
            Cajeros = new HashSet<Cajero>();
        }

        [Key]
        public int IdAceptador_Billetes { get; set; }

        [StringLength(50)]
        public string ModeloAceptador_Billetes { get; set; }

        [StringLength(50)]
        public string NombreAceptador_Billetes { get; set; }

        [StringLength(50)]
        public string NSAceptador_Billetes { get; set; }

        [StringLength(50)]
        public string StatusAceptador_Billetes { get; set; }

        [StringLength(50)]
        public string ErrorAceptador_Billetes { get; set; }

        [StringLength(50)]
        public string MarcaAceptador_Billetes { get; set; }

        public virtual ICollection<Cajero> Cajeros { get; set; }
    }
}
