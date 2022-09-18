using System.Collections.ObjectModel;
using ReactiveUI;

namespace router_test.ViewModels
{
    public class ListViewModel : ViewModelBase, PagedViewModelBase
    {
        public string ListViewText { get; } = "List View";
        // Just example items for test purposes 
        public Example[] ItemList { get; } = {new Example("Item 1"), new Example("Item 2"), new Example("Item 3"), new Example("Item 4"), new Example("Item 5"), new Example("Item 6"), new Example("Item 7"), new Example("Item 8"), new Example("Item 9"), new Example("Item 10"), new Example("Item 11"), new Example("Item 12"), new Example("Item 13"), new Example("Item 14"), new Example("Item 15"), new Example("Item 16"), new Example("Item 17"), new Example("Item 18")};
        private ObservableCollection<Example> currentItemList = new();
        public int PageNumber { get; set; } = 0;

        public ListViewModel(ViewRemote remote, int number)
        {
            this.PageNumber = number;
            Remote = remote;
            InitCurrentList();
        }

        public void InitCurrentList()
        {
            for (int i = 0; i < 10; i++)
            {
                CurrentItemList.Add(ItemList[i]);
            }
        }

        public void NextPage() 
        {
            if (ItemList.Length <= PageNumber * 10 + 10)
                return;

            PageNumber++;

            int start = PageNumber * 10;
            int end = start + 10 > ItemList.Length ? ItemList.Length : start + 10;
            int realEnd = start + 10;

            for (int i = start; i < realEnd; i++)
            {
                if (i >= end)
                {
                    CurrentItemList[i - start].Enabled = false;
                    continue;
                }

                CurrentItemList[i - start] = ItemList[i];
                CurrentItemList[i - start].Enabled = true;
            }
        }

        public void PreviousPage()
        {
            if (PageNumber == 0)
                return;

            PageNumber--;

            int start = PageNumber * 10;
            int end = start + 10 > ItemList.Length ? ItemList.Length : start + 10;

            for (int i = start; i < end; i++)
            {  
                CurrentItemList[i - start] = ItemList[i];
                currentItemList[i - start].Enabled = true;
            }
        }

        public string GetPageName()
        {
            return $"List-{PageNumber}";
        }

        public ObservableCollection<Example> CurrentItemList
        {
            get => currentItemList;
            set => this.RaiseAndSetIfChanged(ref currentItemList, value);
        }
    }

    public class Example : ReactiveObject
    {
        public string Name { get; }
        private bool enabled = true;
        public bool Enabled
        {
            get => enabled;
            set => this.RaiseAndSetIfChanged(ref enabled, value);
        }

        public Example(string name)
        {
            Name = name;
        }
    }
}
