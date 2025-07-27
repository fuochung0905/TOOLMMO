using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using TOOLMMO.VIEWMODELS.ConfigSystem;
using TOOLMMO.VIEWS.ConfigSystem;

namespace TOOLMMO.VIEWMODELS
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private double sidebarOffset = -250;

        [ObservableProperty]
        private bool isOverlayVisible;
        [ObservableProperty]
        private UserControl currentPage;
        
        public MainViewModel()
        {
            NavigateToConfig();
        }
        [RelayCommand]
        private void NavigateToConfig()
        {
            var configVm = new ConfigSystemViewModel(this);
            CurrentPage = new ConfigSystemView(configVm);
            CloseSidebar();
        }

        [RelayCommand]
        private void OpenSidebar()
        {
            SidebarOffset = 0;
            IsOverlayVisible = true;
        }

        [RelayCommand]
        private void CloseSidebar()
        {
            SidebarOffset = -250;
            IsOverlayVisible = false;
        }

        [RelayCommand]
        private void NavigateToConfigSystem()
        {
            var configVm = new ConfigBaseViewModel(this);
            CurrentPage = new ConfigBaseView(configVm);
            CloseSidebar(); 
        }
        
        [RelayCommand]
        public void ToggleSidebar()
        {
            if (SidebarOffset == 0)
                CloseSidebar();
            else
                OpenSidebar();
        }
    }
}
