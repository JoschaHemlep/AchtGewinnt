using System.Collections.ObjectModel;
using System.Reactive;
using AchtGewinnt.Models;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public interface IMoodViewModel : IRoutableViewModel
    {
        Interaction<string, bool> ConfirmRemoveInteraction { get; }
        ReadOnlyObservableCollection<Mood> Moods4View { get; }
        ReactiveCommand<Unit, Unit> AddMoodCommand { get; }
        ReactiveCommand<Unit, Unit> RemoveMoodCommand { get; }
        Mood SelectedMood { get; set; }

    }
}
