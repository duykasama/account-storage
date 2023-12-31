﻿using AccountStorage.Clients.WebClients.Flux.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStorage.Service.Entities
{
    public class Platform : DbEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsVerified { get; set; } = false;
        
        public string? Url { get; set; }
        
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        public override string ToString() => Name;
    }
}
