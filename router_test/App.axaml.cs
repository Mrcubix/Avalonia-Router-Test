using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using router_test.ViewModels;
using router_test.Views;

namespace router_test
{
    public partial class App : Application
    {
        private ViewRemote Remote { get; set; } = new();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var context = new MainViewModel(Remote);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = context
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = context
                };
            }

            Remote.AddVM(context);
            Remote.AddVM(new ListViewModel(Remote, 0));
            
            base.OnFrameworkInitializationCompleted();
        }
    }
}