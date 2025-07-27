using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOLMMO.VIEWMODELS.ConfigSystem
{
    public partial class ConfigBaseViewModel : ObservableObject
    {
        private readonly MainViewModel _mainVm;
        [ObservableProperty]
        private int runtimeAccount = 5;
        public ConfigBaseViewModel(MainViewModel mainVm)
        {
            _mainVm = mainVm;
        }
        [RelayCommand]
        private void ToggleSidebar()
        {
            _mainVm.ToggleSidebar();
        }
    }
}
