using AccountStorage.Clients.WebClients.Enums;
using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using AccountStorage.Service.Services.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.AccountStore
{
    public class AccountStore : StoreBase<ICollection<Account>, IAction>
    {
        private IAccountService _accountService;

        private Action _registeredListeners;
        private IActionDispatcher<IAction> _dispatcher;
        private State<ICollection<Account>> _state;

        public AccountStore(IActionDispatcher<IAction> actionDispatcher)
        {
            _dispatcher = actionDispatcher;
            _dispatcher.Subscribe(HandleActions);
            _state = new State<ICollection<Account>>(new List<Account>(), Status.NONE);
            _accountService = new AccountService();
        }

        public override State<ICollection<Account>> GetState() => _state;

        public override void AddStateChangeListener(Action listener) => _registeredListeners += listener;

        public override void RemoveStateChangeListener(Action listener) => _registeredListeners -= listener;

        public override void BroadcastStateChange() => _registeredListeners?.Invoke();

        protected override void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadAccountsAction:
                    LoadAccounts();
                    break;
                case AddAccountAction:
                    AddAccount(action.Target as Account);
                    break;
                case DeleteAccountAction:
                    break;
                case UpdateAccountAction:
                    break;
                default:
                    return;
            }
        }

        private void LoadAccounts()
        {
            _state = new State<ICollection<Account>>(_accountService.GetAccountsAsync(), Status.NONE);
        }

        private void AddAccount(Account? target)
        {
            if (target is null)
            {
                _state = new State<ICollection<Account>>(_state.Value, Status.FAILURE);
                return;
            }

            if (_accountService.CreateAccount(target))
            {
                _state = new State<ICollection<Account>>(_accountService.GetAccountsAsync(), Status.SUCCESS);
            }
            else
            {
                _state = new State<ICollection<Account>>(_state.Value, Status.FAILURE);
            }
        }
    }
}
