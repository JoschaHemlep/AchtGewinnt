using System.Reactive;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public interface ITimeViewModel : IRoutableViewModel
    {
        ReactiveCommand<Unit, Unit> ResetWorkTimerCommand { get; }
        ReactiveCommand<Unit, Unit> StartWorkTimerCommand { get; }
        ReactiveCommand<Unit, Unit> StopWorkTimerCommand { get; }
    }
}