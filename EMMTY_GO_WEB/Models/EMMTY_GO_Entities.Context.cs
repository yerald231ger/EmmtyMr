﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMMTY_GO_WEB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EMMTY_GO_Entities : DbContext
    {
        public EMMTY_GO_Entities()
            : base("name=EMMTY_GO_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aceptador_Billetes> Aceptadores_Billetes { get; set; }
        public virtual DbSet<Aceptador_Monedas> Aceptadores_Monedas { get; set; }
        public virtual DbSet<Cajero> Cajeros { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Dispensador> Dispensadores { get; set; }
        public virtual DbSet<Impresora> Impresoras { get; set; }
        public virtual DbSet<Monitor> Monitores { get; set; }
        public virtual DbSet<PC> PCes { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }
        public virtual DbSet<ReportesXCajero> ReportesXCajero { get; set; }
        public virtual DbSet<Scanner> Scanners { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; }
        public virtual DbSet<Tarjeta> Tarjetas { get; set; }
        public virtual DbSet<Tonelero> Toneleros { get; set; }
        public virtual DbSet<UPS> UPSes { get; set; }
    }
}