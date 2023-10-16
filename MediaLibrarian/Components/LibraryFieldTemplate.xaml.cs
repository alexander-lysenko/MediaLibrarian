using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MediaLibrarian.Models;

namespace MediaLibrarian.Components
{
    public partial class LibraryFieldTemplate : UserControl
    {
        private static readonly DependencyProperty FieldNameDep = DependencyProperty.Register(
            name: nameof(FieldName),
            propertyType: typeof(string),
            ownerType: typeof(LibraryFieldTemplate)
        );

        private static readonly DependencyProperty FieldTypeDep = DependencyProperty.Register(
            name: nameof(FieldType),
            propertyType: typeof(FieldType),
            ownerType: typeof(LibraryFieldTemplate)
        );

        private static readonly DependencyProperty RemoveCommandDep = DependencyProperty.Register(
            name: nameof(RemoveCommand),
            propertyType: typeof(ICommand),
            ownerType: typeof(LibraryFieldTemplate)
        );

        public string FieldName
        {
            get => (string)GetValue(FieldNameDep);
            set => SetValue(FieldNameDep, value);
        }

        public FieldType FieldType
        {
            get => (FieldType)GetValue(FieldTypeDep);
            set => SetValue(FieldTypeDep, value);
        }

        public ICommand RemoveCommand
        {
            get => (ICommand)GetValue(RemoveCommandDep);
            set => SetValue(RemoveCommandDep, value);
        }

        public List<FieldType> FieldTypes { get; set; } = new List<FieldType>
        {
            FieldType.Line,
            FieldType.Text,
            FieldType.Date
        };

        public string ValidationMessage { get; set; }

        public LibraryFieldTemplate()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}