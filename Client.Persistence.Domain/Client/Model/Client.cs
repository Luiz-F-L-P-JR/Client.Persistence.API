

using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Persistence.Domain.Client.Model
{
    [Table("Client")]
    public sealed class Client
    {
        /// <summary>
        /// Client identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Client name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Client email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Client logo
        /// </summary>
        public string? Logo { get; set; }

        /// <summary>
        /// List of public areas of the client
        /// </summary>
        public IList<PublicArea.Model.PublicArea>? PublicAreas { get; set; }

        /// <summary>
        /// Client primary contructor
        /// </summary>
        public Client()
        {
            PublicAreas = new List<PublicArea.Model.PublicArea>();
        }

        /// <summary>
        /// Client constructor with parameter
        /// </summary>
        /// <param name="publicArea"> A pulic area to implement</param>
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
