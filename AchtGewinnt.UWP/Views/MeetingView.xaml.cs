using AchtGewinnt.ViewModels;
using ReactiveUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AchtGewinnt.UWP.Views
{
    public sealed partial class MeetingView : Page, IViewFor<MeetingViewModel>
    {
        public MeetingView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
#pragma warning disable CC0031 // Check for null before calling a delegate
                d(this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext));
#pragma warning restore CC0031 // Check for null before calling a delegate
            });
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            nameof(ViewModel), typeof(MeetingViewModel), typeof(MeetingView), new PropertyMetadata(default(MeetingViewModel)));

        public MeetingViewModel ViewModel
        {
            get => (MeetingViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MeetingViewModel)value;
        }


    }
}
