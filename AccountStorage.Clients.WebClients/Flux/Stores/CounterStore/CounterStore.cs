using AccountStorage.Clients.WebClients.Enums;
using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.CounterStore.Actions;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CounterStore
{
    public class CounterService
    {
        private List<int> MyList { get; }
        public CounterService()
        {
            MyList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            };
        }

        public List<int> Load()
        {
            return MyList;
        }

        public List<int> Delete(int i)
        {
            MyList.Remove(i);
            return MyList;
        }
    }

    public class CounterStore : StoreBase<List<int>, IAction>
    {
        //protected override Action _registeredListeners { get => _registeredListeners; set => _registeredListeners = value; }
        //protected override IActionDispatcher<IAction> _dispatcher { get => _dispatcher; set => _dispatcher = value; }
        //protected override State<List<int>> _state { get => _state; set => _state = value; }

        private Action _registeredListeners;
        private IActionDispatcher<IAction> _dispatcher;
        private State<List<int>> _state;

        private CounterService _counterService;

        public CounterStore(IActionDispatcher<IAction> actionDispatcher)
        {
            _dispatcher = actionDispatcher;
            _dispatcher.Subscribe(HandleActions);
            _state = new State<List<int>>(new List<int>(), Status.NONE);
            _counterService = new CounterService();
        }

        public override void AddStateChangeListener(Action listener) => _registeredListeners += listener;

        public override State<List<int>> GetState() => _state;

        public override void RemoveStateChangeListener(Action listener) => _registeredListeners -= listener;

        public override void BroadcastStateChange() => _registeredListeners?.Invoke();

        protected override void HandleActions(IAction action)
        {
            switch(action)
            {
                case IncrementCount:
                    //IncreaseCount();
                    break;
                case DecrementCount:
                    //DecreaseCount();
                    break;
                case LoadAction:
                    LoadAsync();
                    break;
                case DeleteAction:
                    DeleteAsync(4);
                    break;
                default:
                    return;
            }
            BroadcastStateChange();
        }

        //private void IncreaseCount()
        //{
        //    _state = new State<int>(_state.Value + 1);
        //}
        
        //private void DecreaseCount()
        //{
        //    _state = new State<int>(_state.Value - 1);
        //}

        private void LoadAsync()
        {
            _state = new State<List<int>>(_counterService.Load(), Status.NONE);
        }
        
        private void DeleteAsync(int i)
        {
            _state = new State<List<int>>(_counterService.Delete(i), Status.NONE);
        }
    }
}
