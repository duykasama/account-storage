using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace AccountStorage.Service.Entities
{
    public class SystemUser : IdentityUser
    {
        public string? Gender { get; set; }
     
        public DateTime? DateOfBirth { get; set; }

        public DateTime JoinDate { get; set; } = DateTime.UtcNow;   

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
