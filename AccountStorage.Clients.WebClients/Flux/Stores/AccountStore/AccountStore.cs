using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using AccountStorage.Service.Services.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.AccountStore
{
    public class AccountStore : StoreBase<ICollection<Account>>
    {
        private Action _registeredListeners;
        private IActionDispatcher _dispatcher;
        private State<ICollection<Account>> _state;
        private IAccountService _accountService;

        public AccountStore(IActionDispatcher dispatcher)
        {
            _state = new State<ICollection<Account>>(new List<Account>());
            _accountService = new AccountService();
            _dispatcher = dispatcher;
            _dispatcher.Subscribe(HandleActions);
        }

        public override State<ICollection<Account>> GetState() => _state;

        public override void AddStateChangeListener(Action listener) => _registeredListeners += listener;

        public override void RemoveStateChangeListener(Action listener) => _registeredListeners -= listener;

        protected override void BroadcastStateChange() => _registeredListeners?.Invoke();

        protected override async void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadAccountsAction:
                    await LoadAccounts();
                    break;
                case AddAccountAction: 
                    break;
                case DeleteAccountAction: 
                    break;
                case UpdateAccountAction:
                    break;
                default: 
                    break;
            }
            BroadcastStateChange();
        }

        private async Task LoadAccounts()
        {
            _state = new State<ICollection<Account>>(await _accountService.GetAccountsAsync());
        }
    }
}
