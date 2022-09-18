namespace router_test.ViewModels
{
    public interface PagedViewModelBase
    {
        public int PageNumber { get; }

        public string GetPageName();
    }
}
