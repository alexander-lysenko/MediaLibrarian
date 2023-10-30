using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetField(ref _isEditMode, value);
        }

        public void Validate()
        {
            IsFormValid = true;
        }

        #region CreateLibraryForm

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

        private bool IsFormValid { get; set; } = false;

        #endregion

        #region Commands

        public ICommand AddNewField => new Command<ObservableCollection<LibraryFieldItem>>(
            execute: fields =>
            {
                var item = new LibraryFieldItem { Type = FieldTypes.Line };
                item.RemoveCommand = new Command<object>(
                    execute: _ => { fields.Remove(item); },
                    canExecute: _ => fields.IndexOf(item) != 0
                );
                fields.Add(item);
            },
            canExecute: _ => Fields.Count <= 20
        );

        public ICommand CreateLibrary => new Command<object>(
            execute: _ => { IsEditMode = true; },
            canExecute: _ => !IsEditMode
        );

        public ICommand Cancel => new Command<object>(
            execute: _ => { IsEditMode = false; }
        );

        public ICommand Save => new Command<object>(
            execute: _ =>
            {
                var library = new Library()
                {
                    Title = Title,
                    Fields = Fields.Select((f) => new LibraryField { Name = f.Name, Type = f.Type }).ToList()
                };
                try
                {
                    if (library.Save()) IsEditMode = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(
                        e.Message,
                        e.GetType().ToString(),
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            },
            canExecute: _ => IsFormValid
        );

        #endregion
    }

    public class LibraryFieldItem
    {
        public string Name { get; set; }
        public FieldTypes Type { get; set; }
        public ICommand RemoveCommand { get; set; }
        public string ValidationMessage { get; set; }
    }
}