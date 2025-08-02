using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TOOLMMO.VIEWMODELS.LISTACCOUNTCUSTOM;
using TOOLMMO.VIEWS.ConfigCustom;

namespace TOOLMMO.VIEWMODELS.CONFIGSCRIPT
{
    public partial class RandomVideoInteractionViewModel : BaseScriptViewModel
    {
        private readonly MainViewModel _mainVm;
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
        [RelayCommand]
        private void NavigateToSelectUser()
        {
            var selectUserViewModel = new ListAccountViewModel();
            var view = new ListAccountView(selectUserViewModel);
            _mainVm.CurrentPage = view;
        }
        public RandomVideoInteractionViewModel(MainViewModel mainVm): base(mainVm)
        {
            _mainVm = mainVm;
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
