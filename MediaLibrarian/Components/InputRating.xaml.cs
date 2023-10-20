using System.Windows;
using System.Windows.Controls;

namespace MediaLibrarian.Components
{
    public partial class InputRating : UserControl
    {
        private static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            name: nameof(Label),
            propertyType: typeof(string),
            ownerType: typeof(InputRating)
        );

        private static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            name: nameof(Value),
            propertyType: typeof(float),
            ownerType: typeof(InputRating)
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

        public InputRating()
        {
            InitializeComponent();
        }
    }
}