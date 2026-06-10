using Ferreteria.API.DTOs;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;

namespace Ferreteria.API.Services;

public class ProveedorService : IProveedorService
{
    private readonly IProveedorRepository _repo;

    public ProveedorService(IProveedorRepository repo)
    {
        _repo = repo;
    }

    private static ProveedorDto ToDto(Proveedores p) => new()
    {
        IdProveedor = p.IdProveedor,
        RazonSocial = p.RazonSocial,
        Cuit = p.Cuit,
        Direccion = p.Direccion,
        Telefono = p.Telefono,
        Email = p.Email
    };

    public async Task<IEnumerable<ProveedorDto>> GetAllAsync()
        => (await _repo.GetAllAsync()).Select(ToDto);

    public async Task<ProveedorDto?> GetByIdAsync(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        return p == null ? null : ToDto(p);
    }

    public async Task<ProveedorDto?> GetByCuitAsync(string cuit)
    {
        var p = await _repo.GetByCuitAsync(cuit);
        return p == null ? null : ToDto(p);
    }

    public async Task<ProveedorDto> CreateAsync(CrearProveedorDto dto)
    {
        var proveedor = new Proveedores
        {
            RazonSocial = dto.RazonSocial,
            Cuit = dto.Cuit,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Email = dto.Email
        };
        var creado = await _repo.CreateAsync(proveedor);
        return ToDto(creado);
    }

    public async Task<ProveedorDto?> UpdateAsync(int id, ActualizarProveedorDto dto)
    {
        var proveedorActualizado = new Proveedores
        {
            RazonSocial = dto.RazonSocial!,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Email = dto.Email
        };
        var resultado = await _repo.UpdateAsync(id, proveedorActualizado);
        return resultado == null ? null : ToDto(resultado);
    }

    public async Task<bool> DeleteAsync(int id)
        => await _repo.DeleteAsync(id);
}