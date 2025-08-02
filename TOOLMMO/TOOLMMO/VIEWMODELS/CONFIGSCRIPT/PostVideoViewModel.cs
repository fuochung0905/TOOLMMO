using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TOOLMMO.VIEWMODELS.CONFIGSCRIPT
{
    public partial class PostVideoViewModel : BaseScriptViewModel
    {
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
            VideoFolders = new ObservableCollection<string>();
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
