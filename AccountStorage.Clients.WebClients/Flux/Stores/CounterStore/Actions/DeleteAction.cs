using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CounterStore.Actions
{
    public class DeleteAction : IAction
    {
        private const string DELETE_ACTION = "DELETE_ACTION";

        public string Name => DELETE_ACTION;

        public object? Target => null;
    }
}
