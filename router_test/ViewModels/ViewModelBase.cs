using ReactiveUI;

namespace router_test.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {

        private ViewRemote remote;

        public ViewRemote Remote
        {
            get => remote;
            set => this.RaiseAndSetIfChanged(ref remote, value);
        }
        
        public ViewModelBase()
        {
            remote = new();
        }

        public ViewModelBase(ViewModelBase initialVM) 
        {
            remote = new(initialVM);
        }

        public ViewModelBase(ViewRemote remote)
        {
            this.remote = remote;
        }
    }
}
