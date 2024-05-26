
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Persistence.Domain.PublicArea.Model;

[Table("PublicArea")]
public sealed class PublicArea
{
    /// <summary>
    /// Public Area identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Client identifier, used to identify the relationship between the public area and the client
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Public Area city
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Public Area state
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Public Area address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Public Area neighborhood
    /// </summary>
    public string? Neighborhood { get; set; }

    /// <summary>
    /// Public Area primary contructor
    /// </summary>
    public PublicArea()
    {
        
    }

    /// <summary>
    /// Public Area constructor with parameter
    /// </summary>
    /// <param name="publicArea"> A pulic area to implement</param>
    public PublicArea(PublicArea publicArea)
    {
        Id = publicArea.Id;
        City = publicArea.City;
        State = publicArea.State;
        Address = publicArea.Address;
        ClientId = publicArea.ClientId;
        Neighborhood = publicArea.Neighborhood;
    }
}
