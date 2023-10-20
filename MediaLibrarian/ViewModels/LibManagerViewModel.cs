using System.Collections.ObjectModel;
using System.Windows;
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

        public ObservableCollection<LibraryFieldItem> Fields { get; set; } =
            new ObservableCollection<LibraryFieldItem>
            {
                new LibraryFieldItem
                {
                    Name = "",
                    Type = FieldTypes.Line.ToString(),
                }
            };

        public ICommand AddNewField => new Command<object>(
            execute: (p) =>
            {
                var aa = new LibraryFieldItem
                {
                    Type = FieldTypes.Line.ToString()
                };
                aa.RemoveCommand = new Command<object>(
                    execute: (q) =>
                    {
                        MessageBox.Show("1");
                        Fields.Remove(aa);
                    }
                );
                Fields.Add(aa);
            }
        );

        public LibManagerViewModel()
        {
        }
    }

    public class LibraryFieldItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ICommand RemoveCommand { get; set; }
        public string ValidationMessage { get; set; }
    }
}