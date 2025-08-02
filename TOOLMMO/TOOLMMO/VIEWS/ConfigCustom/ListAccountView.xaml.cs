using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TOOLMMO.VIEWMODELS.LISTACCOUNTCUSTOM;

namespace TOOLMMO.VIEWS.ConfigCustom
{
    /// <summary>
    /// Interaction logic for ListAccountView.xaml
    /// </summary>
    public partial class ListAccountView : UserControl
    {
        public ListAccountView(ListAccountViewModel listAccountViewModel)
        {
            InitializeComponent();
            DataContext = listAccountViewModel;
        }
    }
}
