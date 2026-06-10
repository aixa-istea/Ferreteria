using Ferreteria.API.DTOs;

namespace Ferreteria.API.Services;

public interface IVentaService
{
    Task<IEnumerable<VentaDto>> GetAllAsync();
    Task<VentaDto?> GetByIdAsync(int id);
    Task<IEnumerable<VentaDto>> GetByFechaAsync(DateOnly desde, DateOnly hasta);
    Task<VentaDto> CreateAsync(CrearVentaDto dto);
    Task<bool> AnularAsync(int id);
}