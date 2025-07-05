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
using System.Windows.Shapes;
using TOOLMMO.SERVICE;
using TOOLMMO.VIEWMODELS;

namespace TOOLMMO.VIEWS
{
    /// <summary>
    /// Interaction logic for ConfigSystemView.xaml
    /// </summary>
    public partial class ConfigSystemView : Window
    {
        public ConfigSystemView(ConfigSystemViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
