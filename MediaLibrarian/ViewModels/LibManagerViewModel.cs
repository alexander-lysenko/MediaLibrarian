using System.Collections.ObjectModel;
using System.Windows.Input;
using MediaLibrarian.Models;

namespace MediaLibrarian.ViewModels
{
    internal class LibManagerViewModel : BaseViewModel
    {
        public LibManagerViewModel()
        {
        }

        private string _libraryName = "Фильмы";

        public string Title
        {
            get => _libraryName;
            set => SetField(ref _libraryName, value);
        }

        public ObservableCollection<LibraryField> Fields { get; set; }
            = new ObservableCollection<LibraryField>();

        public ICommand AddNewField => new Command<object>(
            execute: (p) =>
            {
                Fields.Add(new LibraryField
                {
                    Name = "Название",
                    Type = FieldType.Text
                });
            }
        );
    }
}