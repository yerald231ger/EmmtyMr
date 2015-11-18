
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Policy;

namespace AtmClient.Model
{
    public class AtmTestDbContextInitializer : CreateDatabaseIfNotExists<AtmTestDbContext>
    {
        protected override void Seed(AtmTestDbContext context)
        {
            var aceptadorBilletes = new AceptadorBilletes
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.AceptadoresBilletes.Add(aceptadorBilletes);

            var aceptadorMonedas = new AceptadorMonedas
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.AceptadoresMonedas.Add(aceptadorMonedas);

            var impresora = new Impresora
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.Impresoras.Add(impresora);

            var scanner = new Scanner
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.Scanners.Add(scanner);

            var toneleroA = new ToneleroA
            {
                Id = 1.ToString(),
                EfectivoActual = 0,
                EfectivoInicial = 0,
                EfectivoDispensado = 0,
                ValorDispensador = 1,
                Error = "NoError",
                Status = false
            };

            context.TonelerosA.Add(toneleroA);

            var toneleroB = new ToneleroB
            {
                Id = 1.ToString(),
                EfectivoActual = 0,
                EfectivoInicial = 0,
                EfectivoDispensado = 0,
                ValorDispensador = 5,
                Error = "NoError",
                Status = false
            };

            context.TonelerosB.Add(toneleroB);

            var dispensador = new Dispensador
            {
                Id = 1.ToString(),
                EfectivoActual = 0,
                EfectivoInicial = 0,
                EfectivoDispensado = 0,
                ValorDispensador = 50,
                Error = "NoError",
                Status = false
            };

            context.Dispensadores.Add(dispensador);

            var tarjeta = new Tarjeta
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.Cajeros.Add(new Cajero
            {
                Id = 1.ToString(),
                Dispensador = dispensador,
                ToneleroA = toneleroA,
                ToneleroB = toneleroB,
                Scanner = scanner,
                Impresora = impresora,
                Tarjeta = tarjeta,
                AceptadorBilletes = aceptadorBilletes,
                AceptadorMonedas = aceptadorMonedas,
                NsCajero = AtmClientApp.AppConfig["NsCajero"]
            });
            base.Seed(context);
        }
    }

    public class AtmTestDbContext : DbContext
    {
        public AtmTestDbContext()
            : base("AtmStatusDbConnectionString")
        {
            Database.SetInitializer(new AtmTestDbContextInitializer());
        }

        public DbSet<Cajero> Cajeros { get; set; } 
        public DbSet<Dispensador> Dispensadores { get; set; }
        public DbSet<ToneleroA> TonelerosA { get; set; }
        public DbSet<ToneleroB> TonelerosB { get; set; }
        public DbSet<Scanner> Scanners { get; set; }
        public DbSet<Impresora> Impresoras { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<AceptadorBilletes> AceptadoresBilletes { get; set; }
        public DbSet<AceptadorMonedas> AceptadoresMonedas { get; set; }
    }

    [Table("Dispensadores")]
    public partial class Dispensador : AtmDispenserComponent
    {
        public Dispensador()
        {
            Cajero = new HashSet<Cajero>();
        }
        public virtual ICollection<Cajero> Cajero { get; set; }
    }


    [Table("TonelerosA")]
    public partial class ToneleroA : AtmDispenserComponent
    {
        public ToneleroA()
        {
            Cajero = new HashSet<Cajero>();
        }
        public virtual ICollection<Cajero> Cajero { get; set; }
    }

    [Table("TonelerosB")]
    public partial class ToneleroB : AtmDispenserComponent
    {
        public ToneleroB()
        {
            Cajero = new HashSet<Cajero>();
        }
        public virtual ICollection<Cajero> Cajero { get; set; }
    }

    [Table("Scanners")]
    public partial class Scanner : AtmComponent
    {
        public Scanner()
        {
            Cajero = new HashSet<Cajero>();
        }
        public virtual ICollection<Cajero> Cajero { get; set; }
    }

    [Table("Impresoras")]
    public partial class Impresora : AtmComponent
    {
        public Impresora()
        {
            Cajero = new HashSet<Cajero>();   
        }
        public bool Papel { get; set; }
        public virtual ICollection<Cajero> Cajero { get; set; }
    }

    [Table("Tarjetas")]
    public partial class Tarjeta : AtmComponent
    {
        public Tarjeta()
        {
            Cajero = new HashSet<Cajero>();
        }

        public virtual ICollection<Cajero> Cajero { get; set; }
    }

    [Table("AceptadoresMonedas")]
    public partial class AceptadorMonedas : AtmComponent
    {
        public AceptadorMonedas()
        {
            Cajero = new HashSet<Cajero>();
        }
        public virtual ICollection<Cajero> Cajero { get; set; }
    }

    [Table("AceptadoresBilletes")]
    public partial class AceptadorBilletes : AtmComponent
    {
        public AceptadorBilletes()
        {
            Cajero = new HashSet<Cajero>();
        }
        public virtual ICollection<Cajero> Cajero { get; set; }
    }

    [Table("Cajeros")]
    public partial class Cajero
    {
        [Key]
        public string Id { get; set; }
        
        public virtual AceptadorBilletes AceptadorBilletes { get; set; }
        public virtual AceptadorMonedas AceptadorMonedas { get; set; }
        public virtual ToneleroA ToneleroA { get; set; }
        public virtual ToneleroB ToneleroB { get; set; }
        public virtual Dispensador Dispensador { get; set; }
        public virtual Impresora Impresora { get; set; }
        public virtual Scanner Scanner { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
        public virtual bool RowUpdate { get; set; }
        public virtual string NsCajero { get; set; }
        
    }

    public class AtmDispenserComponent : AtmComponent
    {

        public int EfectivoInicial { get; set; }
        public int EfectivoDispensado { get; set; }
        public int EfectivoActual { get; set; }
        public int ValorDispensador { get; set; }
    }

    public class AtmComponent 
    {
        [Key]
        public string Id { get; set; }
        public bool Status { get; set; }
        public string Error { get; set; }
    }
}


/*
    Anotacion para codemigrations

    Hay 3 formas de hacer referencia a la realcion entre los componentoes y los cajeros
    
    1.-DataAnotattions
    2.-Fluent Api
    3.-Siguiendo las Convenciones de EntityFramework

   ########## 1.- Con dataanotattions, ###################################3
    
            public partial class Dispensador
            {
                public Dispensador()
                {
                    Cajero = new HashSet<Cajero>();
                }
                [Key]
                public int Id {get; set;}
                public virtual ICollection<Cajero> Cajero { get; set; }
            }

            public partial class Cajero
            {
                [Key]
                public int Id { get; set; }
                public int IdDispensador { get; set; }    

                [ForeignKey("IdDispensador")]
                public virtual Dispensador Dispensador { get; set; }
            }
    
    ----------la segunda forma con dataanotattions-------------- 

             public partial class Dispensador
            {
                public Dispensador()
                {
                    Cajero = new HashSet<Cajero>();
                }

                [Key]
                public int IdDispensador {get; set;}
                public virtual ICollection<Cajero> Cajero { get; set; }
            }

            public partial class Cajero
            {
                public int Id { get; set; }
        
                public int IdDispensador {get; set;}
                public virtual Dispensador Dispensador { get; set; }
            }
    ##########################################################################
    ####3.- Con la Convention de entityFramework######

              public partial class Dispensador
            {
                public Dispensador()
                {
                    Cajero = new HashSet<Cajero>();
                }
                public int DispensadorId
                public virtual ICollection<Cajero> Cajero { get; set; }
            }

            public partial class Cajero
            {
                [Key]
                public int Id { get; set; }
        
                public virtual Dispensador Dispensador { get; set; }
            }
    ##############################################################
*/
