using System;
using ReactiveUI;
using Splat;

namespace AchtGewinnt.UWP.ExtensionMethods
{
    public static class RouterExtension
    {
        public static IObservable<IRoutableViewModel> Navigate<T>(this RoutingState Router) where T : IRoutableViewModel
        {
            var destViewModel = (IRoutableViewModel)Locator.Current.GetService(typeof(T));
            return Router.Navigate.Execute(destViewModel);
        }

    }
}
