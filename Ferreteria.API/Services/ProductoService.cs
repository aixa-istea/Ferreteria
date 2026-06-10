using Ferreteria.API.DTOs;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;

namespace Ferreteria.API.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repo;

    public ProductoService(IProductoRepository repo)
    {
        _repo = repo;
    }

    private static ProductoDto ToDto(Productos p) => new()
    {
        IdProducto = p.IdProducto,
        Descripcion = p.Descripcion,
        Marca = p.IdMarcaNavigation?.Nombre ?? "Sin marca",
        PrecioCosto = p.PrecioCosto,
        PrecioVenta = p.PrecioVenta,
        StockActual = p.StockActual ?? 0,
        StockMinimo = p.StockMinimo ?? 0,
        Estado = p.Estado ?? "activo"
    };

    public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        => (await _repo.GetAllAsync()).Select(ToDto);

    public async Task<ProductoDto?> GetByIdAsync(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        return p == null ? null : ToDto(p);
    }

    public async Task<IEnumerable<ProductoDto>> GetBajoStockAsync()
        => (await _repo.GetBajoStockAsync()).Select(ToDto);

    public async Task<IEnumerable<ProductoDto>> GetByCategoriaAsync(int idCategoria)
        => (await _repo.GetByCategoriaAsync(idCategoria)).Select(ToDto);

    public async Task<ProductoDto> CreateAsync(CrearProductoDto dto)
    {
        var producto = new Productos
        {
            IdMarca = dto.IdMarca,
            Descripcion = dto.Descripcion,
            PrecioCosto = dto.PrecioCosto,
            PrecioVenta = dto.PrecioVenta,
            StockActual = dto.StockActual,
            StockMinimo = dto.StockMinimo,
            Estado = "activo"
        };
        var creado = await _repo.CreateAsync(producto);
        return ToDto(creado);
    }

    public async Task<ProductoDto?> UpdateAsync(int id, ActualizarProductoDto dto)
    {
        var productoActualizado = new Productos
        {
            Descripcion = dto.Descripcion!,
            PrecioCosto = dto.PrecioCosto ?? 0,
            PrecioVenta = dto.PrecioVenta ?? 0,
            StockActual = dto.StockActual ?? -1,
            StockMinimo = dto.StockMinimo ?? -1,
            Estado = dto.Estado
        };
        var resultado = await _repo.UpdateAsync(id, productoActualizado);
        return resultado == null ? null : ToDto(resultado);
    }

    public async Task<bool> DeleteAsync(int id)
        => await _repo.DeleteAsync(id);
}