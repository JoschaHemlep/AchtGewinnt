using Windows.UI.Xaml;
using AchtGewinnt.ViewModels;
using ReactiveUI;

namespace AchtGewinnt.Views
{
    public sealed partial class TimeView : IViewFor<TimeViewModel>
    {
        public TimeView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(TimeViewModel), typeof(TimeView), new PropertyMetadata(default(TimeViewModel)));

        public TimeViewModel ViewModel
        {
            get => (TimeViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TimeViewModel) value;
        }

    }
}
