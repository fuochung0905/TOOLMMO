using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using TOOLMMO.SERVICE;
using CommunityToolkit.Mvvm.Messaging;

namespace TOOLMMO.VIEWMODELS
{
    public enum ScenarioOption
    {
        KichBan1,
        KichBan2,
        KichBan3,
        KichBan4
    }

    public partial class ConfigSystemViewModel : ObservableObject
    {
        private readonly MainViewModel _mainVm;

        [ObservableProperty]
        private int _runtimeAccount = 5;

        [ObservableProperty]
        private bool _isDeleteChromeCache = true;

        [ObservableProperty]
        private ScenarioOption _selectedScenario = ScenarioOption.KichBan1;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private ObservableCollection<string> _accountList;

        [ObservableProperty]
        private string _selectedAccount;
        [ObservableProperty]
        private string _textValue;
       
        public ConfigSystemViewModel(MainViewModel mainVm)
        {
            _mainVm = mainVm;
            AccountList = new ObservableCollection<string>
            {
                "Tài khoản A",
                "Tài khoản B",
                "Tài khoản C"
            };

            SelectedAccount = AccountList.FirstOrDefault();
            TextValue = "Nội dung thử";
            IsDeleteChromeCache = true;
        }
        [RelayCommand]
        private void ToggleSidebar()
        {
            _mainVm.ToggleSidebar();
        }
        [RelayCommand]
        public void Click(string name)
        {
            Name = name;
        }

        [RelayCommand]
        public void Click1(string name)
        {
            Name = name;
        }
    }
}
