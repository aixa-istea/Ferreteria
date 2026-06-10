using System;
using System.Collections.Generic;
using Ferreteria.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Data.EF;

public partial class FerreteriaDbContext : DbContext
{
    public FerreteriaDbContext(DbContextOptions<FerreteriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasProducto> CategoriasProducto { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<DetallePedidoProveedor> DetallePedidoProveedor { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<FacturaProveedor> FacturaProveedor { get; set; }

    public virtual DbSet<Marcas> Marcas { get; set; }

    public virtual DbSet<MedioPago> MedioPago { get; set; }

    public virtual DbSet<PagoProveedor> PagoProveedor { get; set; }

    public virtual DbSet<PedidoProveedor> PedidoProveedor { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<RecepcionDetalle> RecepcionDetalle { get; set; }

    public virtual DbSet<RecepcionPedido> RecepcionPedido { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CategoriasProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categorias_producto");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.NumeroDocumento, "numero_documento").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .HasColumnName("numero_documento");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento)
                .HasColumnType("enum('dni','cuit')")
                .HasColumnName("tipo_documento");
        });

        modelBuilder.Entity<DetallePedidoProveedor>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("detalle_pedido_proveedor");

            entity.HasIndex(e => e.IdProducto, "id_producto");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioCosto)
                .HasPrecision(10, 2)
                .HasColumnName("precio_costo");
            entity.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidoProveedor)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_proveedor_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidoProveedor)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_proveedor_ibfk_2");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => new { e.IdVenta, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("detalle_venta");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdProducto, "id_producto");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.PrecioVenta)
                .HasPrecision(10, 2)
                .HasColumnName("precio_venta");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_venta_ibfk_3");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_venta_ibfk_2");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_venta_ibfk_1");
        });

        modelBuilder.Entity<FacturaProveedor>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PRIMARY");

            entity.ToTable("factura_proveedor");

            entity.HasIndex(e => e.IdProveedor, "id_proveedor");

            entity.HasIndex(e => e.NumeroFactura, "numero_factura").IsUnique();

            entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            entity.Property(e => e.EstadoFactura)
                .HasDefaultValueSql("'pendiente'")
                .HasColumnType("enum('pendiente','pagada')")
                .HasColumnName("estado_factura");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(30)
                .HasColumnName("numero_factura");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.FacturaProveedor)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factura_proveedor_ibfk_1");
        });

        modelBuilder.Entity<Marcas>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PRIMARY");

            entity.ToTable("marcas");

            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<MedioPago>(entity =>
        {
            entity.HasKey(e => e.IdMedioDePago).HasName("PRIMARY");

            entity.ToTable("medio_pago");

            entity.Property(e => e.IdMedioDePago).HasColumnName("id_medio_de_pago");
            entity.Property(e => e.Nombre)
                .HasColumnType("enum('efectivo','tarjeta_debito','tarjeta_credito','qr')")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PagoProveedor>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.ToTable("pago_proveedor");

            entity.HasIndex(e => e.IdFacturaProveedor, "id_factura_proveedor");

            entity.HasIndex(e => e.IdMedioPago, "id_medio_pago");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdFacturaProveedor).HasColumnName("id_factura_proveedor");
            entity.Property(e => e.IdMedioPago).HasColumnName("id_medio_pago");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdFacturaProveedorNavigation).WithMany(p => p.PagoProveedor)
                .HasForeignKey(d => d.IdFacturaProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pago_proveedor_ibfk_1");

            entity.HasOne(d => d.IdMedioPagoNavigation).WithMany(p => p.PagoProveedor)
                .HasForeignKey(d => d.IdMedioPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pago_proveedor_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PagoProveedor)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pago_proveedor_ibfk_3");
        });

        modelBuilder.Entity<PedidoProveedor>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.ToTable("pedido_proveedor");

            entity.HasIndex(e => e.IdProveedor, "id_proveedor");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'pendiente'")
                .HasColumnType("enum('pendiente','recibido')")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.PedidoProveedor)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedido_proveedor_ibfk_1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PedidoProveedor)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedido_proveedor_ibfk_2");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdMarca, "id_marca");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'activo'")
                .HasColumnType("enum('activo','discontinuado','eliminado')")
                .HasColumnName("estado");
            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.PrecioCosto)
                .HasPrecision(10, 2)
                .HasColumnName("precio_costo");
            entity.Property(e => e.PrecioVenta)
                .HasPrecision(10, 2)
                .HasColumnName("precio_venta");
            entity.Property(e => e.StockActual)
                .HasDefaultValueSql("'0'")
                .HasColumnName("stock_actual");
            entity.Property(e => e.StockMinimo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("stock_minimo");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_ibfk_1");

            entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdProducto)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductosXCategoria",
                    r => r.HasOne<CategoriasProducto>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productos_x_categoria_ibfk_2"),
                    l => l.HasOne<Productos>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productos_x_categoria_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdCategoria")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productos_x_categoria");
                        j.HasIndex(new[] { "IdCategoria" }, "id_categoria");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("id_producto");
                        j.IndexerProperty<int>("IdCategoria").HasColumnName("id_categoria");
                    });

            entity.HasMany(d => d.IdProveedor).WithMany(p => p.IdProducto)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductosXProveedor",
                    r => r.HasOne<Proveedores>().WithMany()
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productos_x_proveedor_ibfk_2"),
                    l => l.HasOne<Productos>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productos_x_proveedor_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdProveedor")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productos_x_proveedor");
                        j.HasIndex(new[] { "IdProveedor" }, "id_proveedor");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("id_producto");
                        j.IndexerProperty<int>("IdProveedor").HasColumnName("id_proveedor");
                    });
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.Cuit, "cuit").IsUnique();

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Cuit)
                .HasMaxLength(20)
                .HasColumnName("cuit");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .HasColumnName("razon_social");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<RecepcionDetalle>(entity =>
        {
            entity.HasKey(e => new { e.IdRecepcion, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("recepcion_detalle");

            entity.HasIndex(e => e.IdProducto, "id_producto");

            entity.Property(e => e.IdRecepcion).HasColumnName("id_recepcion");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.CantidadRecibida).HasColumnName("cantidad_recibida");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.RecepcionDetalle)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recepcion_detalle_ibfk_2");

            entity.HasOne(d => d.IdRecepcionNavigation).WithMany(p => p.RecepcionDetalle)
                .HasForeignKey(d => d.IdRecepcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recepcion_detalle_ibfk_1");
        });

        modelBuilder.Entity<RecepcionPedido>(entity =>
        {
            entity.HasKey(e => e.IdRecepcion).HasName("PRIMARY");

            entity.ToTable("recepcion_pedido");

            entity.HasIndex(e => e.IdFacturaProveedor, "id_factura_proveedor");

            entity.HasIndex(e => e.IdPedidoProveedor, "id_pedido_proveedor");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdRecepcion).HasColumnName("id_recepcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdFacturaProveedor).HasColumnName("id_factura_proveedor");
            entity.Property(e => e.IdPedidoProveedor).HasColumnName("id_pedido_proveedor");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdFacturaProveedorNavigation).WithMany(p => p.RecepcionPedido)
                .HasForeignKey(d => d.IdFacturaProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recepcion_pedido_ibfk_2");

            entity.HasOne(d => d.IdPedidoProveedorNavigation).WithMany(p => p.RecepcionPedido)
                .HasForeignKey(d => d.IdPedidoProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recepcion_pedido_ibfk_1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RecepcionPedido)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recepcion_pedido_ibfk_3");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasColumnType("enum('admin','vendedor','cajero')")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.IdRol, "id_rol");

            entity.HasIndex(e => e.UsuarioLogin, "usuario_login").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.UsuarioLogin)
                .HasMaxLength(50)
                .HasColumnName("usuario_login");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_ibfk_1");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PRIMARY");

            entity.ToTable("venta");

            entity.HasIndex(e => e.IdMedioDePago, "id_medio_de_pago");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.EstadoVenta)
                .HasDefaultValueSql("'confirmada'")
                .HasColumnType("enum('confirmada','anulada')")
                .HasColumnName("estado_venta");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdMedioDePago).HasColumnName("id_medio_de_pago");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.TotalVenta)
                .HasPrecision(10, 2)
                .HasColumnName("total_venta");

            entity.HasOne(d => d.IdMedioDePagoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdMedioDePago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("venta_ibfk_1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("venta_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
