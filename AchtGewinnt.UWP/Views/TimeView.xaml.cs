using AchtGewinnt.ViewModels;
using ReactiveUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AchtGewinnt.UWP.Views
{
    public sealed partial class TimeView : Page, IViewFor<TimeViewModel>
    {
        public TimeView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            nameof(ViewModel), typeof(TimeViewModel), typeof(TimeView), new PropertyMetadata(default(TimeViewModel)));

        public TimeViewModel ViewModel
        {
            get => (TimeViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TimeViewModel)value;
        }

    }
}
