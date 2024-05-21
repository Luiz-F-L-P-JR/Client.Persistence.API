

namespace Client.Persistence.Domain.Client.Model
{
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
    }
}
