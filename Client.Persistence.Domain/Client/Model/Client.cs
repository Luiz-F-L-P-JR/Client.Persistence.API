

using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Persistence.Domain.Client.Model
{
    [Table("Client")]
    public sealed class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Logo { get; set; }
        public IList<PublicArea.Model.PublicArea>? PublicAreas { get; set; }

        public Client()
        {
            PublicAreas = new List<PublicArea.Model.PublicArea>();
        }

        public Client(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Email = client.Email;
            Logo = client.Logo;
            PublicAreas = client.PublicAreas;
        }

        public Client(int id, string? name, string? email, string? logo, IList<PublicArea.Model.PublicArea>? publicAreas)
        {
            Id = id;
            Name = name;
            Email = email;
            Logo = logo;
            PublicAreas = publicAreas;
        }
    }
}
