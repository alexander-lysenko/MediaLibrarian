﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MediaLibrarian.Models;
using MediaLibrarian.ViewModels;

namespace MediaLibrarian.Components
{
    public partial class LibraryFieldTemplate : UserControl
    {
        private static readonly DependencyProperty FieldNameProperty = DependencyProperty.Register(
            name: nameof(FieldName),
            propertyType: typeof(string),
            ownerType: typeof(LibraryFieldTemplate)
        );

        private static readonly DependencyProperty FieldTypeProperty = DependencyProperty.Register(
            name: nameof(FieldType),
            propertyType: typeof(FieldTypes),
            ownerType: typeof(LibraryFieldTemplate)
        );

        private static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register(
            name: nameof(RemoveCommand),
            propertyType: typeof(ICommand),
            ownerType: typeof(LibraryFieldTemplate)
        );

        public string FieldName
        {
            get => (string)GetValue(FieldNameProperty);
            set => SetValue(FieldNameProperty, value);
        }

        public FieldTypes FieldType
        {
            get => (FieldTypes)GetValue(FieldTypeProperty);
            set => SetValue(FieldTypeProperty, value);
        }

        public ICommand RemoveCommand
        {
            get => (ICommand)GetValue(RemoveCommandProperty);
            set => SetValue(RemoveCommandProperty, value);
        }

        public List<FieldTypes> FieldTypesList { get; set; } =
            Enum.GetValues(typeof(FieldTypes)).Cast<FieldTypes>().ToList();

        public string ValidationMessage { get; set; }

        public LibraryFieldTemplate()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}