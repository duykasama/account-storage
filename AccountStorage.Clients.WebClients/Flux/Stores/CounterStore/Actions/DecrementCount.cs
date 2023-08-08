using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CounterStore.Actions
{
    public class DecrementCount : IAction
    {
        private const string DECREMENT_COUNT = "DECREMENT_COUNT";

        public string Name => DECREMENT_COUNT;

        public object? Target => null;
    }
}
