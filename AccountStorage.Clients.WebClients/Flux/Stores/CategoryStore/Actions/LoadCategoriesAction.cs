using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Service.Entities;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CategoryStore.Actions
{
    public class LoadCategoriesAction : IAction
    {
        private const string LOAD_CATEGORIES = "LOAD_CATEGORIES";
        private Category target;

        public LoadCategoriesAction(Category? target)
        {
            this.target = target;
        }

        public string Name => LOAD_CATEGORIES;

        public object? Target => target;
    }
}
