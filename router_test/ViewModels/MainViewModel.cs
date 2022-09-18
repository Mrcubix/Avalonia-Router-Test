using System;
using ReactiveUI;

namespace router_test.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string greeting = "Welcome to Avalonia!";

        public MainViewModel()
        {
            Remote.AddVM(this);
            Remote.AddVM(new ListViewModel(Remote, 0));

            Remote.CurrentViewModel = this;
        }

        public string Greeting 
        { 
            get => greeting;
            set => this.RaiseAndSetIfChanged(ref greeting, value);
        }

        public void ChangeText(string text)
        {
            if (text != greeting)
                Greeting = text;
        }
    }
}
