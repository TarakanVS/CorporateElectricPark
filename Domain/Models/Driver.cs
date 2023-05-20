using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table ("drivers")]
    public class Driver : User
    {
        [Column("company_id")]
        public Guid CompanyId { get; set; }

        [Column("car_id")]
        public Guid CarId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Car Car { get; set; }

        public virtual ICollection<ChargeSession> ChargeSessions { get; set; }
    }
}
