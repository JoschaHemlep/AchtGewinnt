using System.Reactive;
using ReactiveUI;

namespace AchtGewinnt.ViewModels
{
    public class TimeViewModel : ReactiveObject, ITimeViewModel
    {

        private void StartWorkTimer()
        {

        }

        private void PauseWorkTimer()
        {

        }

        private void ResetWorkTimer()
        {

        }

        public TimeViewModel()
        {

            StartWorkTimerCommand = ReactiveCommand.Create(() => StartWorkTimer());
            StopWorkTimerCommand = ReactiveCommand.Create(() => PauseWorkTimer());
            ResetWorkTimerCommand = ReactiveCommand.Create(() => ResetWorkTimer());
        }

        public ReactiveCommand<Unit, Unit> StartWorkTimerCommand { get; }
        public ReactiveCommand<Unit, Unit> StopWorkTimerCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetWorkTimerCommand { get; }

        public string UrlPathSegment { get; } = nameof(TimeViewModel);
        public IScreen HostScreen { get; }
    }
}
