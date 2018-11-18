using AchtGewinnt.Services;
using AchtGewinnt.UWP.Views;
using AchtGewinnt.ViewModels;
using ReactiveUI;
using Splat;
using Windows.UI.Xaml.Controls;

namespace AchtGewinnt.UWP
{
    public class Bootstrapper
    {
        public void InitContainer(Page shell)
        {
            Locator.CurrentMutable.RegisterConstant(shell, typeof(IScreen));

            // Services
            Locator.CurrentMutable.Register(() => new EnumService(), typeof(IEnumService));

            // Views
            Locator.CurrentMutable.Register(() => shell, typeof(IViewFor<ShellViewModel>));
            Locator.CurrentMutable.Register(() => new TimeView(), typeof(IViewFor<TimeViewModel>));
            Locator.CurrentMutable.Register(() => new MeetingView(), typeof(IViewFor<MeetingViewModel>));

            // ViewModels
            Locator.CurrentMutable.RegisterConstant(new ShellViewModel(), typeof(ShellViewModel));
            Locator.CurrentMutable.RegisterConstant(new TimeViewModel(), typeof(TimeViewModel));
            Locator.CurrentMutable.RegisterConstant(new MeetingViewModel(), typeof(MeetingViewModel));


            shell.DataContext = Locator.Current.GetService<ShellViewModel>();

        }
    }
}
