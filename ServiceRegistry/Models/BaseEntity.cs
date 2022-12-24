using System.ComponentModel.DataAnnotations;

namespace ServiceRegistry.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
