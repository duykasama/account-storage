using AccountStorage.Clients.WebClients.Flux.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.PlatformStore.Actions
{
    public class LoadPlatformByIdAction : IAction
    {
        private const string LOAD_PLATFORM_BY_ID = "LOAD_PLATFORM_BY_ID";
        private string _id;

        public LoadPlatformByIdAction(string id)
        {
                _id = id;
        }
        public string Name => LOAD_PLATFORM_BY_ID;

        public object? Target => _id;
    }
}
