using AccountStorage.Clients.WebClients.Enums;
using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using AccountStorage.Service.Services;
using AccountStorage.Clients.WebClients.Flux.Stores.SystemUserStore.Actions;

namespace AccountStorage.Clients.WebClients.Flux.Stores.SystemUserStore
{
    public class SystemUserStore : StoreBase<ICollection<SystemUser>, IAction>
    {
        private Action _registeredListeners;
        private IActionDispatcher<IAction> _dispatcher;
        private State<ICollection<SystemUser>> _state;
        private ISystemUserService _systemUserService;

        public SystemUserStore(IActionDispatcher<IAction> actionDispatcher, ISystemUserService systemUserService)
        {
            _dispatcher = actionDispatcher;
            _dispatcher.Subscribe(HandleActions);
            _state = new State<ICollection<SystemUser>>(new List<SystemUser>(), Status.NONE);
            //_systemUserService = new SystemUserService();
            _systemUserService = systemUserService;
        }

        public override void AddStateChangeListener(Action listener) => _registeredListeners += listener;

        public override void BroadcastStateChange() => _registeredListeners?.Invoke();

        public override State<ICollection<SystemUser>> GetState() => _state;

        public override void RemoveStateChangeListener(Action listener) => _registeredListeners -= listener;

        protected override async void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadCurrentSystemUserAction:
                    await LoadCurrentSystemUser(action.Target as string);
                    break;
                default:
                    return;
            }
            BroadcastStateChange();
        }

        private async Task LoadCurrentSystemUser(string id)
        {
            try
            {
                var users = new List<SystemUser>() { await _systemUserService.GetSystemUserByIdAsync(id) };
                _state = new State<ICollection<SystemUser>>(users, Status.SUCCESS);
            }
            catch
            {
                _state = new State<ICollection<SystemUser>>(_state.Value, Status.FAILURE);
            }
        }
    }
}
