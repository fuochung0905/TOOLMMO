using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TOOLMMO.SERVICE;

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
        private readonly IUserService _userService;

        public ConfigSystemViewModel(IUserService userService)
        {
            _userService = userService;

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
        [ObservableProperty]
        private int runtimeAccount = 5;

        [ObservableProperty]
        private bool isDeleteChromeCache = true;

        [ObservableProperty]
        private ScenarioOption selectedScenario = ScenarioOption.KichBan1;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ObservableCollection<string> accountList;

        [ObservableProperty]
        private string selectedAccount;
        [ObservableProperty]
        private string textValue;

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
