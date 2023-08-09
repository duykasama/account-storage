using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.SystemUserStore.Actions
{
    public class LoadCurrentSystemUserAction : IAction
    {
        private const string LOAD_CURRENT_SYSTEM_USER = "LOAD_CURRENT_SYSTEM_USER";
        private string? _id;

        public LoadCurrentSystemUserAction(string id)
        {
            _id = id;
        }

        public string Name => LOAD_CURRENT_SYSTEM_USER;

        public object? Target => _id;
    }
}
