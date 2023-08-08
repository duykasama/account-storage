using AccountStorage.Clients.WebClients.Enums;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Interfaces
{
    public class State<T>
    {
        public T Value { get; }
        public Status Status { get; }
        public State(T value, Status status)
        {
            Value = value;
            Status = status;
        }
    }

    public abstract class StoreBase<T1, T2>
    {
        //protected abstract Action _registeredListeners { get; set; }
        //protected abstract IActionDispatcher<T2> _dispatcher { get; set; }
        //protected abstract State<T1> _state { get; set; }

        public abstract void AddStateChangeListener(Action listener);
        public abstract void RemoveStateChangeListener(Action listener);
        public abstract void BroadcastStateChange();
        protected abstract void HandleActions(T2 action);
        public abstract State<T1> GetState();
    }
}
