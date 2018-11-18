using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using AchtGewinnt.Models;
using DynamicData;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class MeetingViewModel : ReactiveObject, IRoutableViewModel, IDisposable
    {
        private ReadOnlyObservableCollection<Meeting> meetings4View;
        private readonly Interaction<string, bool> confirmRemoveInteraction;

        private void AddMeeting()
        {
            Meetings.Add(new Meeting { Title = "New Meeting", Date = DateTime.Now, Description = "Test x" });
        }

        private async Task RemoveSelectedMeeting()
        {
            var result = await confirmRemoveInteraction.Handle($"Remove this Meeting \"{SelectedMeeting.Title}\"?");

            if (result)
            {
                var meetingToRemove = SelectedMeeting;

                // Select another meeting
                SelectedMeeting = Meetings4View.FirstOrDefault(_ => _ != SelectedMeeting);

                // Remove Meeting
                Meetings.Remove(meetingToRemove);
            }
        }

        public MeetingViewModel()
        {
            Meetings = new SourceList<Meeting>();
            Meetings.AsObservableList()
                .Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out meetings4View)
                .Subscribe(_ =>
                {
                    // ToDo Improve
                    if (SelectedMeeting == null && Meetings4View.Any())
                    {
                        SelectedMeeting = Meetings4View.First();
                    }
                    Debug.WriteLine(_);
                });

            Meetings.Add(new Meeting { Date = DateTime.Now, Title = "Weekly", Description = "Test 1" });
            Meetings.Add(new Meeting { Date = DateTime.Now.AddDays(1), Title = "Refinement", Description = "Test 2" });

            // Interactions
            confirmRemoveInteraction = new Interaction<string, bool>();

            // Commands
            AddMeetingCommand = ReactiveCommand.Create(() => AddMeeting());
            RemoveMeetingCommand = ReactiveCommand.CreateFromTask(RemoveSelectedMeeting);

        }

        public SourceList<Meeting> Meetings { get; set; }

        public ReadOnlyObservableCollection<Meeting> Meetings4View
        {
            get => meetings4View;
            set => this.RaiseAndSetIfChanged(ref meetings4View, value);
        }
        public Meeting SelectedMeeting
        {
            get => selectedMeeting;
            set => this.RaiseAndSetIfChanged(ref selectedMeeting, value);
        }

        // Commands
        public ReactiveCommand<Unit, Unit> AddMeetingCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveMeetingCommand { get; }

        // Interactions
        public Interaction<string, bool> ConfirmRemoveInteraction => confirmRemoveInteraction;

        public string UrlPathSegment { get; } = nameof(MeetingViewModel);
        public IScreen HostScreen { get; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private Meeting selectedMeeting;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Meetings.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion




    }
}