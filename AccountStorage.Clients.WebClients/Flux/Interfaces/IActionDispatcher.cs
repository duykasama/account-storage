namespace AccountStorage.Clients.WebClients.Flux.Interfaces
{
    public interface IActionDispatcher
    {
        void Dispatch(IAction action);
        void Subscribe(Action<IAction> action);
        void Unsubscribe(Action<IAction> action);
    }
}
