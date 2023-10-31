using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MediaLibrarian.Models;

namespace MediaLibrarian.ViewModels
{
    // https://stackoverflow.com/questions/34539663
    // https://stackoverflow.com/a/47556421
    // https://kmatyaszek.github.io/wpf%20validation/2019/03/13/wpf-validation-using-inotifydataerrorinfo.html
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

        #region CreateLibraryForm

        public string Title
        {
            get => _libraryName;
            set
            {
                SetField(ref _libraryName, value.Trim());
                ValidateTitle();
            }
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
                ;
                item.ValidationMessage = fields.Count % 2 == 0 ? "Error" : "No Error";
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

        #region Validations

        private void ValidateTitle()
        {
            const string propertyName = nameof(Title);
            ClearErrors(propertyName);

            if (string.IsNullOrEmpty(Title))
                AddError(propertyName, "This field can not be blank");

            if (string.Equals(Title, "Title"))
                AddError(propertyName, "Title is already taken");
        }

        #endregion

        public LibManagerViewModel()
        {
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