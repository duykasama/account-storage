using AccountStorage.Clients.WebClients.Enums;
using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.CategoryStore.Actions;
using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using AccountStorage.Service.Services.Interfaces;

namespace AccountStorage.Clients.WebClients.Flux.Stores.CategoryStore
{
    public class CategoryStore : StoreBase<ICollection<Category>, IAction>
    {
        private Action _stateChangeListeners;
        private IActionDispatcher<IAction> _actionDispatcher;
        private State<ICollection<Category>> _state;
        private ICategoryService _categoryService;

        public CategoryStore(IActionDispatcher<IAction> actionDispatcher, ICategoryService categoryService)
        {
            _actionDispatcher = actionDispatcher;
            _actionDispatcher.Subscribe(HandleActions);
            _state = new State<ICollection<Category>>(new List<Category>(), Status.NONE);
            //_categoryService = new CategoryService();
            _categoryService = categoryService;
        }

        public override void AddStateChangeListener(Action listener) => _stateChangeListeners += listener;

        public override void BroadcastStateChange() => _stateChangeListeners?.Invoke();

        public override State<ICollection<Category>> GetState() => _state;

        public override void RemoveStateChangeListener(Action listener) => _stateChangeListeners -= listener;

        protected override async void HandleActions(IAction action)
        {
            switch (action)
            {
                case LoadCategoriesAction:
                    await LoadCategories();
                    break;
                case LoadCategoryByIdAction:
                    LoadCategoryById(action.Target as string);
                    break;
                default:
                    return;
            }  
            BroadcastStateChange();
        }

        private async Task LoadCategories() 
        {
            try
            {
                _state = new State<ICollection<Category>>(await _categoryService.GetCategoriesAsync(), Status.SUCCESS);
            }
            catch 
            {
                _state = new State<ICollection<Category>>(_state.Value, Status.FAILURE);
            }
        }

        private void LoadCategoryById(string id)
        {
            try
            {
                var categories = new List<Category>() { _state.Value.First(c => c.Id == id) };
                _state = new State<ICollection<Category>>(categories, Status.SUCCESS);
            }
            catch
            {
                _state = new State<ICollection<Category>>(_state.Value, Status.FAILURE);

            }
        }
    }
}
