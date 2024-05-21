
namespace Client.Persistence.Domain.PublicArea.Model;

public sealed class PublicArea
{
    public int Id { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }
    public string? Address { get; set; }
}
