using AccountStorage.Clients.WebClients.Enums;
using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.PlatformStore.Actions;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using AccountStorage.Service.Services.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.PlatformStore
{
    public class PlatformStore : StoreBase<ICollection<Platform>, IAction>
    {
        private Action _registeredListeners;
        private IActionDispatcher<IAction> _dispatcher;
        private State<ICollection<Platform>> _state;
        private IPlatformService _platformService;

        public PlatformStore(IActionDispatcher<IAction> actionDispatcher)
        {
            _dispatcher = actionDispatcher;
            _dispatcher.Subscribe(HandleActions);
            _state = new State<ICollection<Platform>>(new List<Platform>(), Status.NONE);
            _platformService = new PlatformService();
        }


        public override void AddStateChangeListener(Action listener) => _registeredListeners += listener;

        public override void BroadcastStateChange() => _registeredListeners?.Invoke();

        public override State<ICollection<Platform>> GetState() => _state;

        public override void RemoveStateChangeListener(Action listener) => _registeredListeners -= listener;

        protected override void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadPlatformsAction:
                    LoadPlatforms();
                    break;
                default:
                    return;
            }
            BroadcastStateChange();
        }

        private void LoadPlatforms()
        {
            try
            {
                _state = new State<ICollection<Platform>>(_platformService.GetPlatforms(), Status.SUCCESS);
            }
            catch
            {
                _state = new State<ICollection<Platform>>(_state.Value, Status.FAILURE);
            }
        }
    }
}
