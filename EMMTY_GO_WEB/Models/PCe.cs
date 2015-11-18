namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCe
    {
        public PCe()
        {
            Cajeros = new HashSet<Cajero>();
        }

        [Key]
        public int IdPC { get; set; }

        [StringLength(50)]
        public string MarcaPC { get; set; }

        [StringLength(50)]
        public string ModeloPC { get; set; }

        [StringLength(50)]
        public string NombrePC { get; set; }

        [StringLength(50)]
        public string NSPC { get; set; }

        [StringLength(50)]
        public string OSPC { get; set; }

        [StringLength(50)]
        public string StatusPC { get; set; }

        [StringLength(50)]
        public string ErrorPC { get; set; }

        public virtual ICollection<Cajero> Cajeros { get; set; }
    }
}
