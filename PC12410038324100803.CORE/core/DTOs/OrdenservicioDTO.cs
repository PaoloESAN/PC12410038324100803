namespace PC12410038324100803.CORE.core.DTOs;

public class OrdenservicioDTO
{
    public int Id { get; set; }
    public DateTime Fechaingreso { get; set; }
    public string? Descripcionproblema { get; set; }
    public decimal? Costoestimado { get; set; }
    public string? Estado { get; set; }
    public int Vehiculoid { get; set; }
    public int Tiposervicioid { get; set; }
}

public class OrdenservicioCreateDTO
{
    public DateTime Fechaingreso { get; set; }
    public string? Descripcionproblema { get; set; }
    public decimal? Costoestimado { get; set; }
    public string? Estado { get; set; }
    public int Vehiculoid { get; set; }
    public int Tiposervicioid { get; set; }
}

public class OrdenservicioUpdateDTO
{
    public int Id { get; set; }
    public DateTime Fechaingreso { get; set; }
    public string? Descripcionproblema { get; set; }
    public decimal? Costoestimado { get; set; }
    public string? Estado { get; set; }
    public int Vehiculoid { get; set; }
    public int Tiposervicioid { get; set; }
}
