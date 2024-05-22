
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Persistence.Domain.PublicArea.Model;

[Table("PublicArea")]
public sealed class PublicArea
{
    public int Id { get; set; }
    public int IdCliente { get; set; }

    public string? City { get; set; }
    public string? State { get; set; }
    public string? Address { get; set; }
    public string? Neighborhood { get; set; }

    public PublicArea()
    {
        
    }

    public PublicArea(PublicArea publicArea)
    {
        Id = publicArea.Id;
        City = publicArea.City;
        State = publicArea.State;
        Address = publicArea.Address;
        IdCliente = publicArea.IdCliente;
        Neighborhood = publicArea.Neighborhood;
    }
}
