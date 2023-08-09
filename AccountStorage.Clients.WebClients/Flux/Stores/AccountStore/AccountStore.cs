﻿using AccountStorage.Clients.WebClients.Enums;
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

        public AccountStore(IActionDispatcher<IAction> actionDispatcher, IAccountService accountService)
        {
            _dispatcher = actionDispatcher;
            _dispatcher.Subscribe(HandleActions);
            _state = new State<ICollection<Account>>(new List<Account>(), Status.NONE);
            //_accountService = new AccountService();
            _accountService = accountService;
        }

        public override State<ICollection<Account>> GetState() => _state;

        public override void AddStateChangeListener(Action listener) => _registeredListeners += listener;

        public override void RemoveStateChangeListener(Action listener) => _registeredListeners -= listener;

        public override void BroadcastStateChange() => _registeredListeners?.Invoke();

        protected override async void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadAccountsAction:
                    await LoadAccounts();
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
            BroadcastStateChange();
        }

        private async Task LoadAccounts()
        {
            var accounts = await _accountService.GetAccountsAsync();
            //accounts = _accountService.GetAccounts();
            _state = new State<ICollection<Account>>(accounts, Status.NONE);
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
                _state = new State<ICollection<Account>>(_accountService.GetAccounts(), Status.SUCCESS);
            }
            else
            {
                _state = new State<ICollection<Account>>(_state.Value, Status.FAILURE);
            }
        }
    }
}
