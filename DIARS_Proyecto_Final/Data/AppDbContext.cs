using Microsoft.EntityFrameworkCore;
using DIARS_Proyecto_Final.Models;
using System.Diagnostics.Contracts;

namespace DIARS_Proyecto_Final.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<PedidoInstalacion> PedidoInstalacion { get; set; }  // <-- Añadido

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Cargo
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargo");
                entity.HasKey(c => c.cargo_id); // Clave primaria explícita

                entity.Property(c => c.titulo_cargo)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configuración de la relación con Empleado
                entity.HasMany(c => c.Empleados)
                    .WithOne(e => e.Cargo)
                    .HasForeignKey(e => e.cargo_id);
            });

            // Configuración para Empleado
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");
                entity.HasKey(e => e.empleado_id);

                entity.Property(e => e.cargo_id).HasColumnName("cargo_id");
                entity.Property(e => e.nombres).HasColumnName("nombres").IsRequired().HasMaxLength(100);
                entity.Property(e => e.dni).HasColumnName("dni").IsRequired().HasMaxLength(8);
                entity.Property(e => e.telefono).HasColumnName("telefono").HasMaxLength(15);
                entity.Property(e => e.correo).HasColumnName("correo").HasMaxLength(100);
                entity.Property(e => e.password).HasColumnName("password").IsRequired();
                entity.Property(e => e.estado).HasColumnName("estado").IsRequired().HasMaxLength(20);
                entity.Property(e => e.fecha_inicio).HasColumnName("fecha_inicio");
                entity.Property(e => e.fecha_fin).HasColumnName("fecha_fin");
            });

            // Configuración para PedidoInstalacion
            modelBuilder.Entity<PedidoInstalacion>(entity =>
            {
                entity.ToTable("PedidoInstalacion");
                entity.HasKey(p => p.pedido_id);

                entity.Property(p => p.contrato_id).IsRequired();
                entity.Property(p => p.empleado_id).IsRequired();
                entity.Property(p => p.fecha_instalacion).HasColumnType("datetime");
                entity.Property(p => p.estado_instalacion).HasMaxLength(20);
                entity.Property(p => p.observaciones).HasMaxLength(255);
            });
        }
    }
}
