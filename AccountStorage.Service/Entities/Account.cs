using AccountStorage.Clients.WebClients.Flux.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStorage.Service.Entities
{
    public class Account : DbEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public string PlatformId { get; set; } = null!;
        
        [Required]
        public string Email { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
        
        [Required]
        public string AccountName { get; set; } = null!;

        [Required]
        public string CategoryId { get; set; } = null!;
        
        public DateTime CreationDate { get; set; }
        
        public DateTime LastModification { get; set; }

        public virtual SystemUser User { get; set; } = new SystemUser();

        public virtual Platform Platform { get; set; } = new Platform();

        public virtual Category Category { get; set; } = new Category();
    }
}
