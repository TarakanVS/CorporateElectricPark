using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table ("drivers")]
    public class Driver : BaseEntity
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("email_address")]
        public string? EmailAddress { get; set; }

        [Column("company_id")]
        public Guid CompanyId { get; set; }

        [Column("car_id")]
        public Guid CarId { get; set; }
    }
}
