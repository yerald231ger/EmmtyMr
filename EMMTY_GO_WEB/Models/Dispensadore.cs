namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dispensadore
    {
        public Dispensadore()
        {
            Cajeros = new HashSet<Cajero>();
        }

        [Key]
        public int IdDispensador { get; set; }

        public int? EfectivoActualDispensador { get; set; }

        public int? EfectivoDispensadoDispensador { get; set; }

        public int? EfectivoInicialDispensador { get; set; }

        [StringLength(50)]
        public string ModeloDispensador { get; set; }

        [StringLength(50)]
        public string NSDispensador { get; set; }

        [StringLength(50)]
        public string StatusDispensador { get; set; }

        [StringLength(50)]
        public string TipoBillete { get; set; }

        [StringLength(50)]
        public string ErrorDispensador { get; set; }

        [StringLength(50)]
        public string MarcaDispensador { get; set; }

        [StringLength(50)]
        public string NombreDispensador { get; set; }

        public virtual ICollection<Cajero> Cajeros { get; set; }
    }
}
