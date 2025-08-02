using System.Windows.Controls;
using TOOLMMO.VIEWMODELS;
using TOOLMMO.VIEWMODELS.CONFIGSCRIPT;

namespace TOOLMMO.VIEWS.ConfigScript
{
    /// <summary>
    /// Interaction logic for PostVideoView.xaml
    /// </summary>
    public partial class PostVideoView : UserControl
    {
        public BaseScriptViewModel ViewModel
        {
            get => (BaseScriptViewModel)DataContext;
            set => DataContext = value;
        }
        public PostVideoView()
        {
            InitializeComponent();
        }
    }
}
