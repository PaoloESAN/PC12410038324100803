namespace PC12410038324100803.CORE.core.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Paterno { get; set; } = null!;
    public string? Materno { get; set; }
    public string Nombres { get; set; } = null!;
    public string? Correo { get; set; }
    public string? Telefono { get; set; }

    public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
