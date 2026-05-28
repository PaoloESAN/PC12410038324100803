using Microsoft.EntityFrameworkCore;
using PC12410038324100803.CORE.core.Entities;

namespace PC12410038324100803.CORE.infrastructure.Data;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public DbSet<TipoServicio> TipoServicio { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Vehiculo> Vehiculo { get; set; }
    public DbSet<Ordenservicio> Ordenservicio { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.ToTable("TipoServicio");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Preciobase).HasColumnType("decimal(10,2)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("cliente");
            entity.Property(e => e.Paterno).HasMaxLength(50);
            entity.Property(e => e.Materno).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.ToTable("vehiculo");
            entity.Property(e => e.Placa).HasMaxLength(20);
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);

            entity.HasOne(e => e.Cliente)
                  .WithMany(c => c.Vehiculos)
                  .HasForeignKey(e => e.Clienteid)
                  .HasConstraintName("FK_vehiculo_cliente");
        });

        modelBuilder.Entity<Ordenservicio>(entity =>
        {
            entity.ToTable("ordenservicio");
            entity.Property(e => e.Fechaingreso).HasColumnType("date");
            entity.Property(e => e.Descripcionproblema).HasMaxLength(500);
            entity.Property(e => e.Costoestimado).HasColumnType("decimal(10,2)");
            entity.Property(e => e.Estado).HasMaxLength(20);

            entity.HasOne(e => e.Vehiculo)
                  .WithMany(v => v.Ordenservicios)
                  .HasForeignKey(e => e.Vehiculoid)
                  .HasConstraintName("FK_ordenservicio_vehiculo");

            entity.HasOne(e => e.TipoServicio)
                  .WithMany()
                  .HasForeignKey(e => e.Tiposervicioid)
                  .HasConstraintName("FK_ordenservicio_tiposervicio");
        });
    }
}
