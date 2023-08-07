using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CounterStore.Actions
{
    public class IncrementCount : IAction
    {
        private const string INCREMENT_COUNT = "INCREMENT_COUNT";

        public string Name => INCREMENT_COUNT;

        public Account Target => null;
    }
}
