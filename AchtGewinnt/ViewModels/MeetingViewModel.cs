using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using AchtGewinnt.Models;
using DynamicData;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class MeetingViewModel : ReactiveObject, IRoutableViewModel, IDisposable
    {
        private ReadOnlyObservableCollection<Meeting> meetings4View;

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