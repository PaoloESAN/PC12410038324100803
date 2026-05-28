using PC12410038324100803.CORE.core.DTOs;

namespace PC12410038324100803.CORE.core.Interfaces;

public interface IOrdenServicioService
{
    Task<IEnumerable<OrdenservicioDTO>> GetAll();
    Task<OrdenservicioDTO?> GetById(int id);
    Task Create(OrdenservicioCreateDTO dto);
    Task Update(OrdenservicioUpdateDTO dto);
    Task Delete(int id);
}
