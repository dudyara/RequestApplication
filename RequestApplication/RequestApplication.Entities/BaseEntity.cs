using System.ComponentModel.DataAnnotations;

namespace RequestApplication.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
    }
}
