namespace PC12410038324100803.CORE.core.Entities;

public class Vehiculo
{
    public int Id { get; set; }
    public string Placa { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public int? Anio { get; set; }
    public int Clienteid { get; set; }

    public Cliente Cliente { get; set; } = null!;
    public ICollection<Ordenservicio> Ordenservicios { get; set; } = new List<Ordenservicio>();
}
