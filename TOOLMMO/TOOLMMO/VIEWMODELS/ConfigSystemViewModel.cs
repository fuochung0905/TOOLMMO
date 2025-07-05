using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOOLMMO.SERVICE;

namespace TOOLMMO.VIEWMODELS
{
    public partial class ConfigSystemViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        public ConfigSystemViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        private string name;

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
