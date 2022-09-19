using Avalonia.Web.Blazor;

namespace router_test.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<router_test.App>()
            .SetupWithSingleViewLifetime();
    }
}