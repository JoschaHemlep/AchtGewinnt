using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class MeetingViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get; } = nameof(MeetingViewModel);
        public IScreen HostScreen { get; }
    }
}