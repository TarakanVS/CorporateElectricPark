using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    abstract public class User : BaseEntity
    {
        [Column("password")]
        public string? Password { get; protected set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; protected set; }

        [Column ("name")]
        public string? Name { get; protected set; }

        [Column("email_address")]
        public string? EmailAddress { get; protected set; }
    }
}
