using Windows.UI.Xaml.Controls;
using AchtGewinnt.ViewModels;
using AchtGewinnt.Views;
using ReactiveUI;
using Splat;

namespace AchtGewinnt
{
    public class Bootstrapper
    {
        public void InitContainer(Page shell)
        {
            Locator.CurrentMutable.RegisterConstant(shell, typeof(IScreen));

            // Views
            Locator.CurrentMutable.Register(() => new Shell(), typeof(IViewFor<ShellViewModel>));
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
