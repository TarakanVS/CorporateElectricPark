using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("companies")]
    public class Company : BaseEntity
    {
        [Column("name")]
        public string? Name { get; protected set; }

        [Column("email_address")]
        public string? EmailAddress { get; protected set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; protected set; }

        [Column("balance")]
        public double Balance { get; protected set; }

        [Column("debt")]
        public double Debt { get; protected set; }

        [Column("tariff")]
        public double Tariff { get; protected set; }

        [Column("company_owner_id")]
        public Guid CompanyOwnerId { get; set; }

        public virtual CompanyOwner? CompanyOwner { get; set; }
        public virtual ICollection<Driver>? Drivers { get; set; }
        public virtual ICollection<Car>? Cars { get; set; }
    }
}
