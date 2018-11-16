using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class ShellViewModel : ReactiveObject, ISupportsActivation
    {
        public ShellViewModel()
        {
            Activator = new ViewModelActivator();
            TestCommand = ReactiveCommand.CreateFromTask(DisplayMoinDialog);

            this.WhenActivated((CompositeDisposable _) => { Console.WriteLine(nameof(ShellViewModel) + " activated!"); });
        }

        public ViewModelActivator Activator { get; }

        public ReactiveCommand<Unit, Unit> TestCommand { get; set; }

        public async Task DisplayMoinDialog()
        {
            var dialog = new ContentDialog
            {
                Title = "AchtGewinnt",
                Content = "Zeit für Feierabend.",
                CloseButtonText = "Ok"
            };

            var result = await dialog.ShowAsync();
        }

    }
}
