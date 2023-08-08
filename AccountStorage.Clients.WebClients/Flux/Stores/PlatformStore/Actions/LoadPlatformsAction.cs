using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.PlatformStore.Actions
{
    public class LoadPlatformsAction : IAction
    {
        private const string LOAD_PLATFORMS = "LOAD_PLATFORMS";
        private Platform? target;

        public LoadPlatformsAction(Platform? target)
        {
            this.target = target;
        }

        public string Name => LOAD_PLATFORMS;

        public object? Target => target;
    }
}
