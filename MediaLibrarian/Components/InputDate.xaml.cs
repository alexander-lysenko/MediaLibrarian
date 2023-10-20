using System;
using System.Windows;
using System.Windows.Controls;

namespace MediaLibrarian.Components
{
    public partial class InputDate : UserControl
    {
        private static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            name: nameof(Label),
            propertyType: typeof(string),
            ownerType: typeof(InputDate)
        );

        private static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            name: nameof(Value),
            propertyType: typeof(DateTime),
            ownerType: typeof(InputDate)
        );

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public DateTime Value
        {
            get => (DateTime)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public InputDate()
        {
            InitializeComponent();
        }
    }
}