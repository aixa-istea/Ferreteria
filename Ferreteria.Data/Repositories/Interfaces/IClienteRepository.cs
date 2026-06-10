using Ferreteria.Data.Models;

namespace Ferreteria.Data.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<IEnumerable<Clientes>> GetAllAsync();
    Task<Clientes?> GetByIdAsync(int id);
    Task<Clientes?> GetByDocumentoAsync(string numeroDocumento);
    Task<Clientes> CreateAsync(Clientes cliente);
    Task<Clientes?> UpdateAsync(int id, Clientes cliente);
    Task<bool> DeleteAsync(int id);
}