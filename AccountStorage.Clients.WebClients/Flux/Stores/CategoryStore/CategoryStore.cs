using AccountStorage.Clients.WebClients.Enums;
using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.CategoryStore.Actions;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CategoryStore
{
    public class CategoryStore : StoreBase<ICollection<Category>, IAction>
    {
        private Action _stateChangeListeners;
        private IActionDispatcher<IAction> _actionDispatcher;
        private State<ICollection<Category>> _state;
        private CategoryService _categoryService;

        public CategoryStore(IActionDispatcher<IAction> actionDispatcher)
        {
            _actionDispatcher = actionDispatcher;
            _actionDispatcher.Subscribe(HandleActions);
            _state = new State<ICollection<Category>>(new List<Category>(), Status.NONE);
            _categoryService = new CategoryService();
        }

        public override void AddStateChangeListener(Action listener) => _stateChangeListeners += listener;

        public override void BroadcastStateChange() => _stateChangeListeners?.Invoke();

        public override State<ICollection<Category>> GetState() => _state;

        public override void RemoveStateChangeListener(Action listener) => _stateChangeListeners -= listener;

        protected override void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadCategoriesAction:
                    LoadCategories();
                    break;
                default:
                    break;
            }  
            BroadcastStateChange();
        }

        private void LoadCategories() 
        {
            try
            {
                _state = new State<ICollection<Category>>(_categoryService.GetCategories(), Status.SUCCESS);
            }
            catch 
            {
                _state = new State<ICollection<Category>>(_state.Value, Status.FAILURE);
            }
        }
    }
}
