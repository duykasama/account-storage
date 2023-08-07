using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Interfaces
{
    public interface IAction
    {
        public string Name { get; }
        public Account Target { get; }
    }
}
