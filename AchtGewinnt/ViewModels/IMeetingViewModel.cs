using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using AchtGewinnt.Models;
using DynamicData;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public interface IMeetingViewModel : IRoutableViewModel, IDisposable
    {
        ReactiveCommand<Unit, Unit> AddMeetingCommand { get; }
        Interaction<string, bool> ConfirmRemoveInteraction { get; }
        IList<MeetingRating> MeetingRatings { get; }
        SourceList<Meeting> Meetings { get; set; }
        ReadOnlyObservableCollection<Meeting> Meetings4View { get; set; }
        ReactiveCommand<Unit, Unit> RemoveMeetingCommand { get; }
        Meeting SelectedMeeting { get; set; }
    }
}