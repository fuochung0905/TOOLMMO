using System.Collections.ObjectModel;

namespace TOOLMMO.VIEWMODELS.CONFIGSCRIPT
{
    public partial class RandomVideoInteractionViewModel : BaseScriptViewModel
    {
        private int _commentVideo;
        public int Comment
        {
            get => _commentVideo;
            set
            {
                SetProperty(ref _commentVideo, value);
                UpdateCommentFolders();
            }
        }
        public RandomVideoInteractionViewModel(MainViewModel mainVm): base(mainVm)
        {
            CommentFolders = new ObservableCollection<string>();
        }
        public ObservableCollection<string> CommentFolders { get; set; } = new();
        private void UpdateCommentFolders()
        {
            while (CommentFolders.Count < Comment)
                CommentFolders.Add(string.Empty);

            while (CommentFolders.Count > Comment)
                CommentFolders.RemoveAt(CommentFolders.Count - 1);
        }
    }
}
