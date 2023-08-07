using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStorage.Service.Entities
{
    public class Platform
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsVerified { get; set; } = false;
        
        public string? Url { get; set; }
        
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
