using Ferreteria.API.DTOs;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;

namespace Ferreteria.API.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repo;

    public ClienteService(IClienteRepository repo)
    {
        _repo = repo;
    }

    private static ClienteDto ToDto(Clientes c) => new()
    {
        IdCliente = c.IdCliente,
        Nombre = c.Nombre,
        Apellido = c.Apellido,
        Direccion = c.Direccion,
        Telefono = c.Telefono,
        Email = c.Email,
        TipoDocumento = c.TipoDocumento,
        NumeroDocumento = c.NumeroDocumento
    };

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        => (await _repo.GetAllAsync()).Select(ToDto);

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var c = await _repo.GetByIdAsync(id);
        return c == null ? null : ToDto(c);
    }

    public async Task<ClienteDto?> GetByDocumentoAsync(string numeroDocumento)
    {
        var c = await _repo.GetByDocumentoAsync(numeroDocumento);
        return c == null ? null : ToDto(c);
    }

    public async Task<ClienteDto> CreateAsync(CrearClienteDto dto)
    {
        var cliente = new Clientes
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Email = dto.Email,
            TipoDocumento = dto.TipoDocumento,
            NumeroDocumento = dto.NumeroDocumento
        };
        var creado = await _repo.CreateAsync(cliente);
        return ToDto(creado);
    }

    public async Task<ClienteDto?> UpdateAsync(int id, ActualizarClienteDto dto)
    {
        var clienteActualizado = new Clientes
        {
            Nombre = dto.Nombre!,
            Apellido = dto.Apellido!,
            Direccion = dto.Direccion,
            Telefono = dto.Telefono,
            Email = dto.Email
        };
        var resultado = await _repo.UpdateAsync(id, clienteActualizado);
        return resultado == null ? null : ToDto(resultado);
    }

    public async Task<bool> DeleteAsync(int id)
        => await _repo.DeleteAsync(id);
}