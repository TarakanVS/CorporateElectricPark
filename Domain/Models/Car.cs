using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table ("cars")]
    public class Car : BaseEntity
    {
        [Column("number_plate")]
        public string? NumberPlate { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("tariff")]
        public double Tariff { get; set; }

        [Column("mileage")]
        public double Mileage { get; set; }


        [Column("company_id")]
        public Guid CompanyId { get; set; }

        [Column("driver_id")]
        public Guid DriverId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Driver Driver { get; set;}

        public virtual ICollection<ChargeSession> ChargeSessions { get; set; }
    }
}
