using AchtGewinnt.ViewModels;
using ReactiveUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AchtGewinnt.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarView : Page, IViewFor<ICalendarViewModel>
    {
        public CalendarView()
        {
            InitializeComponent();
        }


        public ICalendarViewModel ViewModel
        {
            get => (ICalendarViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(ICalendarViewModel), typeof(CalendarView), new PropertyMetadata(default(ICalendarViewModel)));



        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ICalendarViewModel)value;
        }

        private void OnCalendarViewDayItemChanging(Windows.UI.Xaml.Controls.CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            // Render basic day items.
            if (args.Phase == 0)
            {
                // Register callback for next phase.
                // args.Item.DataContext = GetCalJobItemVM(args.Item.Date);
            }
        }
    }
}
