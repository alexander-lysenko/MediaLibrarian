using System.Windows;
using System.Windows.Controls;

namespace MediaLibrarian.Components
{
    public partial class InputPriority : UserControl
    {
        private static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            name: nameof(Label),
            propertyType: typeof(string),
            ownerType: typeof(InputPriority)
        );

        private static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            name: nameof(Value),
            propertyType: typeof(float),
            ownerType: typeof(InputPriority)
        );

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public float Value
        {
            get => (float)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public InputPriority()
        {
            InitializeComponent();
        }
    }
}