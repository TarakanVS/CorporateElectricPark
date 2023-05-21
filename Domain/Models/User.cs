using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    abstract public class User : BaseEntity
    {
        [Column("password")]
        public string? Password { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column ("name")]
        public string? Name { get;  set; }

        [Column("email_address")]
        public string? EmailAddress { get; set; }
    }
}
