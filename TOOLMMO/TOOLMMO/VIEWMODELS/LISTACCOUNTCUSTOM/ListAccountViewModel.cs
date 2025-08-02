using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TOOLMMO.MODELS;

namespace TOOLMMO.VIEWMODELS.LISTACCOUNTCUSTOM
{
    public partial class ListAccountViewModel : ObservableObject
    {
        public ObservableCollection<Users> Users { get; set; }

        public ListAccountViewModel()
        {
            Users = new ObservableCollection<Users>
            {
                new Users { UserName = "account_user_name1", Name = "Name1", Avatar = "/Assets/tiktok.png" },
                new Users { UserName = "account_user_name2", Name = "Name2", Avatar = "/Assets/tiktok.png" },
                new Users { UserName = "account_user_name3", Name = "Name3", Avatar = "/Assets/tiktok.png" },
            };
        }
    }
}
