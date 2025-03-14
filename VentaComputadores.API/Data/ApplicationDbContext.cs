using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VentaComputadores.API.Data.Models;

namespace VentaComputadores.API.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agencia> Agencias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Computador> Computadores { get; set; }

    public virtual DbSet<TipoComputador> TiposComputadores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agencia>(entity =>
        {
            entity.HasKey(e => e.Nit).HasName("PK__agencia__DF97D0E59EE3D912");

            entity.ToTable("agencia");

            entity.Property(e => e.Nit)
                .ValueGeneratedNever()
                .HasColumnName("nit");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .HasDefaultValue("Medellín")
                .HasColumnName("ciudad");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreAgencia)
                .HasMaxLength(100)
                .HasColumnName("nombre_agencia");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(100)
                .HasColumnName("sitio_web");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__cliente__677F38F58806B7FF");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(70)
                .HasColumnName("dni");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Computador>(entity =>
        {
            entity.HasKey(e => e.NumeroUnicoComputador).HasName("PK__computad__2B7D022C6A3EA3A8");

            entity.ToTable("computador");

            entity.Property(e => e.NumeroUnicoComputador)
                .ValueGeneratedNever()
                .HasColumnName("numero_unico_computador");
            entity.Property(e => e.CapacidadAlmacenamientoGb)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("capacidad_almacenamiento_gb");
            entity.Property(e => e.ComponentesAdicionales).HasColumnName("componentes_adicionales");
            entity.Property(e => e.IdTipoComputador).HasColumnName("id_tipo_computador");
            entity.Property(e => e.MarcaComputador)
                .HasMaxLength(50)
                .HasColumnName("marca_computador");
            entity.Property(e => e.MarcaProcesadores)
                .HasMaxLength(50)
                .HasColumnName("marca_procesadores");
            entity.Property(e => e.NitAgencia).HasColumnName("nit_agencia");
            entity.Property(e => e.NombreModelo)
                .HasMaxLength(100)
                .HasColumnName("nombre_modelo");
            entity.Property(e => e.NumeroProcesadores).HasColumnName("numero_procesadores");
            entity.Property(e => e.RamGb)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("ram_gb");
            entity.Property(e => e.TipoAlmacenamiento)
                .HasMaxLength(100)
                .HasColumnName("tipo_almacenamiento");

            entity.HasOne(d => d.IdTipoComputadorNavigation).WithMany(p => p.Computadores)
                .HasForeignKey(d => d.IdTipoComputador)
                .HasConstraintName("FK__computado__id_ti__3C69FB99");

            entity.HasOne(d => d.NitAgenciaNavigation).WithMany(p => p.Computadores)
                .HasForeignKey(d => d.NitAgencia)
                .HasConstraintName("FK__computado__nit_a__3D5E1FD2");
        });

        modelBuilder.Entity<TipoComputador>(entity =>
        {
            entity.HasKey(e => e.IdTipoComputador).HasName("PK__tipo_com__5A0940438B363F47");

            entity.ToTable("tipo_computador");

            entity.Property(e => e.IdTipoComputador)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo_computador");
            entity.Property(e => e.NombreTipoComputador)
                .HasMaxLength(100)
                .HasColumnName("nombre_tipo_computador");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.CodigoVenta).HasName("PK__venta__064A4E43AD3890F7");

            entity.ToTable("venta");

            entity.Property(e => e.CodigoVenta)
                .ValueGeneratedNever()
                .HasColumnName("codigo_venta");
            entity.Property(e => e.FechaVenta).HasColumnName("fecha_venta");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.NumeroUnicoComputador).HasColumnName("numero_unico_computador");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.PorcentajeDescuentoAplicado)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("porcentaje_descuento_aplicado");
            entity.Property(e => e.PorcentajeImpuestosAplicados)
                .HasDefaultValue(19m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("porcentaje_impuestos_aplicados");
            entity.Property(e => e.PrecioComputador)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_computador");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_venta");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__venta__id_client__4316F928");

            entity.HasOne(d => d.NumeroUnicoComputadorNavigation).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.NumeroUnicoComputador)
                .HasConstraintName("FK__venta__numero_un__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
