using Ferreteria.Data.EF;
using Ferreteria.Data.Models;
using Ferreteria.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Data.Repositories.Implementations;

public class ClienteRepository : IClienteRepository
{
    private readonly FerreteriaDbContext _context;

    public ClienteRepository(FerreteriaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Clientes>> GetAllAsync()
    {
        return await _context.Clientes
            .OrderBy(c => c.Apellido)
            .ToListAsync();
    }

    public async Task<Clientes?> GetByIdAsync(int id)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.IdCliente == id);
    }

    public async Task<Clientes?> GetByDocumentoAsync(string numeroDocumento)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.NumeroDocumento == numeroDocumento);
    }

    public async Task<Clientes> CreateAsync(Clientes cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Clientes?> UpdateAsync(int id, Clientes clienteActualizado)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return null;

        if (clienteActualizado.Nombre != null)
            cliente.Nombre = clienteActualizado.Nombre;
        if (clienteActualizado.Apellido != null)
            cliente.Apellido = clienteActualizado.Apellido;
        if (clienteActualizado.Direccion != null)
            cliente.Direccion = clienteActualizado.Direccion;
        if (clienteActualizado.Telefono != null)
            cliente.Telefono = clienteActualizado.Telefono;
        if (clienteActualizado.Email != null)
            cliente.Email = clienteActualizado.Email;

        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }
}