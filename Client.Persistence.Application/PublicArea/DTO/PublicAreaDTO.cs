namespace Client.Persistence.Application.PublicArea.DTO;

public sealed class PublicAreaDTO
{
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }
    public string? Address { get; set; }

    public PublicAreaDTO()
    {
        
    }

    public PublicAreaDTO(PublicAreaDTO dto)
    {
        State = dto.State;
        City = dto.City;
        Neighborhood = dto.Neighborhood;
        Address = dto.Address;
    }
}
