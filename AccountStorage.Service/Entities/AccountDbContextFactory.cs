using Microsoft.EntityFrameworkCore.Design;

namespace AccountStorage.Service.Entities
{
    public class AccountDbContextFactory : IDesignTimeDbContextFactory<AccountDbContext>
    {
        public AccountDbContext CreateDbContext(string[] args)
        {
            return new AccountDbContext();
        }
    }
}
