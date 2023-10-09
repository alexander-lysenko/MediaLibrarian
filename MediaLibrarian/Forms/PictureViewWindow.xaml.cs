using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace MediaLibrarian.Forms
{
    public partial class PictureViewWindow : Window
    {
        public PictureViewWindow()
        {
            InitializeComponent();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Picture.Height = e.NewSize.Height - 100;
            Picture.Width = e.NewSize.Width - 100;

            var pictureAnimation = new DoubleAnimation
            {
                From = 150,
                To = Picture.Height,
                Duration = TimeSpan.FromMilliseconds(800),
            };
            Picture.BeginAnimation(HeightProperty, pictureAnimation);
        }

        private void OnMouseDown(object sender, RoutedEventArgs e)
        {
            var senderName = ((FrameworkElement)e.Source).Name;
            if (senderName == Picture.Name) return;
            
            var pictureAnimation = new DoubleAnimation
            {
                From = Picture.Height,
                To = 150,
                Duration = TimeSpan.FromMilliseconds(500),
            };
            Picture.BeginAnimation(HeightProperty, pictureAnimation);
            
            Close();
        }
    }
}