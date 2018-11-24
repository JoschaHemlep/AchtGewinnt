using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using AchtGewinnt.Models;
using DynamicData;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class MoodViewModel : ReactiveObject, IMoodViewModel
    {
        private readonly Interaction<string, bool> confirmRemoveInteraction;
        private ReadOnlyObservableCollection<Mood> moods4View;
        private Mood selectedMood;

        public MoodViewModel()
        {
            Moods = new SourceList<Mood>();
            Moods.AsObservableList()
                .Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out moods4View)
                .Subscribe(_ =>
                {
                    // ToDo Improve
                    if (SelectedMood == null && Moods4View.Any())
                    {
                        SelectedMood = Moods4View.First();
                    }
                    Debug.WriteLine(_);
                });

            // ToDo remove test Moods
            Moods.Add(new Mood { Date = DateTime.Now, Description = "Test 1", Rating = MoodRating.None });
            Moods.Add(new Mood { Date = DateTime.Now.AddDays(1), Description = "Test 2", Rating = MoodRating.Yeah });
            Moods.Add(new Mood { Date = DateTime.Now.AddDays(2), Description = "Test 3", Rating = MoodRating.Meh });
            Moods.Add(new Mood { Date = DateTime.Now.AddDays(3), Description = "Test 4", Rating = MoodRating.Meh });
            Moods.Add(new Mood { Date = DateTime.Now.AddDays(4), Description = "Test 5", Rating = MoodRating.NotMyDay });
            Moods.Add(new Mood { Date = DateTime.Now.AddDays(5), Description = "Test 6", Rating = MoodRating.Meh });

            // Interactions
            confirmRemoveInteraction = new Interaction<string, bool>();

            // Commands 
            // ToDo
            //AddMoodCommand = ReactiveCommand.Create(() => AddMood());
            //RemoveMoodCommand = ReactiveCommand.CreateFromTask(RemoveSelectedMood);

        }

        public SourceList<Mood> Moods { get; set; }

        public ReadOnlyObservableCollection<Mood> Moods4View
        {
            get => moods4View;
            set => this.RaiseAndSetIfChanged(ref moods4View, value);
        }
        public Mood SelectedMood
        {
            get => selectedMood;
            set => this.RaiseAndSetIfChanged(ref selectedMood, value);
        }

        // Commands
        public ReactiveCommand<Unit, Unit> AddMoodCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveMoodCommand { get; }

        // Interactions
        public Interaction<string, bool> ConfirmRemoveInteraction => confirmRemoveInteraction;

        public string UrlPathSegment => nameof(MoodViewModel);

        public IScreen HostScreen { get; }
    }
}
