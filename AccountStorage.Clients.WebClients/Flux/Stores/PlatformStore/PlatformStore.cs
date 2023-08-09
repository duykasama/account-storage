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

        public PlatformStore(IActionDispatcher<IAction> actionDispatcher, IPlatformService platformService)
        {
            _dispatcher = actionDispatcher;
            _dispatcher.Subscribe(HandleActions);
            _state = new State<ICollection<Platform>>(new List<Platform>(), Status.NONE);
            //_platformService = new PlatformService();
            _platformService = platformService;
        }


        public override void AddStateChangeListener(Action listener) => _registeredListeners += listener;

        public override void BroadcastStateChange() => _registeredListeners?.Invoke();

        public override State<ICollection<Platform>> GetState() => _state;

        public override void RemoveStateChangeListener(Action listener) => _registeredListeners -= listener;

        protected override async void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadPlatformsAction:
                    await LoadPlatforms();
                    break;
                case LoadPlatformByIdAction:
                    LoadPlatformById(action.Target as string);
                    break;
                default:
                    return;
            }
            BroadcastStateChange();
        }

        private async Task LoadPlatforms()
        {
            try
            {
                _state = new State<ICollection<Platform>>(await _platformService.GetPlatformsAsync(), Status.SUCCESS);
            }
            catch
            {
                _state = new State<ICollection<Platform>>(_state.Value, Status.FAILURE);
            }
        }

        private void LoadPlatformById(string id)
        {
            try
            {
                var platforms = new List<Platform>() { _state.Value.First(p => p.Id == id) };
                _state = new State<ICollection<Platform>>(platforms, Status.SUCCESS);
            }
            catch
            {
                _state = new State<ICollection<Platform>>(_state.Value, Status.FAILURE);
            }
        }
    }
}
