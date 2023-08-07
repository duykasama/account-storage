using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions
{
    public class LoadAccountsAction : IAction
    {
        private const string LOAD_ACCOUNTS = "LOAD_ACCOUNTS";
        private readonly Account target;

        public LoadAccountsAction(Account target)
        {
            this.target = target;
        }

        public string Name => LOAD_ACCOUNTS;

        public Account Target => target;
    }
}
