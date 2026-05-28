namespace PC12410038324100803.CORE.core.Entities;

public class Ordenservicio
{
    public int Id { get; set; }
    public DateTime Fechaingreso { get; set; }
    public string? Descripcionproblema { get; set; }
    public decimal? Costoestimado { get; set; }
    public string? Estado { get; set; }
    public int Vehiculoid { get; set; }
    public int Tiposervicioid { get; set; }

    public Vehiculo Vehiculo { get; set; } = null!;
    public TipoServicio TipoServicio { get; set; } = null!;
}
