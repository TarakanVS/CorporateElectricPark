using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("carge_sessions")]
    public class ChargeSession : BaseEntity
    {
        [Column("session_number")]
        public string? SessionNumber { get; protected set; }

        [Column("energy_spent")]
        public float EnergySpent { get; protected set; }

        [Column("start_date_time")]
        public DateTime StartDateTime { get; protected set; }

        [Column("finish_date_time")]
        public DateTime FinishDateTime { get; protected set; }

        [Column("duration")]
        public TimeOnly Duration { get; protected set; }

        [Column("cost")]
        public double Cost { get; protected set; }

        [Column("debd")]
        public double Debt { get; protected set; }

        [Column("driver_id")]
        public Guid DriverId { get; set; }

        [Column("car_id")]
        public Guid CarId { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Car Car { get; set; }
    }
}
