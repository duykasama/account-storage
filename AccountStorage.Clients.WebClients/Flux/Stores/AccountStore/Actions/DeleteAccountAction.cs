using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;
using Microsoft.IdentityModel.Tokens;

namespace AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions
{
    public class DeleteAccountAction : IAction
    {
        private const string DELETE_ACCOUNT = "DELETE_ACCOUNT";
        private Account _target;

        public DeleteAccountAction(Account target)
        {
            _target = target;
        }

        public string Name => DELETE_ACCOUNT;

        public object? Target => _target;
    }
}
