using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TOOLMMO.VIEWS.BASES.Controls
{
    public class MMONumericUpDown : Control
    {
        static MMONumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MMONumericUpDown),
                new FrameworkPropertyMetadata(typeof(MMONumericUpDown)));
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(MMONumericUpDown),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
           DependencyProperty.Register(nameof(Label), typeof(string), typeof(MMONumericUpDown), new PropertyMetadata(string.Empty));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
        public int MinValue { get; set; } = 0;
        public int MaxValue { get; set; } = 100;

        private ICommand _increaseCommand;
        private ICommand _decreaseCommand;

        public ICommand IncreaseCommand => _increaseCommand ??= new RelayCommand(_ =>
        {
            if (Value < MaxValue)
                Value++;
        });

        public ICommand DecreaseCommand => _decreaseCommand ??= new RelayCommand(_ =>
        {
            if (Value > MinValue)
                Value--;
        });
    }
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged;
    }


}
