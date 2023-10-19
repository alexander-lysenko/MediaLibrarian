using System.Collections.ObjectModel;
using System.Windows.Input;
using MediaLibrarian.Models;

namespace MediaLibrarian.ViewModels
{
    internal class LibManagerViewModel : BaseViewModel
    {
        private string _libraryName = "";

        public string Title
        {
            get => _libraryName;
            set => SetField(ref _libraryName, value);
        }

        public ObservableCollection<LibraryField> Fields { get; set; } = new ObservableCollection<LibraryField>
        {
            new LibraryField
            {
                Name = "",
                Type = FieldTypes.Line,
            }
        };

        public ICommand AddNewField => new Command<object>(
            execute: (p) =>
            {
                Fields.Add(new LibraryField
                {
                    Name = "",
                    Type = FieldTypes.Line
                });
            }
        );

        public LibManagerViewModel()
        {
        }
    }
}