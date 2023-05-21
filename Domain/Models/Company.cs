using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("companies")]
    public class Company : BaseEntity
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("email_address")]
        public string? EmailAddress { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("balance")]
        public double Balance { get; set; }

        [Column("debt")]
        public double Debt { get; set; }

        [Column("tariff")]
        public double Tariff { get; set; }

        [Column("company_owner_id")]
        public Guid CompanyOwnerId { get; set; }
    }
}
