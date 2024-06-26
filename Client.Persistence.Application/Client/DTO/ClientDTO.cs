﻿using Client.Persistence.Application.PublicArea.DTO;
using System.Text.Json.Serialization;

namespace Client.Persistence.Application.Client.DTO;

public sealed class ClientDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Logo { get; set; }
    public IList<PublicAreaDTO>? PublicAreas { get; set; }

    public ClientDTO()
    {
        PublicAreas = new List<PublicAreaDTO>();
    }

    public ClientDTO(ClientDTO dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Email = dto.Email;
        Logo = dto.Logo;
        PublicAreas = dto.PublicAreas;
    }
}
