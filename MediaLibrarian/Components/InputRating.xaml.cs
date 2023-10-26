using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MediaLibrarian.Components
{
    public partial class InputRating : UserControl
    {
        public static readonly DependencyProperty LengthProperty = DependencyProperty.Register(
            name: nameof(Length),
            propertyType: typeof(int),
            ownerType: typeof(InputRating),
            typeMetadata: new PropertyMetadata(5)
        );

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

        public int Length
        {
            get => (int)GetValue(LengthProperty);
            set => SetValue(LengthProperty, value);
        }

        public InputRating()
        {
            InitializeComponent();
            var stars = new List<StarObject>(Length);
            for (var i = 1; i <= Length; i++) stars.Add(new StarObject { Weight = i });

            // Stars = stars;
            StarItems.ItemsSource = stars;
        }

        public List<StarObject> Stars { get; set; }

        private static SolidColorBrush ColorStarsByValue(float value, int length)
        {
            var ratio = value / length;
            var color = Brushes.Transparent;

            if (ratio > 0.0 && ratio < 0.5) color = Brushes.OrangeRed;
            else if (ratio >= 0.5 && ratio < 0.9) color = Brushes.DarkOrange;
            else if (ratio >= 0.9) color = Brushes.LimeGreen;

            return color;
        }

        private void InputRating_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var source = sender as ToggleButton;
            var weight = (int)source?.Tag;
            var color = ColorStarsByValue(weight, Length);

            foreach (var star in Stars)
            {
                star.Fill = star.Weight <= weight ? color : Brushes.Transparent;
            }
        }

        private void InputRating_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }

    public class StarObject
    {
        public int Weight { get; set; }
        public SolidColorBrush Fill { get; set; }
    }
}