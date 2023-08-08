using AccountStorage.Clients.WebClients.Flux.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStorage.Service.Entities
{
    public class Category : DbEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string  Name { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = new Collection<Account>();
    }
}
