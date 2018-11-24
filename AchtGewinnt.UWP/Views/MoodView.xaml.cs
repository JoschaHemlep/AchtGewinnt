using System;
using AchtGewinnt.ViewModels;
using ReactiveUI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AchtGewinnt.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoodView : Page, IViewFor<IMoodViewModel>
    {
        public MoodView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
#pragma warning disable CC0031 // Check for null before calling a delegate
                d(this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext));


                // Interactions
                d(ViewModel.ConfirmRemoveInteraction.RegisterHandler(async interaction =>
                {
                    var dialog = new MessageDialog(interaction.Input);
                    dialog.Commands.Add(new UICommand("Yes, Delete")
                    {
                        Id = true
                    });
                    dialog.Commands.Add(new UICommand("Cancel")
                    {
                        Id = false
                    });
                    dialog.DefaultCommandIndex = 1;
                    dialog.CancelCommandIndex = 1;
                    dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;

                    var result = await dialog.ShowAsync();

                    interaction.SetOutput((bool)result.Id);
                }));

#pragma warning restore CC0031 // Check for null before calling a delegate
            });
        }


        public IMoodViewModel ViewModel
        {
            get => (IMoodViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(IMoodViewModel), typeof(MoodView), new PropertyMetadata(default(IMoodViewModel)));


        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (IMoodViewModel)value;
        }

    }
}
