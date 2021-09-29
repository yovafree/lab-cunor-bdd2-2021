using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Models
{
    public class PostgreSQLContext : DbContext{
        
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options):base(options){

        }

        public DbSet<Producto> Productos {get;set;}
        public DbSet<Factura> Facturas {get;set;}
        public DbSet<DetFactura> DetFactura {get;set;}
        public DbSet<Usuario> Usuario {get;set;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<DetFactura>()
            .HasOne(p => p.Factura)
            .WithMany(b => b.DetFacturas)
            .HasForeignKey(p => p.cod_factura);

            builder.Entity<DetFactura>()
            .HasOne(p => p.Producto)
            .WithMany(b => b.DetFacturas)
            .HasForeignKey(p => p.cod_producto);
        }
    }
}