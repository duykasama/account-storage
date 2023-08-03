using AccountStorage.Service.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStorage.Service.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string AccountName { get; set; } = null!;
        [Required]
        public Platform Platform { get; set; } = null!;
        [Required]
        public Category Category { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModification { get; set; }
    }
}
