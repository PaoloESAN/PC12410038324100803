using Microsoft.EntityFrameworkCore;
using PC12410038324100803.CORE.core.Entities;
using PC12410038324100803.CORE.core.Interfaces;
using InfraData = PC12410038324100803.CORE.infrastructure.Data;

namespace PC12410038324100803.CORE.infrastructure.Repositories;

public class OrdenservicioRepository : IOrdenservicioRepository
{
    private readonly InfraData.DbContext _context;

    public OrdenservicioRepository(InfraData.DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ordenservicio>> GetAll()
    {
        return await _context.Ordenservicio
            .Include(o => o.Vehiculo)
            .Include(o => o.TipoServicio)
            .ToListAsync();
    }

    public async Task<Ordenservicio?> GetById(int id)
    {
        return await _context.Ordenservicio
            .Include(o => o.Vehiculo)
            .Include(o => o.TipoServicio)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task Create(Ordenservicio ordenservicio)
    {
        _context.Ordenservicio.Add(ordenservicio);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Ordenservicio ordenservicio)
    {
        var existing = await _context.Ordenservicio.FindAsync(ordenservicio.Id);
        if (existing != null)
        {
            existing.Fechaingreso = ordenservicio.Fechaingreso;
            existing.Descripcionproblema = ordenservicio.Descripcionproblema;
            existing.Costoestimado = ordenservicio.Costoestimado;
            existing.Estado = ordenservicio.Estado;
            existing.Vehiculoid = ordenservicio.Vehiculoid;
            existing.Tiposervicioid = ordenservicio.Tiposervicioid;
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var existing = await _context.Ordenservicio.FindAsync(id);
        if (existing != null)
        {
            _context.Ordenservicio.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
