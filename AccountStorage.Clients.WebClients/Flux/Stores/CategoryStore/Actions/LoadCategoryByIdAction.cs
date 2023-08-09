using AccountStorage.Clients.WebClients.Flux.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CategoryStore.Actions
{
    public class LoadCategoryByIdAction : IAction
    {
        private const string LOAD_CATEGORY_BY_ID_ACTION = "LOAD_CATEGORY_BY_ID_ACTION";
        private string _id;

        public LoadCategoryByIdAction(string id)
        {
            _id = id;
        }

        public string Name => LOAD_CATEGORY_BY_ID_ACTION;

        public object? Target => _id;
    }
}
