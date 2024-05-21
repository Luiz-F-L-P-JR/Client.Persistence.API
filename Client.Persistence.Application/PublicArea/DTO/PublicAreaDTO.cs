﻿namespace Client.Persistence.Application.PublicArea.DTO;

public sealed class PublicAreaDTO
{
    public int Id { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Neighborhood { get; set; }
    public string? Address { get; set; }

    public PublicAreaDTO()
    {
        
    }

    public PublicAreaDTO(PublicAreaDTO dto)
    {
        Id = dto.Id;
        City = dto.City;
        State = dto.State;
        Address = dto.Address;
        Neighborhood = dto.Neighborhood;
    }
}
