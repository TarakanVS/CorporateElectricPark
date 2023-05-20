using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    abstract public class BaseEntity
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("update_date")]
        public DateTime UpdatedDate { get; set; }

        [Column("added_date")]
        public DateTime AddedDate { get; set; }
    }
}
