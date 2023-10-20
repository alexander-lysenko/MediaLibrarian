using System.Windows;
using System.Windows.Controls;

namespace MediaLibrarian.Components
{
    public partial class InputLine : UserControl
    {
        private static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            name: nameof(Label),
            propertyType: typeof(string),
            ownerType: typeof(InputLine)
        );

        private static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            name: nameof(Value),
            propertyType: typeof(string),
            ownerType: typeof(InputLine)
        );

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public InputLine()
        {
            InitializeComponent();
        }
    }
}