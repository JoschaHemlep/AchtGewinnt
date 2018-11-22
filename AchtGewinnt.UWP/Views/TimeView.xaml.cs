using AchtGewinnt.ViewModels;
using ReactiveUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AchtGewinnt.UWP.Views
{
    public sealed partial class TimeView : Page, IViewFor<ITimeViewModel>
    {
        public TimeView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            nameof(ViewModel), typeof(ITimeViewModel), typeof(TimeView), new PropertyMetadata(default(ITimeViewModel)));

        public ITimeViewModel ViewModel
        {
            get => (ITimeViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ITimeViewModel)value;
        }

    }
}
