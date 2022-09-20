using System.Collections.ObjectModel;
using ReactiveUI;

namespace router_test.ViewModels
{
    public class ViewRemote : ReactiveObject
    {
        private ViewModelBase currentViewModel;
        private ObservableCollection<string> viewModelNames = new();
        private ObservableCollection<ViewModelBase> viewModels = new();

        public ViewRemote() {}

        public ViewRemote(ViewModelBase initialVM)
        {
            currentViewModel = initialVM;
        }

        public ViewModelBase CurrentViewModel 
        { 
            get => currentViewModel;
            set => this.RaiseAndSetIfChanged(ref currentViewModel, value);
        }

        private ObservableCollection<string> ViewModelNames 
        { 
            get => viewModelNames;
            set => this.RaiseAndSetIfChanged(ref viewModelNames, value);
        }

        public ObservableCollection<ViewModelBase> ViewModels 
        { 
            get => viewModels;
            set => this.RaiseAndSetIfChanged(ref viewModels, value);
        }

        public void AddVM(ViewModelBase vm)
        {

            if (vm is PagedViewModelBase pagedVM)
            {
                if (viewModelNames.Contains(pagedVM.GetPageName()))
                    return;
                
                ViewModelNames.Add(pagedVM.GetPageName());
            }
            else
            {
                if (viewModelNames.Contains(vm.GetType().Name))
                    return;

                ViewModelNames.Add(vm.GetType().Name);
            }
            
            ViewModels.Add(vm);

            if (CurrentViewModel == null)
                CurrentViewModel = vm;
        }

        public void AddVM(ViewModelBase vm, string name)
        {
            ViewModels.Add(vm);
            ViewModelNames.Add(name);

            if (CurrentViewModel == null)
                CurrentViewModel = vm;
        }

        public void RemoveVM(ViewModelBase vm)
        {
            ViewModels.Remove(vm);

            if (vm is PagedViewModelBase pagedVM)
            {
                ViewModelNames.Remove(pagedVM.GetPageName());
            }
            else
            {
                ViewModelNames.Remove(vm.GetType().Name);
            }
        }

        public void RemoveVMByName(string name)
        {
            ViewModels.Remove(ViewModels[ViewModelNames.IndexOf(name)]);
            ViewModelNames.Remove(name);
        }

        public bool ShowView(string viewName)
        {
            for(int i = 0; i < viewModelNames.Count; i++)
            {
                if (viewModelNames[i] == viewName)
                {
                    CurrentViewModel = viewModels[i];
                    return true;
                }
            }
            return false;
        }
    }
}
