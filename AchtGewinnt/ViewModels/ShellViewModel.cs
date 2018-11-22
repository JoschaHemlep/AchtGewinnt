using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class ShellViewModel : ReactiveObject, IShellViewModel
    {
        public ShellViewModel()
        {
            Activator = new ViewModelActivator();

            this.WhenActivated((CompositeDisposable _) =>
            {
                // ToDo Remove
                Debug.WriteLine(nameof(ShellViewModel) + " activated!");
            });
        }

        public ViewModelActivator Activator { get; }


    }
}
