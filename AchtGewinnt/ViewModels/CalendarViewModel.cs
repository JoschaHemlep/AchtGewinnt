using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class CalendarViewModel : ReactiveObject, ICalendarViewModel
    {
        public string UrlPathSegment => nameof(CalendarViewModel);

        public IScreen HostScreen { get; }
    }
}
