using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MediaLibrarian
{
    [Serializable]
    public class Category
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Category() 
        {
            this.Name = Name;
            this.Type = Type;
        }
    }
    public class MarksConverter
    {
        public int NumValue { get; set; }
        public string StarValue { get; set; }

        public MarksConverter()
        {
            this.NumValue = NumValue;
            this.StarValue = StarValue;
        }
        public int GetNumValue(string stars)
        {
            int digit = 0;
            switch(stars)
            {
                case "☆☆☆☆☆": digit = 0; break;
                case "☆☆☆☆☆☆☆☆☆☆": digit = 0; break;
                case "▒▒▒▒▒▒▒▒▒▒": digit = 0; break;
                case "★☆☆☆☆": digit = 1; break;
                case "★☆☆☆☆☆☆☆☆☆": digit = 1; break;
                case "█▒▒▒▒▒▒▒▒▒": digit = 1; break;
                case "★★☆☆☆": digit = 2; break;
                case "★★☆☆☆☆☆☆☆": digit = 2; break;
                case "██▒▒▒▒▒▒▒▒": digit = 2; break;
                case "★★★☆☆": digit = 3; break;
                case "★★★☆☆☆☆☆☆☆": digit = 3; break;
                case "███▒▒▒▒▒▒▒": digit = 3; break;
                case "★★★★☆": digit = 4; break;
                case "★★★★☆☆☆☆☆☆": digit = 4; break;
                case "████▒▒▒▒▒▒": digit = 4; break;
                case "★★★★★": digit = 5; break;
                case "★★★★★☆☆☆☆☆": digit = 5; break;
                case "█████▒▒▒▒▒": digit = 5; break;
                case "★★★★★★☆☆☆☆": digit = 6; break;
                case "██████▒▒▒▒": digit = 6; break;
                case "★★★★★★★☆☆☆": digit = 7; break;
                case "███████▒▒▒": digit = 7; break;
                case "★★★★★★★★☆☆": digit = 8; break;
                case "████████▒▒": digit = 8; break;
                case "★★★★★★★★★☆": digit = 9; break;
                case "█████████▒": digit = 9; break;
                case "★★★★★★★★★★": digit = 10; break;
                case "██████████": digit = 10; break;
            }
            return digit;
        }


    }

/*    [Serializable]
    public class LibraryHeaders
    {
        public XmlSerializer formatter = new XmlSerializer(typeof(LibraryHeaders));
        public string LibName { get; set; }
        public List<Category> LibCategory { get; set; }
                        
        public LibraryHeaders(){}
        public LibraryHeaders(string LibName, List<Category> LibCategory)
        {
            this.LibName = LibName;
            this.LibCategory = LibCategory;
        }
        public void Serialize(string Name) 
        {
            using (FileStream file = new FileStream(Environment.CurrentDirectory+"\\Libraries\\" + Name + ".xml", FileMode.OpenOrCreate))
            { 
                formatter.Serialize(file, this);
            }
        }
        public List<Category> CurrentLibraryColumns { get; set; }
    }
        
    [Serializable]
    public class LibraryContent
    {
        public LibraryContent() { }
    
    }

    [Serializable]
    public class Settings
    {        
    }*/

}
