using AccountStorage.Clients.WebClients.Flux.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Dispatcher
{
    public class ActionDispatcher : IActionDispatcher
    {
        private Action<IAction> _registeredHandlers;

        public void Dispatch(IAction action) => _registeredHandlers?.Invoke(action);

        public void Subscribe(Action<IAction> action) => _registeredHandlers += action;

        public void Unsubscribe(Action<IAction> action) => _registeredHandlers -= action;
    }
}
