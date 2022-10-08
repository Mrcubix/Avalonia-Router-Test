using System;
using ReactiveUI;

namespace router_test.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string greeting = "Welcome to Avalonia!";

        public MainViewModel(ViewRemote remote)
        {
            Remote = remote;
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
