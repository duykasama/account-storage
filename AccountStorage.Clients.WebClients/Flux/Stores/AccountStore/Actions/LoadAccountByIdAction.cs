using AccountStorage.Clients.WebClients.Flux.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions
{
    public class LoadAccountByIdAction : IAction
    {
        private const string LOAD_ACCOUNT_BY_ID = "LOAD_ACCOUNT_BY_ID";
        private string _accountId;

        public LoadAccountByIdAction(string accountId)
        {
            _accountId = accountId;
        }

        public string Name => LOAD_ACCOUNT_BY_ID;

        public object? Target => _accountId;
    }
}
