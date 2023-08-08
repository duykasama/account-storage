using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CounterStore.Actions
{
    public class LoadAction : IAction
    {
        private const string LOAD_ACTION = "LOAD_ACTION";

        public string Name => LOAD_ACTION;

        public object? Target => null;
    }
}
