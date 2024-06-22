
using Client.Persistence.Domain.AuthUser.AuthRoleEnumerable;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Persistence.Domain.UserAuth.Model
{
    [Table("User")]
    public sealed class User
    {
        /// <summary>
        /// User identifier
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        /// <value></value>
        public string? Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        /// <value></value>
        public string? Password { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        public AuthRoles? Role { get; set; }
    }
}
