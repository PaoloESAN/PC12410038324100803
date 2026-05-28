using PC12410038324100803.CORE.core.Entities;

namespace PC12410038324100803.CORE.core.Interfaces;

public interface IOrdenservicioRepository
{
    Task<IEnumerable<Ordenservicio>> GetAll();
    Task<Ordenservicio?> GetById(int id);
    Task Create(Ordenservicio ordenservicio);
    Task Update(Ordenservicio ordenservicio);
    Task Delete(int id);
}
