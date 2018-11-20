
using System;
using System.Diagnostics;
using AchtGewinnt.UWP.ExtensionMethods;
using AchtGewinnt.ViewModels;
using ReactiveUI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using EventsMixin = Windows.UI.Xaml.EventsMixin;

namespace AchtGewinnt.UWP.Views
{
    public sealed partial class Shell : Page, IScreen, IViewFor<ShellViewModel>
    {
        private bool canExecute;

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;

            if (canExecute)
            {
                Router.NavigateBack.Execute();
            }
        }

        public Shell()
        {
            InitializeComponent();

            DataContextChanged += (sender, args) => ViewModel = DataContext as ShellViewModel;

            ConfigureRouter();

            this.WhenActivated(disposables =>
            {
                //
            });

            // OnLoaded
            EventsMixin.Events(this).Loaded.Subscribe(_ =>
            {
                // Init Bootstrapper (IoC-Container etc.)
                var bootstrapper = new Bootstrapper();
                bootstrapper.InitContainer(this);

                Router.Navigate<TimeViewModel>();
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
            nameof(ViewModel), typeof(ShellViewModel), typeof(Shell), new PropertyMetadata(default(ShellViewModel)));

        public ShellViewModel ViewModel
        {
            get => (ShellViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ShellViewModel)value;
        }

        public RoutingState Router { get; } = new RoutingState();


        private void NavTimeButton_OnClick(object sender, RoutedEventArgs e) => Router.Navigate<TimeViewModel>();

        private void NavMeetingsButton_OnClick(object sender, RoutedEventArgs e) => Router.Navigate<MeetingViewModel>();
    }
}
