using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TOOLMMO.VIEWMODELS
{
    public partial class ConfigViewModel : ObservableObject
    {
        [ObservableProperty]
        public string name;
        [RelayCommand]
        public async Task ClickCommand(string name)
        {
            this.name = name;
            await Task.CompletedTask; // or some real async work
        }

    }

}
