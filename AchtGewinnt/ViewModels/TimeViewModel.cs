using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class TimeViewModel: ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get; } = nameof(TimeViewModel);
        public IScreen HostScreen { get; }
    }
}
