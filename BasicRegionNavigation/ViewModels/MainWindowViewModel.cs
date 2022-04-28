using System;
using BasicRegionNavigation.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace BasicRegionNavigation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _container;
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, IContainerProvider container)
        {
            _regionManager = regionManager;
            _container = container;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath, NavigationComplete);
        }

        private void NavigationComplete(NavigationResult result)
        {
            System.Windows.MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));
        }

        private DelegateCommand _btnTestCommand;
        public DelegateCommand BtnTestCommand => _btnTestCommand ?? (_btnTestCommand = new DelegateCommand(ExecuteBtSetCommand));
        private void ExecuteBtSetCommand()
        {
            var displayView = _container.Resolve<GoDisplayView>();
            if (displayView != null)
            {
                var displayVM = displayView.DataContext as GoDisplayViewModel;
                displayVM.SetDisplay(); displayVM.SetMidDisplay();
                //displayView.Show();
                //displayVM.ShowClipView.Owner = displayView;
            }
            TextNameCeshi = "测试测试";
        }

        private string _textNameCeshi;

        public string TextNameCeshi
        {
            get { return _textNameCeshi; }
            set { _textNameCeshi = value; }
        }

    }
}
