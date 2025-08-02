using System.Windows.Controls;
using TOOLMMO.VIEWMODELS;
using TOOLMMO.VIEWMODELS.CONFIGSCRIPT;

namespace TOOLMMO.VIEWS.ConfigScript
{
    /// <summary>
    /// Interaction logic for RandomVideoInteraction.xaml
    /// </summary>
    public partial class RandomVideoInteraction : UserControl
    {
        public BaseScriptViewModel ViewModel
        {
            get => (BaseScriptViewModel)DataContext;
            set => DataContext = value;
        }
        public RandomVideoInteraction()
        {
            InitializeComponent();
        }
    }
}
