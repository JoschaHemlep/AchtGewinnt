using AchtGewinnt.Models;
using DynamicData;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class MeetingViewModel : ReactiveObject, IRoutableViewModel
    {

        public SourceList<Meeting> Meetings { get; set; }

        public string UrlPathSegment { get; } = nameof(MeetingViewModel);
        public IScreen HostScreen { get; }


    }
}