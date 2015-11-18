namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Monitore
    {
        public Monitore()
        {
            Cajeros = new HashSet<Cajero>();
        }

        [Key]
        public int IdMonitor { get; set; }

        [StringLength(50)]
        public string MarcaMonitor { get; set; }

        [StringLength(50)]
        public string ModeloMonitor { get; set; }

        [StringLength(50)]
        public string NombreMonitor { get; set; }

        [StringLength(50)]
        public string NSMonitor { get; set; }

        [StringLength(50)]
        public string StatusMonitor { get; set; }

        [StringLength(50)]
        public string ErrorMonitor { get; set; }

        public virtual ICollection<Cajero> Cajeros { get; set; }
    }
}
