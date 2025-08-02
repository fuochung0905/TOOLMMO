using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TOOLMMO.VIEWMODELS.CONFIGSCRIPT
{
    public partial class BaseScriptViewModel : ObservableObject
    {
        private readonly MainViewModel mainViewModel;
        public BaseScriptViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        [RelayCommand]
        public void ToggleSidebar()
        {
            mainViewModel.ToggleSidebar();
        }
    }
}
