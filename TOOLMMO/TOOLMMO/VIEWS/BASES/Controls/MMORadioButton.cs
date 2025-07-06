using System.Windows;
using System.Windows.Controls;

namespace TOOLMMO.VIEWS.BASES.Controls
{
    public class MMORadioButton : RadioButton
    {
        public static readonly DependencyProperty LabelProperty =
    DependencyProperty.Register(nameof(Label), typeof(string), typeof(MMORadioButton), new PropertyMetadata(string.Empty));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
    }
}
