using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using MediaLibrarian.Models;

namespace MediaLibrarian.ViewModels
{
    internal class LibManagerViewModel : BaseViewModel
    {
        private string _libraryName = "";
        private bool _isEditMode = false;

        public ObservableCollection<DataGridColumn> Columns { get; set; } =
            new ObservableCollection<DataGridColumn>
            {
                new DataGridTextColumn { Header = "Hello", },
                new DataGridTextColumn { Header = "BOX" }
            };

        public string Title
        {
            get => _libraryName;
            set => SetField(ref _libraryName, value);
        }

        public ObservableCollection<LibraryFieldItem> Fields { get; set; } =
            new ObservableCollection<LibraryFieldItem>
            {
                new LibraryFieldItem { Type = FieldTypes.Line }
            };

        public ICommand AddNewField => new Command<object>(
            execute: param =>
            {
                var item = new LibraryFieldItem { Type = FieldTypes.Line };
                item.RemoveCommand = new Command<object>(
                    execute: _ => { Fields.Remove(item); },
                    canExecute: _ => Fields.IndexOf(item) != 0
                );
                Fields.Add(item);
            }
        );

        public ICommand CreateLibrary => new Command<object>(
            execute: param =>
            {
                IsEditMode = true;
                IsViewMode = false;
            },
            canExecute: param => IsViewMode
        );

        public ICommand Save = new Command<object>(
            execute: param => { },
            canExecute: p => true
        );

        public bool IsViewMode
        {
            get => !_isEditMode;
            set => SetField(ref _isEditMode, !value);
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetField(ref _isEditMode, value);
        }
    }

    public class LibraryFieldItem
    {
        public string Name { get; set; }
        public FieldTypes Type { get; set; }
        public ICommand RemoveCommand { get; set; }
        public string ValidationMessage { get; set; }
    }
}