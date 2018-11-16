using Windows.UI.Xaml;
using AchtGewinnt.ViewModels;
using ReactiveUI;

namespace AchtGewinnt.Views
{
    public sealed partial class MeetingView : IViewFor<MeetingViewModel>
    {
        public MeetingView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(MeetingViewModel), typeof(MeetingView), new PropertyMetadata(default(MeetingViewModel)));

        public MeetingViewModel ViewModel
        {
            get => (MeetingViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MeetingViewModel)value;
        }

       
    }
}
