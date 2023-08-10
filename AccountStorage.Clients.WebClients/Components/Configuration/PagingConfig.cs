namespace AccountStorage.Clients.WebClients.Components.Configuration
{
    public class PagingConfig
    {
        public bool Enabled { get; set; }

        public int PageSize { get; set; }

        public bool UseCustomPager { get; set; }

        public int NumberOfItemsToSkip(int pageNumber) => Enabled ? (pageNumber - 1) * PageSize : 0;

        public int NumberOfItemsToTake(int totalItemsCount) => Enabled ? PageSize : totalItemsCount;

        public int PreviousPageNumber(int currentPageNumber) => (currentPageNumber > 1) ? currentPageNumber - 1 : 1;

        public int NextPageNumber(int currentPageNumber, int totalItemsCount) => (currentPageNumber < LastPage(totalItemsCount)) ? currentPageNumber + 1 : currentPageNumber;

        public int LastPage(int totalItemsCount) => int.Parse(Math.Ceiling((double)totalItemsCount / (double)PageSize).ToString());

    }
}
