using FubuMVC.Core.Registration;

namespace FubuMVC.Core.UI.Navigation
{
    public class NavigationServiceRegistry : ServiceRegistry
    {
        public NavigationServiceRegistry()
        {
            SetServiceIfNone<INavigationService, NavigationService>();
            SetServiceIfNone<IMenuStateService, MenuStateService>();
        }
    }
}