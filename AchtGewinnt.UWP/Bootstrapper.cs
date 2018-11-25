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
            Locator.CurrentMutable.Register(() => shell, typeof(IViewFor<IShellViewModel>));
            Locator.CurrentMutable.Register(() => new TimeView(), typeof(IViewFor<ITimeViewModel>));
            Locator.CurrentMutable.Register(() => new MeetingView(), typeof(IViewFor<IMeetingViewModel>));
            Locator.CurrentMutable.Register(() => new MoodView(), typeof(IViewFor<IMoodViewModel>));

            // ViewModels
            Locator.CurrentMutable.RegisterConstant(new ShellViewModel(), typeof(IShellViewModel));
            Locator.CurrentMutable.RegisterConstant(new TimeViewModel(), typeof(ITimeViewModel));
            Locator.CurrentMutable.RegisterConstant(new MeetingViewModel(), typeof(IMeetingViewModel));
            Locator.CurrentMutable.RegisterConstant(new MoodViewModel(), typeof(IMoodViewModel));


            shell.DataContext = Locator.Current.GetService<ShellViewModel>();

        }
    }
}
