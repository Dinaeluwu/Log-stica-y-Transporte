using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Logistica_y_transporte.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<ClienteModels> Clientes { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paquete>(entity =>
            {
                entity.HasOne(p => p.Cliente)
                    .WithMany()
                    .HasForeignKey(p => p.id_cliente)
                    .HasPrincipalKey(c => c.Id_Cliente)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasOne(e => e.Paquete)
                    .WithMany()
                    .HasForeignKey(e => e.id_paquete)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Ruta)
                    .WithMany()
                    .HasForeignKey(e => e.id_ruta)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasOne(f => f.Cliente)
                    .WithMany()
                    .HasForeignKey(f => f.id_cliente)
                    .HasPrincipalKey(c => c.Id_Cliente)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.Envio)
                    .WithMany()
                    .HasForeignKey(f => f.id_envio)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
