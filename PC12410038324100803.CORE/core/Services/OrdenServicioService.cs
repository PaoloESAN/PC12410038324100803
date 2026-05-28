using PC12410038324100803.CORE.core.DTOs;
using PC12410038324100803.CORE.core.Entities;
using PC12410038324100803.CORE.core.Interfaces;

namespace PC12410038324100803.CORE.core.Services;

public class OrdenServicioService : IOrdenServicioService
{
    private readonly IOrdenservicioRepository _repository;

    public OrdenServicioService(IOrdenservicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrdenservicioDTO>> GetAll()
    {
        var list = await _repository.GetAll();
        return list.Select(o => new OrdenservicioDTO
        {
            Id = o.Id,
            Fechaingreso = o.Fechaingreso,
            Descripcionproblema = o.Descripcionproblema,
            Costoestimado = o.Costoestimado,
            Estado = o.Estado,
            Vehiculoid = o.Vehiculoid,
            Tiposervicioid = o.Tiposervicioid
        });
    }

    public async Task<OrdenservicioDTO?> GetById(int id)
    {
        var o = await _repository.GetById(id);
        if (o == null) return null;

        return new OrdenservicioDTO
        {
            Id = o.Id,
            Fechaingreso = o.Fechaingreso,
            Descripcionproblema = o.Descripcionproblema,
            Costoestimado = o.Costoestimado,
            Estado = o.Estado,
            Vehiculoid = o.Vehiculoid,
            Tiposervicioid = o.Tiposervicioid
        };
    }

    public async Task Create(OrdenservicioCreateDTO dto)
    {
        var entity = new Ordenservicio
        {
            Fechaingreso = dto.Fechaingreso,
            Descripcionproblema = dto.Descripcionproblema,
            Costoestimado = dto.Costoestimado,
            Estado = dto.Estado,
            Vehiculoid = dto.Vehiculoid,
            Tiposervicioid = dto.Tiposervicioid
        };
        await _repository.Create(entity);
    }

    public async Task Update(OrdenservicioUpdateDTO dto)
    {
        var entity = new Ordenservicio
        {
            Id = dto.Id,
            Fechaingreso = dto.Fechaingreso,
            Descripcionproblema = dto.Descripcionproblema,
            Costoestimado = dto.Costoestimado,
            Estado = dto.Estado,
            Vehiculoid = dto.Vehiculoid,
            Tiposervicioid = dto.Tiposervicioid
        };
        await _repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}
