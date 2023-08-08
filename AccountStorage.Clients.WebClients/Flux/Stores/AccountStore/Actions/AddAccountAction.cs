using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions
{
    public class AddAccountAction : IAction
    {
        private const string ADD_ACCOUNT = "ADD_ACCOUNT";
        private Account target;

        public AddAccountAction(Account target)
        {
            this.target = target;
        }

        public string Name => ADD_ACCOUNT;

        public object? Target => target;
    }
}
