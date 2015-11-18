using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
// ReSharper disable InconsistentNaming

namespace EMMTY_GO_WEB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ApplicationUser : IdentityUser
    {
        public bool IsConnected { get; set; }
        public virtual ICollection<Connection> Connections { get; set; }
        public virtual ICollection<ConversationRoom> Rooms { get; set; }
        public virtual ICollection<Cajero> Cajeros { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El campo 'Nombre(s)', no puedo contener letras o caracteres especiales")]
        [Display(Name = "Nombre(s)")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El campo 'Apellido(s)', no puedo contener letras o caracteres especiales")]
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "El campo 'Email Secundario', no es una direccion de correo valida")]
        [Display(Name = "Email Alternativo")]
        public string AlterEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono/Celular Alternativo")]
        public string AlterPhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El campo 'Email', no es una direccion de correo valida")]
        [Display(Name = "Email")]
        public override string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono/Celular")]
        public override string PhoneNumber
        {
            get { return base.PhoneNumber; }
            set { base.PhoneNumber = value; }
        }

        [Required]
        [Display(Name = "UserName")]
        public override string UserName
        {
            get { return base.UserName; }
            set { base.UserName = value; }
        }
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("EmmtyGoDbDefaultConnection")
        {
            Database.SetInitializer(new ApplicationDbContextInizializer());
        }

        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConversationRoom> Rooms { get; set; }
        public DbSet<Aceptador_Billetes> Aceptadores_Billetes { get; set; }
        public DbSet<Aceptador_Monedas> Aceptadores_Monedas { get; set; }
        public DbSet<Cajero> Cajeros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Dispensador> Dispensadores { get; set; }
        public DbSet<Impresora> Impresoras { get; set; }
        public DbSet<Monitor> Monitores { get; set; }
        public DbSet<PC> PCes { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<ReportesCajero> ReportesCajeros { get; set; }
        public DbSet<Scanner> Scanners { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<ToneleroA> TonelerosA { get; set; }
        public DbSet<ToneleroB> TonelerosB { get; set; }
        public DbSet<UPS> UPSes { get; set; }
    }

    public class ApplicationDbContextInizializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Roles.Add(new IdentityRole
            {
                Id = "A",
                Name = "Admin"
            });
            context.Roles.Add(new IdentityRole
            {
                Id = "U",
                Name = "User"
            });
            context.Roles.Add(new IdentityRole
            {
                Id = "ATM",
                Name = "Atm"
            });
            context.Roles.Add(new IdentityRole
            {
                Id = "UA",
                Name = "UserAdmin"
            });
            base.Seed(context);
        }
    }
}