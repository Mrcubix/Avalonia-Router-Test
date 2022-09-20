using System;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace router_test.ViewModels
{
    public interface PagedViewModelBase
    {
        public int PageNumber { get; set; }
        public int Count { get; set; }
        public ObservableCollection<Example> CurrentItemList { get; set; }
        public void NextPage();
        public void PreviousPage();
        public string GetPageName();
    }
}
