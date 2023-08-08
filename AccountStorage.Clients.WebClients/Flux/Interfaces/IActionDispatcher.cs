namespace AccountStorage.Clients.WebClients.Flux.Interfaces
{
    public interface IActionDispatcher<T>
    {
        void Dispatch(T action);
        void Subscribe(Action<T> action);
        void Unsubscribe(Action<T> action);
    }
}
