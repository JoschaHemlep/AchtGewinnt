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
