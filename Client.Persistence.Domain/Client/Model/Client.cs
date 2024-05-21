
namespace Client.Persistence.Domain.Client.Model
{
    public sealed class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Logo { get; set; }
        public IList<PublicArea>? PublicAreas { get; set; }
    }
}
