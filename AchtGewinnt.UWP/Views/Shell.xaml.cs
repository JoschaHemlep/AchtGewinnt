
using System;
using System.Diagnostics;
using AchtGewinnt.UWP.ExtensionMethods;
using AchtGewinnt.ViewModels;
using ReactiveUI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using EventsMixin = Windows.UI.Xaml.EventsMixin;

namespace AchtGewinnt.UWP.Views
{
    public sealed partial class Shell : Page, IScreen, IViewFor<IShellViewModel>
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

            DataContextChanged += (sender, args) => ViewModel = DataContext as IShellViewModel;

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

                Router.Navigate<ITimeViewModel>();
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
            nameof(ViewModel), typeof(IShellViewModel), typeof(Shell), new PropertyMetadata(default(IShellViewModel)));

        public IShellViewModel ViewModel
        {
            get => (IShellViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (IShellViewModel)value;
        }

        public RoutingState Router { get; } = new RoutingState();


        private void NavTimeButton_OnClick(object sender, TappedRoutedEventArgs e) => Router.Navigate<ITimeViewModel>();

        private void NavMeetingsButton_OnClick(object sender, TappedRoutedEventArgs e) => Router.Navigate<IMeetingViewModel>();

        private void NavCalendarButton_OnClick(object sender, TappedRoutedEventArgs e) => Router.Navigate<ICalendarViewModel>();

    }
}
