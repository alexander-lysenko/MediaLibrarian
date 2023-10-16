using System.Collections.Generic;

namespace MediaLibrarian.Models
{
    public enum FieldType
    {
        Line,
        Text,
        Date,
        DateTime,
        Url,
        CheckBox,
        Rating5,
        Rating5Precision,
        Rating10,
        Rating10Precision,
        Priority
    }

    public class LibraryField
    {
        public string Name { get; set; }
        public FieldType Type { get; set; }
    }

    public class Library
    {
        public string Title;
        public List<LibraryField> Fields;
    }
}