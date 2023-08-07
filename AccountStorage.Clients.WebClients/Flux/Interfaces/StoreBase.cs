using AccountStorage.Clients.WebClients.Enums;

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

    public abstract class StoreBase<T>
    {
        public abstract void AddStateChangeListener(Action listener);
        public abstract void RemoveStateChangeListener(Action listener);
        protected abstract void BroadcastStateChange();
        protected abstract void HandleActions(IAction action);
        public abstract State<T> GetState();
    }
}
