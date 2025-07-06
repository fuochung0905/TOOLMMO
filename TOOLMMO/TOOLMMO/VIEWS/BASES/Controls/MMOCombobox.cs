using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TOOLMMO.VIEWS.BASES.Controls
{
    public class MMOCombobox : ComboBox
    {
        static MMOCombobox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MMOCombobox),
                new FrameworkPropertyMetadata(typeof(MMOCombobox)));
        }
        public static readonly DependencyProperty IsArrowOnlyExpandEnabledProperty =
       DependencyProperty.Register(nameof(IsArrowOnlyExpandEnabled), typeof(bool), typeof(MMOCombobox),
           new PropertyMetadata(false));


        public bool IsArrowOnlyExpandEnabled
        {
            get => (bool)GetValue(IsArrowOnlyExpandEnabledProperty);
            set => SetValue(IsArrowOnlyExpandEnabledProperty, value);
        }
    }
}
