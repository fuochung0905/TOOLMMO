using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TOOLMMO.VIEWMODELS.CONFIGSCRIPT;
using TOOLMMO.VIEWS.ConfigScript;

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
        private MainViewModel _mainVm;

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
        [RelayCommand]
        private void NavigateToConfigScenario()
        {

            switch (SelectedScenario)
            {
                case ScenarioOption.KichBan1:
                {
                        var postVideoViewModel = new PostVideoViewModel(_mainVm);
                        var view = new PostVideoView
                        {
                            ViewModel = postVideoViewModel 
                        };

                        _mainVm.CurrentPage = view;
                    break;
                }
                case ScenarioOption.KichBan2:
                {
                        var randomVideoInteractionViewModel = new RandomVideoInteractionViewModel(_mainVm);
                        var view = new RandomVideoInteraction
                        {
                            ViewModel = randomVideoInteractionViewModel
                        };

                        _mainVm.CurrentPage = view;
                        break;
                }
                case ScenarioOption.KichBan3:
                {
                        var topicAccountMaintenanceViewModel = new TopicAccountMaintenanceViewModel(_mainVm);
                        var view = new TopicAccountMaintenanceView
                        {
                            ViewModel = topicAccountMaintenanceViewModel
                        };

                        _mainVm.CurrentPage = view;
                        break;
                }
            }

            _mainVm.CloseSidebar();
        }
    }

}
