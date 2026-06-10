using Ferreteria.API.DTOs;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;

namespace Ferreteria.API.Services;

public class VentaService : IVentaService
{
    private readonly IVentaRepository _repo;
    private readonly IProductoRepository _productoRepo;

    public VentaService(IVentaRepository repo, IProductoRepository productoRepo)
    {
        _repo = repo;
        _productoRepo = productoRepo;
    }

    private static VentaDto ToDto(Venta v) => new()
    {
        IdVenta = v.IdVenta,
        Fecha = v.Fecha,
        TotalVenta = v.TotalVenta,
        MedioPago = v.IdMedioDePagoNavigation?.Nombre ?? "",
        EstadoVenta = v.EstadoVenta ?? "confirmada",
        Usuario = v.IdUsuarioNavigation != null
            ? $"{v.IdUsuarioNavigation.Nombre} {v.IdUsuarioNavigation.Apellido}"
            : "",
        Detalles = v.DetalleVenta.Select(d => new DetalleVentaDto
        {
            IdProducto = d.IdProducto,
            Descripcion = d.IdProductoNavigation?.Descripcion ?? "",
            Cantidad = d.Cantidad,
            PrecioVenta = d.PrecioVenta,
            Cliente = d.IdClienteNavigation != null
                ? $"{d.IdClienteNavigation.Nombre} {d.IdClienteNavigation.Apellido}"
                : ""
        }).ToList()
    };

    public async Task<IEnumerable<VentaDto>> GetAllAsync()
        => (await _repo.GetAllAsync()).Select(ToDto);

    public async Task<VentaDto?> GetByIdAsync(int id)
    {
        var v = await _repo.GetByIdAsync(id);
        return v == null ? null : ToDto(v);
    }

    public async Task<IEnumerable<VentaDto>> GetByFechaAsync(DateOnly desde, DateOnly hasta)
        => (await _repo.GetByFechaAsync(desde, hasta)).Select(ToDto);

    public async Task<VentaDto> CreateAsync(CrearVentaDto dto)
    {
        // Validar stock antes de crear la venta
        foreach (var item in dto.Detalles)
        {
            var producto = await _productoRepo.GetByIdAsync(item.IdProducto);
            if (producto == null)
                throw new Exception($"Producto {item.IdProducto} no encontrado.");
            if ((producto.StockActual ?? 0) < item.Cantidad)
                throw new Exception($"Stock insuficiente para '{producto.Descripcion}'. Stock actual: {producto.StockActual}.");
        }

        // Calcular total
        decimal total = 0;
        var detalles = new List<DetalleVenta>();

        foreach (var item in dto.Detalles)
        {
            var producto = await _productoRepo.GetByIdAsync(item.IdProducto);
            var subtotal = producto!.PrecioVenta * item.Cantidad;
            total += subtotal;

            detalles.Add(new DetalleVenta
            {
                IdProducto = item.IdProducto,
                Cantidad = item.Cantidad,
                PrecioVenta = producto.PrecioVenta,
                IdCliente = item.IdCliente
            });
        }

        var venta = new Venta
        {
            Fecha = DateOnly.FromDateTime(DateTime.Now),
            TotalVenta = total,
            IdMedioDePago = dto.IdMedioDePago,
            EstadoVenta = "confirmada",
            IdUsuario = dto.IdUsuario
        };

        var creada = await _repo.CreateAsync(venta, detalles);

        // Recargar con navegación para el DTO
        var ventaCompleta = await _repo.GetByIdAsync(creada.IdVenta);
        return ToDto(ventaCompleta!);
    }

    public async Task<bool> AnularAsync(int id)
        => await _repo.AnularAsync(id);
}