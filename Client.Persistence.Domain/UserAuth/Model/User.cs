
using Client.Persistence.Domain.AuthUser.AuthRoleEnumerable;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Persistence.Domain.UserAuth.Model
{
    [Table("User")]
    public sealed class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public AuthRoles? Role { get; set; }
    }
}
