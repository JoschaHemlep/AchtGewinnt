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
                d(this.OneWayBind(ViewModel, vm => vm.Meetings4View, v => v.MeetingList.ItemsSource));
                d(this.Bind(ViewModel, vm => vm.SelectedMeeting, v => v.MeetingList.SelectedItem));
                d(this.Bind(ViewModel, vm => vm.SelectedMeeting.Title, v => v.Title.Text));
                // ToDo
                //d(this.Bind(ViewModel, vm => vm.SelectedMeeting.Date, v => v.Date.Date));
                d(this.Bind(ViewModel, vm => vm.SelectedMeeting.Description, v => v.Description.Text));
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
