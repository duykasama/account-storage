using AccountStorage.Clients.WebClients.Flux.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions
{
    public class LoadAccountsByUserIdAction : IAction
    {
        private const string LOAD_ACCOUNTS_BY_USER_ID = "LOAD_ACCOUNTS_BY_USER_ID";
        private string _userId;

        public LoadAccountsByUserIdAction(string userId)
        {
            _userId = userId;
        }

        public string Name => LOAD_ACCOUNTS_BY_USER_ID;

        public object? Target => _userId;
    }
}
