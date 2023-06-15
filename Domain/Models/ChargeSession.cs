using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("carge_sessions")]
    public class ChargeSession : BaseEntity
    {
        [Column("session_number")]
        public string? SessionNumber { get; set; }

        [Column("energy_spent")]
        public double EnergySpent { get; set; }

        [Column("start_date_time")]
        public DateTime StartDateTime { get; set; }

        [Column("finish_date_time")]
        public DateTime FinishDateTime { get; set; }

        [Column("duration")]
        public TimeOnly Duration { get; set; }

        [Column("cost")]
        public double Cost { get; set; }

        [Column("debd")]
        public double Debt { get; set; }

        [Column("driver_id")]
        public Guid DriverId { get; set; }

        [Column("car_id")]
        public Guid CarId { get; set; }

        [Column("company_id")]
        public Guid CompanyId { get; set; }
    }
}
