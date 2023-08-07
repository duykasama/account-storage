namespace AccountStorage.Clients.WebClients.Flux.Interfaces
{
    public class State<T>
    {
        public T Value { get; }
        public State(T value)
        {
            Value = value;
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
