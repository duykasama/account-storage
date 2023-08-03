using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStorage.Service.Entities
{
    public class Platform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Url { get; set; }
    }
}
