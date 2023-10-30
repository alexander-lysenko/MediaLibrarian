using System.Collections.Generic;

namespace MediaLibrarian.Models
{
    public enum FieldTypes
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
        public FieldTypes Type { get; set; }
    }

    public class Library: IActiveRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<LibraryField> Fields { get; set; }

        public bool Save()
        {
            return true;
        }

        public bool Delete()
        {
            return true;
        }
    }
}