using System.Windows;
using MediaLibrarian.ViewModels;

namespace MediaLibrarian.Views
{
    public partial class LibManagerWindow : Window
    {
        public LibManagerWindow()
        {
            InitializeComponent();
            DataContext = new LibManagerViewModel();
        }
    }
}