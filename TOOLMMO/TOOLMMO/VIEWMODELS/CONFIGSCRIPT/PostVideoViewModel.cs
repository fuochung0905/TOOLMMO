using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TOOLMMO.VIEWMODELS.LISTACCOUNTCUSTOM;
using TOOLMMO.VIEWS.ConfigCustom;
using TOOLMMO.VIEWS.ConfigScript;

namespace TOOLMMO.VIEWMODELS.CONFIGSCRIPT
{
    public partial class PostVideoViewModel : BaseScriptViewModel
    {
        private readonly MainViewModel _mainVm;
        private int _contenVideo;
        public int ContenVideo
        {
            get => _contenVideo;
            set
            {
                SetProperty(ref _contenVideo, value);
                UpdateVideoFolders();
            }
        }
   
        public PostVideoViewModel(MainViewModel mainVm) : base(mainVm) 
        {
            _mainVm = mainVm;
            VideoFolders = new ObservableCollection<string>();
        }
        [RelayCommand]
        private void NavigateToSelectUser()
        {
            var selectUserViewModel = new ListAccountViewModel();
            var view = new ListAccountView(selectUserViewModel);
            _mainVm.CurrentPage = view;
        }

        public ObservableCollection<string> VideoFolders { get; set; } = new();
        private void UpdateVideoFolders()
        {
            while (VideoFolders.Count < ContenVideo)
                VideoFolders.Add(string.Empty);

            while (VideoFolders.Count > ContenVideo)
                VideoFolders.RemoveAt(VideoFolders.Count - 1);
        }
    }
}
