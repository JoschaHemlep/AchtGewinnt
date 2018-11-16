
using System;
using System.Diagnostics;
using Windows.UI.Core;
using Windows.UI.Xaml;
using AchtGewinnt.ViewModels;
using ReactiveUI;
using Splat;
using EventsMixin = Windows.UI.Xaml.EventsMixin;

namespace AchtGewinnt.Views
{
    public sealed partial class Shell : IScreen, IViewFor<ShellViewModel>
    {
        private bool canExecute;

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;

            if (canExecute)
                Router.NavigateBack.Execute();
        }

        public Shell()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) => ViewModel = DataContext as ShellViewModel;

            ConfigureRouter();

            this.WhenActivated(disposables => { this.BindCommand(ViewModel, vm => vm.TestCommand, v => v.TestButton); });

            // OnLoaded
            EventsMixin.Events(this).Loaded.Subscribe(_ =>
            {
                // Init Bootstrapper (IoC-Container etc.)
                var bootstrapper = new Bootstrapper();
                bootstrapper.InitContainer(this);
            });
        }

        private void ConfigureRouter()
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;

            Router.NavigateBack.CanExecute.Subscribe(_ => canExecute = _);

            Router.CurrentViewModel.Subscribe(currentViewModel =>
            {
                var currentVmType = currentViewModel?.GetType();

                Debug.WriteLine($"Navigate to {currentViewModel?.UrlPathSegment}");
            });
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(ShellViewModel), typeof(Shell), new PropertyMetadata(default(ShellViewModel)));

        public ShellViewModel ViewModel
        {
            get => (ShellViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ShellViewModel) value;
        }

        public RoutingState Router { get; } = new RoutingState();

        private void NavTimeButton_OnClick(object sender, RoutedEventArgs e)
        {
            var destViewModel = (IRoutableViewModel) Locator.Current.GetService(typeof(TimeViewModel));
            Router.Navigate.Execute(destViewModel);
        }

        private void NavMeetingButton_OnClick(object sender, RoutedEventArgs e)
        {
            var destViewModel = (IRoutableViewModel)Locator.Current.GetService(typeof(MeetingViewModel));
            Router.Navigate.Execute(destViewModel);
        }
    }
}
